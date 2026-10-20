using CajeroCorrecaminos.Estructuras;
using CajeroCorrecaminos.Modelos;

namespace CajeroCorrecaminos.Servicios
{
    public readonly record struct Resultado(bool Exito, string Mensaje);

    /// Lógica del cajero
    public class Banco
    {
        public ListaEnlazada<Cuenta> Cuentas { get; } = new ListaEnlazada<Cuenta>();
        public ListaEnlazada<Operacion> Historial { get; } = new ListaEnlazada<Operacion>();

        private int siguienteId = 1;

        public Banco()
        {
            // Cuentas de prueba
            Cuentas.AgregarFinal(new Cuenta("1001", "Cliente Uno", "1234", 1000m));
            Cuentas.AgregarFinal(new Cuenta("1002", "Cliente Dos", "1111", 500m));
            Cuentas.AgregarFinal(new Cuenta("1003", "Cliente Tres", "2222", 300m));
        }

        public Cuenta? BuscarCuenta(string numero) =>
            Cuentas.Buscar(c => c.Numero == numero);

        public Cuenta? Login(string numero, string pin)
        {
            Cuenta? cuenta = BuscarCuenta(numero);
            if (cuenta != null && cuenta.Pin == pin) return cuenta;
            return null;
        }

        // ---------------- DEPÓSITO ----------------
        public Resultado Depositar(Cuenta cuenta, decimal monto)
        {
            if (monto <= 0)
                return new Resultado(false, "El monto debe ser mayor a 0.");

            cuenta.Saldo += monto;

            Operacion op = new Operacion(siguienteId++, TipoOperacion.Deposito, cuenta.Numero, null, monto);
            Historial.AgregarInicio(op);
            cuenta.PilaReversas.Apilar(op);

            return new Resultado(true, $"Depósito de S/ {monto:0.00} realizado (operación #{op.Id:000}).");
        }

        // ---------------- RETIRO ----------------
        public Resultado Retirar(Cuenta cuenta, decimal monto)
        {
            if (monto <= 0)
                return new Resultado(false, "El monto debe ser mayor a 0.");
            if (monto > cuenta.Saldo)
                return new Resultado(false, "Saldo insuficiente.");

            cuenta.Saldo -= monto;

            Operacion op = new Operacion(siguienteId++, TipoOperacion.Retiro, cuenta.Numero, null, monto);
            Historial.AgregarInicio(op);

            return new Resultado(true, $"Retiro de S/ {monto:0.00} realizado (operación #{op.Id:000}).");
        }

        // ---------------- TRANSFERENCIA ----------------
        public Resultado Transferir(Cuenta origen, string numeroDestino, decimal monto)
        {
            if (monto <= 0)
                return new Resultado(false, "El monto debe ser mayor a 0.");

            Cuenta? destino = BuscarCuenta(numeroDestino);
            if (destino == null)
                return new Resultado(false, "La cuenta destino no existe.");
            if (destino.Numero == origen.Numero)
                return new Resultado(false, "No puedes transferirte a tu misma cuenta.");
            if (monto > origen.Saldo)
                return new Resultado(false, "Saldo insuficiente.");

            origen.Saldo -= monto;
            destino.Saldo += monto;

            Operacion op = new Operacion(siguienteId++, TipoOperacion.Transferencia,
                                         origen.Numero, destino.Numero, monto);
            Historial.AgregarInicio(op);
            origen.PilaReversas.Apilar(op);

            return new Resultado(true,
                $"Transferencia de S/ {monto:0.00} a la cuenta {destino.Numero} (operación #{op.Id:000}).");
        }

        // ---------------- REVERTIR ----------------

        public Resultado RevertirUltima(Cuenta cuenta)
        {
            if (cuenta.PilaReversas.EstaVacia)
                return new Resultado(false, "No hay operaciones para revertir.");

            Operacion op = cuenta.PilaReversas.VerTope();   // PEEK: se valida antes de sacarla

            string? destinoReversa = null;

            if (op.Tipo == TipoOperacion.Deposito)
            {
                if (cuenta.Saldo < op.Monto)
                    return new Resultado(false, "No se puede revertir el depósito: saldo insuficiente.");

                cuenta.Saldo -= op.Monto;
            }
            else // Transferencia
            {
                Cuenta? destino = BuscarCuenta(op.CuentaDestino ?? "");
                if (destino == null)
                    return new Resultado(false, "La cuenta destino ya no existe.");
                if (destino.Saldo < op.Monto)
                    return new Resultado(false,
                        "No se puede revertir: la cuenta destino ya no tiene saldo suficiente.");

                destino.Saldo -= op.Monto;
                cuenta.Saldo += op.Monto;
                destinoReversa = destino.Numero;
            }

            cuenta.PilaReversas.Desapilar();                // POP
            op.Revertida = true;

            Operacion reversa = new Operacion(siguienteId++, TipoOperacion.Reversa,
                                              cuenta.Numero, destinoReversa, op.Monto, op.Id);
            Historial.AgregarInicio(reversa);

            return new Resultado(true, $"Se revirtió la operación #{op.Id:000} (S/ {op.Monto:0.00}).");
        }

        /// Movimientos donde participa la cuenta
        public IEnumerable<Operacion> HistorialDe(Cuenta cuenta)
        {
            foreach (Operacion op in Historial)
            {
                if (op.CuentaOrigen == cuenta.Numero || op.CuentaDestino == cuenta.Numero)
                    yield return op;
            }
        }
    }
}

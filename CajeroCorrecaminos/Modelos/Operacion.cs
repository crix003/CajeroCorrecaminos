namespace CajeroCorrecaminos.Modelos
{
    public enum TipoOperacion
    {
        Deposito,
        Retiro,
        Transferencia,
        Reversa,
        EliminacionBoleta,
        EliminacionBoletas
    }

    /// movimiento del cajero (depósito, retiro, transferencia o reversa).
    public class Operacion
    {
        public int Id { get; }
        public TipoOperacion Tipo { get; }
        public string CuentaOrigen { get; }
        public string? CuentaDestino { get; }
        public decimal Monto { get; }
        public DateTime Fecha { get; }

        /// Si es una Reversa, Id de la operación original que se deshizo.
        public int? IdReferencia { get; }

        public bool Revertida { get; set; }

        public Operacion(int id, TipoOperacion tipo, string cuentaOrigen, string? cuentaDestino,
                         decimal monto, int? idReferencia = null)
        {
            Id = id;
            Tipo = tipo;
            CuentaOrigen = cuentaOrigen;
            CuentaDestino = cuentaDestino;
            Monto = monto;
            IdReferencia = idReferencia;
            Fecha = DateTime.Now;
        }

        public override string ToString()
        {
            string nombre = Tipo switch
            {
                TipoOperacion.Deposito => "Depósito",
                TipoOperacion.Retiro => "Retiro",
                TipoOperacion.Transferencia => "Transferencia",
                TipoOperacion.Reversa => "Reversa",
                TipoOperacion.EliminacionBoleta => "Eliminación de boleta",
                _ => "Eliminación de boletas"
            };

            string texto = Tipo is TipoOperacion.EliminacionBoleta or TipoOperacion.EliminacionBoletas
                ? $"#{Id:000} {Fecha:HH:mm:ss}  {nombre}"
                : $"#{Id:000} {Fecha:HH:mm:ss}  {nombre}  S/ {Monto:0.00}";

            if (Tipo == TipoOperacion.Transferencia)
                texto += $"  ({CuentaOrigen} → {CuentaDestino})";
            else if (Tipo == TipoOperacion.Reversa)
                texto += $"  (anula #{IdReferencia:000})";
            else if (Tipo == TipoOperacion.EliminacionBoleta)
                texto += $"  (elimina #{IdReferencia:000})";
            else if (Tipo == TipoOperacion.EliminacionBoletas)
                texto += $"  ({Monto:0} boletas eliminadas)";

            if (Revertida) texto += "  [REVERTIDA]";
            return texto;
        }
    }
}

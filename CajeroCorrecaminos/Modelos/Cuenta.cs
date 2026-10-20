using CajeroCorrecaminos.Estructuras;

namespace CajeroCorrecaminos.Modelos
{
    public class Cuenta
    {
        public string Numero { get; }
        public string Titular { get; }
        public string Pin { get; }
        public decimal Saldo { get; set; }

        /// Pila de operaciones reversibles de esta cuenta (depósitos y transferencias enviadas).
        public Pila<Operacion> PilaReversas { get; } = new Pila<Operacion>();

        public Cuenta(string numero, string titular, string pin, decimal saldo)
        {
            Numero = numero;
            Titular = titular;
            Pin = pin;
            Saldo = saldo;
        }
    }
}

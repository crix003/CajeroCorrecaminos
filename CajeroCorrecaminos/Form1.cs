using System.Globalization;
using CajeroCorrecaminos.Modelos;
using CajeroCorrecaminos.Servicios;

namespace CajeroCorrecaminos
{
    public partial class Form1 : Form
    {
        private readonly Banco banco = new Banco();
        private Cuenta? cuentaActual;

        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = btnIngresar;
        }

        // ---------------- LOGIN ----------------
        private void btnIngresar_Click(object? sender, EventArgs e)
        {
            Cuenta? cuenta = banco.Login(txtCuenta.Text.Trim(), txtPin.Text.Trim());
            if (cuenta == null)
            {
                lblLoginMsg.Text = "Cuenta o PIN incorrectos.";
                txtPin.Clear();
                return;
            }

            cuentaActual = cuenta;
            lblLoginMsg.Text = "";
            txtCuenta.Clear();
            txtPin.Clear();

            pnlLogin.Visible = false;
            pnlCajero.Visible = true;
            this.AcceptButton = null;

            MostrarMensaje($"Sesión iniciada. ¡Hola, {cuenta.Titular}!", true);
            ActualizarVista();
        }

        private void btnSalir_Click(object? sender, EventArgs e)
        {
            cuentaActual = null;
            txtMonto.Clear();
            txtDestino.Clear();
            pnlCajero.Visible = false;
            pnlLogin.Visible = true;
            this.AcceptButton = btnIngresar;
            txtCuenta.Focus();
        }

        // ---------------- OPERACIONES ----------------
        private void btnDepositar_Click(object? sender, EventArgs e)
        {
            if (cuentaActual == null) return;

            if (!string.IsNullOrWhiteSpace(txtDestino.Text))
            {
                MostrarMensaje("'Cuenta destino' - Solo para transferencias.", false);
                return;
            }
            if (!TryLeerMonto(out decimal monto)) return;
            Terminar(banco.Depositar(cuentaActual, monto));
        }

        private void btnRetirar_Click(object? sender, EventArgs e)
        {
            if (cuentaActual == null) return;

            if (!string.IsNullOrWhiteSpace(txtDestino.Text))
            {
                MostrarMensaje("'Cuenta destino' — Solo para transferencias.", false);
                return;
            }
            if (!TryLeerMonto(out decimal monto)) return;
            Terminar(banco.Retirar(cuentaActual, monto));
        }

        private void btnTransferir_Click(object? sender, EventArgs e)
        {
            if (cuentaActual == null || !TryLeerMonto(out decimal monto)) return;

            string destino = txtDestino.Text.Trim();
            if (destino.Length == 0)
            {
                MostrarMensaje("Escribe la cuenta destino.", false);
                return;
            }

            Terminar(banco.Transferir(cuentaActual, destino, monto));
        }

        private void btnRevertir_Click(object? sender, EventArgs e)
        {
            if (cuentaActual == null) return;
            Terminar(banco.RevertirUltima(cuentaActual));
        }

        // ---------------- AUXILIARES ----------------
        private void Terminar(Resultado r)
        {
            MostrarMensaje(r.Mensaje, r.Exito);
            if (r.Exito)
            {
                txtMonto.Clear();
                txtDestino.Clear();
            }
            ActualizarVista();
        }

        private bool TryLeerMonto(out decimal monto)
        {
            // Condición : el monto debe ser un número decimal mayor a 0
            string texto = txtMonto.Text.Trim().Replace(',', '.');
            if (!decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out monto) || monto <= 0)
            {
                MostrarMensaje("Ingresa un monto válido (mayor a 0).", false);
                monto = 0;
                return false;
            }
            return true;
        }

        private void MostrarMensaje(string texto, bool exito)
        {
            lblMensaje.ForeColor = exito ? Color.SeaGreen : Color.Firebrick;
            lblMensaje.Text = texto;
        }

        // Función: Refresca saldo, pila e historial a partir de las estructuras de datos
        private void ActualizarVista()
        {
            if (cuentaActual == null) return;

            lblBienvenida.Text = $"Cuenta {cuentaActual.Numero} - {cuentaActual.Titular}";
            lblSaldo.Text = $"Saldo: S/ {cuentaActual.Saldo:0.00}";

            // Pila: se recorre del tope al fondo
            lstPila.Items.Clear();
            bool esTope = true;
            foreach (Operacion op in cuentaActual.PilaReversas)
            {
                lstPila.Items.Add((esTope ? "TOPE > " : "        ") + op);
                esTope = false;
            }
            if (cuentaActual.PilaReversas.EstaVacia)
                lstPila.Items.Add("(pila vacía)");

            btnRevertir.Enabled = !cuentaActual.PilaReversas.EstaVacia;

            // Historial: recorrido de la lista enlazada (más reciente primero)
            lstHistorial.Items.Clear();
            foreach (Operacion op in banco.HistorialDe(cuentaActual))
                lstHistorial.Items.Add(op.ToString());
        }

        private void btnLimpiarOperaciones_Click(object sender, EventArgs e)
        {
            banco.Historial.Limpiar();

            foreach (Cuenta c in banco.Cuentas)
            {
                c.PilaReversas.Vaciar();
            }

            // Limpia las listas y actualiza la vista
            lstPila.Items.Clear();
            lstHistorial.Items.Clear();

            MostrarMensaje("Historial y pila limpiados.", true);
            ActualizarVista();

        }
    }
}

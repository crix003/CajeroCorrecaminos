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

            lstHistorial.DrawMode = DrawMode.OwnerDrawVariable;
            lstHistorial.HorizontalScrollbar = false;
            lstHistorial.MeasureItem += lstHistorial_MeasureItem;
            lstHistorial.DrawItem += lstHistorial_DrawItem;
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

            // Boletas: se recorre la pila desde el tope, la boleta más reciente primero
            lstHistorial.Items.Clear();
            foreach (Operacion op in cuentaActual.PilaReversas)
                lstHistorial.Items.Add(op);

            if (cuentaActual.PilaReversas.EstaVacia)
                lstHistorial.Items.Add("(no hay boletas)");

            // Historial de registros: se recorre la lista enlazada desde el más reciente
            lstPila.Items.Clear();
            List<Operacion> historialPila = new List<Operacion>();
            foreach (Operacion op in cuentaActual.HistorialPila)
                historialPila.Add(op);

            for (int i = historialPila.Count - 1; i >= 0; i--)
            {
                Operacion op = historialPila[i];
                string prefijo = op.Tipo == TipoOperacion.Reversa
                    ? "REVERSA > "
                    : "OPERACIÓN > ";
                lstPila.Items.Add(prefijo + op);
            }

            if (cuentaActual.HistorialPila.EstaVacia)
                lstPila.Items.Add("(historial vacío)");
        }

        private void lstHistorial_MeasureItem(object? sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 150;
        }

        private void lstHistorial_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= lstHistorial.Items.Count)
                return;

            if (lstHistorial.Items[e.Index] is not Operacion operacion)
                return;

            e.DrawBackground();

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle area = new Rectangle(
                e.Bounds.X + 5,
                e.Bounds.Y + 5,
                e.Bounds.Width - 10,
                e.Bounds.Height - 10);

            using SolidBrush fondo = new SolidBrush(Color.WhiteSmoke);
            using Pen borde = new Pen(Color.LightGray);
            using Font titulo = new Font("Segoe UI", 9F, FontStyle.Bold);
            using Font texto = new Font("Segoe UI", 8F);
            using Font monto = new Font("Segoe UI", 10F, FontStyle.Bold);

            graphics.FillRectangle(fondo, area);
            graphics.DrawRectangle(borde, area);

            int posicionY = area.Y + 8;

            TextRenderer.DrawText(
                graphics,
                "CAJERO CORRECAMINOS",
                titulo,
                new Point(area.X + 8, posicionY),
                Color.FromArgb(30, 42, 68));

            posicionY += 19;

            using Pen separador = new Pen(Color.LightGray);
            graphics.DrawLine(
                separador,
                area.X + 8,
                posicionY + 7,
                area.Right - 8,
                posicionY + 7);

            posicionY += 17;

            TextRenderer.DrawText(
                graphics,
                $"Operación: #{operacion.Id:000}",
                texto,
                new Point(area.X + 8, posicionY),
                Color.DimGray);

            if (operacion.Revertida)
            {
                TextRenderer.DrawText(
                    graphics,
                    "REVERTIDA",
                    texto,
                    new Point(area.X + 125, posicionY),
                    Color.Firebrick);
            }

            posicionY += 16;

            TextRenderer.DrawText(
                graphics,
                operacion.Fecha.ToString("dd/MM/yyyy HH:mm"),
                texto,
                new Point(area.X + 8, posicionY),
                Color.DimGray);

            posicionY += 18;

            TextRenderer.DrawText(
                graphics,
                ObtenerNombreOperacion(operacion.Tipo),
                titulo,
                new Point(area.X + 8, posicionY),
                ObtenerColorOperacion(operacion.Tipo));

            posicionY += 19;

            string cuentas = operacion.Tipo == TipoOperacion.Transferencia
                ? $"De: {operacion.CuentaOrigen}  A: {operacion.CuentaDestino}"
                : $"Cuenta: {operacion.CuentaOrigen}";

            TextRenderer.DrawText(
                graphics,
                cuentas,
                texto,
                new Point(area.X + 8, posicionY),
                Color.DimGray);

            posicionY += 20;

            TextRenderer.DrawText(
                graphics,
                $"MONTO: S/ {operacion.Monto:0.00}",
                monto,
                new Point(area.X + 8, posicionY),
                Color.FromArgb(30, 42, 68));

            e.DrawFocusRectangle();
        }

        private static string ObtenerNombreOperacion(TipoOperacion tipo)
        {
            return tipo switch
            {
                TipoOperacion.Deposito => "DEPÓSITO",
                TipoOperacion.Retiro => "RETIRO",
                TipoOperacion.Transferencia => "TRANSFERENCIA",
                TipoOperacion.Reversa => "REVERSA",
                _ => "OPERACIÓN"
            };
        }

        private static Color ObtenerColorOperacion(TipoOperacion tipo)
        {
            return tipo switch
            {
                TipoOperacion.Deposito => Color.SeaGreen,
                TipoOperacion.Retiro => Color.FromArgb(70, 100, 160),
                TipoOperacion.Transferencia => Color.DarkOrange,
                TipoOperacion.Reversa => Color.Firebrick,
                _ => Color.Black
            };
        }

        private void btnEliminarBoletas_Click(object sender, EventArgs e)
        {
            if (cuentaActual == null) return;

            int cantidadBoletas = cuentaActual.PilaReversas.Cantidad;
            if (cantidadBoletas > 0)
            {
                Operacion eliminacion = banco.RegistrarEliminacionBoletas(
                    cuentaActual,
                    cantidadBoletas);
                cuentaActual.HistorialPila.AgregarFinal(eliminacion);
            }

            cuentaActual.PilaReversas.Vaciar();

            ActualizarVista();
            MostrarMensaje("Boletas eliminadas correctamente.", true);
        }
    }
}

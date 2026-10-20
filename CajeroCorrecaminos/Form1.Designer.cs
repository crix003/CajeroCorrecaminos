namespace CajeroCorrecaminos
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlLogin = new Panel();
            pnlLoginCard = new Panel();
            lblLoginTitulo = new Label();
            lblLoginSub = new Label();
            lblCuenta = new Label();
            txtCuenta = new TextBox();
            lblPin = new Label();
            txtPin = new TextBox();
            btnIngresar = new Button();
            lblLoginMsg = new Label();
            lblDemo = new Label();
            pnlCajero = new Panel();
            lblMensaje = new Label();
            grpHistorial = new GroupBox();
            btnEliminarBoletas = new Button();
            lstHistorial = new ListBox();
            btnBorrarBoleta = new Button();
            grpPila = new GroupBox();
            lblPilaInfo = new Label();
            lstPila = new ListBox();
            grpOperaciones = new GroupBox();
            BtnRevertir = new Button();
            lblMonto = new Label();
            txtMonto = new TextBox();
            lblDestino = new Label();
            txtDestino = new TextBox();
            btnDepositar = new Button();
            btnRetirar = new Button();
            btnTransferir = new Button();
            pnlHeader = new Panel();
            lblBienvenida = new Label();
            lblSaldo = new Label();
            btnSalir = new Button();
            pnlLogin.SuspendLayout();
            pnlLoginCard.SuspendLayout();
            pnlCajero.SuspendLayout();
            grpHistorial.SuspendLayout();
            grpPila.SuspendLayout();
            grpOperaciones.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.FromArgb(30, 42, 68);
            pnlLogin.Controls.Add(pnlLoginCard);
            pnlLogin.Dock = DockStyle.Fill;
            pnlLogin.Location = new Point(0, 0);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(996, 560);
            pnlLogin.TabIndex = 1;
            // 
            // pnlLoginCard
            // 
            pnlLoginCard.BackColor = Color.White;
            pnlLoginCard.Controls.Add(lblLoginTitulo);
            pnlLoginCard.Controls.Add(lblLoginSub);
            pnlLoginCard.Controls.Add(lblCuenta);
            pnlLoginCard.Controls.Add(txtCuenta);
            pnlLoginCard.Controls.Add(lblPin);
            pnlLoginCard.Controls.Add(txtPin);
            pnlLoginCard.Controls.Add(btnIngresar);
            pnlLoginCard.Controls.Add(lblLoginMsg);
            pnlLoginCard.Controls.Add(lblDemo);
            pnlLoginCard.Location = new Point(280, 70);
            pnlLoginCard.Name = "pnlLoginCard";
            pnlLoginCard.Size = new Size(380, 420);
            pnlLoginCard.TabIndex = 0;
            // 
            // lblLoginTitulo
            // 
            lblLoginTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLoginTitulo.ForeColor = Color.FromArgb(30, 42, 68);
            lblLoginTitulo.Location = new Point(20, 25);
            lblLoginTitulo.Name = "lblLoginTitulo";
            lblLoginTitulo.Size = new Size(340, 40);
            lblLoginTitulo.TabIndex = 0;
            lblLoginTitulo.Text = "Cajero Correcaminos";
            lblLoginTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLoginSub
            // 
            lblLoginSub.Font = new Font("Segoe UI", 10F);
            lblLoginSub.ForeColor = Color.Gray;
            lblLoginSub.Location = new Point(20, 68);
            lblLoginSub.Name = "lblLoginSub";
            lblLoginSub.Size = new Size(340, 24);
            lblLoginSub.TabIndex = 1;
            lblLoginSub.Text = "Ingresa tu número de cuenta y PIN";
            lblLoginSub.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCuenta
            // 
            lblCuenta.Font = new Font("Segoe UI", 10F);
            lblCuenta.Location = new Point(40, 115);
            lblCuenta.Name = "lblCuenta";
            lblCuenta.Size = new Size(300, 22);
            lblCuenta.TabIndex = 2;
            lblCuenta.Text = "N.º de cuenta";
            // 
            // txtCuenta
            // 
            txtCuenta.Font = new Font("Segoe UI", 12F);
            txtCuenta.Location = new Point(40, 140);
            txtCuenta.MaxLength = 10;
            txtCuenta.Name = "txtCuenta";
            txtCuenta.Size = new Size(300, 29);
            txtCuenta.TabIndex = 0;
            // 
            // lblPin
            // 
            lblPin.Font = new Font("Segoe UI", 10F);
            lblPin.Location = new Point(40, 185);
            lblPin.Name = "lblPin";
            lblPin.Size = new Size(300, 22);
            lblPin.TabIndex = 3;
            lblPin.Text = "PIN";
            // 
            // txtPin
            // 
            txtPin.Font = new Font("Segoe UI", 12F);
            txtPin.Location = new Point(40, 210);
            txtPin.MaxLength = 6;
            txtPin.Name = "txtPin";
            txtPin.Size = new Size(300, 29);
            txtPin.TabIndex = 1;
            txtPin.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(242, 140, 40);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(40, 265);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(300, 42);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // lblLoginMsg
            // 
            lblLoginMsg.Font = new Font("Segoe UI", 9.5F);
            lblLoginMsg.ForeColor = Color.Firebrick;
            lblLoginMsg.Location = new Point(40, 315);
            lblLoginMsg.Name = "lblLoginMsg";
            lblLoginMsg.Size = new Size(300, 22);
            lblLoginMsg.TabIndex = 4;
            lblLoginMsg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDemo
            // 
            lblDemo.Font = new Font("Segoe UI", 9F);
            lblDemo.ForeColor = Color.Gray;
            lblDemo.Location = new Point(20, 350);
            lblDemo.Name = "lblDemo";
            lblDemo.Size = new Size(340, 55);
            lblDemo.TabIndex = 5;
            lblDemo.Text = "Cuentas de prueba (cuenta / PIN):\r\n1001 / 1234     1002 / 1111     1003 / 2222";
            lblDemo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCajero
            // 
            pnlCajero.BackColor = Color.FromArgb(244, 246, 250);
            pnlCajero.Controls.Add(lblMensaje);
            pnlCajero.Controls.Add(grpHistorial);
            pnlCajero.Controls.Add(grpPila);
            pnlCajero.Controls.Add(grpOperaciones);
            pnlCajero.Controls.Add(pnlHeader);
            pnlCajero.Dock = DockStyle.Fill;
            pnlCajero.Location = new Point(0, 0);
            pnlCajero.Name = "pnlCajero";
            pnlCajero.Size = new Size(996, 560);
            pnlCajero.TabIndex = 0;
            pnlCajero.Visible = false;
            // 
            // lblMensaje
            // 
            lblMensaje.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMensaje.Location = new Point(20, 495);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(900, 50);
            lblMensaje.TabIndex = 0;
            lblMensaje.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grpHistorial
            // 
            grpHistorial.Controls.Add(btnEliminarBoletas);
            grpHistorial.Controls.Add(lstHistorial);
            grpHistorial.Controls.Add(btnBorrarBoleta);
            grpHistorial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpHistorial.Location = new Point(714, 90);
            grpHistorial.Name = "grpHistorial";
            grpHistorial.Size = new Size(260, 390);
            grpHistorial.TabIndex = 1;
            grpHistorial.TabStop = false;
            grpHistorial.Text = "Boletas";
            // 
            // btnEliminarBoletas
            // 
            btnEliminarBoletas.BackColor = Color.DimGray;
            btnEliminarBoletas.FlatAppearance.BorderSize = 0;
            btnEliminarBoletas.FlatStyle = FlatStyle.Flat;
            btnEliminarBoletas.ForeColor = Color.White;
            btnEliminarBoletas.Location = new Point(10, 323);
            btnEliminarBoletas.Name = "btnEliminarBoletas";
            btnEliminarBoletas.Size = new Size(240, 50);
            btnEliminarBoletas.TabIndex = 6;
            btnEliminarBoletas.Text = "Eliminar todas las boletas";
            btnEliminarBoletas.UseVisualStyleBackColor = false;
            btnEliminarBoletas.Click += btnEliminarBoletas_Click;
            // 
            // lstHistorial
            // 
            lstHistorial.Font = new Font("Segoe UI", 9F);
            lstHistorial.FormattingEnabled = true;
            lstHistorial.IntegralHeight = false;
            lstHistorial.ItemHeight = 15;
            lstHistorial.Location = new Point(10, 24);
            lstHistorial.Name = "lstHistorial";
            lstHistorial.Size = new Size(240, 237);
            lstHistorial.TabIndex = 0;
            // 
            // btnBorrarBoleta
            // 
            btnBorrarBoleta.BackColor = Color.Firebrick;
            btnBorrarBoleta.FlatAppearance.BorderSize = 0;
            btnBorrarBoleta.FlatStyle = FlatStyle.Flat;
            btnBorrarBoleta.ForeColor = Color.White;
            btnBorrarBoleta.Location = new Point(10, 267);
            btnBorrarBoleta.Name = "btnBorrarBoleta";
            btnBorrarBoleta.Size = new Size(240, 50);
            btnBorrarBoleta.TabIndex = 5;
            btnBorrarBoleta.Text = "Eliminar boleta seleccionada";
            btnBorrarBoleta.UseVisualStyleBackColor = false;
            btnBorrarBoleta.Click += btnBorrarBoleta_Click;
            // 
            // grpPila
            // 
            grpPila.Controls.Add(lblPilaInfo);
            grpPila.Controls.Add(lstPila);
            grpPila.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpPila.Location = new Point(363, 90);
            grpPila.Name = "grpPila";
            grpPila.Size = new Size(338, 390);
            grpPila.TabIndex = 2;
            grpPila.TabStop = false;
            grpPila.Text = "Historial de registros(PILAS)";
            // 
            // lblPilaInfo
            // 
            lblPilaInfo.Font = new Font("Segoe UI", 8.5F);
            lblPilaInfo.ForeColor = Color.Gray;
            lblPilaInfo.Location = new Point(10, 25);
            lblPilaInfo.Name = "lblPilaInfo";
            lblPilaInfo.Size = new Size(250, 34);
            lblPilaInfo.TabIndex = 0;
            lblPilaInfo.Text = "Último en entrar, primero en salir (LIFO). El tope se revierte primero.";
            // 
            // lstPila
            // 
            lstPila.Font = new Font("Consolas", 9F);
            lstPila.FormattingEnabled = true;
            lstPila.HorizontalScrollbar = true;
            lstPila.ItemHeight = 14;
            lstPila.Location = new Point(10, 62);
            lstPila.Name = "lstPila";
            lstPila.Size = new Size(322, 298);
            lstPila.TabIndex = 1;
            // 
            // grpOperaciones
            // 
            grpOperaciones.Controls.Add(BtnRevertir);
            grpOperaciones.Controls.Add(lblMonto);
            grpOperaciones.Controls.Add(txtMonto);
            grpOperaciones.Controls.Add(lblDestino);
            grpOperaciones.Controls.Add(txtDestino);
            grpOperaciones.Controls.Add(btnDepositar);
            grpOperaciones.Controls.Add(btnRetirar);
            grpOperaciones.Controls.Add(btnTransferir);
            grpOperaciones.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpOperaciones.Location = new Point(20, 90);
            grpOperaciones.Name = "grpOperaciones";
            grpOperaciones.Size = new Size(330, 390);
            grpOperaciones.TabIndex = 3;
            grpOperaciones.TabStop = false;
            grpOperaciones.Text = "Operaciones";
            // 
            // BtnRevertir
            // 
            BtnRevertir.BackColor = Color.IndianRed;
            BtnRevertir.FlatAppearance.BorderSize = 0;
            BtnRevertir.FlatStyle = FlatStyle.Flat;
            BtnRevertir.ForeColor = Color.White;
            BtnRevertir.Location = new Point(20, 275);
            BtnRevertir.Name = "BtnRevertir";
            BtnRevertir.Size = new Size(290, 42);
            BtnRevertir.TabIndex = 5;
            BtnRevertir.Text = "Revertir última operación";
            BtnRevertir.UseVisualStyleBackColor = false;
            BtnRevertir.Click += btnRevertir_Click;
            // 
            // lblMonto
            // 
            lblMonto.Font = new Font("Segoe UI", 9.5F);
            lblMonto.Location = new Point(20, 32);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(290, 20);
            lblMonto.TabIndex = 0;
            lblMonto.Text = "Monto (S/)";
            // 
            // txtMonto
            // 
            txtMonto.Font = new Font("Segoe UI", 12F);
            txtMonto.Location = new Point(20, 55);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(290, 29);
            txtMonto.TabIndex = 0;
            // 
            // lblDestino
            // 
            lblDestino.Font = new Font("Segoe UI", 9.5F);
            lblDestino.Location = new Point(20, 95);
            lblDestino.Name = "lblDestino";
            lblDestino.Size = new Size(290, 20);
            lblDestino.TabIndex = 1;
            lblDestino.Text = "Cuenta destino (solo para transferir)";
            // 
            // txtDestino
            // 
            txtDestino.Font = new Font("Segoe UI", 12F);
            txtDestino.Location = new Point(20, 118);
            txtDestino.MaxLength = 10;
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(290, 29);
            txtDestino.TabIndex = 1;
            // 
            // btnDepositar
            // 
            btnDepositar.BackColor = Color.FromArgb(46, 139, 87);
            btnDepositar.FlatAppearance.BorderSize = 0;
            btnDepositar.FlatStyle = FlatStyle.Flat;
            btnDepositar.ForeColor = Color.White;
            btnDepositar.Location = new Point(20, 165);
            btnDepositar.Name = "btnDepositar";
            btnDepositar.Size = new Size(140, 42);
            btnDepositar.TabIndex = 2;
            btnDepositar.Text = "Depositar";
            btnDepositar.UseVisualStyleBackColor = false;
            btnDepositar.Click += btnDepositar_Click;
            // 
            // btnRetirar
            // 
            btnRetirar.BackColor = Color.FromArgb(70, 100, 160);
            btnRetirar.FlatAppearance.BorderSize = 0;
            btnRetirar.FlatStyle = FlatStyle.Flat;
            btnRetirar.ForeColor = Color.White;
            btnRetirar.Location = new Point(170, 165);
            btnRetirar.Name = "btnRetirar";
            btnRetirar.Size = new Size(140, 42);
            btnRetirar.TabIndex = 3;
            btnRetirar.Text = "Retirar";
            btnRetirar.UseVisualStyleBackColor = false;
            btnRetirar.Click += btnRetirar_Click;
            // 
            // btnTransferir
            // 
            btnTransferir.BackColor = Color.FromArgb(242, 140, 40);
            btnTransferir.FlatAppearance.BorderSize = 0;
            btnTransferir.FlatStyle = FlatStyle.Flat;
            btnTransferir.ForeColor = Color.White;
            btnTransferir.Location = new Point(20, 220);
            btnTransferir.Name = "btnTransferir";
            btnTransferir.Size = new Size(290, 42);
            btnTransferir.TabIndex = 4;
            btnTransferir.Text = "Transferir";
            btnTransferir.UseVisualStyleBackColor = false;
            btnTransferir.Click += btnTransferir_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 42, 68);
            pnlHeader.Controls.Add(lblBienvenida);
            pnlHeader.Controls.Add(lblSaldo);
            pnlHeader.Controls.Add(btnSalir);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(996, 70);
            pnlHeader.TabIndex = 4;
            // 
            // lblBienvenida
            // 
            lblBienvenida.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.Location = new Point(20, 12);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(420, 24);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido";
            // 
            // lblSaldo
            // 
            lblSaldo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSaldo.ForeColor = Color.FromArgb(242, 140, 40);
            lblSaldo.Location = new Point(20, 36);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(420, 28);
            lblSaldo.TabIndex = 1;
            lblSaldo.Text = "Saldo: S/ 0.00";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.White;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir.Location = new Point(780, 17);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(130, 36);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Cerrar sesión";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(996, 560);
            Controls.Add(pnlCajero);
            Controls.Add(pnlLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cajero Automático Correcaminos";
            pnlLogin.ResumeLayout(false);
            pnlLoginCard.ResumeLayout(false);
            pnlLoginCard.PerformLayout();
            pnlCajero.ResumeLayout(false);
            grpHistorial.ResumeLayout(false);
            grpPila.ResumeLayout(false);
            grpOperaciones.ResumeLayout(false);
            grpOperaciones.PerformLayout();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Panel pnlLoginCard;
        private System.Windows.Forms.Label lblLoginTitulo;
        private System.Windows.Forms.Label lblLoginSub;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label lblLoginMsg;
        private System.Windows.Forms.Label lblDemo;

        private System.Windows.Forms.Panel pnlCajero;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox grpOperaciones;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Button btnDepositar;
        private System.Windows.Forms.Button btnRetirar;
        private System.Windows.Forms.Button btnTransferir;
        private System.Windows.Forms.Button btnBorrarBoleta;
        private System.Windows.Forms.GroupBox grpPila;
        private System.Windows.Forms.Label lblPilaInfo;
        private System.Windows.Forms.ListBox lstPila;
        private System.Windows.Forms.GroupBox grpHistorial;
        private System.Windows.Forms.ListBox lstHistorial;
        private System.Windows.Forms.Label lblMensaje;
        private Button btnEliminarBoletas;
        private Button BtnRevertir;
    }
}

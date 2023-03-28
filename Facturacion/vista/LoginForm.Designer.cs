namespace vista
{
    partial class LoginForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.AceptarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UsuarioTextBox = new System.Windows.Forms.TextBox();
            this.ContraseñaTextBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.MostrarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // AceptarButton
            // 
            this.AceptarButton.Image = ((System.Drawing.Image)(resources.GetObject("AceptarButton.Image")));
            this.AceptarButton.Location = new System.Drawing.Point(96, 114);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(95, 35);
            this.AceptarButton.TabIndex = 0;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelarButton.Image")));
            this.CancelarButton.Location = new System.Drawing.Point(255, 114);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(95, 35);
            this.CancelarButton.TabIndex = 1;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CancelarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario";
            // 
            // UsuarioTextBox
            // 
            this.UsuarioTextBox.Location = new System.Drawing.Point(96, 26);
            this.UsuarioTextBox.Name = "UsuarioTextBox";
            this.UsuarioTextBox.Size = new System.Drawing.Size(254, 20);
            this.UsuarioTextBox.TabIndex = 4;
            // 
            // ContraseñaTextBox2
            // 
            this.ContraseñaTextBox2.Location = new System.Drawing.Point(96, 73);
            this.ContraseñaTextBox2.Name = "ContraseñaTextBox2";
            this.ContraseñaTextBox2.PasswordChar = '*';
            this.ContraseñaTextBox2.Size = new System.Drawing.Size(254, 20);
            this.ContraseñaTextBox2.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(397, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // MostrarButton
            // 
            this.MostrarButton.Image = ((System.Drawing.Image)(resources.GetObject("MostrarButton.Image")));
            this.MostrarButton.Location = new System.Drawing.Point(365, 73);
            this.MostrarButton.Name = "MostrarButton";
            this.MostrarButton.Size = new System.Drawing.Size(26, 23);
            this.MostrarButton.TabIndex = 7;
            this.MostrarButton.UseVisualStyleBackColor = true;
            this.MostrarButton.Click += new System.EventHandler(this.MostrarButton_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.AceptarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(569, 175);
            this.ControlBox = false;
            this.Controls.Add(this.MostrarButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ContraseñaTextBox2);
            this.Controls.Add(this.UsuarioTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.AceptarButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsuarioTextBox;
        private System.Windows.Forms.TextBox ContraseñaTextBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button MostrarButton;
    }
}


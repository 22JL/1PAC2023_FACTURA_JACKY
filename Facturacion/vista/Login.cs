using System;
using System.Windows.Forms;

namespace vista
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if (UsuarioTextBox.Text == String.Empty)
            {
                errorProvider1.SetError(UsuarioTextBox, "Ingrese un usuario");
                return;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(ContraseñaTextBox2.Text))
            {
                errorProvider1.SetError(ContraseñaTextBox2, "Ingrese una contraseña");
                return;
            }
            errorProvider1.Clear();

            //validar en la base de datos

            // Mostrar Menu
            Menu MenuFormulario = new Menu();
            this.Hide();
            MenuFormulario.Show();

        }

        private void MostrarButton_Click(object sender, EventArgs e)
        {
            if (ContraseñaTextBox2.PasswordChar == '*')
            {
                ContraseñaTextBox2.PasswordChar = '\0';
            }
            else
            {
                ContraseñaTextBox2.PasswordChar = '*';
            }
        }
    }
}

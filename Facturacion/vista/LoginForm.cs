using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace vista
{
    public partial class LoginForm : Form
    {
        public LoginForm()
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

            Login login = new Login(UsuarioTextBox.Text, ContraseñaTextBox2.Text);
            Usuario usuario = new Usuario();
            UsuarioDB usuarioDB = new UsuarioDB();




            usuario = usuarioDB.Autenticar(login);
            if (usuario != null)
            {
                if (usuario.EstaActivo)
                {
                    // Mostrar Menu
                    Menu MenuFormulario = new Menu();
                    this.Hide();
                    MenuFormulario.Show();
                }
                else
                {
                    MessageBox.Show("El usuario no está activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Datos de usuario incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



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

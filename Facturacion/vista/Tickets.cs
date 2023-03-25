using System.Windows.Forms;

namespace vista
{
    public partial class Tickets : Form
    {
        public Tickets()
        {
            InitializeComponent();
        }
        string tipoOperacion;
        private void NuevoBbutton_Click(object sender, System.EventArgs e)
        {
            tipoOperacion = "Nuevo";
            HabilitarControles();
        }
        private void HabilitarControles()
        {
            ClienteTextBox.Enabled = true;
            TipoSoporteComboBox.Enabled = true;
            SolicitudTextBox.Enabled = true;
            RespuestaTextBox.Enabled = true;
            PrecioTextBox.Enabled = true;
            AdjuntarFotoButton.Enabled = true;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            ModificarButton.Enabled = false;
            NuevoButton.Enabled = false;
        }
        private void dehabilitarControles()
        {
            ClienteTextBox.Enabled = false;
            TipoSoporteComboBox.Enabled = false;
            SolicitudTextBox.Enabled = false;
            RespuestaTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
            AdjuntarFotoButton.Enabled = false;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
            ModificarButton.Enabled = true;
            NuevoButton.Enabled = true;
        }

        private void CancelarButton_Click(object sender, System.EventArgs e)
        {
            dehabilitarControles();
        }

        private void ModificarButton_Click(object sender, System.EventArgs e)
        {
            tipoOperacion = "Modificar";
        }

        private void GuardarButton_Click(object sender, System.EventArgs e)
        {
            if (tipoOperacion == "Nuevo")
            {
                if (string.IsNullOrEmpty(ClienteTextBox.Text))
                {
                    errorProvider1.SetError(ClienteTextBox, "Ingrese un cliente");
                    ClienteTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(TipoSoporteComboBox.Text))
                {
                    errorProvider1.SetError(TipoSoporteComboBox, "Ingrese el Tipo de Soporte");
                    TipoSoporteComboBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(SolicitudTextBox.Text))
                {
                    errorProvider1.SetError(SolicitudTextBox, "Ingrese una Descripción de la solicitud");
                    SolicitudTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(RespuestaTextBox.Text))
                {
                    errorProvider1.SetError(RespuestaTextBox, "Seleccione la respuesta");
                    RespuestaTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

            }
        }

        private void PrecioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar) != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}

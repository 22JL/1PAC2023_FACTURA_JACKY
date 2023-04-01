using Datos;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace vista
{
    public partial class TicketsForm : Form
    {
        public TicketsForm()
        {
            InitializeComponent();
        }
        string tipoOperacion;

        Tickets ticket = new Tickets();
        DataTable dt = new DataTable();
        TicketsDB TicketsDB = new TicketsDB();

        private void NuevoBbutton_Click(object sender, System.EventArgs e)
        {
            ClienteTextBox.Focus();
            HabilitarControles();
            tipoOperacion = "Nuevo";

        }
        private void HabilitarControles()
        {
            ClienteTextBox.Enabled = true;
            TipoSoporteComboBox.Enabled = true;
            SolicitudTextBox.Enabled = true;
            RespuestaTextBox.Enabled = true;
            PrecioTextBox.Enabled = true;
            DescuentoTextBox.Enabled = true;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            ModificarButton.Enabled = false;
        }
        private void DeshabilitarControles()
        {
            ClienteTextBox.Enabled = false;
            TipoSoporteComboBox.Enabled = false;
            SolicitudTextBox.Enabled = false;
            RespuestaTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
            DescuentoTextBox.Enabled = false;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
            ModificarButton.Enabled = true;
        }
        private void LimpiarControles()
        {
            ClienteTextBox.Clear();
            TipoSoporteComboBox.Text = "";
            SolicitudTextBox.Clear();
            RespuestaTextBox.Clear();
            PrecioTextBox.Text = "";
            DescuentoTextBox.Clear();
            TicketLabel.Text = "";
            FechaDateTimePicker.Value = DateTime.Now;
        }

        private void CancelarButton_Click(object sender, System.EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();
        }

        private void ModificarButton_Click(object sender, System.EventArgs e)
        {
            tipoOperacion = "Modificar";
            if (TicketsDataGridView.SelectedRows.Count > 0)
            {
                TicketLabel.Text = TicketsDataGridView.CurrentRow.Cells["CodigoTicket"].Value.ToString();
                ClienteTextBox.Text = TicketsDataGridView.CurrentRow.Cells["Cliente"].Value.ToString();
                TipoSoporteComboBox.Text = TicketsDataGridView.CurrentRow.Cells["TipoSoporte"].Value.ToString();
                SolicitudTextBox.Text = TicketsDataGridView.CurrentRow.Cells["DescripcionSolicitud"].Value.ToString();
                RespuestaTextBox.Text = TicketsDataGridView.CurrentRow.Cells["DescripcionRespuesta"].Value.ToString();
                PrecioTextBox.Text = TicketsDataGridView.CurrentRow.Cells["Precio"].Value.ToString();
                DescuentoTextBox.Text = TicketsDataGridView.CurrentRow.Cells["Descuento"].Value.ToString();
                ISVlabel.Text = TicketsDataGridView.CurrentRow.Cells["Impuesto"].Value.ToString();
                TotalLabel.Text = TicketsDataGridView.CurrentRow.Cells["Total"].Value.ToString();
                HabilitarControles();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }

        private void GuardarButton_Click(object sender, System.EventArgs e)
        {
            double precio = Convert.ToDouble(PrecioTextBox.Text);
            double ISV = precio * 0.15;
            decimal SubTotal = Convert.ToDecimal(precio + ISV);
            decimal descuento = SubTotal * (Convert.ToDecimal(DescuentoTextBox.Text) / 100);
            decimal Total = SubTotal - descuento;
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
                    errorProvider1.SetError(RespuestaTextBox, "Ingrese la respuesta/Solución de la solicitud");
                    RespuestaTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(PrecioTextBox.Text))
                {
                    errorProvider1.SetError(PrecioTextBox, "Ingrese un valor");
                    RespuestaTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(DescuentoTextBox.Text))
                {
                    errorProvider1.SetError(DescuentoTextBox, "Ingrese un valor");
                    RespuestaTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                ticket.CodigoTicket = TicketsDB.DevolverUltimoId() + 1;
                ticket.Cliente = ClienteTextBox.Text;
                ticket.TipoSoporte = TipoSoporteComboBox.Text;
                ticket.DescripcionSolicitud = SolicitudTextBox.Text;
                ticket.DescripcionRespuesta = RespuestaTextBox.Text;
                ticket.Precio = Convert.ToDecimal(PrecioTextBox.Text);
                ticket.Descuento = descuento;
                ticket.FechaCreacion = FechaDateTimePicker.Value;

                ticket.Impuesto = Convert.ToDecimal(ISV);
                ticket.Total = Total;

                //Insertar en la base de datos
                bool inserto = TicketsDB.Insertar(ticket);
                if (inserto)
                {
                    LimpiarControles();
                    DeshabilitarControles();
                    TraerUsuarios();
                    MessageBox.Show("Registro guardado");
                }
                else
                {
                    MessageBox.Show("No es posible guardar el registro");
                }


            }
            else if (tipoOperacion == "Modificar")
            {
                ticket.CodigoTicket = Convert.ToInt32(TicketLabel.Text);
                ticket.Cliente = ClienteTextBox.Text;
                ticket.TipoSoporte = TipoSoporteComboBox.Text;
                ticket.DescripcionSolicitud = SolicitudTextBox.Text;
                ticket.DescripcionRespuesta = RespuestaTextBox.Text;
                ticket.Precio = Convert.ToDecimal(PrecioTextBox.Text);
                ticket.Descuento = descuento;
                ticket.Impuesto = Convert.ToDecimal(ISV);
                ticket.Total = Total;



                bool modifico = TicketsDB.Editar(ticket);
                if (modifico)
                {
                    LimpiarControles();
                    DeshabilitarControles();
                    TraerUsuarios();
                    MessageBox.Show("Registro actualizado correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el registro");
                }
            }
        }


        private void TraerUsuarios()
        {
            dt = TicketsDB.DevolverUsuarios();
            TicketsDataGridView.DataSource = dt;
        }


        private void PrecioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar) != '.' && (e.KeyChar) != '\b')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void TicketsForm_Load(object sender, EventArgs e)
        {
            TraerUsuarios();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (TicketsDataGridView.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Esta seguro de eliminar el registro", "Advertencia", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    bool elimino = TicketsDB.Eliminar(TicketsDataGridView.CurrentRow.Cells["CodigoTicket"].Value.ToString());

                    if (elimino)
                    {
                        LimpiarControles();
                        DeshabilitarControles();
                        TraerUsuarios();
                        MessageBox.Show("Registro eliminado");
                    }
                    else
                    { MessageBox.Show("No se pudo eliminar el registro"); }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }



        private void DescuentoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar) != '.' && (e.KeyChar) != '\b')
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

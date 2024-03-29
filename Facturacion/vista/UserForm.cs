﻿using Datos;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace vista
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }
        string tipoOperacion;
        Usuario user = new Usuario();
        DataTable dt = new DataTable();
        UsuarioDB UsuarioDB = new UsuarioDB();

        private void NuevoBbutton_Click(object sender, EventArgs e)
        {
            CodigoTextBox.Focus();
            HabilitarControles();
            tipoOperacion = "Nuevo";
        }

        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            ContraseniaTextBox.Enabled = true;
            CorreoTextBox.Enabled = true;
            RolComboBox.Enabled = true;
            EstaActivoCheckBox.Enabled = true;
            AdjuntarButton.Enabled = true;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            ModificarButton.Enabled = false;
        }
        private void DeshabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            ContraseniaTextBox.Enabled = false;
            CorreoTextBox.Enabled = false;
            RolComboBox.Enabled = false;
            EstaActivoCheckBox.Enabled = false;
            AdjuntarButton.Enabled = false;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
            ModificarButton.Enabled = true;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();
        }
        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            NombreTextBox.Clear();
            ContraseniaTextBox.Clear();
            CorreoTextBox.Clear();
            RolComboBox.Text = "";
            EstaActivoCheckBox.Checked = false;
            FotoPictureBox.Image = null;

        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            tipoOperacion = "Modificar";
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (tipoOperacion == "Nuevo")
            {
                if (string.IsNullOrEmpty(CodigoTextBox.Text))
                {
                    errorProvider1.SetError(CodigoTextBox, "Ingrese un código");
                    CodigoTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(NombreTextBox.Text))
                {
                    errorProvider1.SetError(NombreTextBox, "Ingrese un nombre");
                    NombreTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(ContraseniaTextBox.Text))
                {
                    errorProvider1.SetError(ContraseniaTextBox, "Ingrese una contraseña");
                    ContraseniaTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(RolComboBox.Text))
                {
                    errorProvider1.SetError(RolComboBox, "Seleccione un rol");
                    RolComboBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                user.CodigoUsuario = CodigoTextBox.Text;
                user.Nombre = NombreTextBox.Text;
                user.Contraseña = ContraseniaTextBox.Text;
                user.Rol = RolComboBox.Text;
                user.Correo = CorreoTextBox.Text;
                user.EstaActivo = EstaActivoCheckBox.Checked;

                if (FotoPictureBox.Image != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    FotoPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    user.Foto = ms.GetBuffer();
                }
                //Insertar en la base de datos
                bool inserto = UsuarioDB.Insertar(user);
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
                user.CodigoUsuario = CodigoTextBox.Text;
                user.Nombre = NombreTextBox.Text;
                user.Contraseña = ContraseniaTextBox.Text;
                user.Rol = RolComboBox.Text;
                user.Correo = CorreoTextBox.Text;
                user.EstaActivo = EstaActivoCheckBox.Checked;

                if (FotoPictureBox.Image != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    FotoPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    user.Foto = ms.GetBuffer();
                }

                bool modifico = UsuarioDB.Editar(user);
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

        private void AdjuntarButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                FotoPictureBox.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            TraerUsuarios();
        }

        private void TraerUsuarios()
        {
            dt = UsuarioDB.DevolverUsuarios();

            UsuariosDataGridView.DataSource = dt;

        }

        private void ModificarButton_Click_1(object sender, EventArgs e)
        {
            tipoOperacion = "Modificar";
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                CodigoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["CodigoUsuario"].Value.ToString();
                NombreTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                ContraseniaTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Contrasena"].Value.ToString();
                CorreoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Correo"].Value.ToString();
                RolComboBox.Text = UsuariosDataGridView.CurrentRow.Cells["Rol"].Value.ToString();
                EstaActivoCheckBox.Checked = Convert.ToBoolean(UsuariosDataGridView.CurrentRow.Cells["EstadoActivo"].Value);

                byte[] miFoto = UsuarioDB.DevolverFoto(UsuariosDataGridView.CurrentRow.Cells["CodigoUsuario"].Value.ToString());

                if (miFoto.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(miFoto);
                    FotoPictureBox.Image = System.Drawing.Bitmap.FromStream(ms);
                }

                HabilitarControles();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Esta seguro de eliminar el registro", "Advertencia", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    bool elimino = UsuarioDB.Eliminar(UsuariosDataGridView.CurrentRow.Cells["CodigoUsuario"].Value.ToString());

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
    }
}

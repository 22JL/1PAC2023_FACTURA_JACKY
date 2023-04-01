using System;
using System.Windows.Forms;

namespace vista
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void facturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm usuariosForm = new UserForm();
            usuariosForm.Show();
        }

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TicketsForm ticketsForm = new TicketsForm();
            ticketsForm.Show();
        }
    }
}

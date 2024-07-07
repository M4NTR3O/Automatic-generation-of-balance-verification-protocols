using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automatic_generation_of_balance_verification_protocols
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void createProtocolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateProtocolForm protocol = new CreateProtocolForm();
            this.Hide();
            protocol.ShowDialog();
            if (protocol.DialogResult == DialogResult.OK || protocol.DialogResult == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void открытьПротоколToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + @"\Протоколы";
            openFileDialog.Filter = "Protocols Files (XML)|*.XML";
            openFileDialog.Title = "Выберите файл протокола";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            CreateProtocolForm protocol = new CreateProtocolForm(openFileDialog.FileName);
            this.Hide();
            protocol.ShowDialog();
            if (protocol.DialogResult == DialogResult.OK || protocol.DialogResult == DialogResult.Cancel)
            {
                this.Show();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automatic_generation_of_balance_verification_protocols
{
    public partial class MetrologyParametrsForm : Form
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        public MetrologyParametrsForm()
        {
            InitializeComponent();
        }

        public MetrologyParametrsForm(Dictionary<string, int> parametrs)
        {
            InitializeComponent();
            textBoxMax.Text = parametrs[labelMax.Name].ToString();
            textBoxMaxn.Text = parametrs[labelMaxn.Name].ToString();
            textBoxMin.Text = parametrs[labelMin.Name].ToString();
            textBoxMinn.Text = parametrs[labelMinn.Name].ToString();
            textBoxDe.Text = parametrs[labelDe.Name].ToString();
        }

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                dictionary.Add(labelMax.Name, Convert.ToInt32(textBoxMax.Text));
                dictionary.Add(labelMaxn.Name, Convert.ToInt32(textBoxMaxn.Text));
                dictionary.Add(labelMin.Name, Convert.ToInt32(textBoxMin.Text));
                dictionary.Add(labelMinn.Name, Convert.ToInt32(textBoxMinn.Text));
                dictionary.Add(labelDe.Name, Convert.ToInt32(textBoxDe.Text));
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "Неверный ввод", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dictionary.Clear();
            }
        }

        public Dictionary<string, int> callDictionary()
        {
            return dictionary;
        }
    }
}

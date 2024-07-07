using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Automatic_generation_of_balance_verification_protocols
{
    public partial class AddingForm : Form
    {
        Dictionary<string, string> importantPerson = new Dictionary<string, string>();
        public AddingForm()
        {
            InitializeComponent();
        }
        public AddingForm(Dictionary<string, string> dictionary)
        {
            InitializeComponent();
            textBoxStateTrustee.Text = dictionary[labelStateTrustee.Text];
            textBoxRepresentativeOfTensib.Text = dictionary[labelRepresentativeOfTensib.Text];
            textBoxCustomerRepresentative.Text = dictionary[labelCustomerRepresentative.Text];
        }

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            importantPerson.Add(labelStateTrustee.Name, textBoxStateTrustee.Text);
            importantPerson.Add(labelRepresentativeOfTensib.Name, textBoxRepresentativeOfTensib.Text);
            importantPerson.Add(labelCustomerRepresentative.Name, textBoxCustomerRepresentative.Text);
            if (textBoxStateTrustee.Text != "" && textBoxRepresentativeOfTensib.Text != "" && textBoxCustomerRepresentative.Text != "")
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Yes;
        }

        public Dictionary<string, string> GetDictionary()
        {
            return importantPerson;
        }
    }
}

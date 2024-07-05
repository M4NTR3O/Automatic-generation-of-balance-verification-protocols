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
    public partial class CreateProtocolForm : Form
    {
        private DataGridView wagonsAndTransit = new DataGridView();
        private List<Double> resultWagonsAndTransit = new List<Double>();
        private List<Double> maxDeltaWagonsAndTransit = new List<Double>();
        Dictionary<string, int> parametrsMetrology = new Dictionary<string, int>();
        Dictionary<string, string> importantPerson = new Dictionary<string, string>();
        List<string> flags = new List<string>();

        public CreateProtocolForm()
        {
            InitializeComponent();
        }

        private void DataWagonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataWagonsForm dataWagonsForm = new DataWagonsForm();
            if (wagonsAndTransit != null && wagonsAndTransit.Columns.Count > 2)
            {
                dataWagonsForm = new DataWagonsForm(wagonsAndTransit);
            }
            this.Hide();
            dataWagonsForm.ShowDialog();
            if (dataWagonsForm.DialogResult == DialogResult.OK || dataWagonsForm.DialogResult == DialogResult.Cancel)
            {
                if (dataWagonsForm.DialogResult == DialogResult.OK)
                {
                    if (DataWagonToolStripMenuItem.BackColor != Color.Green)
                    {
                        toolStripProgressBar.Value += 15;
                    }
                    DataWagonToolStripMenuItem.BackColor = Color.Green;
                    wagonsAndTransit = dataWagonsForm.callData();
                    (resultWagonsAndTransit, maxDeltaWagonsAndTransit) = dataWagonsForm.calculateResult();
                    textBoxCountWagons.Text = wagonsAndTransit.Rows.Count.ToString();
                    textBoxWeightWagons.Text = resultWagonsAndTransit[0].ToString();
                }
                checkProgressBar();
                this.Show();
            }
        }

        private void MetrologyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MetrologyParametrsForm met = new MetrologyParametrsForm();
            this.Hide();
            if (parametrsMetrology.Count > 0)
            {
                met = new MetrologyParametrsForm(parametrsMetrology);
            }
            met.ShowDialog();
            if (met.DialogResult == DialogResult.OK || met.DialogResult == DialogResult.Cancel)
            {
                if (met.DialogResult == DialogResult.OK)
                {
                    if (MetrologyToolStripMenuItem.BackColor != Color.Green)
                    {
                        toolStripProgressBar.Value += 10;
                    }
                    MetrologyToolStripMenuItem.BackColor = Color.Green;
                    parametrsMetrology = met.callDictionary();
                }
                checkProgressBar();
                this.Show();
            }
        }

        private void AddingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddingForm addingForm = new AddingForm();
            this.Hide();
            if (importantPerson.Count > 0)
            {
                addingForm = new AddingForm(importantPerson);
            }
            addingForm.ShowDialog();
            if (addingForm.DialogResult == DialogResult.OK || addingForm.DialogResult == DialogResult.Cancel || addingForm.DialogResult == DialogResult.Yes)
            {
                if (addingForm.DialogResult == DialogResult.OK)
                {
                    if (AddingToolStripMenuItem.BackColor != Color.Green)
                    {
                        toolStripProgressBar.Value += 5;
                    }
                    AddingToolStripMenuItem.BackColor = Color.Green;
                    importantPerson = addingForm.GetDictionary();
                }
                else if (addingForm.DialogResult == DialogResult.Yes)
                {
                    if (AddingToolStripMenuItem.BackColor != Color.NavajoWhite)
                    {
                        toolStripProgressBar.Value -= 5;
                    }
                    AddingToolStripMenuItem.BackColor = Color.NavajoWhite;
                    importantPerson = addingForm.GetDictionary();
                }
                checkProgressBar();
                this.Show();
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "" && flags.Contains($"{(sender as TextBox).Name}"))
            {
                toolStripProgressBar.Value -= 10;
                flags.Remove($"{(sender as TextBox).Name}");
            }
            else if ((sender as TextBox).Text.Length > 0 && !flags.Contains($"{(sender as TextBox).Name}"))
            {
                toolStripProgressBar.Value += 10;
                flags.Add($"{(sender as TextBox).Name}");
            }
            checkProgressBar();
        }

        private void checkProgressBar()
        {
            if (toolStripProgressBar.Value <= 30)
            {
                toolStripProgressBar.ForeColor = Color.Red;
            }
            else if (toolStripProgressBar.Value >= 30 && toolStripProgressBar.Value <= 60)
            {
                toolStripProgressBar.ForeColor = Color.Yellow;
            }
            else
            {
                toolStripProgressBar.ForeColor = Color.Green;
                if (toolStripProgressBar.Value >= 95)
                {
                    toolStripButtonPreview.Enabled = true;
                    toolStripButtonConvert.Enabled = true;
                }
            }
        }
    }
}

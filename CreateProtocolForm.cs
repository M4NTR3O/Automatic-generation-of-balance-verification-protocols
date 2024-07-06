using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Automatic_generation_of_balance_verification_protocols
{
    public partial class CreateProtocolForm : Form
    {
        private DataSet wagonsAndTransit = new DataSet();
        private List<Double> resultWagonsAndTransit = new List<Double>();
        private List<Double> maxDeltaWagonsAndTransit = new List<Double>();
        Dictionary<string, int> parametrsMetrology = new Dictionary<string, int>();
        Dictionary<string, string> importantPerson = new Dictionary<string, string>();
        Dictionary<string, string> infoAbout = new Dictionary<string, string>();

        public CreateProtocolForm()
        {
            InitializeComponent();
        }

        private void DataWagonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataWagonsForm dataWagonsForm = new DataWagonsForm();
            if (wagonsAndTransit != null && wagonsAndTransit.Tables.Count > 2)
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
                    textBoxCountWagons.Text = wagonsAndTransit.Tables[0].Rows.Count.ToString();
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
            if ((sender as TextBox).Text == "" && infoAbout.Keys.Contains($"{(sender as TextBox).Name}"))
            {
                toolStripProgressBar.Value -= 10;
                infoAbout.Remove($"{(sender as TextBox).Name}");
            }
            else if ((sender as TextBox).Text.Length > 0 && !infoAbout.Keys.Contains($"{(sender as TextBox).Name}"))
            {
                toolStripProgressBar.Value += 10;
                infoAbout.Add($"{(sender as TextBox).Name}", (sender as TextBox).Text);
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

        private void toolStripButtonConvert_Click(object sender, EventArgs e)
        {
            XDocument xDoc = new XDocument();
            XElement container = new XElement("container");
            XElement xwagonsAndTransit = new XElement("wagonsAndTransit");
            XAttribute xAttribute = new XAttribute("DataSource", wagonsAndTransit);
            xwagonsAndTransit.Add(xAttribute);
            XElement xresultWagonsAndTransit = new XElement("resultWagonsAndTransit", resultWagonsAndTransit);
            xAttribute = new XAttribute("dictionary", resultWagonsAndTransit);
            xresultWagonsAndTransit.Add(xAttribute);
            XElement xmaxDeltaWagonsAndTransit = new XElement("maxDeltaWagonsAndTransit", maxDeltaWagonsAndTransit);
            xAttribute = new XAttribute("dictionary", maxDeltaWagonsAndTransit);
            xmaxDeltaWagonsAndTransit.Add(xAttribute);
            XElement xparametrsMetrology = new XElement("parametrsMetrology", parametrsMetrology);
            xAttribute = new XAttribute("dictionary", parametrsMetrology);
            xparametrsMetrology.Add(xAttribute);
            XElement ximportantPerson = new XElement("importantPerson", importantPerson);
            xAttribute = new XAttribute("dictionary", importantPerson);
            ximportantPerson.Add(xAttribute);
            XElement xinfoAbout = new XElement("infoAbout", infoAbout);
            xAttribute = new XAttribute("dictionary", infoAbout);
            xinfoAbout.Add(xAttribute);
            container.Add(xwagonsAndTransit);
            container.Add(xresultWagonsAndTransit);
            container.Add(xmaxDeltaWagonsAndTransit);
            container.Add(xparametrsMetrology);
            container.Add(ximportantPerson);
            container.Add(xinfoAbout);
            xDoc.Add(container);
            xDoc.Save($"Protocol_{printTime(DateTime.Now)}.xml");
            MessageBox.Show("Файл успешно конвертирован в PDF", "Сохранение файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        string printTime(DateTime dateTime)
        {
            string result =  $"{dateTime.Day.ToString("D2")}-{dateTime.Month.ToString("D2")}-{dateTime.Year.ToString("D4")}_{dateTime.Hour.ToString("D2")}-{dateTime.Minute.ToString("D2")}-{dateTime.Second.ToString("D2")}";
            return result;
        }
    }
}

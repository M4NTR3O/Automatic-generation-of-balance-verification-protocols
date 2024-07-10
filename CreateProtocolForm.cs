using iText.StyledXmlParser.Jsoup.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Westwind.WebView.HtmlToPdf;
using System.Web.UI.HtmlControls;
using Westwind.Utilities;
using iText.Signatures;
using static iText.Kernel.Pdf.Colorspace.PdfSpecialCs;
using Aspose.Html;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Automatic_generation_of_balance_verification_protocols
{
    public partial class CreateProtocolForm : Form
    {
        private DateTime dateTime;
        private DataSet wagonsAndTransit = new DataSet();
        private Dictionary<string, double> resultWagonsAndTransit = new Dictionary<string, double>();
        private Dictionary<string, double> maxDeltaWagonsAndTransit = new Dictionary<string, double>();
        private Dictionary<string, int> parametrsMetrology = new Dictionary<string, int>();
        private Dictionary<string, string> importantPerson = new Dictionary<string, string>();
        private Dictionary<string, string> infoAbout = new Dictionary<string, string>();

        public CreateProtocolForm()
        {
            InitializeComponent();
        }

        public CreateProtocolForm(string filename)
        {
            InitializeComponent();
            XDocument xDoc = XDocument.Load(filename);
            dateTime = Convert.ToDateTime(xDoc.Root.Element("Date").Attribute("Date").Value);
            resultWagonsAndTransit.Clear();
            foreach(XElement el in xDoc.Root.Element("resultWagonsAndTransit").Elements())
            {
                resultWagonsAndTransit.Add(el.Name.LocalName, Convert.ToDouble(el.Value.Replace(".", ",")));
            }
            foreach (XElement el in xDoc.Root.Element("maxDeltaWagonsAndTransit").Elements())
            {
                maxDeltaWagonsAndTransit.Add(el.Name.LocalName, Convert.ToDouble(el.Value.Replace(".", ",")));
            }
            foreach (XElement el in xDoc.Root.Element("parametrsMetrology").Elements())
            {
                parametrsMetrology.Add(el.Name.LocalName, Convert.ToInt32(el.Value));
            }
            foreach (XElement el in xDoc.Root.Element("importantPerson").Elements())
            {
                importantPerson.Add(el.Name.LocalName, el.Value);
            }
            foreach (XElement el in xDoc.Root.Element("infoAbout").Elements())
            {
                infoAbout.Add(el.Name.LocalName, el.Value);
            }
            XDocument tempDoc = new XDocument();
            tempDoc.Add(xDoc.Root.Element("NewDataSet"));
            tempDoc.Save($"Протоколы/Протокол_{printFullTime(dateTime)}-temp.xml");
            wagonsAndTransit.ReadXml($"Протоколы/Протокол_{printFullTime(dateTime)}-temp.xml");
            File.Delete($"Протоколы/Протокол_{printFullTime(dateTime)}-temp.xml");
            toolStripProgressBar.Value = 95;
            FillForm();
            checkProgressBar();
        }

        private void FillForm()
        {
            DataWagonToolStripMenuItem.BackColor = Color.Green;
            MetrologyToolStripMenuItem.BackColor = Color.Green;
            if (importantPerson.Values.All(s => s.Length > 0))
            {
                toolStripProgressBar.Value += 5;
                AddingToolStripMenuItem.BackColor = Color.Green;
            }
            textBoxNameProtocol.Text = infoAbout[textBoxNameProtocol.Name];
            textBoxTypeMeasuringTool.Text = infoAbout[textBoxTypeMeasuringTool.Name];
            textBoxWagonGOST.Text = infoAbout[textBoxWagonGOST.Name];
            textBoxStructureGOST.Text = infoAbout[textBoxStructureGOST.Name];
            textBoxVerificationTools.Text = infoAbout[textBoxVerificationTools.Name];
            textBoxOwnerSI.Text = infoAbout[textBoxOwnerSI.Name];
            textBoxCountWagonsTranslit.Text = infoAbout[textBoxCountWagonsTranslit.Name];
            textBoxCountWagons.Text = wagonsAndTransit.Tables[0].Rows.Count.ToString();
            textBoxWeightWagons.Text = resultWagonsAndTransit["i0"].ToString();
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
                    textBoxWeightWagons.Text = resultWagonsAndTransit["i0"].ToString();
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
            if (dateTime.Year == 0001)
            {
                dateTime = DateTime.Now;
            }
            checkDirectory();
            XDocument xDoc = new XDocument();
            XElement container = new XElement("container");
            XElement xDate = new XElement("Date");
            XAttribute xAttribute = new XAttribute("Date", dateTime.ToString());
            xDate.Add(xAttribute);
            wagonsAndTransit.WriteXml($"Протоколы/Протокол_{printFullTime(dateTime)}.xml");
            xDoc = XDocument.Load($"Протоколы/Протокол_{printFullTime(dateTime)}.xml");
            XElement newDataSet = new XElement("NewDataSet");
            foreach(XElement el in xDoc.Root.Elements())
            {
                newDataSet.Add(el);
            }
            container.Add(newDataSet);
            xDoc.Root.Remove();
            XElement xresultWagonsAndTransit = new XElement("resultWagonsAndTransit", 
                from keyValue in resultWagonsAndTransit
                select new XElement(keyValue.Key, keyValue.Value));
            XElement xmaxDeltaWagonsAndTransit = new XElement("maxDeltaWagonsAndTransit", 
                from keyValue in maxDeltaWagonsAndTransit
                select new XElement(keyValue.Key, keyValue.Value));
            XElement xparametrsMetrology = new XElement("parametrsMetrology",
                from keyValue in parametrsMetrology
                select new XElement(keyValue.Key, keyValue.Value));
            XElement ximportantPerson = new XElement("importantPerson", 
                from keyValue in importantPerson 
                select new XElement(keyValue.Key, keyValue.Value));
            XElement xinfoAbout = new XElement("infoAbout", 
                from keyValue in infoAbout 
                select new XElement(keyValue.Key, keyValue.Value));
            container.Add(xDate);
            container.Add(xresultWagonsAndTransit);
            container.Add(xmaxDeltaWagonsAndTransit);
            container.Add(xparametrsMetrology);
            container.Add(ximportantPerson);
            container.Add(xinfoAbout);
            xDoc.Add(container);
            xDoc.Save($"Протоколы/Протокол_{printFullTime(dateTime)}.xml");
            MessageBox.Show("Файл успешно конвертирован в PDF", "Сохранение файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        string printFullTime(DateTime dateTime)
        {
            string result =  $"{dateTime.Day.ToString("D2")}-{dateTime.Month.ToString("D2")}-{dateTime.Year.ToString("D4")}_{dateTime.Hour.ToString("D2")}-{dateTime.Minute.ToString("D2")}-{dateTime.Second.ToString("D2")}";
            return result;
        }

        string printShortTime(DateTime dateTime)
        {
            string result = $"{dateTime.ToString("d")}";
            return result;
        }

        private void checkDirectory()
        {
            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Протоколы")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Протоколы"));
            }
        }

        private async void HTML2PDF()
        {
            var file = Path.GetFullPath("Pattern.html");
            string directory = Directory.GetCurrentDirectory();
            string filepath = directory + "/Протоколы/HTMLPage.pdf";
            File.Delete(filepath);
            var host = new HtmlToPdfHost();

            var result = await host.PrintToPdfStreamAsync(file);

            using (var fstream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                result.ResultStream.CopyTo(fstream);
                result.ResultStream.Close(); // Close returned stream!
            }

            ShellUtils.OpenUrl(filepath);
        }

        private void dataToHTML()
        {
            string documentPath = @"D:\Проекты\Automatic generation of balance verification protocols\bin\Debug\Pattern.html";

            // Создать экземпляр HTML-документа
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.Load(documentPath);
            //Название протокола поверки
            htmlDoc.DocumentNode.SelectSingleNode("//strong[contains(@id, 'nameProtocol')]").InnerHtml = labelNameProtocol.Text + textBoxNameProtocol.Text;
            //Дата протокола поверки
            htmlDoc.DocumentNode.SelectSingleNode("//strong[contains(@id, 'date')]").InnerHtml = printShortTime(dateTime);




            //Наименование и тип средств измерений
            htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'typeMeasuringTool')]").InnerHtml = "<strong>" + labelTypeMeasuringTool.Text + "</strong> " + textBoxTypeMeasuringTool.Text;
            //Метрологические параметры
            htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'metrologyParametrs')]").InnerHtml = "<strong>" + MetrologyToolStripMenuItem.Text +"</strong> ";
            foreach (var item in parametrsMetrology)
            {
                MetrologyParametrsForm metrology = new MetrologyParametrsForm();
                
                htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'metrologyParametrs')]").InnerHtml += metrology.Controls.Find(item.Key, true)[0].Text + " " + item.Value + ", ";
            }
            //Класс вагона
            htmlDoc.DocumentNode.SelectSingleNode("//strong[contains(@id, 'classWagon')]").InnerHtml = infoAbout[textBoxWagonGOST.Name];
            //Класс состава
            htmlDoc.DocumentNode.SelectSingleNode("//strong[contains(@id, 'classСomposition')]").InnerHtml = infoAbout[textBoxStructureGOST.Name];
            //Средства поверки Проверить!!!
            //htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'verificationTool')]").InnerHtml = $"<strong>{labelVerificationTools.Text}</strong> {textBoxVerificationTools.Text}. {labelCountWagons.Text} {infoAbout[textBoxCountWagons.Name]}({infoAbout[textBoxCountWagonsTranslit.Name]}) <strong>{textBoxWeightWagons.Text}</strong> {labelKg.Text}";
            //Наименование собственника
            htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'ownerSi')]").InnerHtml = $"<strong>{labelOwnerSi.Text}</strong> {textBoxOwnerSI.Text}";
            //Приложения
            htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'stateTrustee')]").InnerHtml = (importantPerson["labelStateTrustee"].Length > 0 ? importantPerson["labelStateTrustee"] : "____________________") + @" \_____________\";
            htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'representativeOfTensib')]").InnerHtml = (importantPerson["labelRepresentativeOfTensib"].Length > 0 ? importantPerson["labelRepresentativeOfTensib"] : "____________________") + @" \_____________\";
            htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'customerRepresentative')]").InnerHtml = (importantPerson["labelCustomerRepresentative"].Length > 0 ? importantPerson["labelCustomerRepresentative"] : "____________________") + @" \_____________\";
            //Сохранение шаблона
            htmlDoc.Save(documentPath);
        }

        private void toolStripButtonPreview_Click(object sender, EventArgs e)
        {
            dataToHTML();
            //HTML2PDF();
        }
    }
}

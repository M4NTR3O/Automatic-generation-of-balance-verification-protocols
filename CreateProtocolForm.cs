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
using Aspose.Html;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Automatic_generation_of_balance_verification_protocols
{
    public partial class CreateProtocolForm : Form
    {
        private Dictionary<int, string> numbers2Translit = new Dictionary<int, string> { { 1, "одного" }, { 2, "двух" }, { 3, "трех" }, { 4, "четырех" }, { 5, "пяти" },
            {6, "шести" }, {7, "семи" }, { 8, "восьми" }, { 9, "девяти"}, { 10, "десяти"},
            { 11, "одинадцати" }, { 12, "двенадцати" }, { 13, "тринадцати" }, { 14, "четырнадцати" }, { 15, "пятнадцати" },
            {16, "шестнадцати" },{17, "семнадцати" }, { 18, "восемнадцати" }, { 19, "девятнадцати"}, { 20, "двадцати"}};
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
            importantPerson.Add("labelStateTrustee", "");
            importantPerson.Add("labelRepresentativeOfTensib", "");
            importantPerson.Add("labelCustomerRepresentative", "");
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
            if (wagonsAndTransit != null && wagonsAndTransit.Tables.Count > 0)
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
                        toolStripProgressBar.Value += 25;
                    }
                    DataWagonToolStripMenuItem.BackColor = Color.Green;
                    wagonsAndTransit = dataWagonsForm.callData();
                    (resultWagonsAndTransit, maxDeltaWagonsAndTransit) = dataWagonsForm.calculateResult();
                    textBoxCountWagons.Text = wagonsAndTransit.Tables[0].Rows.Count.ToString();
                    textBoxCountWagonsTranslit.Text = numbers2Translit[Convert.ToInt32(textBoxCountWagons.Text)];
                    if (infoAbout.ContainsKey(textBoxCountWagonsTranslit.Name))
                    {
                        infoAbout[textBoxCountWagonsTranslit.Name] = textBoxCountWagonsTranslit.Text;
                    }
                    else
                    {
                        infoAbout.Add($"{textBoxCountWagonsTranslit.Name}", textBoxCountWagonsTranslit.Text);
                    }
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
                toolStripProgressBar.BackColor = Color.Red;
            }
            else if (toolStripProgressBar.Value >= 30 && toolStripProgressBar.Value <= 60)
            {
                toolStripProgressBar.BackColor = Color.Yellow;
            }
            else
            {
                toolStripProgressBar.ForeColor = Color.Green;
                if (toolStripProgressBar.Value >= 95)
                {
                    toolStripButtonPreview.Enabled = true;
                }
                else
                {
                    toolStripButtonPreview.Enabled = false;
                }
            }
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

        private void HTML2PDF()
        {
            var file = Path.GetFullPath($"Протоколы/Протокол_{printFullTime(dateTime)}.html");
            string directory = Directory.GetCurrentDirectory();
            string filepath = directory + $"/Протоколы/Протокол_{printFullTime(dateTime)}.pdf";
            File.Delete(filepath);
            var host = new HtmlToPdfHost();

            var result = host.PrintToPdfStreamAsync(file).GetAwaiter().GetResult();

            using (var fstream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                result.ResultStream.CopyTo(fstream);
                result.ResultStream.Close(); // Close returned stream!
            }

            File.Delete(file);

        }

        private void dataToHTML()
        {
            string documentPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pattern\\Pattern.html");

            // Создать экземпляр HTML-документа
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.Load(documentPath);
            //Название протокола поверки
            htmlDoc.DocumentNode.SelectSingleNode("//strong[contains(@id, 'nameProtocol')]").InnerHtml = labelNameProtocol.Text + " " + textBoxNameProtocol.Text;
            //Дата протокола поверки
            htmlDoc.DocumentNode.SelectSingleNode("//strong[contains(@id, 'date')]").InnerHtml = printShortTime(dateTime);
            //Наименование и тип средств измерений
            htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'typeMeasuringTool')]").InnerHtml = "<strong>" + labelTypeMeasuringTool.Text + "</strong> " + textBoxTypeMeasuringTool.Text;
            //Метрологические параметры
            htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'metrologyParametrs')]").InnerHtml = "<strong>" + MetrologyToolStripMenuItem.Text +":</strong> ";
            foreach (var item in parametrsMetrology)
            {
                MetrologyParametrsForm metrology = new MetrologyParametrsForm();
                
                htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'metrologyParametrs')]").InnerHtml += metrology.Controls.Find(item.Key, true)[0].Text + " " + item.Value + ", ";
            }
            //Класс вагона
            htmlDoc.DocumentNode.SelectSingleNode("//strong[contains(@id, 'classWagon')]").InnerHtml = infoAbout[textBoxWagonGOST.Name];
            //Класс состава
            htmlDoc.DocumentNode.SelectSingleNode("//strong[contains(@id, 'classСomposition')]").InnerHtml = infoAbout[textBoxStructureGOST.Name];
            //Средства поверки
            htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'verificationTool')]").InnerHtml = $"<strong>{labelVerificationTools.Text}</strong> {textBoxVerificationTools.Text}. {labelCountWagons.Text} <strong>{wagonsAndTransit.Tables[0].Rows.Count}</strong> ({infoAbout[textBoxCountWagonsTranslit.Name]}) {labelWeightSummary.Text} <strong>{resultWagonsAndTransit["i0"]}</strong> {labelKg.Text}";
            //Наименование собственника
            htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'ownerSi')]").InnerHtml = $"<strong>{labelOwnerSi.Text}</strong> {textBoxOwnerSI.Text}";
            //Приложения
            htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'stateTrustee')]").InnerHtml = (importantPerson["labelStateTrustee"].Length > 0 ? importantPerson["labelStateTrustee"] : "____________________") + @" \_____________\";
            htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'representativeOfTensib')]").InnerHtml = (importantPerson["labelRepresentativeOfTensib"].Length > 0 ? importantPerson["labelRepresentativeOfTensib"] : "____________________") + @" \_____________\";
            htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'customerRepresentative')]").InnerHtml = (importantPerson["labelCustomerRepresentative"].Length > 0 ? importantPerson["labelCustomerRepresentative"] : "____________________") + @" \_____________\";
            //Заполнение таблиц
            if (wagonsAndTransit.Tables.Count > 6)
            {
                for (int i = 0; i < ((wagonsAndTransit.Tables.Count - 1) / 6) + 1; i++)
                {
                    if (i != 0)
                    {
                        var pageFirstHtml = htmlDoc.DocumentNode.SelectSingleNode($"//div[contains(@id, 'page0')]").InnerHtml;
                        var body = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'container-page')]");
                        var newPage = HtmlNode.CreateNode($"<div class=\"page\" id=\"page{i}\">" + pageFirstHtml + "</div>");
                        body.AppendChild(newPage);
                    }
                }
                for (int i = 0; i < ((wagonsAndTransit.Tables.Count - 1) / 6) + 1; i++)
                {
                    var currentPage = htmlDoc.DocumentNode.SelectSingleNode($"//div[contains(@id, 'page{i}')]");
                    //функция для печати многостранички
                    var tables = currentPage.SelectSingleNode($"//div[contains(@id, 'tables')]");
                    var allTables = tables.SelectNodes("//table");
                    allTables[0].Attributes["id"].Value = $"P{i}tableCells1";
                    allTables[1].Attributes["id"].Value = $"P{i}tableCells2";
                    for (int j = i * 6; j < (i + 1) * 6; j++)
                    {
                        if (wagonsAndTransit.Tables.Count - (i * 6) < 3 && j % 6 > 2)
                        {

                        }
                        else
                        {
                            FillTable1Page(allTables[(j % 6) / 3], j, htmlDoc);
                        }
                    }
                }
            }
            else
            {
                var page = htmlDoc.DocumentNode.SelectSingleNode($"//div[contains(@id, 'page0')]");
                var tables = page.SelectSingleNode($"//div[contains(@id, 'tables')]");
                var allTables = tables.SelectNodes("//div/div/div//div/div/table");

                for (int i = 0; i < 6; i++)
                {
                    if (wagonsAndTransit.Tables.Count < 3 && i > 2)
                    {

                    }
                    else
                    {
                        FillTable1Page(allTables[i / 3], i, htmlDoc);
                    }
                    
                }
                    
            }

            //Сохранение шаблона
            htmlDoc.Save($"Протоколы/Протокол_{printFullTime(dateTime)}.html");
        }

        private void toolStripButtonPreview_Click(object sender, EventArgs e)
        {
            dataToHTML();
            HTML2PDF();
            if (dateTime.Year == 0001)
            {
                dateTime = DateTime.Now;
            }
            PreviewPdfForm previewPdfForm = new PreviewPdfForm(printFullTime(dateTime));
            this.Hide();
            previewPdfForm.ShowDialog();
            if (previewPdfForm.DialogResult == DialogResult.OK)
            { 
                checkDirectory();
                XDocument xDoc = new XDocument();
                XElement container = new XElement("container");
                XElement xDate = new XElement("Date");
                XAttribute xAttribute = new XAttribute("Date", dateTime.ToString());
                xDate.Add(xAttribute);
                wagonsAndTransit.WriteXml($"Протоколы/Протокол_{printFullTime(dateTime)}.xml");
                xDoc = XDocument.Load($"Протоколы/Протокол_{printFullTime(dateTime)}.xml");
                XElement newDataSet = new XElement("NewDataSet");
                foreach (XElement el in xDoc.Root.Elements())
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
                this.Show();
                MessageBox.Show("Файл успешно конвертирован в PDF", "Сохранение файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                ShellUtils.OpenUrl($@"./Протоколы/Протокол_{printFullTime(dateTime)}.pdf");
            }
            else
            {
                File.Delete($"Протоколы/Протокол_{printFullTime(dateTime)}.pdf");
                this.Show();
            }
        }

        private void RenameId(HtmlNode table, int i, HtmlAgilityPack.HtmlDocument htmlDoc)
        {
            int workI = i % 6;
            HtmlNode score, delta, headerRow;
            table.SelectSingleNode($"//thead/th[contains(@id, 'P0T{workI / 3 + 1}transit{(workI % 3) + 1}')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}transit{(workI % 3) + 1}";
            if (i % 3 == 0)
            {
                table.SelectSingleNode($"//tr[contains(@id, 'P0T{workI / 3 + 1}rowWagon{1}')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}rowWagon{1}";
                table.SelectSingleNode($"//tr[contains(@id, 'P0ScoreEx{workI / 3 + 1}')]").Attributes["id"].Value = $"P{i / 6}ScoreEx{workI / 3 + 1}";
                table.SelectSingleNode($"//tr[contains(@id, 'P0MaxDeltaOnStructureEx{workI / 3 + 1}')]").Attributes["id"].Value = $"P{i / 6}MaxDeltaOnStructureEx{workI / 3 + 1}";
                table.SelectSingleNode($"//thead[contains(@id, 'P0T{workI / 3 + 1}headerTable')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}headerTable";
                table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWagon{1}')]").SelectSingleNode($"//th[contains(@id, 'P0T{workI / 3 + 1}numberWagon')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}numberWagon";
                table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWagon{1}')]").SelectSingleNode($"//th[contains(@id, 'P0T{workI / 3 + 1}WeightStatic')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}WeightStatic";
                table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWagon{1}')]").SelectSingleNode($"//th[contains(@id, 'P0T{workI / 3 + 1}rowWeightTransit{(workI % 3) + 1}')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}rowWeightTransit{(workI % 3) + 1}";
                table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWagon{1}')]").SelectSingleNode($"//th[contains(@id, 'P0T{workI / 3 + 1}rowDeltaAbsTransit{(workI % 3) + 1}')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}rowDeltaAbsTransit{(workI % 3) + 1}";
                table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWagon{1}')]").SelectSingleNode($"//th[contains(@id, 'P0T{workI / 3 + 1}rowDeltaRelativeTransit{(workI % 3) + 1}')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}rowDeltaRelativeTransit{(workI % 3) + 1}";
            }
            else
            {
                for (int wagon = 0; wagon < wagonsAndTransit.Tables[0].Rows.Count; wagon++)
                {
                    if (i % 3 == 1)
                    {
                        table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWagon{wagon + 1}')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}rowWagon{wagon + 1}";
                    }
                    table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWagon{wagon + 1}')]").SelectSingleNode($"//th[contains(@id, 'P0T{workI / 3 + 1}rowWeightTransit{(workI % 3) + 1}')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}rowWeightTransit{(workI % 3) + 1}";
                    table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWagon{wagon + 1}')]").SelectSingleNode($"//th[contains(@id, 'P0T{workI / 3 + 1}rowDeltaAbsTransit{(workI % 3) + 1}')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}rowDeltaAbsTransit{(workI % 3) + 1}";
                    table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWagon{wagon + 1}')]").SelectSingleNode($"//th[contains(@id, 'P0T{workI / 3 + 1}rowDeltaRelativeTransit{(workI % 3) + 1}')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}rowDeltaRelativeTransit{(workI % 3) + 1}";
                }
            }
            headerRow = table.SelectSingleNode($"//thead[contains(@id, 'P{i / 6}T{workI / 3 + 1}headerTable')]");
            headerRow.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}transit{workI % 3 + 1}')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}transit{workI % 3 + 1}";
            headerRow.SelectSingleNode($"//th[contains(@id, 'P0T{workI / 3 + 1}DeltaAbsTransit{workI % 3 + 1}')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}DeltaAbsTransit{workI % 3 + 1}";
            headerRow.SelectSingleNode($"//th[contains(@id, 'P0T{workI / 3 + 1}DeltaRelativeTransit{workI % 3 + 1}')]").Attributes["id"].Value = $"P{i / 6}T{workI / 3 + 1}DeltaRelativeTransit{workI % 3 + 1}";

            if (i % 3 > 0)
            {
                score = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}Score{workI / 3 + 1}')]");
                delta = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}MaxDeltaOnStructure{workI / 3 + 1}')]");
            }
            else
            {
                score = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}ScoreEx{workI / 3 + 1}')]");
                delta = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}MaxDeltaOnStructureEx{workI / 3 + 1}')]");
            }
            score.SelectSingleNode($"//th[contains(@id, 'P0ScoreWeightTransit{workI % 3 + 1}')]").Attributes["id"].Value = $"P{i / 6}ScoreWeightTransit{workI % 3 + 1}";
            score.SelectSingleNode($"//th[contains(@id, 'P0ScoreDeltaAbsTransit{workI % 3 + 1}')]").Attributes["id"].Value = $"P{i / 6}ScoreDeltaAbsTransit{workI % 3 + 1}";
            score.SelectSingleNode($"//th[contains(@id, 'P0ScoreDeltaRelativeTransit{workI % 3 + 1}')]").Attributes["id"].Value = $"P{i / 6}ScoreDeltaRelativeTransit{workI % 3 + 1}";
            delta.SelectSingleNode($"//th[contains(@id, 'P0MaxDeltaAbsTransit{workI % 3 + 1}')]").Attributes["id"].Value = $"P{i / 6}MaxDeltaAbsTransit{workI % 3 + 1}";
            delta.SelectSingleNode($"//th[contains(@id, 'P0MaxDeltaRelativeTransit{workI % 3 + 1}')]").Attributes["id"].Value = $"P{i / 6}MaxDeltaRelativeTransit{workI % 3 + 1}";
        }
        private void FillTable1Page(HtmlNode table, int i, HtmlAgilityPack.HtmlDocument htmlDoc)
        {
            int workI = i % 6;
            if (i < wagonsAndTransit.Tables.Count)
            {
                if (i >= 6)
                {
                    RenameId(table, i, htmlDoc);
                }
                table.SelectSingleNode($"//thead/th[contains(@id, 'P{i / 6}T{workI / 3 + 1}transit{(workI % 3) + 1}')]").InnerHtml = $"Проезд №{i + 1}";

                for (int j = 0; j < wagonsAndTransit.Tables[0].Rows.Count; j++)
                {
                    HtmlNode row;
                    if (j != 0 && (i % 3) == 0)
                    {
                        var newRowHtml = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWagon1')]").InnerHtml;
                        var newRow = HtmlNode.CreateNode($"<tr class=\"table_cells10\" id=\"P{i / 6}T{workI / 3 + 1}rowWagon{j + 1}\">" + newRowHtml + "</tr>");
                        table.AppendChild(newRow);
                    }
                    row = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWagon{j + 1}')]");
                    if (i % 3 == 0)
                    {
                        row.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}numberWagon')]").InnerHtml = wagonsAndTransit.Tables[i].Rows[j].ItemArray[0].ToString();
                        row.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}WeightStatic')]").InnerHtml = wagonsAndTransit.Tables[i].Rows[j].ItemArray[1].ToString();
                    }
                    row.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWeightTransit{(workI % 3) + 1}')]").InnerHtml = wagonsAndTransit.Tables[i].Rows[j].ItemArray[2].ToString();
                    row.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowDeltaAbsTransit{(workI % 3) + 1}')]").InnerHtml = wagonsAndTransit.Tables[i].Rows[j].ItemArray[3].ToString();
                    row.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowDeltaRelativeTransit{(workI % 3) + 1}')]").InnerHtml = wagonsAndTransit.Tables[i].Rows[j].ItemArray[4].ToString();
                }
                if (i % 3 == 0)
                {
                    HtmlNode emptyRow = HtmlNode.CreateNode("<tr><th></th></tr>");
                    table.AppendChild(emptyRow);
                }
                HtmlNode score;
                HtmlNode delta;
                if (i % 3 == 0)
                {
                    var scoreHtml = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}ScoreEx{workI / 3 + 1}')]").InnerHtml;
                    table.RemoveChild(table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}ScoreEx{workI / 3 + 1}')]"));
                    score = HtmlNode.CreateNode($"<tr class=\"table_cells10\" id=\"P{i / 6}Score{(workI / 3) + 1}\">" + scoreHtml + "</tr>");
                    var deltaHtml = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}MaxDeltaOnStructureEx{workI / 3 + 1}')]").InnerHtml;
                    delta = HtmlNode.CreateNode($"<tr class=\"table_cells10\" id=\"P{i / 6}MaxDeltaOnStructure{(workI / 3) + 1}\">" + deltaHtml + "</tr>");
                    table.RemoveChild(table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}MaxDeltaOnStructureEx{workI / 3 + 1}')]"));
                    table.AppendChild(score);
                    table.AppendChild(delta);
                }
                else
                {
                    score = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}Score{workI / 3 + 1}')]");
                    delta = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}MaxDeltaOnStructure{workI / 3 + 1}')]");
                }
                if (i % 3 == 0)
                {
                    score.SelectSingleNode("//th[contains(@id, 'ScoreWeightStatic')]").InnerHtml = resultWagonsAndTransit["i0"].ToString();
                }
                score.SelectSingleNode($"//th[contains(@id, 'P{i / 6}ScoreWeightTransit{workI % 3 + 1}')]").InnerHtml = resultWagonsAndTransit[$"i{i * 3 + 1}"].ToString();
                score.SelectSingleNode($"//th[contains(@id, 'P{i / 6}ScoreDeltaAbsTransit{workI % 3 + 1}')]").InnerHtml = resultWagonsAndTransit[$"i{i * 3 + 2}"].ToString();
                score.SelectSingleNode($"//th[contains(@id, 'P{i / 6}ScoreDeltaRelativeTransit{workI % 3 + 1}')]").InnerHtml = resultWagonsAndTransit[$"i{i * 3 + 3}"].ToString();
                delta.SelectSingleNode($"//th[contains(@id, 'P{i / 6}MaxDeltaAbsTransit{workI % 3 + 1}')]").InnerHtml = maxDeltaWagonsAndTransit[$"i{i * 2}"].ToString();
                delta.SelectSingleNode($"//th[contains(@id, 'P{i / 6}MaxDeltaRelativeTransit{workI % 3 + 1}')]").InnerHtml = maxDeltaWagonsAndTransit[$"i{i * 2 + 1}"].ToString();
            }
            else
            {
                if (wagonsAndTransit.Tables.Count % 6 < 3)
                {
                    if (i >= 6)
                    {
                        RenameId(table, i, htmlDoc);
                    }
                    HtmlNode headerRow = table.SelectSingleNode($"//thead[contains(@id, 'P{i / 6}T{workI / 3 + 1}headerTable')]");
                    headerRow.RemoveChild(headerRow.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}transit{(workI % 3) + 1}')]"));
                    headerRow.RemoveChild(headerRow.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}DeltaAbsTransit{(workI % 3) + 1}')]"));
                    headerRow.RemoveChild(headerRow.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}DeltaRelativeTransit{(workI % 3) + 1}')]"));
                    for (int row = 0; row < wagonsAndTransit.Tables[0].Rows.Count; row++)
                    {
                        var currentRow = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWagon{row + 1}')]");
                        currentRow.RemoveChild(currentRow.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWeightTransit{(workI % 3) + 1}')]"));
                        currentRow.RemoveChild(currentRow.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowDeltaAbsTransit{(workI % 3) + 1}')]"));
                        currentRow.RemoveChild(currentRow.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowDeltaRelativeTransit{(workI % 3) + 1}')]"));
                    }
                    var score = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}Score{workI / 3 + 1}')]");
                    var delta = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}MaxDeltaOnStructure{workI / 3 + 1}')]");
                    score.RemoveChild(score.SelectSingleNode($"//th[contains(@id, 'P{i / 6}ScoreWeightTransit{(workI % 3) + 1}')]"));
                    score.RemoveChild(score.SelectSingleNode($"//th[contains(@id, 'P{i / 6}ScoreDeltaAbsTransit{(workI % 3) + 1}')]"));
                    score.RemoveChild(score.SelectSingleNode($"//th[contains(@id, 'P{i / 6}ScoreDeltaRelativeTransit{(workI % 3) + 1}')]"));
                    delta.RemoveChild(delta.SelectSingleNode($"//th[contains(@id, 'P{i / 6}MaxDeltaAbsTransit{(workI % 3) + 1}')]"));
                    delta.RemoveChild(delta.SelectSingleNode($"//th[contains(@id, 'P{i / 6}MaxDeltaRelativeTransit{(workI % 3) + 1}')]"));
                    if (workI + 1 == 3)
                    {
                        var tables = htmlDoc.DocumentNode.SelectNodes($"//div[contains(@id, 'tables')]")[i / 6];
                        tables.SelectSingleNode($"//div/div/table[contains(@id, 'P{i / 6}tableCells2')]").InnerHtml = "";
                        htmlDoc.Save($"Протоколы/Протокол_{printFullTime(dateTime)}.html");
                        return;
                    }
                }
                else
                {
                    if (wagonsAndTransit.Tables.Count % 6 == 3)
                    {
                        var tables = htmlDoc.DocumentNode.SelectSingleNode($"//div[contains(@id, 'tables')]");
                        tables.SelectSingleNode($"//div/div/table[contains(@id, 'P{i / 6}tableCells2')]").InnerHtml = "";
                        htmlDoc.Save($"Протоколы/Протокол_{printFullTime(dateTime)}.html");
                        return;
                    }
                    if (i >= 6)
                    {
                        RenameId(table, i, htmlDoc);
                    }
                    HtmlNode headerRow = table.SelectSingleNode($"//div/div/table/thead[contains(@id, 'P{i / 6}T{workI / 3 + 1}headerTable')]");
                    headerRow.RemoveChild(headerRow.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}transit{workI % 3 + 1}')]"));
                    headerRow.RemoveChild(headerRow.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}DeltaAbsTransit{workI % 3 + 1}')]"));
                    headerRow.RemoveChild(headerRow.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}DeltaRelativeTransit{workI % 3 + 1}')]"));
                    for (int row = 0; row < wagonsAndTransit.Tables[0].Rows.Count; row++)
                    {
                        var currentRow = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWagon{row + 1}')]");
                        currentRow.RemoveChild(currentRow.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowWeightTransit{(workI % 3) + 1}')]"));
                        currentRow.RemoveChild(currentRow.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowDeltaAbsTransit{(workI % 3) + 1}')]"));
                        currentRow.RemoveChild(currentRow.SelectSingleNode($"//th[contains(@id, 'P{i / 6}T{workI / 3 + 1}rowDeltaRelativeTransit{(workI % 3) + 1}')]"));
                    }
                    var score = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}Score{workI / 3 + 1}')]");
                    var delta = table.SelectSingleNode($"//tr[contains(@id, 'P{i / 6}MaxDeltaOnStructure{workI / 3 + 1}')]");
                    score.RemoveChild(score.SelectSingleNode($"//th[contains(@id, 'P{i / 6}ScoreWeightTransit{(workI % 3) + 1}')]"));
                    score.RemoveChild(score.SelectSingleNode($"//th[contains(@id, 'P{i / 6}ScoreDeltaAbsTransit{(workI % 3) + 1}')]"));
                    score.RemoveChild(score.SelectSingleNode($"//th[contains(@id, 'P{i / 6}ScoreDeltaRelativeTransit{(workI % 3) + 1}')]"));
                    delta.RemoveChild(delta.SelectSingleNode($"//th[contains(@id, 'P{i / 6}MaxDeltaAbsTransit{(workI % 3) + 1}')]"));
                    delta.RemoveChild(delta.SelectSingleNode($"//th[contains(@id, 'P{i / 6}MaxDeltaRelativeTransit{(workI % 3) + 1}')]"));
                }
            }
        }
    }
}

using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;


namespace Automatic_generation_of_balance_verification_protocols
{
    public partial class PreviewPdfForm : Form
    {
        public PreviewPdfForm(string dateTime)
        {
            InitializeComponent();
            var file = Path.GetFullPath($@"./Протоколы/Протокол_{dateTime}.pdf");
            chromiumWebBrowser1.Load(file);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

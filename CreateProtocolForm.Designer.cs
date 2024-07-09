namespace Automatic_generation_of_balance_verification_protocols
{
    partial class CreateProtocolForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateProtocolForm));
            this.menuStripRequired = new System.Windows.Forms.MenuStrip();
            this.DataWagonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MetrologyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonConvert = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.labelNameProtocol = new System.Windows.Forms.Label();
            this.textBoxNameProtocol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTypeMeasuringTool = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxWagonGOST = new System.Windows.Forms.TextBox();
            this.textBoxStructureGOST = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxVerificationTools = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxOwnerSI = new System.Windows.Forms.TextBox();
            this.textBoxWeightWagons = new System.Windows.Forms.TextBox();
            this.textBoxCountWagons = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCountWagonsTranslit = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStripRequired.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripRequired
            // 
            this.menuStripRequired.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripRequired.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataWagonToolStripMenuItem,
            this.MetrologyToolStripMenuItem,
            this.AddingToolStripMenuItem});
            this.menuStripRequired.Location = new System.Drawing.Point(0, 0);
            this.menuStripRequired.Name = "menuStripRequired";
            this.menuStripRequired.Size = new System.Drawing.Size(1009, 28);
            this.menuStripRequired.TabIndex = 0;
            this.menuStripRequired.Text = "menuStrip";
            // 
            // DataWagonToolStripMenuItem
            // 
            this.DataWagonToolStripMenuItem.BackColor = System.Drawing.Color.Coral;
            this.DataWagonToolStripMenuItem.Name = "DataWagonToolStripMenuItem";
            this.DataWagonToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.DataWagonToolStripMenuItem.Text = "Данные о вагонах и проездах";
            this.DataWagonToolStripMenuItem.Click += new System.EventHandler(this.DataWagonToolStripMenuItem_Click);
            // 
            // MetrologyToolStripMenuItem
            // 
            this.MetrologyToolStripMenuItem.BackColor = System.Drawing.Color.Coral;
            this.MetrologyToolStripMenuItem.Name = "MetrologyToolStripMenuItem";
            this.MetrologyToolStripMenuItem.Size = new System.Drawing.Size(304, 24);
            this.MetrologyToolStripMenuItem.Text = "Основные метрологические параметры";
            this.MetrologyToolStripMenuItem.Click += new System.EventHandler(this.MetrologyToolStripMenuItem_Click);
            // 
            // AddingToolStripMenuItem
            // 
            this.AddingToolStripMenuItem.BackColor = System.Drawing.Color.NavajoWhite;
            this.AddingToolStripMenuItem.Name = "AddingToolStripMenuItem";
            this.AddingToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.AddingToolStripMenuItem.Text = "Приложения";
            this.AddingToolStripMenuItem.Click += new System.EventHandler(this.AddingToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonConvert,
            this.toolStripSeparator1,
            this.toolStripButtonPreview,
            this.toolStripSeparator2,
            this.toolStripProgressBar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 533);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(1009, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStripConvertation";
            // 
            // toolStripButtonConvert
            // 
            this.toolStripButtonConvert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonConvert.Enabled = false;
            this.toolStripButtonConvert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConvert.Name = "toolStripButtonConvert";
            this.toolStripButtonConvert.Size = new System.Drawing.Size(188, 28);
            this.toolStripButtonConvert.Text = "Сформировать протокол";
            this.toolStripButtonConvert.Click += new System.EventHandler(this.toolStripButtonConvert_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonPreview
            // 
            this.toolStripButtonPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonPreview.Enabled = false;
            this.toolStripButtonPreview.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPreview.Image")));
            this.toolStripButtonPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPreview.Name = "toolStripButtonPreview";
            this.toolStripButtonPreview.Size = new System.Drawing.Size(196, 28);
            this.toolStripButtonPreview.Text = "Предпросмотр протокола";
            this.toolStripButtonPreview.Click += new System.EventHandler(this.toolStripButtonPreview_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 28);
            // 
            // labelNameProtocol
            // 
            this.labelNameProtocol.AutoSize = true;
            this.labelNameProtocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameProtocol.Location = new System.Drawing.Point(155, 53);
            this.labelNameProtocol.Name = "labelNameProtocol";
            this.labelNameProtocol.Size = new System.Drawing.Size(181, 20);
            this.labelNameProtocol.TabIndex = 2;
            this.labelNameProtocol.Text = "Протокол поверки";
            // 
            // textBoxNameProtocol
            // 
            this.textBoxNameProtocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNameProtocol.Location = new System.Drawing.Point(383, 50);
            this.textBoxNameProtocol.Multiline = true;
            this.textBoxNameProtocol.Name = "textBoxNameProtocol";
            this.textBoxNameProtocol.Size = new System.Drawing.Size(614, 77);
            this.textBoxNameProtocol.TabIndex = 3;
            this.textBoxNameProtocol.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Наименование и тип средства измерений:";
            // 
            // textBoxTypeMeasuringTool
            // 
            this.textBoxTypeMeasuringTool.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTypeMeasuringTool.Location = new System.Drawing.Point(383, 144);
            this.textBoxTypeMeasuringTool.Multiline = true;
            this.textBoxTypeMeasuringTool.Name = "textBoxTypeMeasuringTool";
            this.textBoxTypeMeasuringTool.Size = new System.Drawing.Size(614, 67);
            this.textBoxTypeMeasuringTool.TabIndex = 5;
            this.textBoxTypeMeasuringTool.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(63, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Класс точности по ГОСТ 8.647-2015: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(491, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = ", состав ";
            // 
            // textBoxWagonGOST
            // 
            this.textBoxWagonGOST.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxWagonGOST.Location = new System.Drawing.Point(445, 225);
            this.textBoxWagonGOST.Name = "textBoxWagonGOST";
            this.textBoxWagonGOST.Size = new System.Drawing.Size(40, 22);
            this.textBoxWagonGOST.TabIndex = 8;
            this.textBoxWagonGOST.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBoxStructureGOST
            // 
            this.textBoxStructureGOST.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxStructureGOST.Location = new System.Drawing.Point(558, 225);
            this.textBoxStructureGOST.Name = "textBoxStructureGOST";
            this.textBoxStructureGOST.Size = new System.Drawing.Size(40, 22);
            this.textBoxStructureGOST.TabIndex = 9;
            this.textBoxStructureGOST.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(391, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "вагон ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(188, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Средства поверки:";
            // 
            // textBoxVerificationTools
            // 
            this.textBoxVerificationTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxVerificationTools.Location = new System.Drawing.Point(383, 275);
            this.textBoxVerificationTools.Multiline = true;
            this.textBoxVerificationTools.Name = "textBoxVerificationTools";
            this.textBoxVerificationTools.Size = new System.Drawing.Size(614, 63);
            this.textBoxVerificationTools.TabIndex = 12;
            this.textBoxVerificationTools.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(81, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(255, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Наименование собственника СИ:";
            // 
            // textBoxOwnerSI
            // 
            this.textBoxOwnerSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxOwnerSI.Location = new System.Drawing.Point(383, 427);
            this.textBoxOwnerSI.Multiline = true;
            this.textBoxOwnerSI.Name = "textBoxOwnerSI";
            this.textBoxOwnerSI.Size = new System.Drawing.Size(614, 63);
            this.textBoxOwnerSI.TabIndex = 14;
            this.textBoxOwnerSI.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBoxWeightWagons
            // 
            this.textBoxWeightWagons.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxWeightWagons.Location = new System.Drawing.Point(561, 365);
            this.textBoxWeightWagons.Name = "textBoxWeightWagons";
            this.textBoxWeightWagons.ReadOnly = true;
            this.textBoxWeightWagons.Size = new System.Drawing.Size(102, 22);
            this.textBoxWeightWagons.TabIndex = 18;
            this.textBoxWeightWagons.TabStop = false;
            // 
            // textBoxCountWagons
            // 
            this.textBoxCountWagons.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCountWagons.Location = new System.Drawing.Point(153, 365);
            this.textBoxCountWagons.Name = "textBoxCountWagons";
            this.textBoxCountWagons.ReadOnly = true;
            this.textBoxCountWagons.Size = new System.Drawing.Size(45, 22);
            this.textBoxCountWagons.TabIndex = 17;
            this.textBoxCountWagons.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(397, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "вагонов общей массой";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(74, 368);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Состав из";
            // 
            // textBoxCountWagonsTranslit
            // 
            this.textBoxCountWagonsTranslit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCountWagonsTranslit.Location = new System.Drawing.Point(223, 365);
            this.textBoxCountWagonsTranslit.Name = "textBoxCountWagonsTranslit";
            this.textBoxCountWagonsTranslit.Size = new System.Drawing.Size(151, 22);
            this.textBoxCountWagonsTranslit.TabIndex = 13;
            this.textBoxCountWagonsTranslit.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(206, 368);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "(";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(380, 368);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = ")";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(669, 368);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "килограмм.";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(30, 88);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(528, 421);
            this.webBrowser1.TabIndex = 23;
            this.webBrowser1.Visible = false;
            // 
            // CreateProtocolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 564);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxCountWagonsTranslit);
            this.Controls.Add(this.textBoxWeightWagons);
            this.Controls.Add(this.textBoxCountWagons);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxOwnerSI);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxVerificationTools);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxStructureGOST);
            this.Controls.Add(this.textBoxWagonGOST);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTypeMeasuringTool);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNameProtocol);
            this.Controls.Add(this.labelNameProtocol);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStripRequired);
            this.MainMenuStrip = this.menuStripRequired;
            this.Name = "CreateProtocolForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание протокола поверки весов";
            this.menuStripRequired.ResumeLayout(false);
            this.menuStripRequired.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripRequired;
        private System.Windows.Forms.ToolStripMenuItem DataWagonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MetrologyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddingToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonConvert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.Label labelNameProtocol;
        private System.Windows.Forms.TextBox textBoxNameProtocol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTypeMeasuringTool;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxWagonGOST;
        private System.Windows.Forms.TextBox textBoxStructureGOST;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxVerificationTools;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxOwnerSI;
        private System.Windows.Forms.TextBox textBoxWeightWagons;
        private System.Windows.Forms.TextBox textBoxCountWagons;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxCountWagonsTranslit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}
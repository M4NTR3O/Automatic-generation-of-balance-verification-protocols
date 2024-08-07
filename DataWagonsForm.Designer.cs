namespace Automatic_generation_of_balance_verification_protocols
{
    partial class DataWagonsForm
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
            this.tableWagonsAndTransit = new System.Windows.Forms.DataGridView();
            this.panelData = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonSaveData = new System.Windows.Forms.Button();
            this.numericUpDownTransit = new System.Windows.Forms.NumericUpDown();
            this.labelTransit = new System.Windows.Forms.Label();
            this.numericUpDownWagons = new System.Windows.Forms.NumericUpDown();
            this.labelWagons = new System.Windows.Forms.Label();
            this.menuStripTransitButton = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTimeTransit = new System.Windows.Forms.Label();
            this.dateTimePickerTimeTransit = new System.Windows.Forms.DateTimePicker();
            this.comboBoxDirection = new System.Windows.Forms.ComboBox();
            this.labelDirection = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelNumberTransit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableWagonsAndTransit)).BeginInit();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWagons)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableWagonsAndTransit
            // 
            this.tableWagonsAndTransit.AllowUserToAddRows = false;
            this.tableWagonsAndTransit.AllowUserToDeleteRows = false;
            this.tableWagonsAndTransit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableWagonsAndTransit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableWagonsAndTransit.Location = new System.Drawing.Point(0, 50);
            this.tableWagonsAndTransit.Name = "tableWagonsAndTransit";
            this.tableWagonsAndTransit.RowHeadersWidth = 51;
            this.tableWagonsAndTransit.RowTemplate.Height = 24;
            this.tableWagonsAndTransit.Size = new System.Drawing.Size(1164, 668);
            this.tableWagonsAndTransit.TabIndex = 1;
            this.tableWagonsAndTransit.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableWagonsAndTransit_CellEndEdit);
            this.tableWagonsAndTransit.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tableWagonsAndTransit_DataError);
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.progressBar);
            this.panelData.Controls.Add(this.buttonSaveData);
            this.panelData.Controls.Add(this.numericUpDownTransit);
            this.panelData.Controls.Add(this.labelTransit);
            this.panelData.Controls.Add(this.numericUpDownWagons);
            this.panelData.Controls.Add(this.labelWagons);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelData.Location = new System.Drawing.Point(0, 0);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(1164, 50);
            this.panelData.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(866, 15);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.TabIndex = 3;
            this.progressBar.Visible = false;
            // 
            // buttonSaveData
            // 
            this.buttonSaveData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonSaveData.Enabled = false;
            this.buttonSaveData.Location = new System.Drawing.Point(972, 12);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonSaveData.Size = new System.Drawing.Size(180, 30);
            this.buttonSaveData.TabIndex = 5;
            this.buttonSaveData.Text = "Сохранить показатели";
            this.buttonSaveData.UseVisualStyleBackColor = false;
            this.buttonSaveData.Click += new System.EventHandler(this.buttonSaveData_Click);
            // 
            // numericUpDownTransit
            // 
            this.numericUpDownTransit.Location = new System.Drawing.Point(491, 20);
            this.numericUpDownTransit.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownTransit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTransit.Name = "numericUpDownTransit";
            this.numericUpDownTransit.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownTransit.TabIndex = 3;
            this.numericUpDownTransit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTransit.ValueChanged += new System.EventHandler(this.numericUpDownTransit_ValueChanged);
            // 
            // labelTransit
            // 
            this.labelTransit.AutoSize = true;
            this.labelTransit.Location = new System.Drawing.Point(333, 22);
            this.labelTransit.Name = "labelTransit";
            this.labelTransit.Size = new System.Drawing.Size(152, 16);
            this.labelTransit.TabIndex = 2;
            this.labelTransit.Text = "Количество проездов";
            // 
            // numericUpDownWagons
            // 
            this.numericUpDownWagons.Location = new System.Drawing.Point(160, 20);
            this.numericUpDownWagons.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownWagons.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWagons.Name = "numericUpDownWagons";
            this.numericUpDownWagons.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownWagons.TabIndex = 1;
            this.numericUpDownWagons.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWagons.ValueChanged += new System.EventHandler(this.numericUpDownWagons_ValueChanged);
            // 
            // labelWagons
            // 
            this.labelWagons.AutoSize = true;
            this.labelWagons.Location = new System.Drawing.Point(12, 22);
            this.labelWagons.Name = "labelWagons";
            this.labelWagons.Size = new System.Drawing.Size(142, 16);
            this.labelWagons.TabIndex = 0;
            this.labelWagons.Text = "Количество вагонов";
            // 
            // menuStripTransitButton
            // 
            this.menuStripTransitButton.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripTransitButton.Location = new System.Drawing.Point(0, 0);
            this.menuStripTransitButton.Name = "menuStripTransitButton";
            this.menuStripTransitButton.Size = new System.Drawing.Size(1164, 24);
            this.menuStripTransitButton.TabIndex = 2;
            this.menuStripTransitButton.Text = "menuStrip1";
            this.menuStripTransitButton.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.menuStripTransitButton_ItemAdded);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.menuStripTransitButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 753);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 24);
            this.panel1.TabIndex = 4;
            // 
            // labelTimeTransit
            // 
            this.labelTimeTransit.AutoSize = true;
            this.labelTimeTransit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimeTransit.Location = new System.Drawing.Point(257, 10);
            this.labelTimeTransit.Name = "labelTimeTransit";
            this.labelTimeTransit.Size = new System.Drawing.Size(124, 16);
            this.labelTimeTransit.TabIndex = 38;
            this.labelTimeTransit.Text = "Время проезда:";
            // 
            // dateTimePickerTimeTransit
            // 
            this.dateTimePickerTimeTransit.CustomFormat = "HH:mm";
            this.dateTimePickerTimeTransit.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTimeTransit.Location = new System.Drawing.Point(387, 7);
            this.dateTimePickerTimeTransit.Name = "dateTimePickerTimeTransit";
            this.dateTimePickerTimeTransit.ShowUpDown = true;
            this.dateTimePickerTimeTransit.Size = new System.Drawing.Size(95, 22);
            this.dateTimePickerTimeTransit.TabIndex = 37;
            this.dateTimePickerTimeTransit.ValueChanged += new System.EventHandler(this.dateTimePickerTimeTransit_ValueChanged);
            // 
            // comboBoxDirection
            // 
            this.comboBoxDirection.AutoCompleteCustomSource.AddRange(new string[] {
            "слева направо",
            "справа налево"});
            this.comboBoxDirection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxDirection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxDirection.Items.AddRange(new object[] {
            "слева направо",
            "справа налево"});
            this.comboBoxDirection.Location = new System.Drawing.Point(691, 7);
            this.comboBoxDirection.Name = "comboBoxDirection";
            this.comboBoxDirection.Size = new System.Drawing.Size(137, 24);
            this.comboBoxDirection.Sorted = true;
            this.comboBoxDirection.TabIndex = 35;
            this.comboBoxDirection.Text = "слева направо";
            this.comboBoxDirection.SelectedIndexChanged += new System.EventHandler(this.comboBoxDirection_TextChanged);
            // 
            // labelDirection
            // 
            this.labelDirection.AutoSize = true;
            this.labelDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDirection.Location = new System.Drawing.Point(497, 10);
            this.labelDirection.Name = "labelDirection";
            this.labelDirection.Size = new System.Drawing.Size(188, 16);
            this.labelDirection.TabIndex = 36;
            this.labelDirection.Text = "Направление движения:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelNumberTransit);
            this.panel2.Controls.Add(this.labelTimeTransit);
            this.panel2.Controls.Add(this.dateTimePickerTimeTransit);
            this.panel2.Controls.Add(this.labelDirection);
            this.panel2.Controls.Add(this.comboBoxDirection);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 718);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1164, 35);
            this.panel2.TabIndex = 39;
            // 
            // labelNumberTransit
            // 
            this.labelNumberTransit.AutoSize = true;
            this.labelNumberTransit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNumberTransit.Location = new System.Drawing.Point(12, 10);
            this.labelNumberTransit.Name = "labelNumberTransit";
            this.labelNumberTransit.Size = new System.Drawing.Size(90, 16);
            this.labelNumberTransit.TabIndex = 39;
            this.labelNumberTransit.Text = "Проезд №1";
            // 
            // DataWagonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 777);
            this.Controls.Add(this.tableWagonsAndTransit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelData);
            this.MainMenuStrip = this.menuStripTransitButton;
            this.Name = "DataWagonsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Данные о вагонах и проездах";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tableWagonsAndTransit)).EndInit();
            this.panelData.ResumeLayout(false);
            this.panelData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWagons)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Label labelWagons;
        private System.Windows.Forms.NumericUpDown numericUpDownTransit;
        private System.Windows.Forms.Label labelTransit;
        private System.Windows.Forms.NumericUpDown numericUpDownWagons;
        private System.Windows.Forms.Button buttonSaveData;
        protected System.Windows.Forms.DataGridView tableWagonsAndTransit;
        private System.Windows.Forms.MenuStrip menuStripTransitButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTimeTransit;
        private System.Windows.Forms.DateTimePicker dateTimePickerTimeTransit;
        private System.Windows.Forms.ComboBox comboBoxDirection;
        private System.Windows.Forms.Label labelDirection;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelNumberTransit;
    }
}
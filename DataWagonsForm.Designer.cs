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
            ((System.ComponentModel.ISupportInitialize)(this.tableWagonsAndTransit)).BeginInit();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWagons)).BeginInit();
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
            this.tableWagonsAndTransit.Size = new System.Drawing.Size(1071, 372);
            this.tableWagonsAndTransit.TabIndex = 1;
            this.tableWagonsAndTransit.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableWagonsAndTransit_CellEndEdit);
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
            this.panelData.Size = new System.Drawing.Size(1071, 50);
            this.panelData.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(773, 15);
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
            this.buttonSaveData.Location = new System.Drawing.Point(879, 12);
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
            20,
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
            5,
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
            this.menuStripTransitButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStripTransitButton.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripTransitButton.Location = new System.Drawing.Point(0, 422);
            this.menuStripTransitButton.Name = "menuStripTransitButton";
            this.menuStripTransitButton.Size = new System.Drawing.Size(1071, 28);
            this.menuStripTransitButton.TabIndex = 2;
            this.menuStripTransitButton.Text = "menuStrip1";
            // 
            // DataWagonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 450);
            this.Controls.Add(this.tableWagonsAndTransit);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.menuStripTransitButton);
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
    }
}
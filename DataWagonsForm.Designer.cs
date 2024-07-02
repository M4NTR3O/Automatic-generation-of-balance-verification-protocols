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
            this.numericUpDownTransit = new System.Windows.Forms.NumericUpDown();
            this.labelTransit = new System.Windows.Forms.Label();
            this.numericUpDownWagons = new System.Windows.Forms.NumericUpDown();
            this.labelWagons = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonSaveData = new System.Windows.Forms.Button();
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
            this.tableWagonsAndTransit.Size = new System.Drawing.Size(1071, 400);
            this.tableWagonsAndTransit.TabIndex = 1;
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.buttonSaveData);
            this.panelData.Controls.Add(this.buttonCalculate);
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
            // numericUpDownTransit
            // 
            this.numericUpDownTransit.Location = new System.Drawing.Point(491, 20);
            this.numericUpDownTransit.Maximum = new decimal(new int[] {
            10,
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
            10,
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
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(631, 20);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(180, 23);
            this.buttonCalculate.TabIndex = 4;
            this.buttonCalculate.Text = "Рассчитать показатели";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonSaveData
            // 
            this.buttonSaveData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonSaveData.Location = new System.Drawing.Point(817, 19);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonSaveData.Size = new System.Drawing.Size(180, 23);
            this.buttonSaveData.TabIndex = 5;
            this.buttonSaveData.Text = "Сохранить показатели";
            this.buttonSaveData.UseVisualStyleBackColor = false;
            this.buttonSaveData.Click += new System.EventHandler(this.buttonSaveData_Click);
            // 
            // DataWagonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 450);
            this.Controls.Add(this.tableWagonsAndTransit);
            this.Controls.Add(this.panelData);
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

        }

        #endregion
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Label labelWagons;
        private System.Windows.Forms.NumericUpDown numericUpDownTransit;
        private System.Windows.Forms.Label labelTransit;
        private System.Windows.Forms.NumericUpDown numericUpDownWagons;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonSaveData;
        protected System.Windows.Forms.DataGridView tableWagonsAndTransit;
    }
}
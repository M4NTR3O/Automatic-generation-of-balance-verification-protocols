namespace Automatic_generation_of_balance_verification_protocols
{
    partial class MetrologyParametrsForm
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
            this.labelMax = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelDe = new System.Windows.Forms.Label();
            this.textBoxMax = new System.Windows.Forms.TextBox();
            this.textBoxMin = new System.Windows.Forms.TextBox();
            this.buttonSaveData = new System.Windows.Forms.Button();
            this.comboBoxDe = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(268, 58);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(55, 16);
            this.labelMax.TabIndex = 0;
            this.labelMax.Text = "Max, т =";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(268, 106);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(51, 16);
            this.labelMin.TabIndex = 2;
            this.labelMin.Text = "Min, т =";
            // 
            // labelDe
            // 
            this.labelDe.AutoSize = true;
            this.labelDe.Location = new System.Drawing.Point(277, 156);
            this.labelDe.Name = "labelDe";
            this.labelDe.Size = new System.Drawing.Size(42, 16);
            this.labelDe.TabIndex = 4;
            this.labelDe.Text = "D=e =";
            // 
            // textBoxMax
            // 
            this.textBoxMax.Location = new System.Drawing.Point(329, 58);
            this.textBoxMax.Name = "textBoxMax";
            this.textBoxMax.Size = new System.Drawing.Size(177, 22);
            this.textBoxMax.TabIndex = 5;
            // 
            // textBoxMin
            // 
            this.textBoxMin.Location = new System.Drawing.Point(329, 106);
            this.textBoxMin.Name = "textBoxMin";
            this.textBoxMin.Size = new System.Drawing.Size(177, 22);
            this.textBoxMin.TabIndex = 7;
            // 
            // buttonSaveData
            // 
            this.buttonSaveData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonSaveData.Location = new System.Drawing.Point(283, 351);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonSaveData.Size = new System.Drawing.Size(180, 32);
            this.buttonSaveData.TabIndex = 10;
            this.buttonSaveData.Text = "Сохранить показатели";
            this.buttonSaveData.UseVisualStyleBackColor = false;
            this.buttonSaveData.Click += new System.EventHandler(this.buttonSaveData_Click);
            // 
            // comboBoxDe
            // 
            this.comboBoxDe.FormattingEnabled = true;
            this.comboBoxDe.Items.AddRange(new object[] {
            "20",
            "50",
            "100",
            "200",
            "500"});
            this.comboBoxDe.Location = new System.Drawing.Point(329, 153);
            this.comboBoxDe.Name = "comboBoxDe";
            this.comboBoxDe.Size = new System.Drawing.Size(177, 24);
            this.comboBoxDe.TabIndex = 11;
            // 
            // MetrologyParametrsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxDe);
            this.Controls.Add(this.buttonSaveData);
            this.Controls.Add(this.textBoxMin);
            this.Controls.Add(this.textBoxMax);
            this.Controls.Add(this.labelDe);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.labelMax);
            this.Name = "MetrologyParametrsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Основные метрологические параметры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxMax;
        private System.Windows.Forms.TextBox textBoxMin;
        private System.Windows.Forms.Button buttonSaveData;
        internal System.Windows.Forms.Label labelMax;
        internal System.Windows.Forms.Label labelMin;
        internal System.Windows.Forms.Label labelDe;
        private System.Windows.Forms.ComboBox comboBoxDe;
    }
}
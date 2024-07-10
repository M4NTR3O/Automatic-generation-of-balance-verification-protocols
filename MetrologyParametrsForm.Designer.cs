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
            this.labelMaxn = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelMinn = new System.Windows.Forms.Label();
            this.labelDe = new System.Windows.Forms.Label();
            this.textBoxMax = new System.Windows.Forms.TextBox();
            this.textBoxMaxn = new System.Windows.Forms.TextBox();
            this.textBoxMin = new System.Windows.Forms.TextBox();
            this.textBoxMinn = new System.Windows.Forms.TextBox();
            this.textBoxDe = new System.Windows.Forms.TextBox();
            this.buttonSaveData = new System.Windows.Forms.Button();
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
            // labelMaxn
            // 
            this.labelMaxn.AutoSize = true;
            this.labelMaxn.Location = new System.Drawing.Point(261, 101);
            this.labelMaxn.Name = "labelMaxn";
            this.labelMaxn.Size = new System.Drawing.Size(62, 16);
            this.labelMaxn.TabIndex = 1;
            this.labelMaxn.Text = "Max,n т =";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(272, 144);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(51, 16);
            this.labelMin.TabIndex = 2;
            this.labelMin.Text = "Min, т =";
            // 
            // labelMinn
            // 
            this.labelMinn.AutoSize = true;
            this.labelMinn.Location = new System.Drawing.Point(264, 192);
            this.labelMinn.Name = "labelMinn";
            this.labelMinn.Size = new System.Drawing.Size(58, 16);
            this.labelMinn.TabIndex = 3;
            this.labelMinn.Text = "Min,n т =";
            // 
            // labelDe
            // 
            this.labelDe.AutoSize = true;
            this.labelDe.Location = new System.Drawing.Point(280, 241);
            this.labelDe.Name = "labelDe";
            this.labelDe.Size = new System.Drawing.Size(39, 16);
            this.labelDe.TabIndex = 4;
            this.labelDe.Text = "D=e=";
            // 
            // textBoxMax
            // 
            this.textBoxMax.Location = new System.Drawing.Point(329, 58);
            this.textBoxMax.Name = "textBoxMax";
            this.textBoxMax.Size = new System.Drawing.Size(177, 22);
            this.textBoxMax.TabIndex = 5;
            // 
            // textBoxMaxn
            // 
            this.textBoxMaxn.Location = new System.Drawing.Point(329, 98);
            this.textBoxMaxn.Name = "textBoxMaxn";
            this.textBoxMaxn.Size = new System.Drawing.Size(177, 22);
            this.textBoxMaxn.TabIndex = 6;
            // 
            // textBoxMin
            // 
            this.textBoxMin.Location = new System.Drawing.Point(329, 141);
            this.textBoxMin.Name = "textBoxMin";
            this.textBoxMin.Size = new System.Drawing.Size(177, 22);
            this.textBoxMin.TabIndex = 7;
            // 
            // textBoxMinn
            // 
            this.textBoxMinn.Location = new System.Drawing.Point(329, 189);
            this.textBoxMinn.Name = "textBoxMinn";
            this.textBoxMinn.Size = new System.Drawing.Size(177, 22);
            this.textBoxMinn.TabIndex = 8;
            // 
            // textBoxDe
            // 
            this.textBoxDe.Location = new System.Drawing.Point(329, 238);
            this.textBoxDe.Name = "textBoxDe";
            this.textBoxDe.Size = new System.Drawing.Size(177, 22);
            this.textBoxDe.TabIndex = 9;
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
            // MetrologyParametrsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSaveData);
            this.Controls.Add(this.textBoxDe);
            this.Controls.Add(this.textBoxMinn);
            this.Controls.Add(this.textBoxMin);
            this.Controls.Add(this.textBoxMaxn);
            this.Controls.Add(this.textBoxMax);
            this.Controls.Add(this.labelDe);
            this.Controls.Add(this.labelMinn);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.labelMaxn);
            this.Controls.Add(this.labelMax);
            this.Name = "MetrologyParametrsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Основные метрологические параметры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxMax;
        private System.Windows.Forms.TextBox textBoxMaxn;
        private System.Windows.Forms.TextBox textBoxMin;
        private System.Windows.Forms.TextBox textBoxMinn;
        private System.Windows.Forms.TextBox textBoxDe;
        private System.Windows.Forms.Button buttonSaveData;
        internal System.Windows.Forms.Label labelMax;
        internal System.Windows.Forms.Label labelMaxn;
        internal System.Windows.Forms.Label labelMin;
        internal System.Windows.Forms.Label labelMinn;
        internal System.Windows.Forms.Label labelDe;
    }
}
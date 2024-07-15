namespace Automatic_generation_of_balance_verification_protocols
{
    partial class AddingForm
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
            this.buttonSaveData = new System.Windows.Forms.Button();
            this.textBoxCustomerRepresentative = new System.Windows.Forms.TextBox();
            this.textBoxRepresentativeOfTensib = new System.Windows.Forms.TextBox();
            this.textBoxStateTrustee = new System.Windows.Forms.TextBox();
            this.labelCustomerRepresentative = new System.Windows.Forms.Label();
            this.labelRepresentativeOfTensib = new System.Windows.Forms.Label();
            this.labelStateTrustee = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSaveData
            // 
            this.buttonSaveData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonSaveData.Location = new System.Drawing.Point(295, 276);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonSaveData.Size = new System.Drawing.Size(180, 32);
            this.buttonSaveData.TabIndex = 17;
            this.buttonSaveData.Text = "Сохранить показатели";
            this.buttonSaveData.UseVisualStyleBackColor = false;
            this.buttonSaveData.Click += new System.EventHandler(this.buttonSaveData_Click);
            // 
            // textBoxCustomerRepresentative
            // 
            this.textBoxCustomerRepresentative.Location = new System.Drawing.Point(409, 143);
            this.textBoxCustomerRepresentative.Name = "textBoxCustomerRepresentative";
            this.textBoxCustomerRepresentative.Size = new System.Drawing.Size(177, 22);
            this.textBoxCustomerRepresentative.TabIndex = 16;
            // 
            // textBoxRepresentativeOfTensib
            // 
            this.textBoxRepresentativeOfTensib.Location = new System.Drawing.Point(409, 100);
            this.textBoxRepresentativeOfTensib.Name = "textBoxRepresentativeOfTensib";
            this.textBoxRepresentativeOfTensib.Size = new System.Drawing.Size(177, 22);
            this.textBoxRepresentativeOfTensib.TabIndex = 15;
            // 
            // textBoxStateTrustee
            // 
            this.textBoxStateTrustee.Location = new System.Drawing.Point(409, 60);
            this.textBoxStateTrustee.Name = "textBoxStateTrustee";
            this.textBoxStateTrustee.Size = new System.Drawing.Size(177, 22);
            this.textBoxStateTrustee.TabIndex = 14;
            // 
            // labelCustomerRepresentative
            // 
            this.labelCustomerRepresentative.AutoSize = true;
            this.labelCustomerRepresentative.Location = new System.Drawing.Point(171, 149);
            this.labelCustomerRepresentative.Name = "labelCustomerRepresentative";
            this.labelCustomerRepresentative.Size = new System.Drawing.Size(183, 16);
            this.labelCustomerRepresentative.TabIndex = 13;
            this.labelCustomerRepresentative.Text = "Представитель Заказчика";
            // 
            // labelRepresentativeOfTensib
            // 
            this.labelRepresentativeOfTensib.AutoSize = true;
            this.labelRepresentativeOfTensib.Location = new System.Drawing.Point(171, 106);
            this.labelRepresentativeOfTensib.Name = "labelRepresentativeOfTensib";
            this.labelRepresentativeOfTensib.Size = new System.Drawing.Size(203, 16);
            this.labelRepresentativeOfTensib.TabIndex = 12;
            this.labelRepresentativeOfTensib.Text = "Представитель ООО \"Тенсиб\"";
            // 
            // labelStateTrustee
            // 
            this.labelStateTrustee.AutoSize = true;
            this.labelStateTrustee.Location = new System.Drawing.Point(171, 60);
            this.labelStateTrustee.Name = "labelStateTrustee";
            this.labelStateTrustee.Size = new System.Drawing.Size(205, 16);
            this.labelStateTrustee.TabIndex = 11;
            this.labelStateTrustee.Text = "Государственный поверитель";
            // 
            // AddingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSaveData);
            this.Controls.Add(this.textBoxCustomerRepresentative);
            this.Controls.Add(this.textBoxRepresentativeOfTensib);
            this.Controls.Add(this.textBoxStateTrustee);
            this.Controls.Add(this.labelCustomerRepresentative);
            this.Controls.Add(this.labelRepresentativeOfTensib);
            this.Controls.Add(this.labelStateTrustee);
            this.Name = "AddingForm";
            this.Text = "Приложения";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveData;
        private System.Windows.Forms.TextBox textBoxCustomerRepresentative;
        private System.Windows.Forms.TextBox textBoxRepresentativeOfTensib;
        private System.Windows.Forms.TextBox textBoxStateTrustee;
        private System.Windows.Forms.Label labelCustomerRepresentative;
        private System.Windows.Forms.Label labelRepresentativeOfTensib;
        private System.Windows.Forms.Label labelStateTrustee;
    }
}
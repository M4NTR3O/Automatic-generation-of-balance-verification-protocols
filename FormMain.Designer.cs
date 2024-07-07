namespace Automatic_generation_of_balance_verification_protocols
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripInformation = new System.Windows.Forms.MenuStrip();
            this.createProtocolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьПротоколToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripInformation
            // 
            this.menuStripInformation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripInformation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createProtocolToolStripMenuItem,
            this.открытьПротоколToolStripMenuItem});
            this.menuStripInformation.Location = new System.Drawing.Point(0, 0);
            this.menuStripInformation.Name = "menuStripInformation";
            this.menuStripInformation.Size = new System.Drawing.Size(800, 28);
            this.menuStripInformation.TabIndex = 0;
            this.menuStripInformation.Text = "menuStripInformation";
            // 
            // createProtocolToolStripMenuItem
            // 
            this.createProtocolToolStripMenuItem.Name = "createProtocolToolStripMenuItem";
            this.createProtocolToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.createProtocolToolStripMenuItem.Text = "Создать новый протокол";
            this.createProtocolToolStripMenuItem.Click += new System.EventHandler(this.createProtocolToolStripMenuItem_Click);
            // 
            // открытьПротоколToolStripMenuItem
            // 
            this.открытьПротоколToolStripMenuItem.Name = "открытьПротоколToolStripMenuItem";
            this.открытьПротоколToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.открытьПротоколToolStripMenuItem.Text = "Открыть протокол";
            this.открытьПротоколToolStripMenuItem.Click += new System.EventHandler(this.открытьПротоколToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStripInformation);
            this.MainMenuStrip = this.menuStripInformation;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автоматическое формирование протокола для поверки весов";
            this.menuStripInformation.ResumeLayout(false);
            this.menuStripInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripInformation;
        private System.Windows.Forms.ToolStripMenuItem createProtocolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьПротоколToolStripMenuItem;
    }
}


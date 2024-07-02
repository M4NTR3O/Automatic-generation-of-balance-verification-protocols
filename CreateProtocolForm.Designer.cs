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
            this.menuStripRequired.Size = new System.Drawing.Size(800, 28);
            this.menuStripRequired.TabIndex = 0;
            this.menuStripRequired.Text = "menuStrip";
            // 
            // DataWagonToolStripMenuItem
            // 
            this.DataWagonToolStripMenuItem.Name = "DataWagonToolStripMenuItem";
            this.DataWagonToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.DataWagonToolStripMenuItem.Text = "Данные о вагонах и проездах";
            // 
            // MetrologyToolStripMenuItem
            // 
            this.MetrologyToolStripMenuItem.Name = "MetrologyToolStripMenuItem";
            this.MetrologyToolStripMenuItem.Size = new System.Drawing.Size(304, 24);
            this.MetrologyToolStripMenuItem.Text = "Основные метрологические параметры";
            // 
            // AddingToolStripMenuItem
            // 
            this.AddingToolStripMenuItem.Name = "AddingToolStripMenuItem";
            this.AddingToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.AddingToolStripMenuItem.Text = "Приложения";
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 423);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStripConvertation";
            // 
            // toolStripButtonConvert
            // 
            this.toolStripButtonConvert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonConvert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConvert.Name = "toolStripButtonConvert";
            this.toolStripButtonConvert.Size = new System.Drawing.Size(188, 24);
            this.toolStripButtonConvert.Text = "Сформировать протокол";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonPreview
            // 
            this.toolStripButtonPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonPreview.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPreview.Image")));
            this.toolStripButtonPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPreview.Name = "toolStripButtonPreview";
            this.toolStripButtonPreview.Size = new System.Drawing.Size(196, 24);
            this.toolStripButtonPreview.Text = "Предпросмотр протокола";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 24);
            // 
            // CreateProtocolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStripRequired);
            this.MainMenuStrip = this.menuStripRequired;
            this.Name = "CreateProtocolForm";
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
    }
}
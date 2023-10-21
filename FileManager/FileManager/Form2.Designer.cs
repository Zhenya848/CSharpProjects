
namespace FileManager
{
    partial class Form2
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
            this.showInExplorerBox = new System.Windows.Forms.CheckBox();
            this.driveMenu = new System.Windows.Forms.MenuStrip();
            this.дискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driveMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // showInExplorerBox
            // 
            this.showInExplorerBox.AutoSize = true;
            this.showInExplorerBox.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showInExplorerBox.ForeColor = System.Drawing.Color.Aqua;
            this.showInExplorerBox.Location = new System.Drawing.Point(12, 12);
            this.showInExplorerBox.Name = "showInExplorerBox";
            this.showInExplorerBox.Size = new System.Drawing.Size(208, 27);
            this.showInExplorerBox.TabIndex = 0;
            this.showInExplorerBox.Text = "Открыть в проводнике";
            this.showInExplorerBox.UseVisualStyleBackColor = true;
            this.showInExplorerBox.CheckedChanged += new System.EventHandler(this.showInExplorerBox_CheckedChanged);
            // 
            // driveMenu
            // 
            this.driveMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.driveMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.дискToolStripMenuItem});
            this.driveMenu.Location = new System.Drawing.Point(12, 72);
            this.driveMenu.Name = "driveMenu";
            this.driveMenu.Size = new System.Drawing.Size(60, 24);
            this.driveMenu.TabIndex = 1;
            this.driveMenu.Text = "menuStrip1";
            this.driveMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.driveMenu_ItemClicked);
            // 
            // дискToolStripMenuItem
            // 
            this.дискToolStripMenuItem.Name = "дискToolStripMenuItem";
            this.дискToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.дискToolStripMenuItem.Text = "Диск: ";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.showInExplorerBox);
            this.Controls.Add(this.driveMenu);
            this.MainMenuStrip = this.driveMenu;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.driveMenu.ResumeLayout(false);
            this.driveMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox showInExplorerBox;
        private System.Windows.Forms.MenuStrip driveMenu;
        private System.Windows.Forms.ToolStripMenuItem дискToolStripMenuItem;
    }
}

namespace FileManager
{
    partial class Form1
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
            this.brousePanel = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.resultText = new System.Windows.Forms.Label();
            this.icon = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.optionsButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // brousePanel
            // 
            this.brousePanel.BackColor = System.Drawing.Color.DimGray;
            this.brousePanel.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.brousePanel.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.brousePanel.ForeColor = System.Drawing.Color.Aqua;
            this.brousePanel.Location = new System.Drawing.Point(166, 80);
            this.brousePanel.MaxLength = 80;
            this.brousePanel.Name = "brousePanel";
            this.brousePanel.Size = new System.Drawing.Size(394, 37);
            this.brousePanel.TabIndex = 0;
            // 
            // findButton
            // 
            this.findButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.findButton.AutoSize = true;
            this.findButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.findButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.findButton.FlatAppearance.BorderSize = 0;
            this.findButton.Font = new System.Drawing.Font("Comic Sans MS", 17.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(204)), true);
            this.findButton.ForeColor = System.Drawing.Color.Aqua;
            this.findButton.Location = new System.Drawing.Point(566, 80);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(115, 37);
            this.findButton.TabIndex = 1;
            this.findButton.Text = "Найти";
            this.findButton.UseVisualStyleBackColor = false;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // resultText
            // 
            this.resultText.AutoSize = true;
            this.resultText.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultText.ForeColor = System.Drawing.Color.Aqua;
            this.resultText.Location = new System.Drawing.Point(162, 137);
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(0, 30);
            this.resultText.TabIndex = 2;
            // 
            // icon
            // 
            this.icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.icon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.icon.Image = global::FileManager.Properties.Resources.PinClipart_com_bookkeeping_clipart_4117593;
            this.icon.Location = new System.Drawing.Point(860, 12);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(50, 50);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icon.TabIndex = 5;
            this.icon.TabStop = false;
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.ForeColor = System.Drawing.Color.Aqua;
            this.title.Location = new System.Drawing.Point(273, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(397, 45);
            this.title.TabIndex = 6;
            this.title.Text = "Быстрый поиск файлов";
            // 
            // optionsButton
            // 
            this.optionsButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.optionsButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.optionsButton.FlatAppearance.BorderSize = 0;
            this.optionsButton.Font = new System.Drawing.Font("Comic Sans MS", 16.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(204)), true);
            this.optionsButton.ForeColor = System.Drawing.Color.Aqua;
            this.optionsButton.Location = new System.Drawing.Point(0, -1);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(115, 37);
            this.optionsButton.TabIndex = 7;
            this.optionsButton.Text = "Параметры";
            this.optionsButton.UseVisualStyleBackColor = false;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 246);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(922, 219);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(922, 465);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.title);
            this.Controls.Add(this.icon);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.brousePanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox brousePanel;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Label resultText;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}


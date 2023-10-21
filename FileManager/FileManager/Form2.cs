using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileManager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void showInExplorerBox_CheckedChanged(object sender, EventArgs e)
        {
            Form1.showInExplorer = showInExplorerBox.Checked;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (var drive in DriveInfo.GetDrives())
                driveMenu.Items.Add(drive.Name);
        }

        private void driveMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form1.ChangeDriveDirectories(e.ClickedItem.Text);
        }
    }
}

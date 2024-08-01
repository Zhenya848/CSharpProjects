using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveWallpaper
{
    public partial class Form2 : Form
    {
        private Form1 _backgroundWallpaper;

        private string _url;
        private bool _isActive = true;

        public Form2()
        {
            InitializeComponent();
        }

        private void selectVideoButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                _url = Path.GetFullPath(file);

                if (_backgroundWallpaper != null)
                    _backgroundWallpaper.Close();

                _backgroundWallpaper = new Form1(_url);
                _backgroundWallpaper.Show();
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (_backgroundWallpaper == null)
                return;

            if (_isActive)
            {
                _backgroundWallpaper.Stop();
                startButton.Text = "Продолжить";
            }
            else
            {
                _backgroundWallpaper.Continue();
                startButton.Text = "Остановить";
            }

            _isActive = !_isActive;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SteamKeyGeneratorSampleProject
{
    public partial class Form1 : Form
    {
        static Random rand = new Random();
        static char[] charArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        static int maxLengthOfOnePrompt = 5;
        static int maxLengthOfKey = 29;


        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        public Form1() 
        { 
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);

            /*textBox1.Text = Cursor.Position.X.ToString();
            textBox2.Text = Cursor.Position.Y.ToString();*/

            for (int i = 0; i < 3; i++)
            {
                SendKeys.Send(GetRandomKey(""));
                System.Threading.Thread.Sleep(80);

                SendKeys.Send("{ENTER}");
                System.Threading.Thread.Sleep(1000);

                Cursor.Position = new Point(875, 583);

                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }
        }

        private static string GetRandomKey(string result)
        {
            for (int i = 0; i < maxLengthOfOnePrompt; i++)

                result += charArray[rand.Next(0, charArray.Length)];

            if (result.Length >= maxLengthOfKey)
                return result;

            return GetRandomKey(result + '-');
        }
    }
}
using AxWMPLib;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace LiveWallpaper
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessageTimeout(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam, SendMessageTimeoutFlags fuFlags, uint uTimeout, out IntPtr lpdwResult);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);

        private const int SPI_GETDESKWALLPAPER = 0x0073;
        private const int SPI_SETDESKWALLPAPER = 0x0014;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDCHANGE = 0x02;
        private const int MAX_PATH = 260;

        private string _url;
        private string currentWallpaper;

        [Flags]
        private enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0000,
            SMTO_BLOCK = 0x0001,
            SMTO_ABORTIFHUNG = 0x0002,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        }

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        private IntPtr progman;
        private IntPtr workerw;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;

        public Form1()
        {
            InitializeComponent();
            InitializeAxWindowsMediaPlayer();
        }

        public Form1(string url)
        {
            InitializeComponent();
            InitializeAxWindowsMediaPlayer();

            _url = url;
        }

        public void Stop()
        {
            Hide();
            SetWallpaper();

            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        public void Continue()
        {
            Show();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void SetWallpaper()
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, currentWallpaper, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }

        private void SaveCurrentWallpaper()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", false);

            if (regKey != null)
            {
                currentWallpaper = regKey.GetValue("WallPaper").ToString();
                regKey.Close();
            }
        }

        private void InitializeAxWindowsMediaPlayer()
        {
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SaveCurrentWallpaper();
            progman = FindWindow("Progman", null);

            IntPtr result = IntPtr.Zero;
            SendMessageTimeout(progman, 0x052C, IntPtr.Zero, IntPtr.Zero, SendMessageTimeoutFlags.SMTO_NORMAL, 1000, out result);

            workerw = IntPtr.Zero;

            EnumWindows((hWnd, lParam) =>
            {
                IntPtr shellViewWin = FindWindowEx(hWnd, IntPtr.Zero, "SHELLDLL_DefView", null);
                if (shellViewWin != IntPtr.Zero)
                {
                    workerw = FindWindowEx(IntPtr.Zero, hWnd, "WorkerW", null);
                    return false;
                }
                return true;
            }, IntPtr.Zero);

            SetParent(this.Handle, workerw);

            Screen primaryScreen = Screen.PrimaryScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = primaryScreen.Bounds;

            axWindowsMediaPlayer1.URL = _url;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.enableContextMenu = false;
            axWindowsMediaPlayer1.stretchToFit = true;
        }
    }
}
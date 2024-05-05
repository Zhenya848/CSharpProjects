using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FileManager
{
    public partial class Form1 : Form
    {
        Form2 optionsWindow = new Form2();

        static string[] directories = Directory.GetDirectories(DriveInfo.GetDrives()[0].Name);
        string searchingFile;

        string directory1 = "";
        string directory2 = " ";

        Thread searchUpToDown;
        Thread searchDownToUp;
        Thread stopSearch;

        Rectangle originalFormRectangle;
        Rectangle originalFindButtonRectangle;
        Rectangle originalResultTextRectangle;
        Rectangle originalBrousePanelRectangle;
        Rectangle originalOptionsButtonRectangle;
        Rectangle originalFlowLayoutPanelRectangle;

        public static bool showInExplorer;

        public Form1()
        {
            InitializeComponent();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            searchingFile = brousePanel.Text;
            resultText.Text = "Идёт поиск...";
            flowLayoutPanel1.Controls.Clear();

            searchUpToDown = new Thread(CheckFilesUpToDown);
            searchDownToUp = new Thread(CheckFilesDownToUp);
            stopSearch = new Thread(StopSearch);

            searchUpToDown.Start();
            searchDownToUp.Start();
            stopSearch.Start();
        }

        public static void ChangeDriveDirectories(string driveName)
        {
            directories = Directory.GetDirectories(driveName);
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            optionsWindow.Show();
        }

        private void StopSearch()
        {
            while (true)
            {
                if (directory1 == directory2)
                {
                    searchUpToDown.Abort();
                    searchDownToUp.Abort();

                    CheckFileInDirectories(directory1);

                    Invoke(new Action(() => resultText.Text = $"Поиск завершён. Найдено: {flowLayoutPanel1.Controls.Count} файлов"));
                    return;
                }
            }
        }

        private void CheckFilesUpToDown()
        {
            for (int i = 0; i < directories.Length; i++)
            {
                directory1 = directories[i];
                CheckFileInDirectories(directory1);
            }
        }

        private void CheckFilesDownToUp()
        {
            for (int i = directories.Length - 1; i >= 0; i--)
            {
                directory2 = directories[i];
                CheckFileInDirectories(directory2);
            }
        }

        private void CheckFileInDirectories(in string path)
        {
            try
            {
                Directory
                    .GetFiles(path, "*", SearchOption.AllDirectories)
                    .ToList()
                    .ForEach(f =>
                    {
                        if (searchingFile == Path.GetFileName(f))
                        {
                            Invoke(new Action(() => { flowLayoutPanel1.Controls.Add(GetTextBox(f)); }));

                            if (showInExplorer)
                                Process.Start(new ProcessStartInfo { FileName = "explorer", Arguments = $"/n, select, {GetPath(f)}"});
                        }
                    });
            }
            catch (UnauthorizedAccessException) {  };
        }

        private string GetPath(string filePath)
        {
            while (true)
            {
                if (filePath[filePath.Length - 1] == @"\".ToCharArray()[0])
                    break;

                filePath = filePath.Remove(filePath.Length - 1);
            }

            return filePath;
        }

        private TextBox GetTextBox(string text)
        {
            TextBox result = new TextBox();

            result.Text = text;

            result.ForeColor = resultText.ForeColor;
            result.Font = resultText.Font;
            result.BackColor = flowLayoutPanel1.BackColor;

            result.Width = result.PreferredSize.Width;

            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeRectangle(out originalFormRectangle, this);
            InitializeRectangle(out originalFindButtonRectangle, findButton);
            InitializeRectangle(out originalResultTextRectangle, resultText);
            InitializeRectangle(out originalBrousePanelRectangle, brousePanel);
            InitializeRectangle(out originalOptionsButtonRectangle, optionsButton);
            InitializeRectangle(out originalFlowLayoutPanelRectangle, flowLayoutPanel1);
        }

        private void InitializeRectangle(out Rectangle rectangle, Control element)
        {
            rectangle = new Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeElement(originalFindButtonRectangle, findButton, true, false);
            ResizeElement(originalResultTextRectangle, resultText, false, false);
            ResizeElement(originalBrousePanelRectangle, brousePanel, true, false);
            ResizeElement(originalOptionsButtonRectangle, optionsButton, true, false);
            ResizeElement(originalFlowLayoutPanelRectangle, flowLayoutPanel1, false, true);
        }

        private void ResizeElement(Rectangle rectangle, Control element, bool changeWight, bool changeHeight)
        {
            float xRatio = (float)(Width) / (float)(originalFormRectangle.Width);
            float yRatio = (float)(Height) / (float)(originalFormRectangle.Height);

            element.Location = new Point((int)(rectangle.Location.X * xRatio), (int)(rectangle.Location.Y * yRatio));
            element.Size = new Size((int)(rectangle.Width * (changeWight ? xRatio : 1)), (int)(rectangle.Height * (changeHeight ? yRatio : 1)));
        }
    }
}
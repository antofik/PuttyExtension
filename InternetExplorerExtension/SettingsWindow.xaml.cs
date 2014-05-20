using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InternetExplorerExtension
{
    public partial class SettingsWindow
    {
        public static void Execute(string path, Action<string> callback)
        {
            var window = new SettingsWindow(path);
            window.Closed += delegate
            {
                if (callback != null) callback(window._path);
            };
            window.Show();
        }

        private string _path;

        public SettingsWindow(string path)
        {
            InitializeComponent();
            _path = path;
            txtPuttyPath.Text = path;
            cmdPuttyPath.Click += delegate
            {
                try
                {
                    var dialog = new OpenFileDialog();
                    
                    dialog.Filter = "Putty|putty.exe";
                    dialog.CheckFileExists = true;
                    if (dialog.ShowDialog() == true)
                    {
                        txtPuttyPath.Text = dialog.FileName;
                    }
                }
                catch (Exception ex)
                {
                    txtError.Text = ex.ToString();
                }
            };
            cmdSave.Click += delegate {
                _path = txtPuttyPath.Text;
                Close(); 
            };
            cmdCancel.Click += delegate { Close(); };
            cmdPuttyConfig.Click += delegate
            {
                if (!File.Exists(txtPuttyPath.Text)) return;
                var process = new Process();
                process.EnableRaisingEvents = true;
                process.StartInfo.FileName = txtPuttyPath.Text;
                process.Start();
            };
        }
    }
}

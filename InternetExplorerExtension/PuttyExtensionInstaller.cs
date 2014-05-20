using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Windows;

namespace InternetExplorerExtension
{
    [RunInstaller(true)]
    public partial class PuttyExtensionInstaller : System.Configuration.Install.Installer
    {
        public static string RegBHO = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Browser Helper Objects";
        public static string RegCmd = "Software\\Microsoft\\Internet Explorer\\Extensions";

        public PuttyExtensionInstaller()
        {
            InitializeComponent();

        }

        protected override void OnCommitted(IDictionary savedState)
        {
            base.OnCommitted(savedState);
            try
            {
                PuttyExtension.RegisterBHO(typeof(PuttyExtension));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Installing error " + ex);
            }
        }

        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);
            try
            {
                PuttyExtension.UnregisterBHO(typeof(PuttyExtension));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uninstalling error " + ex);
            }
        }

    }
}

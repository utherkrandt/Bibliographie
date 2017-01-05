using Bibliographie.Core;
using log4net.Config;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace Bibliographie
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            XmlConfigurator.Configure(new FileInfo(ConfigurationManager.AppSettings.Get("LogConfiguration")));
            CategoryManagement factor = new CategoryManagement();
            Application.Run(new MainForm(factor));
        }
    }
}

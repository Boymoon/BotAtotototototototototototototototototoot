using System;
using System.Collections.Generic;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using System.Data;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Core;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Instagram.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnAppStartup_UpdateThemeName(object sender, StartupEventArgs e)
        {
            DevExpress.Xpf.Core.ApplicationThemeHelper.UpdateApplicationThemeName();
            Task.Run(() =>
            {
                ContainerCollection<ObservableCollection<ModelPost>>.Init();
                CollectionsHelper.Init();
                KernalWeb.Setup();
                garbage.Init();
                for (int i = 0; i < KernalWeb._PID.Count; i++)
                {
                    garbage.Collect(KernalWeb._PID[i]);
                }
                KernalWeb.Driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 5, 0);
                KernalWeb.Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0,5,0);
            });
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                // KernalWeb.Driver.Close();
                garbage.Clear();
            }
            catch (Exception)
            {

            }
        }
    }
}

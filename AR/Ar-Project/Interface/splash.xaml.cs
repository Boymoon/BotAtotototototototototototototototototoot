using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using DevExpress.Xpf.Core;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.Xpf.Printing;

namespace Ar_Project
{
    /// <summary>
    /// Interaction logic for splash.xaml
    /// </summary>
    public partial class splash : Window
    {

        public splash()
        {
            InitializeComponent();
        }
        DataBaseHelper DataBaseHelper = new DataBaseHelper();

        private async void progressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            try
            {
                if (textBlock.Text == "Loading...")
                {
                    try
                    {
                        Properties.Settings.Default.path = System.Windows.Forms.Application.StartupPath;
                        Properties.Settings.Default.Save();
                    }
                    catch(Exception ex)
                    {

                    }
                  

                    if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\dbPascal.db"))
                        goto ISReady;

                    if (!File.Exists(System.Windows.Forms.Application.StartupPath + "\\dbPascal.db"))
                    {
                        try
                        {
                            if (!File.Exists(System.Windows.Forms.Application.StartupPath+ "\\Data_Backup.db"))
                            {
                                File.Copy(System.Windows.Forms.Application.StartupPath + "\\corvk1.db", System.Windows.Forms.Application.StartupPath + "\\Data_Backup.db");
                            }
                            if (DataBaseHelper.ExecuteBackUpDataBase())
                            {
                                goto ISReady;
                            }
                        }
                        catch (Exception ex) {
                          
                                DXMessageBox.Show(ex.Message,"خطأ",MessageBoxButton.OK,MessageBoxImage.Error); }

                    }
                    try
                    {

                        DataBaseHelper.CheckIfDatabaseExiOrnor();
                        if (!DataBaseHelper.CheckIfDatabaseExiOrnor())
                        {
                            DataBaseHelper.ExecuteBackUpDataBase();

                        }
                    }
                    catch (Exception ex) { }

                    ISReady: if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\dbPascal.db"))
                    {
                        Task task =Task.Run(() =>
                          {
                              DataBaseHelper.BackUp();

                          });
                        
                        var x_ = new Window1();
                        x_.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        x_.Show();
                        this.Close();
                    }
                    else
                    {
                        Task task = Task.Run(() =>
                        {
                            DataBaseHelper.ExecuteBackUpDataBase();
                        });
                        this.Close();
                    }
                }
            }
            catch (Exception ex) { DXMessageBox.Show(ex.Message, "خطأ", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void textBlock_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void textBlock_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void textBlock_TextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}

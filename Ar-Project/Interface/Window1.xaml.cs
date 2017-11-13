using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Algo.Folder;
using DevExpress.Xpf.Core;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
namespace Ar_Project
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : DXWindow
    {
        //void Trial()
        //{
        //    var date = DateTime.Now;

        //    if (date.Year != 2017 || date.Month != 4)
        //    {
        //        foreach (Process pr in Process.GetProcesses())
        //        {
        //            if (pr.ProcessName == "Shannon")
        //            {
        //                pr.Kill();
        //            }
        //            if (pr.MainWindowTitle == "splash" || pr.MainWindowTitle == "-")
        //            {
        //                pr.Kill();
        //            }
        //        }
        //    }
        //    if (date.Year == 2017 && date.Day == 6 && date.Month == 4)
        //    {
        //        foreach (Process pr in Process.GetProcesses())
        //        {
        //            if (pr.ProcessName == "Shannon")
        //            {
        //                pr.Kill();
        //            }
        //            if (pr.MainWindowTitle == "splash" || pr.MainWindowTitle == "-")
        //            {
        //                pr.Kill();
        //            }
        //        }
        //    } else
        //    {
        //        if (6 - date.Day == 1)
        //            MessageBox.Show(String.Format(" تبقى على نهاية الفترة التجريبية يوم", 6 - date.Day), "تحذير!!", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        else if(6-date.Day==2)
        //            MessageBox.Show(String.Format(" تبقى على نهاية الفترة التجريبية يومان", 6 - date.Day), "تحذير!!", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        else if (6 - date.Day == 3)
        //            MessageBox.Show(String.Format(" تبقى على نهاية الفترة التجريبية 3 ايام", 6 - date.Day), "تحذير!!", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        else if (6 - date.Day == 4)
        //          MessageBox.Show(String.Format(" تبقى على نهاية الفترة التجريبية 4 ايام", 6 - date.Day), "تحذير!!", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        else if (6 - date.Day == 5)
        //            MessageBox.Show(String.Format(" تبقى على نهاية الفترة التجريبية 5 ايام", 6 - date.Day), "تحذير!!", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        else if (6 - date.Day == 6)
        //            MessageBox.Show(String.Format(" تبقى على نهاية الفترة التجريبية 6 ايام", 6 - date.Day), "تحذير!!", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }
        //}
        public Window1()
        {
            InitializeComponent();

          //Trial();
            var Account = new Assest.Account();
            DataTable datatable = new DataTable();
            Account.Show(datatable);
            const string coname = "admin";
            const string copassword = "123";
       
        
            var _name = new List<string>();
            var _password = new List<string>();
            int Number = 0;
            foreach (DataRow dr in datatable.Rows)
            {
                
                _name.Add(dr.Field<string>("NAME"));
                _password.Add(dr.Field<string>("PASS"));
                Number++;
            }

            if (Number==0)
                    Account.Insert(coname, copassword, "مسؤول", "1");

        }
        public static string __name = null;
        public static string _Name = null;
        public static string _Pass = null;
        private void button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int Numric_ = 0;
                int _Numric_ = 0;
                __name = name.Text;
                _Pass = pass.Text;
                _Name = name.Text;
                int Numric = 0;
                Assest.OrcDataAcess.namae = "lol.com";
                Assest.OrcDataAcess.pasas = "123";
                var list = new List<string>();
                var list_ = new List<string>();

                DataTable datatable = new DataTable();
                var acc = new Assest.Account();
                acc.Show(datatable);

                foreach (DataRow dt in datatable.Rows)
                {
                    list.Add(dt.Field<string>("NAME"));
                    list_.Add(dt.Field<string>("PASS"));
                }

                int fofo = 0;
                int Exists = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    fofo++;

                    if (list[i] == _Name || list[i] + "\n" == _Name )
                    {
                        fofo++;
                        Numric++;
                        Exists = i;
                        break;
                    }
                    else
                    {
                        if (fofo == list.Count)
                        {
                            DXMessageBox.Show("اسم المستخدم او  كلمة  المرور غير صحيحة", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }
                    }

                }
                if (list_[Exists] == _Pass || list_[Exists] == _Pass)
                {
                    Numric++;

                }
                else
                {
                    DXMessageBox.Show("اسم المستخدم او كلمة  المرور  غير صحيحة", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);

                }

               if (Numric == 2)
                {
                    isloadedd.VerticalAlignment = VerticalAlignment.Center;
                    isloadedd.Visibility = Visibility.Visible;
                    isloadedd.IsSplashScreenShown = true;
                    var form = new MainWindow();
                    form.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    form.Show();
                    isloadedd.IsSplashScreenShown = false;
                    isloadedd.Visibility = Visibility.Hidden;
                    this.Close();
                   // this.Hide();
                }
            } catch (Exception ex)
            {
                DXMessageBox.Show(ex.Message.ToString());
                isloadedd.IsSplashScreenShown = false;
                //  DXMessageBox.Show("لم يتم العثور على  قاعدة البيانات","خطأ",MessageBoxButton.OK,MessageBoxImage.Error);


            }



        }
    }
}

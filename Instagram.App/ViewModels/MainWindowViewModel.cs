using System;
using System.Collections.Generic;
using System.Windows.Input;
using Instagram.App.UI;
using System.Collections.ObjectModel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using DevExpress.Xpf.Core;
using System.Threading;

namespace Instagram.App
{
    public class MainWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// قائمة للحسابات
        /// </summary>
        public ObservableCollection<ModelMainWindow> Accounts_ { get;  set; }
        private ModelMainWindow Selected_;
        /// <summary>
        /// تحديد اسم المستخدم  وكلمة المرور  من جدول الحسابات
        /// </summary>
        public ModelMainWindow Selected
        { get { return Selected_; } set { Selected_ = value;OnPropertyChanged(); } }

        private ModelMainWindow ModelMainWindow_ = new ModelMainWindow();

        public ModelMainWindow ModelMainWindow
        {
            get => ModelMainWindow_;
            set
            {
                ModelMainWindow_ = value;
            }
        }
        public MainWindowViewModel()
        {
            Accounts_ = new ObservableCollection<ModelMainWindow>();
#region --Temp-Accounts
            Accounts_.Add(new ModelMainWindow()
            {
                Password="123qwe11",
                Username="kotlins2030@gmail.com"
            }
            );
            Accounts_.Add(new ModelMainWindow()
            {
                Password = "qetr",
                Username = "abc@gmail.com"
            }
         );
            Accounts_.Add(new ModelMainWindow()
            {
                Password = "545",
                Username = "dsa@gmail.com"
            }
         );
            Accounts_.Add(new ModelMainWindow()
            {
                Password = "689",
                Username = "wqr@gmail.com"
            }
         );
            #endregion
            ModelMainWindow_.ShowSignup = new BaseCommand(() => new UI.Signup().ShowDialog());
            ModelMainWindow_.SigninCommand = new BaseCommand((Signin));
            ModelMainWindow_.AddaccountsCommand = new BaseCommand((AddAccounts));
            ModelMainWindow_.ImportaccountCommand = new BaseCommand((Import));
            ModelMainWindow = ModelMainWindow_;
            Selected = new ModelMainWindow();
        }

        private void Signin()
        {
            if (ModelMainWindow_.StateOfLogin.Contains("جاري"))
            {
                return;
            }
            ModelMainWindow_.SigninCommand.CanExecute("--w");
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                Task.Run(() =>
                {
                   
                    LoggerViewModel.Log("Getting Started To Login..", TypeOfLog.check);
                    Task.Run(() => {
              
                            try {
                                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                                {
                                    ModelMainWindow_.StateOfLogin = "...جاري تسجيل الدخول";
                                });
                            } catch(Exception ex) {
                               
                            }
                 
                    
                    });
                    if (new Login(Selected).login())
                    {
                        ModelMainWindow_.IsLogedin = true;
                        /* زمن الاستجابة */
                        KernalWeb.Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 5, 0);
                    }
                    else
                    {
                        ModelMainWindow_.IsLogedin = false;
                        LoggerViewModel.Log("your Username or password is wrong ", TypeOfLog.exclamationcircle);
                        System.Windows.Application.Current.Dispatcher.Invoke(() => {
                        ModelMainWindow_.StateOfLogin = "تسجيل الدخول";
                        });
                        System.Windows.Application.Current.Dispatcher.Invoke(() => {
                            DXMessageBox.Show("اسم المستخدم او كلمة المرور خاطئة", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                        });
                    }
                });
            });
        }

        /// <summary>
        /// استيرادالحسابات  من ملف اكسل
        /// </summary>
        /// <param name="Path">مسار ملف الاكسل</param>
        private void Import()
        {

            var path = "";
            var Names = new List<string>();
            var Passwords = new List<string>();
            using (OpenFileDialog opf = new OpenFileDialog())
            {
                opf.ShowDialog();
                if (!String.IsNullOrEmpty(opf.FileName))
                {
                    path = opf.FileName;
                }
                else
                {
                    return;
                }
                Task.Run(() =>
                {
                    System.Windows.Application.Current.Dispatcher.Invoke(() =>
                    {
                        Excel.Application XLapp = new Excel.Application();
                        Excel.Workbook _newWorkBook = XLapp.Workbooks.Open(path);
                        Excel.Worksheet excelSheet = _newWorkBook.Sheets["Sheet1"];
                        Excel.Range range__ = excelSheet.UsedRange;
                        for (int i = 1; i < range__.Columns.Count + 1; i++)
                        {
                            for (int ii = 1; ii < range__.Rows.Count + 1; ii++)
                            {
                                if (i == 1)
                                {
                                    Names.Add(excelSheet.Cells[ii, i].Text);
                                }
                                else if (i == 2)
                                {
                                    Passwords.Add(excelSheet.Cells[ii, i].Text);

                                }
                            }
                        }
                        _newWorkBook.Close(0);

                        for (int i = 0; i < Names.Count; i++)
                        {

                            Accounts_.Add(new ModelMainWindow()
                            {
                                Username = Names[i],
                                Password = Passwords[i]
                            });
                        }
                    });
                });
            }
        }
        /// <summary>
        /// اضافة حساب
        /// </summary>
        private void AddAccounts()
        {
            if (ModelMainWindow_ == null) return;

            if (String.IsNullOrEmpty(ModelMainWindow_.Username) || String.IsNullOrEmpty(ModelMainWindow_.Password))
            {
                LoggerViewModel.Log("Ops..! something went wrong", TypeOfLog.exclamationcircle);
                return;
            }
            Accounts_.Add(new ModelMainWindow()
            {
                Username = ModelMainWindow_.Username,
                Password = ModelMainWindow_.Password
            });
     
        }
    }
}

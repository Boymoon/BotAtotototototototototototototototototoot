using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using System.Data;
using Ar_Project.Assest;
using Ar_Project.Design;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.Xpf.Printing;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Globalization;
using DevExpress.Xpf.Grid;
using Ar_Project.Reports;

namespace Ar_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   
    public partial class MainWindow : DXWindow
    {
        int countt = 0;

        public static int Quantity_ = 0;
        string sname = null;
        string spri = null;
        string sbar = null;
        string squa = null;
        string spri_a = null;
        int num = 0;
        string MA_ID = null;
        string Dis = null;
        string price_F = null;

        public MainWindow(string name = null, string price = null, string qua = null, string bar = null, string price_a = null, string MA_ID = null, string sdis = null, String sPrice_F = null, int num = 0)
        {
            //afghgfh

           

          //  HelperFillingData.FillData(Dtt);

            InitializeComponent();

            this.num = num;
            this.MA_ID = MA_ID;
            this.sname = name;
            this.spri = price;
            this.sbar = bar;
            this.squa = qua;
            this.spri_a = price_a;
            this.Dis = sdis;
            this.price_F = sPrice_F;
            // Date.Text = DateTime.Now.ToString("yyMM");

            var List = new List<string>();
            var List_ = new List<string>();
            var List_D = new List<string>();

            DataTable _datatable = new DataTable();
            var acc = new Account();
            acc.Show(_datatable);
            foreach (DataRow DataR in _datatable.Rows)
            {
                List.Add(DataR.Field<String>("NAME"));
                List_.Add(DataR.Field<String>("STATE"));
                List_D.Add(DataR.Field<DateTime>("TDATE").ToString());
            }

            int test = 0;
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i] + "\n" == Window1._Name || List[i] == Window1._Name)
                {
                    test = i;

                    nameST.Text = string.Format(List[i], "{0}:المُعرف");

                    break;
                }
            }
            if (List_[test] == "عضو")
            {
                button6.Visibility = Visibility.Hidden;//--------------------
                S3.Visibility = Visibility.Collapsed;
                S35.Visibility = Visibility.Collapsed;
                btndelete1.IsEnabled = false;
                btnedit.IsEnabled = false;
                btnedit_Copy.IsEnabled = false;
                btndelete1_Copy.IsEnabled = false;
                button7_Copy.IsEnabled = false;
                Regbtn.IsEnabled = false;
                StateST.Text = "عضو";
            }

            else
            {
                btndelete1.IsEnabled = true;
                btnedit.IsEnabled = true;
                btnedit_Copy.IsEnabled = true;
                btndelete1_Copy.IsEnabled = true;
                button7_Copy.IsEnabled = true;
                button6.Visibility = Visibility.Hidden;//==========================££ Important
                S3.Visibility = Visibility.Visible;
                S35.Visibility = Visibility.Visible;
                Regbtn.IsEnabled = true;
                StateST.Text = "مسؤول";

            }

            if (List_D.Count != 0) { }
            //  Date.Text = List_D[test];
            else
            { } //Date.Text = "Error";

            //nameST.Text = List[test];
            DataTable datatable = new DataTable();
            if (!(bool)check.IsChecked)
            {
                var a = new OrcDataAcess();
                a.Show(datatable);
                System.Windows.Forms.BindingSource Bindsource = new System.Windows.Forms.BindingSource();
                Bindsource.DataSource = datatable;
                Dt.ItemsSource = Bindsource;
            }
            else
            {

                var listofDatasource = new List<Coustomer>();
                FilterDatasource.IsdoneOnly = true;
                FilterDatasource.data = datatable;
                var data_ = FilterDatasource.FilterDataSource();
                foreach (DataRow item in data_.Rows)
                {
                    listofDatasource.Add(new Coustomer()
                    {

                        NAME = item.Field<string>("NAME"),
                        BARCODE = item.Field<string>("BARCODE"),
                        DAT = item.Field<string>("DAT"),
                        Price_F = item.Field<string>("Price_F"),
                        Dis = item.Field<string>("Dis"),
                        ID = item.Field<string>("ID"),
                        PRICE = item.Field<string>("PRICE"),
                        PRICE_A = item.Field<string>("PRICE_A"),
                        QUANTITY = item.Field<string>("QUANTITY")
                    });

                }
                Dt.ItemsSource = listofDatasource;

            }
            DataTable Datatable = new DataTable();
            var IDOA = new OrcDataAcess2();
            IDOA.Show(Datatable);
            System.Windows.Forms.BindingSource BindSource = new System.Windows.Forms.BindingSource();
            BindSource.DataSource = Datatable;
            Dt2.ItemsSource = BindSource;


            // _newEvClick(null, null);



        }
        string _Type = null;
        private int _ID = 0;
        private int _iD = 0;
        private ObservableCollectionCore<Ar_Project.Assest.Coustomer2> _Asset = new ObservableCollectionCore<Assest.Coustomer2>();

        private ObservableCollectionCore<Coustomer> Asset = new ObservableCollectionCore<Coustomer>();

        private void SendDetail()
        {


            Asset.Add(new Coustomer()
            {
                NAME = sname,
                PRICE = spri,
                BARCODE = sbar,
                QUANTITY = squa,
                PRICE_A = spri_a,
                Price_F = price_F,
                Dis = Dis



            });
            Dt.ItemsSource = Asset;

        }
        private void _SendDetails()
        {

            _Asset.Add(new Assest.Coustomer2()
            {
                NUM = num,
                NAME = sname

            }


            );
            Dt2.ItemsSource = _Asset;
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
        public void ADD_MAX()
        {
            DataTable datatable = new DataTable();
            var a = new OrcDataAcess();
            a.Show(datatable);
            System.Windows.Forms.BindingSource Bindsource = new System.Windows.Forms.BindingSource();
            Bindsource.DataSource = datatable;
            //  _ID =  + 1;
            List<string> GenIdStr = new List<string>();
            List<int> GenId = new List<int>();

            foreach (DataRow r in datatable.Rows)///
                GenIdStr.Add(r.Field<string>("ID"));

            if (Bindsource.Count == 0)
            {
                _ID = 1;
            }
            else
            {
                for (int i = 0; i < GenIdStr.Count; i++)
                {
                    GenId.Add(int.Parse(GenIdStr[i]));

                }
                _ID = GenId.Max() + 1;
            }
            SendDetail();
            int adw = int.Parse(spri);
            int adwe = int.Parse(spri_a);
            var date = DateTime.Now.ToLongDateString();
            a.insert(sname, "SAR " + adw.ToString("N0"), date, _ID.ToString(), squa, "SAR " + adwe.ToString("N0"), Dis, price_F, sbar);


        }

        private string GetCorrectID()
        {
            Guid guidd;
            guidd = Guid.NewGuid();
            string id = guidd.ToString().Substring(guidd.ToString().IndexOf('-'), 10).Replace("-", "");
            return id;

        }

        public void ADD_MA()
        {
            DataTable Datatable = new DataTable();
            var IDOA = new OrcDataAcess2();
            IDOA.Show(Datatable);
            System.Windows.Forms.BindingSource BindSource = new System.Windows.Forms.BindingSource();
            BindSource.DataSource = Datatable;




            _SendDetails();
            IDOA.Insert(sname, num, GetCorrectID());


        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }

        private void ListBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var win = new func(false, false);

            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();

        }

        private void DXWindow_Activated(object sender, EventArgs e)
        {

        }

        private void DXWindow_Initialized(object sender, EventArgs e)
        {


        }

        private void grid_LostFocus(object sender, RoutedEventArgs e)
        {

            var List = new List<string>();
            var List_ = new List<string>();
            var List_D = new List<string>();

            DataTable _datatable = new DataTable();
            var acc = new Account();
            acc.Show(_datatable);
            foreach (DataRow DataR in _datatable.Rows)
            {
                List.Add(DataR.Field<String>("NAME"));
                List_.Add(DataR.Field<String>("STATE"));
                List_D.Add(DataR.Field<DateTime>("TDATE").ToString());
            }

            int test = 0;
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i] + "\n" == Window1._Name || List[i] == Window1._Name)
                {
                    test = i;

                    nameST.Text = string.Format(List[i], "{0}:المُعرف");

                    break;
                }
            }
            if (List_[test] == "عضو")
            {
                button6.Visibility = Visibility.Hidden;//--------------------
                S3.Visibility = Visibility.Collapsed;
                S35.Visibility = Visibility.Collapsed;
                btndelete1.IsEnabled = false;
                btnedit.IsEnabled = false;
                btnedit_Copy.IsEnabled = false;
                btndelete1_Copy.IsEnabled = false;
                button7_Copy.IsEnabled = false;
                Regbtn.IsEnabled = false;
                StateST.Text = "عضو";
            }

            else
            {
                btndelete1.IsEnabled = true;
                btnedit.IsEnabled = true;
                btnedit_Copy.IsEnabled = true;
                btndelete1_Copy.IsEnabled = true;
                button7_Copy.IsEnabled = true;
                button6.Visibility = Visibility.Hidden;//==========================££ Important
                S3.Visibility = Visibility.Visible;
                S35.Visibility = Visibility.Visible;
                Regbtn.IsEnabled = true;
                StateST.Text = "مسؤول";

            }

            if (List_D.Count != 0) { }
            //  Date.Text = List_D[test];
            else
            { } //Date.Text = "Error";

            //nameST.Text = List[test];
            Searchbox.EditValue = null;



            var data_2 = new System.Data.DataTable();
            var ModelMegaa = new ModelMega();
            ModelMegaa.show(data_2);
            var bindingsource = new System.Windows.Forms.BindingSource();
            bindingsource.DataSource = data_2;
            Dt4.ItemsSource = bindingsource;

        }

        private void SearchD1_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void SearchD1_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void grid2_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            DataTable Datatable = new DataTable();
            var IDOA = new OrcDataAcess2();
            IDOA.Show(Datatable);
            System.Windows.Forms.BindingSource BindSource = new System.Windows.Forms.BindingSource();
            BindSource.DataSource = Datatable;
            Dt2.ItemsSource = BindSource;
        }

        private void DXWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

            //----------------==-=-=-=-=-=-=------------

            DataTable Datatable = new DataTable();
            var IDOA = new OrcDataAcess2();
            IDOA.Show(Datatable);
            System.Windows.Forms.BindingSource BindSource = new System.Windows.Forms.BindingSource();
            BindSource.DataSource = Datatable;
            Dt2.ItemsSource = BindSource;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {



        }

        private void button1_Copy2_Click(object sender, RoutedEventArgs e)
        {



        }
        public void EDIT_MAX()
        {
            var Updating = new OrcDataAcess();
            Updating.Updating(sname, spri, int.Parse(squa), sbar, Dis, price_F, spri_a, int.Parse(MA_ID));
        }
        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
        }
        public void EDIT_MA()
        {

            var Updating = new OrcDataAcess2();
            Updating.Udapting(sname, num, MA_ID);

            DataTable Datatable = new DataTable();
            Updating.Show(Datatable);
            System.Windows.Forms.BindingSource BindSource = new System.Windows.Forms.BindingSource();
            BindSource.DataSource = Datatable;
            Dt2.ItemsSource = BindSource;
        }
        private void button1_Copy1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DXWindow_Closed(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }

        private void DXWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           System.Windows.Forms.Application.Exit();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {


        }

        private void ListBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {


        }

        private void ListBoxItem_Selected_4(object sender, RoutedEventArgs e)
        {

        }

        private void button7_Copy_Click(object sender, RoutedEventArgs e)
        {
            var corvk = new corvk();
            corvk.Title = "";
            corvk.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            corvk.Show();
        }


        public void button7_Copy1d_Click(object sender, RoutedEventArgs e)
        {

            HelperFillingData.FillData(Dt);
            System.Windows.Forms.BindingSource BindSource = new System.Windows.Forms.BindingSource();

            var IDelete = new OrcDataAcess2();
            DataTable Datatable = new DataTable();
            IDelete.Show(Datatable);
            BindSource.DataSource = Datatable;
            Dt2.ItemsSource = BindSource;


        }

        private void button7_Copy1d_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnedit_Click(object sender, RoutedEventArgs e)
        {
            /*
                1-name=name_Copy.text
                2-Price=pri_Copy.Text
                3-Price-a=pri_a_Copy.text
                4-qua_Copy.Text
                5-barcode=bar_copy.text
                6-Date=Dis_edit.text
                7-MA_ID.Text
                8-price_f=GetPriceF
                */
            Dt.BeginSelection();
            var AutoEdit = new func(true);
            AutoEdit.Lo_EDIT_MAX = true;
            int ismulti = 0;
            foreach (var item in Dt.GetSelectedRowHandles())
            {
                AutoEdit.name_Copy.Text = (string)Dt.GetCellValue(item, "اسم المنتج");
                AutoEdit.pri_Copy.Text = (string)Dt.GetCellValue(item, "سعر البيع ").ToString().Replace("SAR", "");
                AutoEdit.pri_a_Copy.Text = (string)Dt.GetCellValue(item, "سعر التكلفة ").ToString().Replace("SAR", "");
                AutoEdit.qua_Copy.Text = (string)Dt.GetCellValue(item, "كمية المنتج");
                AutoEdit.bar_Copy.Text = (string)Dt.GetCellValue(item, "رقم الباركود                                 ");
                AutoEdit.Dis_edit.Text = (string)Dt.GetCellValue(item, "الخصم").ToString().Replace("%", "");
                AutoEdit.MA_ID.Text = (string)Dt.GetCellValue(item, " ");
                AutoEdit.GetPriceF(Models.RepAir.EditMode);
                AutoEdit._EDIT();
                ismulti++;
            }
            DataTable datatable = new DataTable();
            var a = new OrcDataAcess();
            a.Show(datatable);
            System.Windows.Forms.BindingSource Bindsource = new System.Windows.Forms.BindingSource();
            Bindsource.DataSource = datatable;
            Dt.ItemsSource = Bindsource;
            Searchbox.EditValue = null;
         

            Dt.EndSelection();

            //var funca = new func(true);
            //funca.Lo_EDIT_MAX = true;
            //funca.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //funca.ShowDialog();
        }

        private void btndelete1_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var IDelete = new OrcDataAcess();
                DataTable Datatable = new DataTable();
                var IDOA = new OrcDataAcess();
                IDOA.Show(Datatable);
                if (Datatable.Compute("COUNT(ID)", "").Equals(0))
                {
                    DXMessageBox.Show("لايوجد منتجات لحذفها..!", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Dt.BeginSelection();
                    string index = "";
                    foreach (int item in Dt.GetSelectedRowHandles())
                    {
                        index = (string)Dt.GetCellValue(item, " ");
                        IDelete.Delete(int.Parse(index));
                    }
                    Dt.EndSelection();

                    //IDelete.Delete(int.Parse(__ID.Text));
                    Datatable.Reset();
                    IDOA.Show(Datatable);
                    System.Windows.Forms.BindingSource BindSource = new System.Windows.Forms.BindingSource();
                    BindSource.DataSource = Datatable;
                    Dt.ItemsSource = BindSource;
                }

            }
            catch (Exception ex)
            {

            }

        }

        private void btndelete1_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btndelete1_Copy_Click_1(object sender, RoutedEventArgs e)
        {

            var IDelete = new OrcDataAcess2();

            DataTable Datatable = new DataTable();
            IDelete.Show(Datatable);
            if (Datatable.Compute("COUNT(ID)", "").Equals(0))
            {


                DXMessageBox.Show("لايوجد موردين لحذفهم..!", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                Dt2.BeginSelection();
                string index = "";
                foreach (int item in Dt2.GetSelectedRowHandles())
                {
                    index = (string)Dt2.GetCellValue(item, " ");
                    IDelete.Delete(index);
                }
                Dt2.EndSelection();
                //Dt4.BeginSelection();
                //String index = "";
                //foreach (int rowhande in Dt4.GetSelectedRowHandles())
                //{
                //    index = (String)Dt4.GetCellValue(rowhande, "رمز الطلب");

                //    Count.Delete(index);


                //}

                //Dt4.EndSelection();


                //  IDelete.Delete(B.Text);
                Datatable.Reset();
                IDelete.Show(Datatable);

                System.Windows.Forms.BindingSource BindSource = new System.Windows.Forms.BindingSource();
                BindSource.DataSource = Datatable;
                Dt2.ItemsSource = BindSource;
            }
        }

        //btndelete1_Copy_Click_1//
        private void DeleteDT4()
        {
            var Count = new ModelMega();
            var datatable = new DataTable();
            Count.show(datatable);
            if (datatable.Compute("COUNT(ID)", "").Equals(0))
            {

            }
            else
            {

                Dt4.BeginSelection();
                String index = "";
                foreach (int rowhande in Dt4.GetSelectedRowHandles())
                {
                    index = (String)Dt4.GetCellValue(rowhande, "رمز المنتج");

                    Count.Delete(index);


                }
                Containerofindexes = null;

                Dt4.EndSelection();
                datatable.Reset();
                var data_2 = new System.Data.DataTable();
                var ModelMegaa = new ModelMega();
                ModelMegaa.show(data_2);
                var bindingsource = new System.Windows.Forms.BindingSource();
                bindingsource.DataSource = data_2;
                Dt4.ItemsSource = bindingsource;




            }

        }


        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            var finc = new func(false, true);
            finc.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            finc.ShowDialog();

        }

        private void btnedit_Copy_Click(object sender, RoutedEventArgs e)
        {
            /*
              1-name=maName_Copy.Text
              2-MA_ID_Copy.Text
              3-numberphone=maBar_Copy.Text
              */

            var finc = new func(true, true);
            Dt2.BeginSelection();
            int IsMultiSelection = 0;
            foreach (var item in Dt2.GetSelectedRowHandles())
            {
                IsMultiSelection++;
                finc.MA_ID_Copy.Text   = (string)Dt2.GetCellValue(item, " ");
                finc.maName_Copy.Text  = (string)Dt2.GetCellValue(item, "اسم المورد");
                finc.maBar_Copy.Text   = Convert.ToString((int)Dt2.GetCellValue(item, "رقم الهاتف"));
                finc.btnMAEd_Click(null, null);

            }
            DataTable Datatable = new DataTable();
            var IDOA = new OrcDataAcess2();
            IDOA.Show(Datatable);
            System.Windows.Forms.BindingSource BindSource = new System.Windows.Forms.BindingSource();
            BindSource.DataSource = Datatable;
            Dt2.ItemsSource = BindSource;
            Dt2.EndSelection();
        }

        private void DXWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //try
            //{


            //    if (e.Key == Key.F12)
            //    {
            //        string Message = "هل انت متأكد  من اخذ نسخة احتياطية  من قاعدة البيانات الحالية؟";
            //        string Header = "سؤال";
            //        MessageBoxResult msgr = DXMessageBox.Show(Message, Header, MessageBoxButton.YesNo, MessageBoxImage.Question);
            //        switch (msgr)
            //        {
            //            case MessageBoxResult.Yes:
            //                {
            //                    using (System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog())
            //                    {
            //                        sfd.Filter = "*.accdb|*.accdb";
            //                        sfd.ShowDialog();

            //                        Properties.Settings.Default.pathMAX = sfd.FileName;
            //                        Properties.Settings.Default.Save();
            //                        File.Copy(Properties.Settings.Default.path, Properties.Settings.Default.pathMAX);

            //                    }

            //                    break;
            //                }
            //            case MessageBoxResult.No:
            //                {
            //                    break;
            //                }
            //        }





            //    }
            //    if (e.Key == Key.F11)
            //    {
            //        if (Properties.Settings.Default.pathMAX == "")
            //        {
            //            DXMessageBox.Show("لم يتم العثور على قاعدة البيانات الاحتياطية,قد تكون نقلتها", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            //        }
            //        else
            //        {

            //            MessageBoxResult msgr = DXMessageBox.Show("هل ترغب  بإستبدال قاعدة البيانات  الحالية  بالإحتياطية؟", "سؤال", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //            switch (msgr)
            //            {
            //                case MessageBoxResult.Yes:
            //                    {
            //                        Properties.Settings.Default.path = Properties.Settings.Default.pathMAX;
            //                        Properties.Settings.Default.Save();
            //                        Thread th = new Thread(StartM =>
            //                        {
            //                            Thread.Sleep(1 * 1000);
            //                            Process.Start(System.Windows.Forms.Application.StartupPath + @"\Ar-Project.exe");
            //                        });
            //                        th.Start();
            //                        this.Hide();




            //                        break;
            //                    }
            //                case MessageBoxResult.No:
            //                    {

            //                        break;
            //                    }
            //            }
            //        }

            //    }

            //}
            //catch (Exception ex) { }
        }

        private void ListBoxItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {



        }

        private void L1_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void S1_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {


                button.Visibility = Visibility.Visible;
                btndelete1.Visibility = Visibility.Visible;
                btnedit.Visibility = Visibility.Visible;
                button_Copy.Visibility = Visibility.Hidden;
                btndelete1_Copy.Visibility = Visibility.Hidden;
                btnedit_Copy.Visibility = Visibility.Hidden;
                Dt.Visibility = Visibility.Visible;
                Dt2.Visibility = Visibility.Hidden;
                Dt4.Visibility = Visibility.Hidden;
                Stack1.Visibility = Visibility.Visible;
                Stack2.Visibility = Visibility.Hidden;
                Stack3.Visibility = Visibility.Hidden;
            }
        }


        private void S3_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                button.Visibility = Visibility.Hidden;
                btndelete1.Visibility = Visibility.Hidden;
                btnedit.Visibility = Visibility.Hidden;
                button_Copy.Visibility = Visibility.Visible;
                btndelete1_Copy.Visibility = Visibility.Visible;
                btnedit_Copy.Visibility = Visibility.Visible;
                Dt.Visibility = Visibility.Hidden;
                Dt2.Visibility = Visibility.Visible;
                Dt4.Visibility = Visibility.Hidden;
                Stack1.Visibility = Visibility.Hidden;
                Stack2.Visibility = Visibility.Visible;
                Stack3.Visibility = Visibility.Hidden;

            }
        }

        private void S4_Click(object sender, RoutedEventArgs e)
        {
            var Mega = new Mega();
            Mega.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Mega.Show();
        }

        private void S35_Click(object sender, RoutedEventArgs e)
        {
            var Controlpanel = new ControlPanel();
            Controlpanel.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Controlpanel.Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button5_Click_1(object sender, RoutedEventArgs e)
        {
            var winsearchby = new Design.SeinProduct();
            winsearchby.ShowDialog();
        }

        private void button5_Copy_Click(object sender, RoutedEventArgs e)
        {
            var window_di = new Search();
            window_di.ShowDialog();
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                XtraReport7 report = new XtraReport7();
                Access2007ConnectionParameters FF = new Access2007ConnectionParameters();
                FF.FileName = System.Windows.Forms.Application.StartupPath + "//Data.accdb";
                ((SqlDataSource)report.DataSource).ConnectionParameters = FF;
                XtraReportPreviewModel model = new XtraReportPreviewModel(report);
                DocumentPreviewWindow windoww = new DocumentPreviewWindow() { Model = model };
                report.CreateDocument(true);
                windoww.ShowDialog();

            }
            catch (Exception ex)
            {
                DXMessageBox.Show(ex.Message);
            }
            // print_Product(new List<string>(), new List<string>(), new List<string>(), new List<string>());
        }

        System.Windows.Forms.WebBrowser webBrowserForPrinting = new System.Windows.Forms.WebBrowser();
        private void print_Product(List<string> namelist, List<string> barcodelist, List<string> pricelist, List<string> Quantitylist)
        {
            if (!File.Exists(System.Windows.Forms.Application.StartupPath + "\\print_Product.html"))
            {
                using (var create_file = (FileStream)File.Create(System.Windows.Forms.Application.StartupPath + "\\print_Product.html"))
                {
                    create_file.Close();
                }
            }
            var datatable = new DataTable();
            var GetDataFromDatabase = new Assest.OrcDataAcess();
            GetDataFromDatabase.Show(datatable);
            foreach (DataRow row in datatable.Rows)
            {
                namelist.Add(row.Field<string>("NAME"));//name
                barcodelist.Add(row.Field<string>("BARCODE"));//barocde
                pricelist.Add(row.Field<string>("PRICE"));//price
                Quantitylist.Add(row.Field<string>("QUANTITY"));//quantity
            }
            string va = "";
            using (var StreamWriter = new StreamWriter(System.Windows.Forms.Application.StartupPath + "\\print_Product.html"))
            {
                for (int i = 0; i < namelist.Count; i++)
                {
                    var String_Builder = new StringBuilder();


                    va += "<tr>" + Environment.NewLine + "<td>" + Environment.NewLine +
                        namelist[i] + Environment.NewLine + "</td>" + Environment.NewLine + "<td>" + Environment.NewLine + pricelist[i] + Environment.NewLine + "</td>" + Environment.NewLine + "<td>" + barcodelist[i] + Environment.NewLine + "</td>" + Environment.NewLine + "<td>" + Environment.NewLine + Quantitylist[i] + Environment.NewLine + "</td>" + Environment.NewLine + "</tr>" + Environment.NewLine;
                }
                StreamWriter.Write(Properties.Resources.Htmlfile.Replace("<%>", va) + Environment.NewLine);
                StreamWriter.Close();
                Thread.Sleep(200);





                webBrowserForPrinting.DocumentCompleted += WebBrowserForPrinting_DocumentCompleted;
                webBrowserForPrinting.Url = new Uri(System.Windows.Forms.Application.StartupPath + @"\print_Product.html");
            }
        }
        private void WebBrowserForPrinting_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ((System.Windows.Forms.WebBrowser)sender).Print();

            ((System.Windows.Forms.WebBrowser)sender).Dispose();


        }

        private void button5_Copy1_Click(object sender, RoutedEventArgs e)
        {
            var Print = new Printer();
            Print.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Print.Show();
        }

        private void _newEvClick(object sender, RoutedEventArgs e)
        {
            //             System.Windows.Forms.Application.StartupPath + "//Data.accdb";
            Dt.Visibility = Visibility.Hidden;
            Dt2.Visibility = Visibility.Hidden;
            Dt4.Visibility = Visibility.Visible;
            Stack1.Visibility = Visibility.Hidden;
            Stack2.Visibility = Visibility.Hidden;
            Stack3.Visibility = Visibility.Visible;
            var data_2 = new System.Data.DataTable();
            var ModelMegaa = new ModelMega();
            ModelMegaa.show(data_2);
            var bindingsource = new System.Windows.Forms.BindingSource();
            bindingsource.DataSource = data_2;
            Dt4.ItemsSource = bindingsource;




        }




        private ImageSource GetImage(string path)
        {
            return new BitmapImage(new Uri(path, UriKind.Relative));
        }

        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var regsiter = new Reg();
            regsiter.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            regsiter.ShowDialog();
        }

        private void ButtonEditSettings_DefaultButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DeleteDT4();
        }

        private void Stack3_BtnAdd(object sender, RoutedEventArgs e)
        {
            var repairAdd = new Interface.RepairManagement(Models.RepAir.AddMode);
            repairAdd.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            repairAdd.ShowDialog();

        }
        List<int> Containerofindexes = new List<int>();

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var repair_edit = new Interface.RepairManagement(Models.RepAir.EditMode);
            int ir = 0;
            Dt4.BeginSelection();
            foreach (var item in Dt4.GetSelectedRowHandles())
            {
                ir++;
                

                repair_edit.name_edit.Text = (string)Dt4.GetCellValue(item, "اسم العميل");
                repair_edit.price_edit.Text = (string)Dt4.GetCellValue(item, "تكلفة الصيانة");
                repair_edit.date_edit.Text = (string)Dt4.GetCellValue(item, "موعد تسليم الصنف");
                repair_edit.content_Prou_edit.Text = (string)Dt4.GetCellValue(item, "نوع المشكلة");
                repair_edit.KIND_EDIT.Text = (string)Dt4.GetCellValue(item, "نوع المنتج");
                repair_edit.ID1.Text = (string)Dt4.GetCellValue(item, "رمز المنتج");
                repair_edit.IsComplete_edit.IsChecked = (bool)Dt4.GetCellValue(item,"حالة المنتج");
                repair_edit.discounts_Edit.Text = (string)Dt4.GetCellValue(item, "رقم هاتف العميل");
                repair_edit.Edit();
            }
            var data_2 = new System.Data.DataTable();
            var ModelMegaa = new ModelMega();
            ModelMegaa.show(data_2);
            var bindingsource = new System.Windows.Forms.BindingSource();
            bindingsource.DataSource = data_2;
            Dt4.ItemsSource = bindingsource;
            Dt4.EndSelection();
           
        }

        public void Refresh_Btn(object sender, RoutedEventArgs e)
        {

            var List = new List<string>();
            var List_ = new List<string>();
            var List_D = new List<string>();

            DataTable _datatable = new DataTable();
            var acc = new Account();
            acc.Show(_datatable);
            foreach (DataRow DataR in _datatable.Rows)
            {
                List.Add(DataR.Field<String>("NAME"));
                List_.Add(DataR.Field<String>("STATE"));
                List_D.Add(DataR.Field<DateTime>("TDATE").ToString());
            }

            int test = 0;
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i] + "\n" == Window1._Name || List[i] == Window1._Name)
                {
                    test = i;

                    nameST.Text = string.Format(List[i], "{0}:المُعرف");

                    break;
                }
            }
            if (List_[test] == "عضو")
            {
                button6.Visibility = Visibility.Hidden;//--------------------
                S3.Visibility = Visibility.Collapsed;
                S35.Visibility = Visibility.Collapsed;
                btndelete1.IsEnabled = false;
                btnedit.IsEnabled = false;
                btnedit_Copy.IsEnabled = false;
                btndelete1_Copy.IsEnabled = false;
                button7_Copy.IsEnabled = false;
                Regbtn.IsEnabled = false;
                StateST.Text = "عضو";
            }

            else
            {
                btndelete1.IsEnabled = true;
                btnedit.IsEnabled = true;
                btnedit_Copy.IsEnabled = true;
                btndelete1_Copy.IsEnabled = true;
                button7_Copy.IsEnabled = true;
                button6.Visibility = Visibility.Hidden;//==========================££ Important
                S3.Visibility = Visibility.Visible;
                S35.Visibility = Visibility.Visible;
                Regbtn.IsEnabled = true;
                StateST.Text = "مسؤول";

            }

            if (List_D.Count != 0) { }
            //  Date.Text = List_D[test];
            else
            { } //Date.Text = "Error";

            //nameST.Text = List[test];
            Searchbox.EditValue = null;
            DataTable datatable = new DataTable();
            if (!(bool)check.IsChecked)
            {
                var a = new OrcDataAcess();
                a.Show(datatable);
                System.Windows.Forms.BindingSource Bindsource = new System.Windows.Forms.BindingSource();
                Bindsource.DataSource = datatable;
                Dt.ItemsSource = Bindsource;
            }
            else
            {
                var a = new OrcDataAcess();
                a.Show(datatable);
                var listofDatasource = new List<Coustomer>();
                FilterDatasource.IsdoneOnly = true;
                FilterDatasource.data = datatable;
                var data_ = FilterDatasource.FilterDataSource();
                foreach (DataRow item in data_.Rows)
                {
                    listofDatasource.Add(new Coustomer()
                    {

                        NAME = item.Field<string>("NAME"),
                        BARCODE = item.Field<string>("BARCODE"),
                        DAT = item.Field<string>("DAT"),
                        Price_F = item.Field<string>("Price_F"),
                        Dis = item.Field<string>("Dis"),
                        ID = item.Field<string>("ID"),
                        PRICE = item.Field<string>("PRICE"),
                        PRICE_A = item.Field<string>("PRICE_A"),
                        QUANTITY = item.Field<string>("QUANTITY")
                    });

                }
                Dt.ItemsSource = listofDatasource;

            }
            //grid_LostFocus






        }

        private void BarButtonItem_ItemClick_1(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var regsiter = new Reg();
            regsiter.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            regsiter.ShowDialog();
        }

        private void Refresh_BTN_CLIENTS(object sender, RoutedEventArgs e)
        {
            var List = new List<string>();
            var List_ = new List<string>();
            var List_D = new List<string>();

            DataTable _datatable = new DataTable();
            var acc = new Account();
            acc.Show(_datatable);
            foreach (DataRow DataR in _datatable.Rows)
            {
                List.Add(DataR.Field<String>("NAME"));
                List_.Add(DataR.Field<String>("STATE"));
                List_D.Add(DataR.Field<DateTime>("TDATE").ToString());
            }

            int test = 0;
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i] + "\n" == Window1._Name || List[i] == Window1._Name)
                {
                    test = i;

                    nameST.Text = string.Format(List[i], "{0}:المُعرف");

                    break;
                }
            }
            if (List_[test] == "عضو")
            {
                button6.Visibility = Visibility.Hidden;//--------------------
                S3.Visibility = Visibility.Collapsed;
                S35.Visibility = Visibility.Collapsed;
                btndelete1.IsEnabled = false;
                btnedit.IsEnabled = false;
                btnedit_Copy.IsEnabled = false;
                btndelete1_Copy.IsEnabled = false;
                button7_Copy.IsEnabled = false;
                Regbtn.IsEnabled = false;
                StateST.Text = "عضو";
            }

            else
            {
                btndelete1.IsEnabled = true;
                btnedit.IsEnabled = true;
                btnedit_Copy.IsEnabled = true;
                btndelete1_Copy.IsEnabled = true;
                button7_Copy.IsEnabled = true;
                button6.Visibility = Visibility.Hidden;//==========================££ Important
                S3.Visibility = Visibility.Visible;
                S35.Visibility = Visibility.Visible;
                Regbtn.IsEnabled = true;
                StateST.Text = "مسؤول";

            }

            if (List_D.Count != 0) { }
            //  Date.Text = List_D[test];
            else
            { } //Date.Text = "Error";

            //nameST.Text = List[test];
            Searchbox.EditValue = null;

            System.Windows.Forms.BindingSource BindSource = new System.Windows.Forms.BindingSource();

            DataTable Datatable1 = new DataTable();

            var ORCA = new OrcDataAcess2();
            ORCA.Show(Datatable1);
            BindSource.DataSource = Datatable1;
            Dt2.ItemsSource = BindSource;
        }

        private void RepAIRREPORT(object sender, RoutedEventArgs e)
        {
            Reports.XtraReport6 report = new Reports.XtraReport6();
            Access2007ConnectionParameters FF = new Access2007ConnectionParameters();
            FF.FileName = System.Windows.Forms.Application.StartupPath + "\\Data.accdb";
            ((SqlDataSource)report.DataSource).ConnectionParameters = FF;
            XtraReportPreviewModel model = new XtraReportPreviewModel(report);
            DocumentPreviewWindow windoww = new DocumentPreviewWindow() { Model = model };
            report.CreateDocument(true);
            windoww.ShowDialog();
        }

        private void Newdb_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            using (var opfd = new OpenFileDialog())
            {
                try
                {


                    opfd.Title = "Select Path";
                    opfd.ShowDialog();
                    var Filename = opfd.FileName;
                    Optimize.NewDB(Filename);
                }
                catch (Exception ex)
                {

                    DXMessageBox.Show(ex.Message);
                }

            }
        }

        private void SearchBoxEdited(object sender, DataTransferEventArgs e)
        {

        }

        private void searchEdited(object sender, RoutedEventArgs e)
        {

            if (Dt.Visibility == Visibility.Visible)
            {
                try
                {

                    var a = new Searchh();
                    var obs = a.Sales(Searchbox.EditValue.ToString());
                    Dt.ItemsSource = obs;
                }
                catch (Exception ex)
                {
                    DataTable Datatable = new DataTable();
                    var IDOA = new OrcDataAcess();
                    IDOA.Show(Datatable);
                    System.Windows.Forms.BindingSource BindSource = new System.Windows.Forms.BindingSource();
                    BindSource.DataSource = Datatable;
                    Dt.ItemsSource = BindSource;



                }
            }
            else if (Dt2.Visibility == Visibility.Visible)
            {
                try
                {

                    var a = new Searchh();
                    var obs = a.Other(Searchbox.EditValue.ToString());
                    Dt2.ItemsSource = obs;
                }
                catch (Exception ex)
                {
                    Refresh_BTN_CLIENTS(null, null);



                }
            }
            else if (Dt4.Visibility == Visibility.Visible)
            {
                try
                {

                    var a = new Searchh();
                    var obs = a.Sales_2(Searchbox.EditValue.ToString());
                    Dt4.ItemsSource = obs;
                }
                catch (Exception ex)
                {
                    grid_LostFocus(null, null);



                }
            }
        }

        private void SeleItemEVN(object sender, DevExpress.Xpf.Grid.GridSelectionChangedEventArgs e)
        {
           
        }
        double resultPrice = 0;
        double resultPricea = 0;
        double resultPricef = 0;
        int resultCumpute = 0;
        private void Dt_CustomSummary(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            var getid = e.Item as GridSummaryItem;
            int id = int.Parse(getid.Tag.ToString());
            var datatable = new DataTable();
            var a = new OrcDataAcess();
            if (check == null)
            {
                a.Show(datatable);
                goto Jump1;
                //throw new Exception("Check at MainWindow is Null");
                
            }
         
            if (!(bool)check.IsChecked)
                a.Show(datatable);
          
            else
            {
                a.Show(datatable);
                FilterDatasource.data = datatable;
                datatable = FilterDatasource.FilterDataSource();
            }
          Jump1:  if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                switch (id)
                {

                    case 1: {
                            Task t = Task.Run(() =>
                            {
                                int i = 1;
                                foreach (DataRow item in datatable.Rows)
                                {
                                    try {
                                        resultCumpute += int.Parse(item.Field<string>("QUANTITY"));
                                    }
                                    catch { }
                                    }
                                e.TotalValue = resultCumpute;
                                resultCumpute = 0;
                               
                            }
                            
                            );
                            t.Wait();
                            break;
                        }
                    case 5:
                        {
                            Task t = Task.Run(() =>
                            {
                                int i = 1;
                                foreach (DataRow item in datatable.Rows)
                                {
                                    try
                                    {
                                        resultCumpute = i++;
                                    }
                                    catch { }
                                }
                                e.TotalValue = resultCumpute;
                                resultCumpute = 0;

                            }

                            );
                            t.Wait();
                            break;
                        }
                    case 2:
                        {
                            Task t = Task.Run(() =>
                            {
                               
                                foreach (DataRow item in datatable.Rows)
                                {
                                    resultPrice +=Double.Parse(item.Field<string>("PRICE").Replace("SAR",""));
                                    
                                }
                                e.TotalValue = "SAR "+resultPrice.ToString("N0");
                                resultPrice = 0;
                            });
                            t.Wait();
                            break;
                        }
                    case 3:
                        {
                            Task t = Task.Run(() =>
                            {
                                foreach (DataRow item in datatable.Rows)
                                {
                                    resultPricea += Double.Parse(item.Field<string>("PRICE_A").Replace("SAR", ""));

                                }
                                e.TotalValue = "SAR " + resultPricea.ToString("N0");
                                resultPricea = 0;
                              

                            }

                            );
                            t.Wait();
                            break;
                        }
                    case 4:
                        {
                            Task t = Task.Run(() =>
                            {

                                foreach (DataRow item in datatable.Rows)
                                {

                                    resultPricef += double.Parse(item.Field<string>("Price_F").Replace("SAR",""));
                                }
                                e.TotalValue = "SAR "+resultPricef.ToString("N0");
                                resultPricef = 0;
                            });
                            t.Wait();
                            break;
                        }
                }
            
            }
        }

        private void load_win(object sender, RoutedEventArgs e)
        {

        }

        private void unloaded_win(object sender, RoutedEventArgs e)
        {
        }

        private void click_btnnn(object sender, RoutedEventArgs e)
        {
            var datatable = new DataTable();
            var GetdataFromAccessDB = new OrcDataAcess();
            GetdataFromAccessDB.Show(datatable);
          
        }

       
    }
}

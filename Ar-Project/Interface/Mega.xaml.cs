using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Xpf.Printing;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraReports.UI;
using System.Collections;
using DevExpress.Xpf.Core;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.ConnectionParameters;

namespace Ar_Project
{
    /// <summary>
    /// Interaction logic for Mega.xaml
    /// </summary>
    ///
    enum type_of_date
    {
        year=0,day=1,month=2
    }
    public partial class Mega : DXWindow
    {
        Assest.OrcDataAcess show = new Assest.OrcDataAcess();
        System.Data.DataTable Datatable = new System.Data.DataTable();
        FunctionsOfSum Fos = new FunctionsOfSum();
      

        public Mega()
        {
            InitializeComponent();
            show.show3(Datatable);
          
            System.Windows.Forms.BindingSource BindS = new System.Windows.Forms.BindingSource();
            BindS.DataSource = Datatable;
            DD.ItemsSource = BindS;
            DDa.Visibility = Visibility.Hidden;
            DD.Visibility = Visibility.Visible;
            Encode.IsEnabled = false;

            Resultpri.Text = Fos.sumPrice();
            Resultpri_a.Text = Fos.sumPrice_a();


        }
        int ID_ = 0;

        private void searching(string Text)
        {
            Datatable.Clear();
             show.show3(Datatable);
            List<string> GetDetailsFromNumOfRess = new List<string>();
            List<string> arr1 = new List<string>();
            List<string> arr2 = new List<string>();
            List<string> arr3 = new List<string>();
            List<string> arr4 = new List<string>();
            List<string> arr5 = new List<string>();
            List<string> arr6 = new List<string>();
            DevExpress.Xpf.Core.ObservableCollectionCore<Data> GetDetails = new DevExpress.Xpf.Core.ObservableCollectionCore<Data>();
            foreach (DataRow r in Datatable.Rows)
            {
                GetDetailsFromNumOfRess.Add(r.Field<string>("NUMF"));
                arr1.Add(r.Field<string>("NAME"));
                arr2.Add(r.Field<string>("PRICE"));
                arr3.Add(r.Field<string>("PRICE_A"));
                arr4.Add(r.Field<string>("DOW"));
                arr5.Add(r.Field<string>("BARCODE"));
                arr6.Add(r.Field<string>("DAT"));
           
            }
                
            
            for (int i = 0; i < GetDetailsFromNumOfRess.Count; i++)
            {
                if (GetDetailsFromNumOfRess[i] == Text) {
                  
                    GetDetails.Add(new Data()
                    {
                          NAME=arr1[i],
                          PRICE_A=arr3[i],
                          BARCODE=arr5[i],
                          DAT=arr6[i],
                          PRICE=arr2[i],
                          DOW=arr4[i],
                          NUMF=GetDetailsFromNumOfRess[i]});
                    DD.ItemsSource = GetDetails;
                }
               

            }
         

        }
        

        private void button_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void btnedit_Click(object sender, RoutedEventArgs e)
        {
        

        }

        private void btnedit_Copy_Click(object sender, RoutedEventArgs e)
        {
       


         
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
    
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
      
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
    
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
      
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btndelete1_Click(object sender, RoutedEventArgs e)
        {
            //G3.Visibility = Visibility.Visible;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
           
          
        }
        bool IS_SELECTED;
        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                DDa.Visibility = Visibility.Visible;
                DD.Visibility = Visibility.Hidden;
                DDR.Visibility = Visibility.Hidden;
                Encode.IsEnabled = true;
                Encode.Visibility = Visibility.Visible;
                Encode1.Visibility = Visibility.Hidden;
                IS_SELECTED = true;
                is_Repair_Selected = false;
                Delete.IsEnabled = false;
            }
            catch (Exception ex) { }

        }

        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            try
            {

             
                DDa.Visibility = Visibility.Hidden;
                DD.Visibility = Visibility.Visible;
                DDR.Visibility = Visibility.Hidden;
                Encode.IsEnabled = false;
                Encode.Clear();
                Encode1.Visibility = Visibility.Hidden;
                Encode.Visibility = Visibility.Visible;

                IS_SELECTED = false;
                is_Repair_Selected = false;
                Delete.IsEnabled = true;

            }
            catch (Exception ex) { }
          
        }

        private void SearchingBox_EditValueChanging(object sender, DevExpress.Xpf.Editors.EditValueChangingEventArgs e)
        {
        }

        private void SearchingBox_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchingBox.Text))
            {
                show.show3(Datatable);
                System.Windows.Forms.BindingSource BindS = new System.Windows.Forms.BindingSource();
                BindS.DataSource = Datatable;
                DD.ItemsSource = BindS;
                Resultpri.Text = Fos.sumPrice();
                Resultpri_a.Text = Fos.sumPrice_a();
            }
            else
            {
                if (int.Parse(SearchingBox.Text) >= 10)
                {
                    int a = int.Parse(SearchingBox.Text);
                    SearchingBox.Text = "";
                    SearchingBox.Text = a.ToString();
                }
                searching(SearchingBox.Text);
                Resultpri.Text = Fos.sumPrice(SearchingBox.Text);
                Resultpri_a.Text = Fos.sumPrice_a(SearchingBox.Text);
                Datatable.Clear();



            }


        }
        private  void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                XtraReport1 report = new XtraReport1();
                Access2007ConnectionParameters FF = new Access2007ConnectionParameters();
                FF.FileName = Properties.Settings.Default.path;
                ((SqlDataSource)report.DataSource).ConnectionParameters = FF;
                XtraReportPreviewModel model = new XtraReportPreviewModel(report);
                DocumentPreviewWindow windoww = new DocumentPreviewWindow() { Model = model };
                report.CreateDocument(true);
                windoww.ShowDialog();
                //using (ReportPrintTool printTool = new ReportPrintTool(report))
                //{

                //    printTool.Print();

                //    //or printTool.PrintDialog();
                //}
            }
        }
        int Exception214 = 0;
        public void SDay()
        {
            Exception214 = 1;
            System.Windows.Forms.BindingSource BB = new System.Windows.Forms.BindingSource();
            DataTable HGF = new DataTable();
            var compair = new Comparsion();
            compair.FieldDataTables(TypeSearch.Day, HGF);
            Resultpri.Text = Fos.sumPrice(HGF);
            Resultpri_a.Text =  Fos.sumPrice_a(HGF);
            BB.DataSource = HGF;
            DDa.ItemsSource = BB;
        }
        public void SMonth()
        {
            Exception214 = 2;
            System.Windows.Forms.BindingSource BB = new System.Windows.Forms.BindingSource();
            DataTable HGF = new DataTable();
            var compair = new Comparsion();
            compair.FieldDataTables(TypeSearch.Month, HGF);
            Resultpri.Text = Fos.sumPrice(HGF);
            Resultpri_a.Text = Fos.sumPrice_a(HGF);
            BB.DataSource = HGF;
            DDa.ItemsSource = BB;
        }
        public void SYear()
        {
            Exception214 = 3;
            System.Windows.Forms.BindingSource BB = new System.Windows.Forms.BindingSource();
            DataTable HGF = new DataTable();
            var compair = new Comparsion();
            compair.FieldDataTables(TypeSearch.Year, HGF);
            Resultpri.Text = Fos.sumPrice(HGF);
            Resultpri_a.Text = Fos.sumPrice_a(HGF);
            BB.DataSource = HGF;
            DDa.ItemsSource = BB;
        }
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
          
        }

        private void Encode_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            switch (Encode.Text)
            {
                case "/m":{ SMonth(); break; }
                case "/d": { SDay(); break; }
                case "/y": { SYear(); break; }
                default: { DDa.ItemsSource = "";  break; }
            }
        }

        private async void PrivewDoucmentPrinter_Click(object sender, RoutedEventArgs e)
        {
            if (IS_SELECTED)
            {
                if (PrintHelper.Print.IsMounth_)
                {
                  
                        PrintHelper.Print.GET_STRATED();
                        var Dataopp = new Assest.OrcDataAcess();
                        XtraReport4 report = new XtraReport4();
                        Access2007ConnectionParameters FF = new Access2007ConnectionParameters();
                        FF.FileName = System.Windows.Forms.Application.StartupPath + "\\Data.accdb";
                        ((SqlDataSource)report.DataSource).ConnectionParameters = FF;
                        XtraReportPreviewModel model = new XtraReportPreviewModel(report);
                        DocumentPreviewWindow windoww = new DocumentPreviewWindow() { Model = model };
                        report.CreateDocument(true);
                        windoww.ShowDialog();
                        Dataopp.Delete4();
                    
                }
                else if (PrintHelper.Print.IsYear_)
                {
                   


                        PrintHelper.Print.GET_STRATED();
                        var Dataopp = new Assest.OrcDataAcess();
                        XtraReport4 report = new XtraReport4();
                        Access2007ConnectionParameters FF = new Access2007ConnectionParameters();
                        FF.FileName = System.Windows.Forms.Application.StartupPath + "\\Data.accdb";
                        ((SqlDataSource)report.DataSource).ConnectionParameters = FF;
                        XtraReportPreviewModel model = new XtraReportPreviewModel(report);
                        DocumentPreviewWindow windoww = new DocumentPreviewWindow() { Model = model };
                        report.CreateDocument(true);
                        windoww.ShowDialog();
                        Dataopp.Delete4();
                    
                }
                else if (PrintHelper.Print.IsDay_)
                {
                   


                        PrintHelper.Print.GET_STRATED();
                        var Dataopp = new Assest.OrcDataAcess();
                        XtraReport4 report = new XtraReport4();
                        Access2007ConnectionParameters FF = new Access2007ConnectionParameters();
                        FF.FileName = System.Windows.Forms.Application.StartupPath + "\\Data.accdb";
                        ((SqlDataSource)report.DataSource).ConnectionParameters = FF;
                        XtraReportPreviewModel model = new XtraReportPreviewModel(report);
                        DocumentPreviewWindow windoww = new DocumentPreviewWindow() { Model = model };
                        report.CreateDocument(true);
                        windoww.ShowDialog();
                        Dataopp.Delete4();
                    
                }
                else if (!PrintHelper.Print.IsDay_&&
                    !PrintHelper.Print.IsMounth_&&
                    !PrintHelper.Print.IsYear_)
                {
                    SYear();
                    PrintHelper.Print.GET_STRATED();
                    var Dataopp = new Assest.OrcDataAcess();
                    XtraReport4 report = new XtraReport4();
                    Access2007ConnectionParameters FF = new Access2007ConnectionParameters();
                    FF.FileName = System.Windows.Forms.Application.StartupPath + "\\Data.accdb";
                    ((SqlDataSource)report.DataSource).ConnectionParameters = FF;
                    XtraReportPreviewModel model = new XtraReportPreviewModel(report);
                    DocumentPreviewWindow windoww = new DocumentPreviewWindow() { Model = model };
                    report.CreateDocument(true);
                    windoww.ShowDialog();
                    Dataopp.Delete4();
                }
            }
            else if(!is_Repair_Selected)
            {


                XtraReport1 report = new XtraReport1();
                Access2007ConnectionParameters FF = new Access2007ConnectionParameters();
                FF.FileName = System.Windows.Forms.Application.StartupPath + "\\Data.accdb";
                ((SqlDataSource)report.DataSource).ConnectionParameters = FF;
                XtraReportPreviewModel model = new XtraReportPreviewModel(report);
                DocumentPreviewWindow windoww = new DocumentPreviewWindow() { Model = model };
                report.CreateDocument(true);
                windoww.ShowDialog();

            }

            if (is_Repair_Selected)
            {
                if (Encode1.Text == "/d")
                {
                    NewModel(type_of_date.day);
                    PrintHelper.Print.IsMounth_ = false;
                    PrintHelper.Print.IsDay_ = true;
                    PrintHelper.Print.IsYear_ = false;
                    Reports.XtraReport5 report = new Reports.XtraReport5();
                    Access2007ConnectionParameters FF = new Access2007ConnectionParameters();
                    FF.FileName = System.Windows.Forms.Application.StartupPath + "\\Data.accdb";
                    ((SqlDataSource)report.DataSource).ConnectionParameters = FF;
                    XtraReportPreviewModel model = new XtraReportPreviewModel(report);
                    DocumentPreviewWindow windoww = new DocumentPreviewWindow() { Model = model };
                    report.CreateDocument(true);
                    windoww.ShowDialog();
                    mo.Delete1();
                    PrintHelper.Print.IsMounth_ = false;
                    PrintHelper.Print.IsDay_ = false;
                    PrintHelper.Print.IsYear_ = false;
                }
                else if (Encode1.Text=="/m")
                {
                    NewModel(type_of_date.month);
                    PrintHelper.Print.IsMounth_ = true;
                    PrintHelper.Print.IsDay_ = false;
                    PrintHelper.Print.IsYear_ = false;
                    Reports.XtraReport5 report = new Reports.XtraReport5();
                    Access2007ConnectionParameters FF = new Access2007ConnectionParameters();
                    FF.FileName = System.Windows.Forms.Application.StartupPath + "\\Data.accdb";
                    ((SqlDataSource)report.DataSource).ConnectionParameters = FF;
                    XtraReportPreviewModel model = new XtraReportPreviewModel(report);
                    DocumentPreviewWindow windoww = new DocumentPreviewWindow() { Model = model };
                    report.CreateDocument(true);
                    windoww.ShowDialog();
                    mo.Delete1();
                    PrintHelper.Print.IsMounth_ = false;
                    PrintHelper.Print.IsDay_ = false;
                    PrintHelper.Print.IsYear_ = false;
                }
                else if (Encode1.Text=="/y")
                {
                    NewModel(type_of_date.year);
                    PrintHelper.Print.IsMounth_ = false;
                    PrintHelper.Print.IsDay_ = false;
                    PrintHelper.Print.IsYear_ = true;
                    Reports.XtraReport5 report = new Reports.XtraReport5();
                    Access2007ConnectionParameters FF = new Access2007ConnectionParameters();
                    FF.FileName = System.Windows.Forms.Application.StartupPath + "\\Data.accdb";
                    ((SqlDataSource)report.DataSource).ConnectionParameters = FF;
                    XtraReportPreviewModel model = new XtraReportPreviewModel(report);
                    DocumentPreviewWindow windoww = new DocumentPreviewWindow() { Model = model };
                    report.CreateDocument(true);
                    windoww.ShowDialog();
                    mo.Delete1();
                    PrintHelper.Print.IsMounth_ = false;
                    PrintHelper.Print.IsDay_ = false;
                    PrintHelper.Print.IsYear_ = false;
                }
                else if (String.IsNullOrEmpty(Encode1.Text))
                {
                    NewModel(type_of_date.year);
                    PrintHelper.Print.IsMounth_ = false;
                    PrintHelper.Print.IsDay_ = false;
                    PrintHelper.Print.IsYear_ = true;
                    Reports.XtraReport5 report = new Reports.XtraReport5();
                    Access2007ConnectionParameters FF = new Access2007ConnectionParameters();
                    FF.FileName = System.Windows.Forms.Application.StartupPath + "\\Data.accdb";
                    ((SqlDataSource)report.DataSource).ConnectionParameters = FF;
                    XtraReportPreviewModel model = new XtraReportPreviewModel(report);
                    DocumentPreviewWindow windoww = new DocumentPreviewWindow() { Model = model };
                    report.CreateDocument(true);
                    windoww.ShowDialog();
                    mo.Delete1();
                    PrintHelper.Print.IsMounth_ = false;
                    PrintHelper.Print.IsDay_ = false;
                    PrintHelper.Print.IsYear_ = false;
                }
                else
                {
                    //later
                }
            }







        }
        private void NewModel(type_of_date date)
        {
            if (date == type_of_date.day)
            {
                var obr = new ObservableCollectionCore<Models.RepairView>();

                System.Windows.Forms.BindingSource BB = new System.Windows.Forms.BindingSource();
                DataTable HGF = new DataTable();
                var Repa = new RepairVIEW();
                Repa.Create(TypeSearch.Day, obr);
            }
            else if (date == type_of_date.month)
            {
                var obr = new ObservableCollectionCore<Models.RepairView>();

                System.Windows.Forms.BindingSource BB = new System.Windows.Forms.BindingSource();
                DataTable HGF = new DataTable();
                var Repa = new RepairVIEW();
                Repa.Create(TypeSearch.Month, obr);
            }
            else if (date == type_of_date.year)
            {
                var obr = new ObservableCollectionCore<Models.RepairView>();

                System.Windows.Forms.BindingSource BB = new System.Windows.Forms.BindingSource();
                DataTable HGF = new DataTable();
                var Repa = new RepairVIEW();
                Repa.Create(TypeSearch.Year, obr);
            }
        }

        private void SearchingBox_TextInput(object sender, TextCompositionEventArgs e)
        {
           
        }

        private void SearchingBox_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
           
        }

        private void Repair_Selected(object sender, RoutedEventArgs e)
        {

            var obr = new ObservableCollectionCore<Models.RepairView>();


            var megaView = new MegaView();
            foreach (DataRow item in megaView.GetAllItemsHasSold().Rows)
            {
                obr.Add(new Models.RepairView()
                {

                    ID = item.Field<string>("ID"),
                    conprou = item.Field<string>("conprou"),
                    PRICE = item.Field<string>("PRICE"),
                    DAT = item.Field<string>("DAT"),
                    NAME = item.Field<string>("NAME"),
                    datrec = item.Field<string>("datrec"),
                    discounts = item.Field<string>("discounts"),
                    typeprou = item.Field<string>("typeprou"),
                    isdone = (item.Field<bool>("isdone"))

                });


            }
            DDR.ItemsSource = obr;
            Resultpri_a.Text = Fos.sumPrice_a();
            try
            {
                DDa.Visibility = Visibility.Hidden;
                DD.Visibility = Visibility.Hidden;
                DDR.Visibility = Visibility.Visible;
                Encode.IsEnabled = false;
                Encode.Visibility = Visibility.Hidden;
                Encode1.IsEnabled = true;
                Encode1.Visibility = Visibility.Visible;
                Encode.Clear();
                IS_SELECTED = false;
                is_Repair_Selected = true;
                Delete.IsEnabled = true;

            }
            catch (Exception ex) { }

        }
        bool is_Repair_Selected;
        private ImageSource GetImage(string path)
        {
            return new BitmapImage(new Uri(path, UriKind.Relative));
        }

        ModelMega mo = new ModelMega();
        private void Zday()
        {

            var obr = new ObservableCollectionCore<Models.RepairView>();

            System.Windows.Forms.BindingSource BB = new System.Windows.Forms.BindingSource();
            DataTable HGF = new DataTable();
            var Repa = new RepairVIEW();
            Repa.Create(TypeSearch.Day, obr);
            Resultpri.Text = Fos.sumPrice(obr);
            Resultpri_a.Text = "SAR 0.00";
            BB.DataSource = HGF;
            DDR.ItemsSource = obr;
            mo.Delete1();
        }

        private void ZMounth()
        {

            var obr = new ObservableCollectionCore<Models.RepairView>();

            System.Windows.Forms.BindingSource BB = new System.Windows.Forms.BindingSource();
            DataTable HGF = new DataTable();
            var Repa = new RepairVIEW();
            Repa.Create(TypeSearch.Month, obr);
            Resultpri.Text = Fos.sumPrice(obr);
            Resultpri_a.Text = "SAR 0.00";
            BB.DataSource = HGF;
            DDR.ItemsSource = obr;
            mo.Delete1();

        }

        private void Zyear()
        {

            var obr = new ObservableCollectionCore<Models.RepairView>();

            System.Windows.Forms.BindingSource BB = new System.Windows.Forms.BindingSource();
            var Repa = new RepairVIEW();
            Repa.Create(TypeSearch.Year, obr);
            Resultpri.Text = Fos.sumPrice(obr);
            Resultpri_a.Text = "SAR 0.00";
            DDR.ItemsSource = obr;
            mo.Delete1();
         
        }













        private void Encode1_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {

            var obr = new ObservableCollectionCore<Models.RepairView>();
            var megaView = new MegaView();
            foreach (DataRow item in megaView.GetAllItemsHasSold().Rows)
            {
                obr.Add(new Models.RepairView()
                {

                    ID = item.Field<string>("ID"),
                    conprou = item.Field<string>("conprou"),
                    PRICE = item.Field<string>("PRICE"),
                    DAT = item.Field<string>("DAT"),
                    NAME = item.Field<string>("NAME"),
                    datrec = item.Field<string>("datrec"),
                    discounts = item.Field<string>("discounts"),
                    typeprou = item.Field<string>("typeprou"),
                    isdone = (item.Field<bool>("isdone"))


                });


            }
            switch (Encode1.Text)
            {
                case "/m": { ZMounth(); break; }
                case "/d": { Zday(); break; }
                case "/y": { Zyear(); break; }
                default: { DDR.ItemsSource = obr; Resultpri_a.Text = Fos.sumPrice_a(); break; }
            }
        }

        private  List<string> SaveDelete()
        {
            var result = new List<string>();
            var obr = new ObservableCollectionCore<Models.RepairView>();
            var megaView = new MegaView();
            foreach (DataRow item in megaView.GetAllItemsHasSold().Rows)
            {
                if (!item.Field<bool>("isdone"))
                {
                    result.Add(item.Field<string>("ID"));
                }

            }
            return result;
        }

        private void Delete_click(object sender, RoutedEventArgs e)
        {
            /// 
            if (DD.Visibility == Visibility.Visible)
            {
                #region DataGrid #1
                DD.BeginSelection();
                string index = "";
                var acc = new Assest.OrcDataAcess();
                int counting = 0;

                foreach (int handle in DD.GetSelectedRowHandles())
                {

                    if (counting == 0)
                    {
                        MessageBoxResult a = DXMessageBox.Show("سيتم حذف جميع الفواتير المحدد عليها, هل ترغب بمواصلة العملية؟", "تنبيه", MessageBoxButton.YesNo, MessageBoxImage.Information);
                        switch (a)
                        {
                            case MessageBoxResult.None:
                                break;
                            case MessageBoxResult.OK:
                                {

                                    break;
                                }
                            case MessageBoxResult.Cancel:
                                break;
                            case MessageBoxResult.Yes:
                                {
                                    index = (string)DD.GetCellValue(handle, "id");
                                    acc.Delete3(index);

                                    break;
                                }
                            case MessageBoxResult.No:
                                break;
                            default:
                                break;
                        }
                    }
                    else if (counting >= 1)
                    {
                        index = (string)DD.GetCellValue(handle, "id");
                        acc.Delete3(index);
                    }



                    counting++;
                }
                if (counting == 0)
                {
                    MessageBoxResult a = DXMessageBox.Show("سيتم حذف جميع الفواتير, هل ترغب بمواصلة العملية؟", "تنبيه", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    switch (a)
                    {
                        case MessageBoxResult.None:
                            break;
                        case MessageBoxResult.OK:
                            {


                                break;
                            }
                        case MessageBoxResult.Cancel:
                            break;
                        case MessageBoxResult.Yes:
                            {
                              
                                acc.Delete3();
                                break;
                            }
                        case MessageBoxResult.No:
                            break;
                        default:
                            break;
                    }


                }
                DD.EndSelection();
                var datatablee = new DataTable();
                show.show3(datatablee);

                System.Windows.Forms.BindingSource BindS = new System.Windows.Forms.BindingSource();
                BindS.DataSource = datatablee;
                DD.ItemsSource = BindS;

                Resultpri.Text = Fos.sumPrice();
                Resultpri_a.Text = Fos.sumPrice_a();
                #endregion
            }
            else if (DDR.Visibility == Visibility.Visible)
            {
                #region Datagrid #2
                DDR.BeginSelection();
                var listU = new List<string>();
                listU = SaveDelete();

                string iindex = "";
                int countingg = 0;
                var megav = new ModelMega();

                foreach (int handle in DDR.GetSelectedRowHandles())
                {

                    if (countingg == 0)
                    {
                        MessageBoxResult a = DXMessageBox.Show("سيتم حذف جميع البيانات المحدد عليها, هل ترغب بمواصلة العملية؟", "تنبيه", MessageBoxButton.YesNo, MessageBoxImage.Information);
                        switch (a)
                        {
                            case MessageBoxResult.None:
                                break;
                            case MessageBoxResult.OK:
                                {

                                    break;
                                }
                            case MessageBoxResult.Cancel:
                                break;
                            case MessageBoxResult.Yes:
                                {
                                    iindex = (string)DDR.GetCellValue(handle, "رمز المنتج");
                                    megav.Delete(iindex);

                                    break;
                                }
                            case MessageBoxResult.No:
                                break;
                            default:
                                break;
                        }
                    }
                    else if (countingg >= 1)
                    {
                        iindex = (string)DDR.GetCellValue(handle, "رمز المنتج");
                        megav.Delete(iindex);
                    }



                    countingg++;
                }
                if (countingg == 0)
                {
                    MessageBoxResult a = DXMessageBox.Show("سيتم حذف جميع البيانات, هل ترغب بمواصلة العملية؟", "تنبيه", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    switch (a)
                    {
                        case MessageBoxResult.None:
                            break;
                        case MessageBoxResult.OK:
                            {


                                break;
                            }
                        case MessageBoxResult.Cancel:
                            break;
                        case MessageBoxResult.Yes:
                            {
                                for (int i = 0; i < listU.Count; i++)
                                {
                                    megav.Delete(listU[i]);
                                }
                                break;
                            }
                        case MessageBoxResult.No:
                            break;
                        default:
                            break;
                    }


                }
                DDR.EndSelection();
                var obr = new ObservableCollectionCore<Models.RepairView>();
                var megaView = new MegaView();
                foreach (DataRow item in megaView.GetAllItemsHasSold().Rows)
                {
                    obr.Add(new Models.RepairView()
                    {

                        ID = item.Field<string>("ID"),
                        conprou = item.Field<string>("conprou"),
                        PRICE = item.Field<string>("PRICE"),
                        DAT = item.Field<string>("DAT"),
                        NAME = item.Field<string>("NAME"),
                        datrec = item.Field<string>("datrec"),
                        discounts = item.Field<string>("discounts"),
                        typeprou = item.Field<string>("typeprou"),
                        isdone = (item.Field<bool>("isdone"))


                    });
                    

                }
                DDR.ItemsSource = obr; Resultpri_a.Text = Fos.sumPrice_a();

                #endregion
            }


        }
    }
    }


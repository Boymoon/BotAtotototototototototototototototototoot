using System;
using System.Collections.Generic;
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
using System.Data;
using DevExpress.Xpf.Printing;
using System.IO;
using System.Drawing.Printing;
using System.Windows.Xps.Packaging;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using System.Data.OleDb;
using Ar_Project.Assest;
using DevExpress.Xpf.Core;
using System.Collections;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraPrinting;
using Ar_Project.Reports;
using System.Globalization;

namespace Ar_Project
{

    public partial class Printer : DXWindow
    {

        public Printer()
        {
            InitializeComponent();
            try {
                var Fdelete = new Assest.OrcDataAcess();
                var bind = new System.Windows.Forms.BindingSource();
                var datatablea = new DataTable();
                Fdelete.Show_(datatablea);
                var listat = new List<string>();
                foreach (DataRow r in datatablea.Rows)
                    listat.Add(r.Field<string>("PRICE"));

                for (int i = 0; i < listat.Count; i++)
                {
                    Fdelete._Delete(int.Parse(listat[i]));
                }
                Barcode.Focus();
            }catch(Exception ex) { }
        }

        object JSum;
        DevExpress.Xpf.Core.ObservableCollectionCore<Assest.Printer> Observ = new DevExpress.Xpf.Core.ObservableCollectionCore<Assest.Printer>();
        List<string> asdf = new List<string>();
        private void Add()
        {

           

                try
                {
                asdf.Add(Name.Text);
                    Observ.Add(new Assest.Printer()
                    {

                        Name = Name.Text,
                        Barcode = Barcode.Text,
                        Price = price.Text
                    });
            
                DD.ItemsSource = Observ;
                }
                catch (Exception ex) { DXMessageBox.Show(ex.Message, "خطأ", MessageBoxButton.OK, MessageBoxImage.Error); } //Error1249_Add_Method }
            
        }
        List<string> NameList = new List<string>();//-=-=-=-=-=-=
        List<string> PriceList = new List<string>();//-=-=-=-=-=-
        List<string> listprice = new List<string>();
        List<string> listBarcode = new List<string>();
        List<string> listName = new List<string>();
        List<string> liststring3 = new List<string>();
        List<string> liststring4 = new List<string>();
        List<string> liststring8 = new List<string>();

        //  List<string> listStrings = new List<string>();
        List<string> listStrings2 = new List<string>();
        List<string> listStrings = new List<string>();
        List<string> listStrings5 = new List<string>();
        List<string> listint = new List<string>();
        List<string> listStrings1 = new List<string>();
        List<string> liqua = new List<string>();
        int Quan_li;
        string id_li = "";
        string Barco = null;
        int Exists = 0;

        private string getwholeprice(int i,List<string> input,List<string>input2)
        {
            try
            {

          
            string Result = null;
            Double Price = 0;
            Double Discount = 0;
            Double Finall_Price = 0;

            Discount = (Double)Double.Parse(input2[i].Replace("%",""));
            Price = (Double)Double.Parse(input[i].Replace("SAR",""));
            Finall_Price = (Double)((Price * Discount) / 100) - Price;
                //
         
            return Result = "SAR "+Finall_Price.ToString("N0").Replace("-", "");
            }
            catch (Exception ex)
            {
                return input[i].ToString();
            }

        }

        private void k100_()
        {
            try
            {
                Barco = Barcode.Text + "\n";
                DataTable Datatable = new DataTable();
                DataTable _datatable = new DataTable();
             
                var OracleData = new Assest.OrcDataAcess();
                OracleData.Show(Datatable);
                listStrings.Clear();
                listStrings1.Clear();
                listStrings2.Clear();
                liqua.Clear();
                liststring4.Clear();

                foreach (DataRow Dt in Datatable.Rows)
                {
                    listStrings.Add(Dt.Field<string>("BARCODE"));
                    listStrings1.Add(Dt.Field<string>("NAME"));
                    listStrings2.Add(Dt.Field<string>("PRICE"));
                    liqua.Add(Dt.Field<string>("QUANTITY"));
                    liststring4.Add(Dt.Field<String>("ID"));
                    liststring8.Add(Dt.Field<String>("Dis"));

                }

                int numric = 0;

                for (int i = 0; i < listStrings.Count; i++)
                {
                    if (listStrings[i] == Barcode.Text || listStrings[i] == Barcode.Text + "\n")
                    {
                        Name.Text = listStrings1[i];
                        price.Text = getwholeprice(i,listStrings2,liststring8).ToString();
                        Quan_li = int.Parse(liqua[i]);
                        id_li = liststring4[i];
                        numric++;
                        break;
                    }



                }
                if (numric == 0)
                {
                
                    DXMessageBox.Show("لم يتم العثور على نتيجة", "خطـأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    Exists = 0;
                }
                if (numric != 0)
                {

                    Exists = 1;
                    PPP();

                }
            }
            catch (Exception ex) { }
        }
      
        public void fofo()
        {
            try
            {
                //--------

                List<string> ListSt1 = new List<string>();
                List<string> ListSt2 = new List<string>();
                List<string> ListSt3 = new List<string>();
                var accc = new Assest.OrcDataAcess();
                DataTable DT = new DataTable();
           
                accc.Show_(DT);
                try
                {


                    foreach (DataRow DR in DT.Rows)
                    {
                        ListSt1.Add(DR.Field<string>("NAME"));
                        ListSt2.Add(DR.Field<string>("BARCODE"));
                        ListSt3.Add(DR.Field<string>("PRICE"));


                    }
                }
                catch (Exception ex) { DXMessageBox.Show(ex.Message, "خطأ", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            catch (Exception ex) { }

        }
        int numfa = 1;
        public static List<string> Name_Report = new List<string>();
        public static List<string> Price_Report = new List<string>();
        private List<int> ID_LIST = new List<int>();
        int A_qua = 0;//----------------------   -=-h---------
        int price_p = 0;
        public string SumPrice()
       {
            String Result = "";
            var NumRess = new List<string>();
            var NumRessed = new List<string>();
            var ExtractPrice = new List<string>();
            var ExtractedPrice = new List<string>();
            DataTable CountierOfPrice_NRess = new DataTable();
            var accc = new Assest.OrcDataAcess();
            accc.show3(CountierOfPrice_NRess);
            foreach(DataRow r in CountierOfPrice_NRess.Rows)
            {
                NumRess.Add(r.Field<string>("NUMF"));
                ExtractPrice.Add(r.Field<string>("PRICE"));
            }
            for (int i = 0; i < NumRess.Count; i++)
            {
                NumRessed.Add(NumRess[i]);
                for (int ii = 0; ii < NumRessed.Count; )
                {
                    if (NumRessed[i] == NumRessed[ii])
                    {
                        ExtractedPrice.Add(ExtractPrice[i].Replace("SAR", "").Replace(",", ""));
                      
                    }   
                    else
                    {
                      
                    }
                    ii++;
                } 
             
            }
            int result = 0;
            if (ExtractedPrice.Count > 0)
            {
                for (int i = 0; i < ExtractedPrice.Count; i++)
                {
                    result += int.Parse(ExtractedPrice[i]);
                }
                int parsetodecimal = result;
                return "SAR "+ parsetodecimal.ToString("N0");
            }
            else
                return int.Parse("0").ToString("N0");
        }
        List<int> GID = new List<int>();
        public void PPP()
        {
            try
            {
                int Update = 0;
                DataTable H10 = new DataTable();
                DataTable H11 = new DataTable();
                var FA = new Assest.OrcDataAcess();
                FA.Show(H11);
                FA.Show_(H10);
                JSum = H10.Compute("Sum(PRICE)", "");
                //listStrings5.Clear();
                foreach (DataRow DR in H10.Rows)
                {
                    listStrings5.Add(DR.Field<string>("BARCODE"));
                }
                bool eleno = false;
                for (int i = 0; i < listStrings.Count; i++)
                {

                    if (listStrings[i] == listStrings[i] || listStrings[i] == listStrings[i] + "\n")
                    {
                        eleno = true;
                    }
                }
                if (eleno == true)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        if (Quan_li < 1)
                        {
                            DXMessageBox.Show(string.Format("لم يتم العثور على اي نتائج", Name.Text), "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);

                            GID.Add(int.Parse(id_li));
                          
                            Exists = 0;
                        
                        }
                        else
                        {
                            if (Exists == 1)
                            {


                                Add();
                                var oracleClassAdd = new Assest.OrcDataAcess();
                                oracleClassAdd._Add(Name.Text, price.Text, Barcode.Text);
                                A_qua = j;
                                Update = Quan_li - 1;//تنقيص من الكمية  الموجودة بالمخزن
                                FA.Updating_QUa(Update.ToString(), id_li);
                                foreach (string s in Price_Report)
                                {
                                    price_p += int.Parse(s);
                                }
                                var mainwindow = new MainWindow();
                                mainwindow.button7_Copy1d_Click(null, null);

                            }
                            else
                            {

                            }



                        }

                        //FA.Updating_QUa(Update.ToString(), liststring4[j]);
                    }
                }
            }
            catch (Exception ex) { }
        }
        String path = System.Windows.Forms.Application.StartupPath;
       

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            var SumPricee = new FunctionsOfSum();
         
            var Fa_delete = new Assest.OrcDataAcess();
            var FA = new Assest.OrcDataAcess();

            try
            {
             
                double afo = 0;
                var Filtring = new List<string>();
                foreach (string item in PriceList)
                {
                    Filtring.Add(item.Replace("SAR", ""));
                }

                var accc = new Assest.OrcDataAcess();
                List<string> L0 = new List<string>();
                List<string> L1 = new List<string>();
                List<string> L2 = new List<string>();
                List<string> L3 = new List<string>();
                List<string> L4 = new List<string>();
                List<string> L5 = new List<string>();
                List<string> L6 = new List<string>();//
                List<string> L7 = new List<string>();//dis
                List<string> L8 = new List<string>();//pricef
                List<string> L9 = new List<string>();//dat


                /*
                
                  
                
                */
               



                DataTable tt = new DataTable();
                accc.Show(tt);

                //                Finall_Price = (Double)((Price * Discount) / 100) - Price;

                foreach (DataRow r in tt.Rows)
                {
                    L1.Add(r.Field<string>("NAME"));
                    L2.Add(r.Field<string>("BARCODE"));
                    L3.Add(r.Field<string>("PRICE_A"));
                    L4.Add(r.Field<string>("PRICE"));
                    L5.Add(r.Field<string>("ID"));
                    L6.Add(r.Field<string>("QUANTITY"));
                    L7.Add(r.Field<string>("Dis"));
                    L8.Add(r.Field<string>("Price_F"));

                }
                tt.Clear();
                accc.show3(tt);
                foreach (DataRow r in tt.Rows)
                {
                    L0.Add(r.Field<String>("NUMF"));


                }
                foreach (string asf in Filtring)
                {
                    afo += double.Parse(asf);
                }
                PriceList.Add(afo.ToString());
                Pricce.Text = "SAR " + afo.ToString();
                
                var RepHelper = new ReportHelper();
                var ILIST = new List<ReportHelper>();
                ILIST.Add(new ReportHelper() {Getprice_=Pricce.Text});
                XtraReport3 report = new XtraReport3();
                Access2007ConnectionParameters FF = new Access2007ConnectionParameters();
                FF.FileName = System.Windows.Forms.Application.StartupPath + "\\Data.accdb";
                ((SqlDataSource)report.DataSource).ConnectionParameters = FF;
                XtraReportPreviewModel model = new XtraReportPreviewModel(report);
                DocumentPreviewWindow windoww = new DocumentPreviewWindow() { Model = model };
                report.CreateDocument(true);
                windoww.ShowDialog();

                string id_3 = "";
                //int finalprice = int.Parse(SumPricee.sumPrice().Replace("SAR", "").Replace(",", ""));
                //double Ristt = double.Parse(afo.ToString().Replace("SAR", "").Replace(",", ""));
                //double FInaal = finalprice + Ristt;
                for (int i = 0; i < L1.Count; i++)
                {
                    if (L1[i] == Name.Text)
                        id_3 = L5[i];

                }
                List<int> sawf = new List<int>();

                foreach (string d in L0)
                {
                    sawf.Add(int.Parse(d));
                }
                #region Convert Days to arabic language
                string dayoftheweek = "";
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        {
                            dayoftheweek = ".الاحد";
                            break;
                        }
                    case DayOfWeek.Monday:
                        {
                            dayoftheweek = ".الاثنين";
                            break;
                        }
                    case DayOfWeek.Thursday:
                        {
                            dayoftheweek = ".الخميس";
                            break;
                        }
                    case DayOfWeek.Saturday:
                        {
                            dayoftheweek = ".السبت";
                            break;
                        }

                    case DayOfWeek.Friday:
                        {
                            dayoftheweek = "الجمعة.";
                            break;

                        }
                    case DayOfWeek.Tuesday:
                        {
                            dayoftheweek = "الثلاثاء.";
                            break;
                        }
                    case DayOfWeek.Wednesday:
                        {
                            dayoftheweek = "الاربعاء.";
                            break;
                        }
                }
                #endregion
                if (L0.Count == 0) {
                    //null
                }
  
                else
                {
                    numfa = sawf.Max() + 1;
                }
                if (sawf.Count == 0)
                {
                    UmAlQuraCalendar um = new UmAlQuraCalendar();
                    String CurrentDate = (int.Parse(DateTime.Now.Year.ToString()) < 1600) ? DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() :
                            um.GetYear(DateTime.Parse(DateTime.Now.ToString())).ToString() + "/" + um.GetMonth(DateTime.Parse(DateTime.Now.ToString())).ToString() + "/" + um.GetDayOfMonth(DateTime.Parse(DateTime.Now.ToString())).ToString();

                    for (int i = 0; i < L1.Count; i++)
                    {
                        double Price = 0;
                        double Discount = 0;
                        double Finall_Price = 0;
                        string Result = "";

                        DateTime dtttt = new DateTime();
                        for (int ii = 0; ii < asdf.Count; ii++)
                        {
                            if (L1[i] == asdf[ii])
                            {
                                accc.insert3(CurrentDate, L1[i], getwholeprice(i, L4, L7), L5[i], L6[i], L3[i], L2[i], numfa.ToString(), dayoftheweek, Pricce.Text);

                                Price = (String.IsNullOrEmpty(L4[i].Replace("SAR", ""))) ? 0 : (Double)Double.Parse(double.Parse(L4[i].Replace("SAR", "")).ToString().Replace("SAR", ""));
                                Discount = (String.IsNullOrEmpty(L7[i].Replace("%", ""))) ? 0 : (Double)Double.Parse(double.Parse(L7[i].Replace("%", "")).ToString().Replace("%", ""));
                                Finall_Price = (Double)((Price * Discount) / 100) - Price;
                                Finall_Price = Finall_Price * int.Parse(L6[i]);
                                Result = "SAR " + Finall_Price.ToString("N2").Replace("-", "");
                                var mainwi = new MainWindow(L1[i], L4[i], L6[i], L2[i], L3[i], L5[i], L7[i], Result);
                                mainwi.EDIT_MAX();

                            }

                            /*
                            
                         L1.Add(r.Field<string>("NAME"));
                    L2.Add(r.Field<string>("BARCODE"));
                    L3.Add(r.Field<string>("PRICE_A"));
                    L4.Add(r.Field<string>("PRICE"));
                    L5.Add(r.Field<string>("ID"));
                    L6.Add(r.Field<string>("QUANTITY"));
                    L7.Add(r.Field<string>("Dis"));
                    L8.Add(r.Field<string>("Price_F"));
                        */


                        }


                    }

                    if (GID.Count > 0)
                    {
                        for (int i = 0; i < GID.Count; i++)
                        {
                            FA.Delete(GID[i]);
                        }
                    }
                }
                else
                {
                    #region Date

                    UmAlQuraCalendar um = new UmAlQuraCalendar();
                    String CurrentDate = (int.Parse(DateTime.Now.Year.ToString()) < 1600) ? DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() :
                            um.GetYear(DateTime.Parse(DateTime.Now.ToString())).ToString() + "/" + um.GetMonth(DateTime.Parse(DateTime.Now.ToString())).ToString() + "/" + um.GetDayOfMonth(DateTime.Parse(DateTime.Now.ToString())).ToString();

                    #endregion


                    for (int i = 0; i < L1.Count; i++)
                    {
                        double Price = 0;
                        double Discount = 0;
                        double Finall_Price = 0;
                        string Result = "";

                        DateTime dtttt = new DateTime();
                        for (int ii = 0; ii < asdf.Count; ii++)
                        {
                            if (L1[i] == asdf[ii])
                            {
                                accc.insert3(CurrentDate, L1[i], getwholeprice(i, L4, L7), L5[i], L6[i], L3[i], L2[i], numfa.ToString(), dayoftheweek, Pricce.Text);
                                Price = (String.IsNullOrEmpty(L4[i].Replace("SAR", ""))) ? 0 : (Double)Double.Parse(double.Parse(L4[i].Replace("SAR", "")).ToString().Replace("SAR", ""));
                                Discount = (String.IsNullOrEmpty(L7[i].Replace("%", ""))) ? 0 : (Double)Double.Parse(double.Parse(L7[i].Replace("%", "")).ToString().Replace("%", ""));
                                Finall_Price = (Double)((Price * Discount) / 100) - Price;
                                Finall_Price = Finall_Price * int.Parse(L6[i]);
                                Result = "SAR " + Finall_Price.ToString("N2").Replace("-", "");
                                var mainwi = new MainWindow(L1[i], L4[i], L6[i], L2[i], L3[i], L5[i], L7[i], Result);
                                mainwi.EDIT_MAX();

                            }
                        }

                    }

                        if (GID.Count > 0)
                        {
                            for (int i = 0; i < GID.Count; i++)
                            {
                                FA.Updating_QUa("0",GID[i].ToString());
                            }
                        }
                    }
                    asdf.Clear();
             
            



                    for (int i = 0; i < PriceList.Count; i++)
                    {
                        Fa_delete._Delete(double.Parse(PriceList[i].Replace("SAR", "").Replace(",", "")));
                    }


                
            }
            catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message+":"+ex.HResult.ToString()); }
            DD.ItemsSource = "";
            Observ.Clear();
            NameList.Clear();
            PriceList.Clear();
        }
        List<string> publicbar = new List<string>();
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {


            if (e.Key == Key.Enter)
            {
                try {
                    publicbar.Add(Barcode.Text);
                    k100_();
                    if (Exists == 1)
                    {

                        NameList.Add(Name.Text);
                        PriceList.Add(price.Text);
                        var Capt = new Assest.Capt2();
                        Capt.Insert(price.Text, DateTime.Now.Day.ToString(),
                            DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), DateTime.Now.ToString(), Name.Text);
                    }
                }catch(Exception ex) {  }
                }
                

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Barcode_TextChanged(object sender, TextChangedEventArgs e)
        {



        }

        private void Print_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Barcode_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)

        {

        }
    }
}

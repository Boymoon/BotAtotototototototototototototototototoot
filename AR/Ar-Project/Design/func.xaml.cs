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
using Ar_Project.Assest;
using DevExpress.Xpf.Core;
namespace Ar_Project.Design
{
    /// <summary>
    /// this  form for add items  in edit items  products \...
    /// void Edit for edit  info  in database 
    /// 
    /// </summary>
    /// 

    public partial class func : DXWindow
    {

        public func(bool Lo_Max, bool Lo_Ma = false)
        {

            this.Lo_EDIT_MAX = Lo_Max;
            InitializeComponent();
            #region Imp1
            if (Lo_Ma == false)
            {
                if (Lo_EDIT_MAX == true)
                {
                    System.Windows.Forms.BindingSource bindS = new System.Windows.Forms.BindingSource();
                    var Acc_dataACCess = new OrcDataAcess();
                    var datatable = new System.Data.DataTable();
                    Acc_dataACCess.Show(datatable);
                    bindS.DataSource = datatable;
                    DD.ItemsSource = bindS;
                    TX.Visibility = Visibility.Visible;
                    TX_Copy.Visibility = Visibility.Visible;
                    L.Visibility = Visibility.Hidden;
                    textBlock.Visibility = Visibility.Visible;
                    textBlock_Copy3.Visibility = Visibility.Hidden;
                    textBlock_Copy.Visibility = Visibility.Visible;
                    textBlock_Copy2.Visibility = Visibility.Visible;
                    DD.Visibility = Visibility.Visible;
                    Dis_add.Visibility = Visibility.Hidden;
                    Tx_Add.Visibility = Visibility.Hidden;
                    Tx_Edit.Visibility = Visibility.Visible;
                    Dis_edit.Visibility = Visibility.Visible;
                    DDD.Visibility = Visibility.Hidden;
                    B.Visibility = Visibility.Hidden;
                    S2.Visibility = Visibility.Visible;
                    btnMA.Visibility = Visibility.Hidden;
                    maBar.Visibility = Visibility.Hidden;
                    maName.Visibility = Visibility.Hidden;
                    name_Copy.Visibility = Visibility.Visible;
                    pri_Copy.Visibility = Visibility.Visible;
                    pri_a_Copy.Visibility = Visibility.Visible;
                    qua_Copy.Visibility = Visibility.Visible;
                    bar_Copy.Visibility = Visibility.Visible;
                    name.Visibility = Visibility.Hidden;
                    pri.Visibility = Visibility.Hidden;
                    pri_a.Visibility = Visibility.Hidden;
                    qua.Visibility = Visibility.Hidden;
                    bar.Visibility = Visibility.Hidden;
                    btn_add.Visibility = Visibility.Hidden;
                    btn_add_Copy.Visibility = Visibility.Visible;
                }
                else
                {
                    ADD_LOA_MAX();
                    textBlock.Visibility = Visibility.Visible;
                    textBlock_Copy3.Visibility = Visibility.Hidden;
                    TX.Visibility = Visibility.Visible;
                    TX_Copy.Visibility = Visibility.Visible;
                    textBlock_Copy.Visibility = Visibility.Visible;
                    textBlock_Copy2.Visibility = Visibility.Visible;
                    L.Visibility = Visibility.Hidden;
                    B.Visibility = Visibility.Hidden;
                    S2.Visibility = Visibility.Visible;
                    Dis_add.Visibility = Visibility.Visible;
                    Tx_Add.Visibility = Visibility.Visible;
                    Tx_Edit.Visibility = Visibility.Hidden;
                    Dis_edit.Visibility = Visibility.Hidden;
                    DD.Visibility = Visibility.Visible;
                    DDD.Visibility = Visibility.Hidden;
                    btnMA.Visibility = Visibility.Hidden;
                    maBar.Visibility = Visibility.Hidden;
                    maName.Visibility = Visibility.Hidden;
                    btn_add.Visibility = Visibility.Visible;
                    btn_add_Copy.Visibility = Visibility.Hidden;
                    name_Copy.Visibility = Visibility.Hidden;
                    pri_Copy.Visibility = Visibility.Hidden;
                    qua_Copy.Visibility = Visibility.Hidden;
                    pri_a_Copy.Visibility = Visibility.Hidden;
                    bar_Copy.Visibility = Visibility.Hidden;
                    name.Visibility = Visibility.Visible;
                    pri.Visibility = Visibility.Visible;
                    pri_a.Visibility = Visibility.Visible;
                    qua.Visibility = Visibility.Visible;
                    bar.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (Lo_EDIT_MAX == true)
                {
                    System.Windows.Forms.BindingSource bindS = new System.Windows.Forms.BindingSource();
                    var Acc_dataACCess = new OrcDataAcess2();
                    var datatable = new System.Data.DataTable();
                    Acc_dataACCess.Show(datatable);
                    bindS.DataSource = datatable;
                    DDD.ItemsSource = bindS;
                    btnMA.Visibility = Visibility.Hidden;
                    btnMAEd.Visibility = Visibility.Visible;
                    L.Visibility = Visibility.Visible;
                    TX.Visibility = Visibility.Hidden;
                    TX_Copy.Visibility = Visibility.Hidden;
                    textBlock_Copy3.Visibility = Visibility.Visible;
                    textBlock_Copy.Visibility = Visibility.Hidden;
                    textBlock_Copy2.Visibility = Visibility.Hidden;
                    B.Visibility = Visibility.Visible;
                    S2.Visibility = Visibility.Hidden;
                    DD.Visibility = Visibility.Hidden;
                    DDD.Visibility = Visibility.Visible;
                    btnMA.Visibility = Visibility.Hidden;
                    maBar.Visibility = Visibility.Hidden;
                    maName.Visibility = Visibility.Hidden;
                    maName_Copy.Visibility = Visibility.Visible;
                    maBar_Copy.Visibility = Visibility.Visible;
                    name_Copy.Visibility = Visibility.Hidden;
                    pri_Copy.Visibility = Visibility.Hidden;
                    pri_a_Copy.Visibility = Visibility.Hidden;
                    Dis_add.Visibility = Visibility.Hidden;
                    Tx_Add.Visibility = Visibility.Hidden;
                    Tx_Edit.Visibility = Visibility.Hidden;
                    Dis_edit.Visibility = Visibility.Hidden;
                    qua_Copy.Visibility = Visibility.Hidden;
                    bar_Copy.Visibility = Visibility.Hidden;
                    name.Visibility = Visibility.Hidden;
                    pri.Visibility = Visibility.Hidden;
                    pri_a.Visibility = Visibility.Hidden;
                    qua.Visibility = Visibility.Hidden;
                    bar.Visibility = Visibility.Hidden;
                    btn_add.Visibility = Visibility.Hidden;
                    btn_add_Copy.Visibility = Visibility.Hidden;
                }
                else
                {
                    ADD_LOA_MAX();
                    L.Visibility = Visibility.Visible;
                    TX.Visibility = Visibility.Hidden;
                    TX_Copy.Visibility = Visibility.Hidden;
                    btnMA.Visibility = Visibility.Visible;
                    btnMAEd.Visibility = Visibility.Hidden;
                    textBlock_Copy.Visibility = Visibility.Hidden;
                    textBlock_Copy2.Visibility = Visibility.Hidden;
                    B.Visibility = Visibility.Visible;
                    maName_Copy.Visibility = Visibility.Hidden;
                    maBar_Copy.Visibility = Visibility.Hidden;
                    S2.Visibility = Visibility.Hidden;
                    textBlock_Copy3.Visibility = Visibility.Visible;
                    DD.Visibility = Visibility.Hidden;
                    DDD.Visibility = Visibility.Visible;
                    btnMA.Visibility = Visibility.Visible;
                    maBar.Visibility = Visibility.Visible;
                    maName.Visibility = Visibility.Visible;
                    btn_add.Visibility = Visibility.Hidden;
                    btn_add_Copy.Visibility = Visibility.Hidden;
                    name_Copy.Visibility = Visibility.Hidden;
                    pri_Copy.Visibility = Visibility.Hidden;
                    Dis_add.Visibility = Visibility.Hidden;
                    Tx_Add.Visibility = Visibility.Hidden;
                    Tx_Edit.Visibility = Visibility.Hidden;
                    Dis_edit.Visibility = Visibility.Hidden;
                    pri_a_Copy.Visibility = Visibility.Hidden;
                    qua_Copy.Visibility = Visibility.Hidden;
                    bar_Copy.Visibility = Visibility.Hidden;
                    name.Visibility = Visibility.Hidden;
                    pri.Visibility = Visibility.Hidden;
                    pri_a.Visibility = Visibility.Hidden;
                    qua.Visibility = Visibility.Hidden;
                    bar.Visibility = Visibility.Hidden;
                }
            }

            #endregion
        }

        public String GetPriceF(Models.RepAir Kind_of_Request)
        {
            string Result = null;
            Double Price = 0;
            Double Discount = 0;
            Double Finall_Price = 0;
            if (Kind_of_Request == Models.RepAir.AddMode)
            {
                Price = (String.IsNullOrEmpty(pri.Text)) ? 0 : (Double)Double.Parse(double.Parse(pri.Text).ToString().Replace("SAR", ""));
                Discount = (String.IsNullOrEmpty(Dis_add.Text)) ? 0 : (Double)Double.Parse(double.Parse(Dis_add.Text).ToString().Replace("%", ""));
                Finall_Price = (Double)((Price * Discount) / 100) - Price;

                Finall_Price = Finall_Price * int.Parse(qua.Text);
                Result = "SAR " + Finall_Price.ToString("N0").Replace("-", "");


            }
            else if (Kind_of_Request == Models.RepAir.EditMode)
            {
                Price = (String.IsNullOrEmpty(pri_Copy.Text)) ? 0 : (Double)Double.Parse(double.Parse(pri_Copy.Text).ToString().Replace("SAR", ""));
                Discount = (String.IsNullOrEmpty(Dis_edit.Text)) ? 0 : (Double)Double.Parse(double.Parse(Dis_edit.Text).ToString().Replace("%", ""));
                Finall_Price = (Double)((Price * Discount) / 100) - Price;
                Finall_Price = Finall_Price * int.Parse(qua_Copy.Text);

                Result = "SAR " + Finall_Price.ToString("N0").Replace("-", "");
            }


            return Result;
        }

        #region Imp2

        private string name_ = null;
        private string barcode = null;
        private string price = null;
        private string price_a = null;
        private string quantity = null;
        public bool Lo_EDIT_MAX = false;
        DevExpress.Xpf.Core.ObservableCollectionCore<FUNC__> MAADD = new DevExpress.Xpf.Core.ObservableCollectionCore<FUNC__>();
        private void ADD_LOA_MA()
        {
            try
            {


                MAADD.Add(new FUNC__()
                {
                    NAME = maName.Text,
                    NUM = int.Parse(maBar.Text)

                });
                DDD.ItemsSource = MAADD;
            }
            catch (Exception ex) { }
        }
        private void EDIT_LOA_MAX()
        {
            try
            {
              
                var MAXe_MA = new MainWindow(maName_Copy.Text, null, null, null, null, MA_ID_Copy.Text, null, null, int.Parse(maBar_Copy.Text));
                MAXe_MA.EDIT_MA();
             
            }
            catch (Exception ex) { MessageBox.Show("Error in Edit Client's Class:Func.xaml function:EDIT_LOA_MAX Sloution:Unknown ):"); }
        }
        private void ADD_LOA_MAX()
        {
            try
            {
                DevExpress.Xpf.Core.ObservableCollectionCore<func_> ADDMAX = new DevExpress.Xpf.Core.ObservableCollectionCore<func_>();


                ADDMAX.Add(new func_()
                {
                    NAME = name.Text,
                    BARCODE = bar.Text,
                    PRICE = pri.Text,
                    PRICE_A = pri_a.Text,
                    QUANTITY = qua.Text,
                    Dis = "%" + Dis_add.Text,
                    Price_F = GetPriceF(Models.RepAir.AddMode)


                });
                DD.ItemsSource = ADDMAX;
            }
            catch (Exception ex) { }
        }

        #endregion


        public func(string name, string barcode, string price, string quantity, string price_a, String Dis, String Price_F, bool Lo_MAX)
        {
            try
            {
                this.Lo_EDIT_MAX = Lo_MAX;
                this.name_ = name;
                this.barcode = barcode;
                this.price = price;
                this.price_a = price_a;
                this.quantity = quantity;

            }
            catch (Exception ex) { }
        }
        public void _EDIT()
        {
            try
            {
                
                int pri_1 = int.Parse(pri_Copy.Text.Replace("SAR", "").Replace(",", ""));
                int pri_2 = int.Parse(pri_a_Copy.Text.Replace("SAR", "").Replace(",", ""));
                var mainwi = new MainWindow(name_Copy.Text, "SAR " + pri_1.ToString("N0"), qua_Copy.Text, bar_Copy.Text, "SAR " + pri_2.ToString("N0"), MA_ID.Text, "%" + Dis_edit.Text, GetPriceF(Models.RepAir.EditMode));
                mainwi.EDIT_MAX();
                pri_a_Copy.Text = "";
                name_Copy.Text = "";
                pri_Copy.Text = "";
                qua_Copy.Text = "";
                bar_Copy.Text = "";
                Dis_edit.Text = "";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {



                while (true)
                {
                    /*

                      pri_a_Copy.Text = "";
                    name_Copy.Text = "";
                    pri_Copy.Text = "";
                    qua_Copy.Text = "";
                    bar_Copy.Text = "";
                    Dis_edit.Text = "";
                    */

                    if (string.IsNullOrEmpty(pri_a.Text))
                    {
                        DXMessageBox.Show(String.Format("لم يتم تحديد {0 } لتحديث البيانات", "سعر التكلفة "));
                        break;

                    }
                    else if (string.IsNullOrEmpty(name.Text))
                    {
                      DXMessageBox.Show(String.Format("لم يتم تحديد {0 } لتحديث البيانات", "اسم المنتج"));
                        break;

                    }
                    else if (string.IsNullOrEmpty(pri.Text))
                    {
                        DXMessageBox.Show(String.Format("لم يتم تحديد {0 } لتحديث البيانات", "سعر البيع"));
                        break;

                    }
                    else if (string.IsNullOrEmpty(qua.Text))
                    {
                        DXMessageBox.Show(String.Format("لم تحدد {0 } لتحديث البيانات", "الكمية"));
                        break;

                    }
                    else if (string.IsNullOrEmpty(bar.Text))
                    {
                       DXMessageBox.Show(String.Format("لم يتم ايجاد {0 } لتحديث البيانات", "رقم الباركود"));
                        break;

                    }
                    else if (string.IsNullOrEmpty(Dis_add.Text))
                    {
                        Dis_add.Text = "0";
                        break;

                    }
                    if (int.Parse(Dis_add.Text) < 0 || int.Parse(Dis_add.Text) > 100)
                    {
                        Dis_add.Text = "0";
                        DXMessageBox.Show("يجب ان تتراوح قيمة الخصم بين 100 و 0", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                    var ADD_MAX = new MainWindow(name.Text, pri.Text, qua.Text, bar.Text, pri_a.Text, null, "%" + Dis_add.Text, GetPriceF(Models.RepAir.AddMode));
                    ADD_MAX.ADD_MAX();
                    ADD_LOA_MAX();
                    break;
                    #region Imp3
                    pri_a.Text = "";
                    name.Text = "";
                    pri.Text = "";
                    qua.Text = "";
                    bar.Text = "";
                    Dis_add.Text = "";
                }


               

            }
            catch (Exception ex) { DXMessageBox.Show(ex.Message); }
            #endregion
        }

        private void btn_add_Copy_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                /*
                
                  pri_a_Copy.Text = "";
                name_Copy.Text = "";
                pri_Copy.Text = "";
                qua_Copy.Text = "";
                bar_Copy.Text = "";
                Dis_edit.Text = "";
                */

                if (string.IsNullOrEmpty(pri_a_Copy.Text))
                {
                   DXMessageBox.Show(String.Format("لم يتم تحديد {0 } لتحديث البيانات", "سعر التكلفة "));
                    break;

                }
                else if (string.IsNullOrEmpty(name_Copy.Text))
                {
                    DXMessageBox.Show(String.Format("لم يتم تحديد {0 } لتحديث البيانات", "اسم المنتج"));
                    break;

                }
                else if (string.IsNullOrEmpty(pri_Copy.Text))
                {
                    DXMessageBox.Show(String.Format("لم يتم تحديد {0 } لتحديث البيانات", "سعر البيع"));
                    break;

                }
                else if (string.IsNullOrEmpty(qua_Copy.Text))
                {
                    DXMessageBox.Show(String.Format("لم تحدد {0 } لتحديث البيانات", "الكمية"));
                    break;

                }
                else if (string.IsNullOrEmpty(bar_Copy.Text))
                {
                    DXMessageBox.Show(String.Format("لم يتم ايجاد {0 } لتحديث البيانات", "رقم الباركود"));
                    break;

                }
                else if (string.IsNullOrEmpty(Dis_edit.Text))
                {
                    Dis_edit.Text = "0";
                    break;

                }
                if (int.Parse(Dis_edit.Text) < 0 || int.Parse(Dis_edit.Text) > 100)
                {
                    Dis_edit.Text = "0";
                    DXMessageBox.Show("يجب ان تتراوح قيمة الخصم بين 100 و 0", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }

                Dis_edit.Text = Dis_edit.Text.Replace("%", "");
                pri_a_Copy.Text = pri_a_Copy.Text.Replace("SAR", "");
                pri_Copy.Text = pri_Copy.Text.Replace("SAR", "");
                _EDIT();
                break;
            }


        }

        private void btnMA_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                while (true)
                {
                    if (String.IsNullOrEmpty(maBar.Text))
                    {
                         DXMessageBox.Show(String.Format("لايوجد {0 } لتحديث البيانات", "رقم هاتف")); 
                        break;
                    }
                    if (string.IsNullOrEmpty(maName.Text))
                    {
                         DXMessageBox.Show(string.Format("لايوجد {0 } لتحديث البيانات", "اسم العميل"));
                        break;
                    }







                    var Addma = new MainWindow(maName.Text, null, null, null, null, null, null, null, int.Parse(maBar.Text));
                    Addma.ADD_MA();
                    ADD_LOA_MA();
                    maBar.Text = "";
                    maName.Text = "";
                    break;
                }
            }
            catch (Exception ex) { }
        }

        public void btnMAEd_Click(object sender, RoutedEventArgs e)
        {

            while (true)
            {
                if (String.IsNullOrEmpty(maBar_Copy.Text))
                {
                     DXMessageBox.Show(String.Format("لايوجد {0 } لتحديث البيانات", "رقم هاتف"));
                    break;
                }
                if (string.IsNullOrEmpty(maName_Copy.Text))
                {
                     DXMessageBox.Show(string.Format("لايوجد {0 } لتحديث البيانات", "اسم العميل"));
                    break;
                }


//            this.MA_ID = MA_ID;

                EDIT_LOA_MAX();
                break;

            }

        }

        private void pri_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        //}
        /*
        
            Dis_add.Visibility = Visibility.Visible;
                    Tx_Add.Visibility = Visibility.Visible;
                    Tx_Edit.Visibility = Visibility.Hidden;
                    Dis_edit.Visibility = Visibility.Hidden;
            */
        class func_
        {
            public string NAME { get; set; }
            public string PRICE { get; set; }
            public string PRICE_A { get; set; }
            public string BARCODE { get; set; }
            public string QUANTITY { get; set; }
            public string Dis { get; set; }
            public string Price_F { get; set; }
        }
        class FUNC__
        {
            public string NAME { get; set; }
            public int NUM { get; set; }

        }

        private void pri_a_Copy_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void pri_a_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}


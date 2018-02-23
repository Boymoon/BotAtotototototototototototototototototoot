using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DevExpress.XtraEditors.Repository;
using System.Data;
using System.Globalization;

namespace Ar_Project.Interface
{
    /// <summary>
    /// Interaction logic for RepairManagement.xaml
    /// </summary>
    /// 



    public partial class RepairManagement : DXWindow
    {
        Guid id;
        System.Data.DataTable data = new System.Data.DataTable();
        bool RepAir_State;
        public RepairManagement(Models.RepAir Struct_RepAir)
        {
            InitializeComponent();

            RepAir_State = (Struct_RepAir == Models.RepAir.AddMode) ? true : false;


            if (Struct_RepAir == Models.RepAir.EditMode)
            {
                addd.Visibility = Visibility.Hidden;
                Aadd.Visibility = Visibility.Hidden;
                A3.Visibility = Visibility.Visible;
                A4.Visibility = Visibility.Visible;
                Data_Edit.Visibility = Visibility.Visible;
                Data_Add.Visibility = Visibility.Hidden;

                //var data_2 = new System.Data.DataTable();
                //var ModelMegaa = new ModelMega();
                //ModelMegaa.show(data_2);
                //var bindingsource = new System.Windows.Forms.BindingSource();
                //bindingsource.DataSource = data_2;
                //Data_Edit.ItemsSource = bindingsource;

            }
            else if (Struct_RepAir == Models.RepAir.AddMode)
            {
                addd.Visibility = Visibility.Visible;
                Aadd.Visibility = Visibility.Visible;
                A3.Visibility = Visibility.Hidden;
                A4.Visibility = Visibility.Hidden;
                Data_Edit.Visibility = Visibility.Hidden;
                Data_Add.Visibility = Visibility.Visible;
            }
            //type_cou.ItemsSource = items;


        }
        ObservableCollectionCore<Models.RepairVieww> obsrepairview = new ObservableCollectionCore<Models.RepairVieww>();

        void add()
        {

            //repair_state==False ==>Update
            // Repair_state=True  ==>Add
          

            while (true)
            {
                if (String.IsNullOrEmpty(name.Text))
                {
                    DXMessageBox.Show(null, "لم يتم  تحديد اسم العميل لتحديث البيانات", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }

                else if (String.IsNullOrEmpty(price.Text))
                {
                    DXMessageBox.Show(null, "لم يتم  تحديد السعر لتحديث البيانات", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                else if (String.IsNullOrEmpty(date.Text))
                {
                    DXMessageBox.Show(null, "لم يتم  تحديد التاريخ لتحديث البيانات", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                else if (String.IsNullOrEmpty(content_Prou.Text))
                {
                    MessageBoxResult resultmsg = DXMessageBox.Show(null, @"لم يتم تحديد وصف للمشكلة, هل تريد  مواصلة  العملية؟", "خطأ", MessageBoxButton.YesNo, MessageBoxImage.Error);
                    if (resultmsg == MessageBoxResult.No)
                    {
                        break;
                    }
                    else if (resultmsg == MessageBoxResult.Yes)
                    {
                        content_Prou.Text = "لايوجد";
                    }

                }
                else if (String.IsNullOrEmpty(KIND.Text))
                {
                    DXMessageBox.Show(null, "لم يتم  تحديد نوع الصنف لتحديث البيانات", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }



                if (RepAir_State)
                {


                    if (IsComplete.IsChecked == true)
                    {
                        UmAlQuraCalendar um = new UmAlQuraCalendar();
                        String CurrentDate = (int.Parse(DateTime.Now.Year.ToString()) < 1600) ? DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() :
                                um.GetYear(DateTime.Parse(DateTime.Now.ToString())).ToString() + "/" + um.GetMonth(DateTime.Parse(DateTime.Now.ToString())).ToString() + "/" + um.GetDayOfMonth(DateTime.Parse(DateTime.Now.ToString())).ToString();

                        String CurrentDatee = (int.Parse(date.DateTime.Year.ToString()) < 1600) ? date.DateTime.Year.ToString() + "/" + date.DateTime.Month.ToString() + "/" + date.DateTime.Day.ToString() :
                        um.GetYear(date.DateTime).ToString() + "/" + um.GetMonth(date.DateTime).ToString() + "/" + um.GetDayOfMonth(date.DateTime).ToString();

                        id = Guid.NewGuid();
                        ID.Text = id.ToString().Substring(id.ToString().IndexOf('-'), 10).Replace("-", "");
                        int Price = int.Parse(price.Text);
                        string Price_ = "SAR " + Price.ToString("N0");
                        HelperRepair.Add(ID.Text, name.Text, Price_,
                            
                            
                            
                                (int.Parse(DateTime.Parse(CurrentDatee).Year.ToString())<1600)? CurrentDatee : DateConverter.ConvertToHijri(CurrentDatee)
                            
                            ,
                            
                            
                            (int.Parse(DateTime.Parse(CurrentDate).Year.ToString())<1600) ? CurrentDate : DateConverter.ConvertToHijri(CurrentDate), content_Prou.Text, KIND.Text, (string.IsNullOrEmpty(discounts.Text) ? "لايوجد" : discounts.Text), false, data);
                        obsrepairview.Add(new Models.RepairVieww()
                        {
                            ID = ID.Text,
                            NAME = name.Text,
                            PRICE = Price_,
                            conprou = KIND.Text,
                            DAT = (int.Parse(DateTime.Parse(CurrentDate).Year.ToString())<1600) ? CurrentDate : DateConverter.ConvertToHijri(CurrentDate),
                            datrec =      (int.Parse(DateTime.Parse(CurrentDatee).Year.ToString())<1600)? CurrentDatee : DateConverter.ConvertToHijri(CurrentDatee),
                            typeprou = content_Prou.Text,
                            discounts = (string.IsNullOrEmpty(discounts.Text) ? "لايوجد" : discounts.Text)
                        });



                        Data_Add.ItemsSource = obsrepairview;
                        DXMessageBox.Show("تم اضافة طلبكم بنجاح", "!تنبيه", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        UmAlQuraCalendar um = new UmAlQuraCalendar();
                        String CurrentDate = (int.Parse(DateTime.Now.Year.ToString()) < 1600) ? DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() :
                                              um.GetYear(DateTime.Parse(DateTime.Now.ToString())).ToString() + "/" + um.GetMonth(DateTime.Parse(DateTime.Now.ToString())).ToString() + "/" + um.GetDayOfMonth(DateTime.Parse(DateTime.Now.ToString())).ToString();

                        String CurrentDatee = (int.Parse(date.DateTime.Year.ToString()) < 1600) ? date.DateTime.Year.ToString() + "/" + date.DateTime.Month.ToString() + "/" + date.DateTime.Day.ToString() :
                        um.GetYear(date.DateTime).ToString() + "/" + um.GetMonth(date.DateTime).ToString() + "/" + um.GetDayOfMonth(date.DateTime).ToString();

                        id = Guid.NewGuid();
                        ID.Text = id.ToString().Substring(id.ToString().IndexOf('-'), 10).Replace("-", "");
                        int Price = int.Parse(price.Text);


                        string Price_ = "SAR " + Price.ToString("N0");

                        HelperRepair.Add(ID.Text, name.Text, Price_,    (int.Parse(DateTime.Parse(CurrentDatee).Year.ToString())<1600)? CurrentDatee : DateConverter.ConvertToHijri(CurrentDatee), (int.Parse(DateTime.Parse(CurrentDate).Year.ToString())<1600)? CurrentDate: DateConverter.ConvertToHijri(CurrentDate), content_Prou.Text, KIND.Text, (string.IsNullOrEmpty(discounts.Text) ? "لايوجد" : discounts.Text), true, data);






                       // var obsrepairview = new ObservableCollectionCore<Models.RepairView>();

                        obsrepairview.Add(new Models.RepairVieww()
                        {
                            ID = ID.Text,
                            NAME = name.Text,
                            PRICE = Price_,
                            conprou = KIND.Text,
                            DAT = (int.Parse(DateTime.Parse(CurrentDate).Year.ToString())<1600) ? CurrentDate : DateConverter.ConvertToHijri(CurrentDate),
                            datrec =      (int.Parse(DateTime.Parse(CurrentDatee).Year.ToString())<1600)? CurrentDatee : DateConverter.ConvertToHijri(CurrentDatee),
                            typeprou = content_Prou.Text,
                            discounts = (string.IsNullOrEmpty(discounts.Text) ? "لايوجد" : discounts.Text)
                        });


                        Data_Add.ItemsSource = obsrepairview;
                        DXMessageBox.Show("تم اضافة طلبكم بنجاح", "!تنبيه", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {



                }

                break;
            }

            // ModelMega_Add.add();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {


            add();
        }
        public void Edit()
        {







            while (true)
            {
                if (String.IsNullOrEmpty(name_edit.Text))
                {
                    DXMessageBox.Show(null, "لم يتم  تحديد اسم العميل لتحديث البيانات", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }

                else if (String.IsNullOrEmpty(price_edit.Text))
                {
                    DXMessageBox.Show(null, "لم يتم  تحديد السعر لتحديث البيانات", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                else if (String.IsNullOrEmpty(date_edit.Text))
                {
                    DXMessageBox.Show(null, "لم يتم  تحديد التاريخ لتحديث البيانات", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                else if (String.IsNullOrEmpty(content_Prou_edit.Text))
                {
                    MessageBoxResult resultmsg = DXMessageBox.Show(null, @"لم يتم تحديد وصف للمشكلة, هل تريد  مواصلة  العملية؟", "خطأ", MessageBoxButton.YesNo, MessageBoxImage.Error);
                    if (resultmsg==MessageBoxResult.No)
                    {
                        break;
                    }
                    else if (resultmsg==MessageBoxResult.Yes)
                    {
                        content_Prou_edit.Text = "لايوجد";
                    }
               
                }
                else if (String.IsNullOrEmpty(KIND_EDIT.Text))
                {
                    DXMessageBox.Show(null, "لم يتم  تحديد نوع الصنف لتحديث البيانات", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }

            
















                var data_21 = new System.Data.DataTable();
                var ModelMegaa2 = new ModelMega();
                ModelMegaa2.show(data_21);
                var lis = new List<string>();
                var lisDate = new List<string>();

                foreach (System.Data.DataRow item in data_21.Rows)
                {
                    lis.Add(item.Field<String>("ID"));
                    lisDate.Add(item.Field<String>("datrec"));
                }
                if (IsComplete_edit.IsChecked == true)
                {
                    string price = int.Parse(price_edit.Text.Replace("SAR ","")).ToString("N0"); 
                    UmAlQuraCalendar um = new UmAlQuraCalendar();
                    String CurrentDate = (int.Parse(DateTime.Now.Year.ToString()) < 1600) ? DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() :
                                         um.GetYear(DateTime.Parse(DateTime.Now.ToString())).ToString() + "/" + um.GetMonth(DateTime.Parse(DateTime.Now.ToString())).ToString() + "/" + um.GetDayOfMonth(DateTime.Parse(DateTime.Now.ToString())).ToString();

                    String CurrentDatee = (int.Parse(date_edit.DateTime.Year.ToString()) < 1600) ? date.DateTime.Year.ToString() + "/" + date_edit.DateTime.Month.ToString() + "/" + date_edit.DateTime.Day.ToString() :
                   um.GetYear(date_edit.DateTime).ToString() + "/" + um.GetMonth(date_edit.DateTime).ToString() + "/" + um.GetDayOfMonth(date_edit.DateTime).ToString();
                    if (int.Parse(DateTime.Now.Year.ToString()) < 2000)
                    {
                        String CurrentDateee =
                   um.GetYear(DateTime.Parse(CurrentDatee)).ToString() + "/" + um.GetMonth(DateTime.Parse(CurrentDatee)).ToString() + "/" + um.GetDayOfMonth(DateTime.Parse(CurrentDatee)).ToString();
                        HelperRepair.Edit(ID1.Text, name_edit.Text, "SAR "+ price, (int.Parse(DateTime.Parse(CurrentDateee).Year.ToString()) < 1600) ? CurrentDateee : DateConverter.ConvertToHijri(CurrentDateee), lisDate[lis.IndexOf(ID1.Text)], content_Prou_edit.Text, KIND_EDIT.Text, (string.IsNullOrEmpty(discounts_Edit.Text) ? "لايوجد" : discounts_Edit.Text), false, data);

                    }
                    else
                    {

                        HelperRepair.Edit(ID1.Text, name_edit.Text, "SAR " + price, (int.Parse(DateTime.Parse(CurrentDatee).Year.ToString()) < 1600) ? CurrentDatee : DateConverter.ConvertToHijri(CurrentDatee), lisDate[lis.IndexOf(ID1.Text)], content_Prou_edit.Text, KIND_EDIT.Text, (string.IsNullOrEmpty(discounts_Edit.Text) ? "لايوجد" : discounts_Edit.Text), false, data);



                    }



                }
                else
                {

                    //id = Guid.NewGuid();
                    //ID1.Text = id.ToString().Substring(id.ToString().IndexOf('-'), 10).Replace("-", "");
                    int Price = int.Parse(double.Parse(price_edit.Text.Replace("SAR", "")).ToString());
                    String CurrentDateee = "";

                         UmAlQuraCalendar um = new UmAlQuraCalendar();
                         String CurrentDate = (int.Parse(DateTime.Now.Year.ToString()) < 1600) ? DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() :
                                              um.GetYear(DateTime.Parse(DateTime.Now.ToString())).ToString() + "/" + um.GetMonth(DateTime.Parse(DateTime.Now.ToString())).ToString() + "/" + um.GetDayOfMonth(DateTime.Parse(DateTime.Now.ToString())).ToString();
                    String CurrentDatee = (int.Parse(date_edit.DateTime.Year.ToString()) < 1600) ? date.DateTime.Year.ToString() + "/" + date_edit.DateTime.Month.ToString() + "/" + date_edit.DateTime.Day.ToString() :
                   um.GetYear(date_edit.DateTime).ToString() + "/" + um.GetMonth(date_edit.DateTime).ToString() + "/" + um.GetDayOfMonth(date_edit.DateTime).ToString();
                    if (int.Parse(CurrentDatee.Split('/')[0]) > 2000)
                    {
                        CurrentDateee =
                   um.GetYear(DateTime.Parse(CurrentDatee)).ToString() + "/" + um.GetMonth(DateTime.Parse(CurrentDatee)).ToString() + "/" + um.GetDayOfMonth(DateTime.Parse(CurrentDatee)).ToString();
                        string Price_ = "SAR " + Price.ToString("N0");



                        HelperRepair.Edit(ID1.Text, name_edit.Text, Price_, (int.Parse(DateTime.Parse(CurrentDateee).Year.ToString()) < 1600) ? CurrentDateee : DateConverter.ConvertToHijri(CurrentDateee), lisDate[lis.IndexOf(ID1.Text)], content_Prou_edit.Text, KIND_EDIT.Text, (String.IsNullOrEmpty(discounts_Edit.Text)) ? "لايوجد" : discounts_Edit.Text, true, data);


                    }
                    else {

                        string Price_ = "SAR " + Price.ToString("N0");



                        HelperRepair.Edit(ID1.Text, name_edit.Text, Price_, (int.Parse(DateTime.Parse(CurrentDatee).Year.ToString()) < 1600) ? CurrentDatee : DateConverter.ConvertToHijri(CurrentDatee), lisDate[lis.IndexOf(ID1.Text)], content_Prou_edit.Text, KIND_EDIT.Text, (String.IsNullOrEmpty(discounts_Edit.Text)) ? "لايوجد" : discounts_Edit.Text, true, data);
                    }


                    }
                    break;
            }
        }
        private void Btn_Add1_Click(object sender, RoutedEventArgs e)
        {
            Edit();
        }
    }
}

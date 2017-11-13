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
using System.Collections;
using System.Data;
namespace Ar_Project.Design
{
    /// <summary>
    /// Interaction logic for SeinProduct.xaml
    /// </summary>
    public partial class SeinProduct : DXWindow
    {
        public SeinProduct()
        {
            InitializeComponent();
            day.IsChecked = true;
        }
        private void AddByday()
        {
            try
            {

           
            var LiName = new List<string>();
            var LiPrice = new List<string>();
            var LiDate = new List<string>();
            var SearchinProduct = new Assest.Capt2();
            var IEnuDayList = new ObservableCollectionCore<Assest.SearchInProduct>();
            var Datatable = new DataTable();
            SearchinProduct.show(Datatable);
            foreach (DataRow datarow in Datatable.Rows)
            {
                if (datarow.Field<string>("DAY") == DateTime.Now.Day.ToString())
                {
                    LiName.Add(datarow.Field<string>("NAME"));
                    LiPrice.Add(datarow.Field<string>("PRICE"));
                    LiDate.Add(datarow.Field<string>("YEAR") + "/" +
                        datarow.Field<string>("MOUNTH") + "/" +
                        datarow.Field<string>("DAY"));
                }
               
            }
            int if_can=0;
            for (int i = 0; i < LiName.Count; i++)
            {
                
                if (name.Text == LiName[i])
                {
                    IEnuDayList.Add(new
                                      Assest.SearchInProduct()
                    {
                        Date = LiDate[i],
                        name = LiName[i],
                        price = LiPrice[i]
                    });
                    if_can = 1;
                }
                 

                }
            if (if_can != 1)
            {
                DXMessageBox.Show("لم يتم العثور على اي نتيجة", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
             
            }


            GridData.ItemsSource = IEnuDayList;

            }
            catch (Exception ex) { }
        }
        private void AddBymounth()
        {
            try
            {

            
            var LiName = new List<string>();
            var LiPrice = new List<string>();
            var LiDate = new List<string>();
            var SearchinProduct = new Assest.Capt2();
            var IEnuDayList = new ObservableCollectionCore<Assest.SearchInProduct>();
            var Datatable = new DataTable();
            SearchinProduct.show(Datatable);
            foreach (DataRow datarow in Datatable.Rows)
            {
                if (datarow.Field<string>("MOUNTH") == DateTime.Now.Month.ToString())
                {
                    LiName.Add(datarow.Field<string>("NAME"));
                    LiPrice.Add(datarow.Field<string>("PRICE"));
                    LiDate.Add(datarow.Field<string>("YEAR") + "/" +
                        datarow.Field<string>("MOUNTH") + "/" +
                        datarow.Field<string>("DAY"));
                }

            }
            int if_can = 0;
            for (int i = 0; i < LiName.Count; i++)
            {

                if (name.Text == LiName[i])
                {
                    IEnuDayList.Add(new
                                      Assest.SearchInProduct()
                    {
                        Date = LiDate[i],
                        name = LiName[i],
                        price = LiPrice[i]
                    });
                    if_can = 1;
                }


            }
            if (if_can != 1)
            {
                DXMessageBox.Show("لم يتم العثور على اي نتيجة", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);

            }


            GridData.ItemsSource = IEnuDayList;
            }
            catch (Exception ex) { }
        }
        private void AddByyear()
        {
            try
            {

            
            var LiName = new List<string>();
            var LiPrice = new List<string>();
            var LiDate = new List<string>();
            var SearchinProduct = new Assest.Capt2();
            var IEnuDayList = new ObservableCollectionCore<Assest.SearchInProduct>();
            var Datatable = new DataTable();
            SearchinProduct.show(Datatable);
            foreach (DataRow datarow in Datatable.Rows)
            {
                if (datarow.Field<string>("YEAR") == DateTime.Now.Year.ToString())
                {
                    LiName.Add(datarow.Field<string>("NAME"));
                    LiPrice.Add(datarow.Field<string>("PRICE"));
                    LiDate.Add(datarow.Field<string>("YEAR") + "/" +
                        datarow.Field<string>("MOUNTH") + "/" +
                        datarow.Field<string>("DAY"));
                }

            }
            int if_can = 0;
            for (int i = 0; i < LiName.Count; i++)
            {

                if (name.Text == LiName[i])
                {
                    IEnuDayList.Add(new
                                      Assest.SearchInProduct()
                    {
                        Date = LiDate[i],
                        name = LiName[i],
                        price = LiPrice[i]
                    });
                    if_can = 1;
                }


            }
            if (if_can != 1)
            {
                DXMessageBox.Show("لم يتم العثور على اي نتيجة", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);

            }


            GridData.ItemsSource = IEnuDayList;
            }
            catch (Exception ex) { }
        }

        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            if (year.IsChecked==true)
                AddByyear();
            else if (mounth.IsChecked == true)
                AddBymounth();
            else if (day.IsChecked == true)
                AddByday();


        }
    }

}

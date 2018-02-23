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
using DevExpress.Xpf.Core;

namespace Ar_Project
{
    /// <summary>
    /// Interaction logic for corvk.xaml
    /// </summary>
    public partial class corvk : Window
    {
        public corvk()
        {
            InitializeComponent();
        
        }

        private void A1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void A3_MouseEnter(object sender, MouseEventArgs e)
        {
            showA3();
            Ye.Visibility = Visibility.Collapsed;
            A1.IsEnabled = false;
            A2.IsEnabled = false;
            A3.IsEnabled = true;
            Br3.Visibility = Visibility.Collapsed;

        }
       
        private void A3_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {

        
            showA3();

            Ye.Visibility = Visibility.Visible;
            if (Ye.IsSelected)
            {
                A1.IsEnabled = true;
                A2.IsEnabled = true;
                A3.IsEnabled = true;
                Br3.Visibility = Visibility.Visible;
                price.Text = "0.00";
                price1.Text = "0.00";
                price2.Text = "0.00";
            }
            else
            {
                A1.IsEnabled = false;
                A2.IsEnabled = false;
                A3.IsEnabled = true;
                Br3.Visibility = Visibility.Collapsed;

            }
            }
            catch (Exception ex) { }
        }
        List<string> Ca_price = new List<string>();
        List<string> Ca_Day = new List<string>();
        List<string> Ca_year = new List<string>();
        List<string> Ca_mounth = new List<string>();
        List<string> Ca_index = new List<string>();
        List<int> S = new List<int>();

        private void showA1()
        {
            try
            {

            
            Ca_price.Clear();
            Ca_Day.Clear();
            Ca_year.Clear();
            Ca_mounth.Clear();
            Ca_index.Clear();


            var capt = new Assest.Capt2();
            DataTable datatable = new DataTable();
            DataTable Comput = new DataTable();
            DataTable Maxe = new DataTable();
            var asd = new Assest.orcDataacess4();
     
            capt.show(datatable);
            asd.Show(datatable);
          
            
            object JCmpute;
            
            foreach (DataRow dr in datatable.Rows)
            {
                Ca_price.Add(dr.Field<string>("PRICE"));
                Ca_Day.Add(dr.Field<string>("YEAR"));//mounth
                Ca_year.Add(dr.Field<string>("DAY"));
                Ca_mounth.Add(dr.Field<string>("MOUNTH"));//year
            }
            DataRow Drr;
            ComboBoxItem C = (ComboBoxItem)A1.SelectedItem;
            string C2 = C.Content.ToString();
            for (int i = 0; i < Ca_price.Count; i++)
            {
                if (Ca_year[i] == C2)
                {
                    Ca_index.Add(Ca_price[i]);
                    price2.Text = "0.00";
                    price1.Text = "0.00";
                }
                if (Ca_year[i] == 30.ToString())
                {
                    var edit_day = new Assest.Capt2();
                    edit_day.Updating2("0");
                  
                }
            }
            Comput.Clear();
            Comput.Columns.Add("D");
            Int32 loool = 0;

            for (int i = 0; i < Ca_index.Count; i++)
            {
                Drr = Comput.NewRow();
                Drr["D"] = Ca_index[i];
                Comput.Rows.Add(Drr);
                loool += Int32.Parse(Ca_index[i]);
           
            }
            price.Text = loool.ToString();



            }
            catch (Exception ex) { }

        }
        private void showA2()
        {
            try
            {


            Ca_price.Clear();
            Ca_Day.Clear();
            Ca_year.Clear();
            Ca_mounth.Clear();
            Ca_index.Clear();
            var capt = new Assest.Capt2();
            DataTable datatable = new DataTable();
            DataTable Comput = new DataTable();
            capt.show(datatable);
            foreach (DataRow dr in datatable.Rows)
            {
                Ca_price.Add(dr.Field<string>("PRICE"));
                Ca_Day.Add(dr.Field<string>("MOUNTH"));//mounth
                Ca_year.Add(dr.Field<string>("DAY"));
                Ca_mounth.Add(dr.Field<string>("YEAR"));//year
            }

            object JCmpute;
            ComboBoxItem C = (ComboBoxItem)A2.SelectedItem;
            string C2 = C.Content.ToString();

            for (int i = 0; i < Ca_Day.Count; i++)
            {
                if (Ca_Day[i] == C2)
                {
                    Ca_index.Add(Ca_price[i]);

                }
                if (Ca_Day[i] == 12.ToString())
                {
                    capt.Updating3("0");
                }
            }
            Comput.Clear();
            Comput.Columns.Add("D");
            DataRow Drr;
            int loool = 0;

            for (int i = 0; i < Ca_index.Count; i++)
            {
                Drr = Comput.NewRow();
                Drr["D"] = Ca_index[i];
                Comput.Rows.Add(Drr);
                loool += int.Parse(Ca_index[i]);

            }
            price1.Text = loool.ToString();
            }
            catch (Exception ex) { }
        }
        private void showA3()
        {
            try { 
            Ca_price.Clear();
            Ca_Day.Clear();
            Ca_year.Clear();
            Ca_mounth.Clear();
            Ca_index.Clear();
            var capt = new Assest.Capt2();
            DataTable datatable = new DataTable();
            DataTable Comput = new DataTable();
            capt.show(datatable);
          
          
            foreach (DataRow dr in datatable.Rows)
            {
                Ca_price.Add(dr.Field<string>("PRICE"));
                Ca_Day.Add(dr.Field<string>("MOUNTH"));//mounth
                Ca_year.Add(dr.Field<string>("DAY"));
                Ca_mounth.Add(dr.Field<string>("YEAR"));//year
            }
            ComboBoxItem C = (ComboBoxItem)A3.SelectedItem;
            string C2 = C.Content.ToString();

            for (int i = 0; i < Ca_price.Count; i++)
            {
                if (Ca_mounth[i] == C2)
                {
                    Ca_index.Add(Ca_price[i]);

                }
                if (Ca_mounth[i] == Ca_mounth[i] + 1)
                {
                    capt.Updating4("0");
                }
            }
            Comput.Clear();
            Comput.Columns.Add("D");
            DataRow Drr;
            int loool = 0;

            for (int i = 0; i < Ca_index.Count; i++)
            {
                Drr = Comput.NewRow();
                Drr["D"] = Ca_index[i];
                Comput.Rows.Add(Drr);
                loool += int.Parse(Ca_index[i]);

            }
            price2.Text = loool.ToString();
            }
            catch (Exception ex) { }
        }
        private void A2_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {

            
            showA2();
            Mou.Visibility = Visibility.Collapsed;
            A1.IsEnabled = false;
            A2.IsEnabled = true;
            A3.IsEnabled = false;
            Br2.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex) { }
        }

        private void A2_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {

            
            showA2();
            Mou.Visibility = Visibility.Visible;
            if (Mou.IsSelected)
            {
                A1.IsEnabled = true;
                A2.IsEnabled = true;
                A3.IsEnabled = true;
                Br2.Visibility = Visibility.Visible;
                price2.Text = "0.00";
                price.Text = "0.00";
                price1.Text = "0.00";

            }
            else
            {
                A1.IsEnabled = false;
                A2.IsEnabled = true;
                A3.IsEnabled = false;
                Br2.Visibility = Visibility.Collapsed;

            }
            }
            catch (Exception ex) { }
        }

        private void A1_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {

            
            showA1();

            Day.Visibility = Visibility.Collapsed;
            A1.IsEnabled = true;
            A2.IsEnabled = false;
            A3.IsEnabled = false;
            Br1.Visibility = Visibility.Collapsed;

            }
            catch (Exception ex) { }
        }

        private void A1_MouseLeave(object sender, MouseEventArgs e)
        {
            try { 
            showA1();

            Day.Visibility = Visibility.Visible;
            if (Day.IsSelected)
            {
                A1.IsEnabled = true;
                A2.IsEnabled = true;
                A3.IsEnabled = true;
                Br1.Visibility = Visibility.Visible;
                price2.Text = "0.00";
                price.Text = "0.00";
                price1.Text = "0.00";
            }
            else
            {
                A1.IsEnabled = true;
                A2.IsEnabled = false;
                A3.IsEnabled = false;
                Br1.Visibility = Visibility.Collapsed;

            }
            }
            catch (Exception ex) { }


        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void T_Click(object sender, RoutedEventArgs e)
        {
           // showA1();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           

        }
    }
}

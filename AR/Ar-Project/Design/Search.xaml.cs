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
using System.Text.RegularExpressions;
using Ar_Project.Assest;
namespace Ar_Project.Design
{
    /// <summary>
    /// this window for search in Project\Proudct  by Barcode And name ..
    /// done
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
            radioButton_Copy.IsChecked = true;
        }
        private void search_P()
        {
            try { 
            var name = new List<string>();
            var bar = new List<string>();
            var pri = new List<string>();
            var qua = new List<string>();
            var data_acc = new OrcDataAcess();
            var dt = new DataTable();
            data_acc.Show(dt);
            foreach (DataRow Dr in dt.Rows)
            {
                name.Add(Dr.Field<string>("NAME"));
                bar.Add(Dr.Field<string>("BARCODE"));
                pri.Add(Dr.Field<string>("PRICE"));
                qua.Add(Dr.Field<string>("QUANTITY"));
            }
            int MAX = 0;
            for (int i = 0; i < name.Count; i++)
            {

                if (Regex.IsMatch(search.Text, "^[0-9]*$"))
                {
                    if (search.Text == bar[i])
                    {
                        this.AA.IsChecked = false;
                        this.bar.Text = bar[i];
                        this.qua.Text = qua[i];
                        this.pri.Text = pri[i];
                        Name.Text = name[i];

                    }
                    else
                    {
                        MAX++;

                    }

                }
                else
                {
                    if (search.Text != name[i])
                    {
                        MAX++;

                    }
                    else
                    {
                        this.AA.IsChecked = false;
                        this.bar.Text = bar[i];
                        this.qua.Text = qua[i];
                        this.pri.Text = pri[i];
                        Name.Text = name[i];
                    }
                }

            }
            if (MAX == name.Count)
            {
                this.AA.IsChecked = false;
                this.AA.IsChecked = true;
                this.bar.Text = "";
                this.qua.Text = "";
                this.pri.Text = "";
                Name.Text = "";
            }
            bar.Clear();
            qua.Clear();
            pri.Clear();
            name.Clear();

            }
            catch (Exception ex) { }
        }

        private void search_J()
        {
            try { 
            var name = new List<string>();
            var sta = new List<string>();
            var pri = new List<string>();
            var data_acc = new OrcDataAcess3();
            var data_acc1 = new orcDataacess4();
            var dt = new DataTable();
            data_acc.Show(dt);
            data_acc1.Show(dt);

            foreach (DataRow Dr in dt.Rows)
            {

                name.Add(Dr.Field<string>("NAME"));
                sta.Add(Dr.Field<string>("PRICE"));
                pri.Add(Dr.Field<string>("STATE"));
            }
            int MAX = 0;
            for (int i = 0; i < name.Count; i++)
            {
                if (this.search.Text != name[i])
                {
                    MAX++;
                }
                else
                {
                    this.AA.IsChecked = false;
                    this.pri1.Text = pri[i];
                    this.Name1.Text = name[i];
                    this.bar1.Text = sta[i];
                }
                if (MAX == name.Count)
                {
                    this.AA.IsChecked = false;
                    this.AA.IsChecked = true;
                    this.pri1.Text = "";
                    this.Name1.Text = "";
                    this.bar1.Text = "";
                }


            }
            }
            catch (Exception ex) { }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_search_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (radioButton_Copy.IsChecked == true)
                search_P();
            else
                search_J();
        }

        private void radioButton_Copy_Checked(object sender, RoutedEventArgs e)
        {
            this.Name1.Visibility = Visibility.Hidden;
            this.bar1.Visibility = Visibility.Hidden;
            this.pri1.Visibility = Visibility.Hidden;
            this.textBlock1.Visibility = Visibility.Hidden;
            this.textBlock_Copy3.Visibility = Visibility.Hidden;
            this.textBlock_Copy4.Visibility = Visibility.Hidden;
            this.Name.Visibility = Visibility.Visible;
            this.bar.Visibility = Visibility.Visible;
            this.pri.Visibility = Visibility.Visible;
            this.qua.Visibility = Visibility.Visible;
            this.textBlock.Visibility = Visibility.Visible;
            this.textBlock_Copy.Visibility = Visibility.Visible;
            this.textBlock_Copy1.Visibility = Visibility.Visible;
            this.textBlock_Copy2.Visibility = Visibility.Visible;
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.Name.Visibility = Visibility.Hidden;
            this.bar.Visibility = Visibility.Hidden;
            this.pri.Visibility = Visibility.Hidden;
            this.qua.Visibility = Visibility.Hidden;
            this.textBlock.Visibility = Visibility.Hidden;
            this.textBlock_Copy.Visibility = Visibility.Hidden;
            this.textBlock_Copy1.Visibility = Visibility.Hidden;
            this.textBlock_Copy2.Visibility = Visibility.Hidden;
            this.Name1.Visibility = Visibility.Visible;
            this.bar1.Visibility = Visibility.Visible;
            this.pri1.Visibility = Visibility.Visible;
            this.textBlock1.Visibility = Visibility.Visible;
            this.textBlock_Copy3.Visibility = Visibility.Visible;
            this.textBlock_Copy4.Visibility = Visibility.Visible;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

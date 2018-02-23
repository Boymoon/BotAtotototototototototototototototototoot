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
    /// Interaction logic for ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : DXWindow
    {
        public ControlPanel()
        {
            InitializeComponent();
            Show();

        }
        private int NUMError = 0;
        private int FindErrors = 0;
        List<string> passlist = new List<string>();

        private void Show()
        {
            try { 
            DataTable datatable = new DataTable();
            var a = new Assest.Account();
            a.Show(datatable);
            var bindingsource = new System.Windows.Forms.BindingSource();
            bindingsource.DataSource = datatable;
            DT.ItemsSource = bindingsource;
            }
            catch (Exception ex) { }
        }
        private void Delete()
        {
            try
            {

            
            var a = new Assest.Account();
                DT.BeginSelection();
                foreach (int item in DT.GetSelectedRowHandles())
                {
                    a.Delete((String)DT.GetCellValue(item, "id"));
                }
                DT.EndSelection();
            }
            catch (Exception ex) { DXMessageBox.Show("الرجاء التحديد على العضو لتتمكن من حذفه", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
       
        private void FindError()
        {
            try
            {

       
            List<string> Lol = new List<string>();
            DataTable datatable = new DataTable();
            var a = new Assest.Account();
            a.Show(datatable);
            foreach(DataRow DR in datatable.Rows)
            {
                Lol.Add(DR.Field<string>("NAME"));  
            }
            
            for (int i = 0; i < Lol.Count; i++)
            {
                if (Lol[i] == name.Text || Lol[i] + "\n" == name.Text)
                {
                    DXMessageBox.Show("هذا الاسم  مستخدم سابقاً", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    NUMError =1;
                    break;

                }
                else
                {
                    FindErrors = 0;
                 
                }
            }
            if (FindErrors == 1&&NUMError!=1 || FindErrors == 0&&NUMError!=1)
            {
                FindError2 = 1;

            }
            else
            {
                FindError2--;
            
            }
            }
            catch (Exception ex) { }
        }
        private void Updating()
        {
            try
            {

            
            var a = new Assest.Account();
            if (name.Text == "")
            {
                DXMessageBox.Show("املأ حقل الاسم حتى يتم تحديث  البيانات", "خطـأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }else if (pass.Text == "")
            {
                DXMessageBox.Show("املأ حقل كلمة المرور حتى يتم تحديث  البيانات", "خطـأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }else if (state.Text=="")
            {
                DXMessageBox.Show("املأ حقل الصلاحية حتى يتم تحديث  البيانات", "خطـأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (name.Text != "" && pass.Text != "" && state.Text != "")
            {
                a.Udapting(name.Text, pass.Text,pass.Text, id.Text, state.Text);


            }
            }
            catch (Exception ex) { }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            
            FindError();
            Show();


            if (FindErrors == 1&&NUMError!=1 || FindErrors == 0 && NUMError != 1)
            {
                passlist.Add(pass.Text);
                Updating();
                XX.Visibility = Visibility.Hidden;
            
                Show();


            }
            }
            catch (Exception ex) { }

        }

        private void btndelete1_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            
            Delete();
            Show();
            }
            catch (Exception ex) { }
        }
        private int FindError2 = 0;
            private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            //FindError2 += 1;
        }

        private void btnedit_Click(object sender, RoutedEventArgs e)
        {
            var a = new Interface.PaneL();
            a.Show();
        }
    }
}

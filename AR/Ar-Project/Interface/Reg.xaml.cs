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
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class Reg : DXWindow
    {
        public Reg()
        {
            InitializeComponent();
        }
        public static string Name_Static = null;
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        string id = "";
        private void button_Click(object sender, RoutedEventArgs e)
        {
            int FindError = 0;
            int Ifinderror = 0;
            if (string.IsNullOrEmpty(name_style.Text)|| string.IsNullOrEmpty(pass_style.Text)|| string.IsNullOrEmpty(cm_style.Text))
            {
                MessageBox.Show("املأ الحقول الفارغة  لتتمكن  من التسجِيل", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                Ifinderror++;
                
            }
            if (Ifinderror==0)
            {
                var list = new List<string>();
                DataTable datatable = new DataTable();
                var acc = new Assest.Account();
                acc.Show(datatable);
                foreach (DataRow dt in datatable.Rows)
                {
                    list.Add(dt.Field<string>("NAME"));
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == name_style.Text)
                    {
                        DXMessageBox.Show("اسم المستخدم مُستخدم سابقاً", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                        FindError += 1;
                        break;
                    }
                    else
                    {
                        FindError = 0;
                        //null
                    }


                }
                if (FindError == 0)
                {
                    try
                    {

                        //DevExpress.Xpf.Editors.ComboBoxEditItem
                        DataTable DTable = new DataTable();
                        var a_ = new Assest.Account();
                        a_.Show(DTable); 
                        Guid genid = Guid.NewGuid();
                        id = genid.ToString().Replace("-", "");
                        id = id.Substring(10);
                       
                       // MessageBox.Show(cm_style.EditValue.ToString());
                      //  DevExpress.Xpf.Editors.ComboBoxEdit CM = (DevExpress.Xpf.Editors.ComboBoxEdit)cm_style.SelectedItemValue;
                        string Val = cm_style.EditValue.ToString();
                        acc.Insert(name_style.Text, pass_style.Text, Val, id.ToString());
                        this.Close();
                        DXMessageBox.Show(string.Format("تم التسجيل بنجاح {0}", name_style.Text), "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        Name_Static = name_style.Text;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
                }
                else
                {
                    //null
                }
            }
            else
            {

            }
         
          
        }
    }
}

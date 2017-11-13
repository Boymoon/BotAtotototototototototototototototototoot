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
using System.Data;

namespace Ar_Project.Interface
{
    /// <summary>
    /// Interaction logic for PaneL.xaml
    /// </summary>
    public partial class PaneL : DXWindow
    {
        public PaneL()
        {
            InitializeComponent();
            Show();

      
        }
        List<string> Names = new List<string>();
        int info = 0;


        void Show()
        {
            try
            {
                DataTable datatable = new DataTable();
                var a = new Assest.Account();
                a.Show(datatable);
                var bindingsource = new System.Windows.Forms.BindingSource();
                bindingsource.DataSource = datatable;
                Datacontrol.ItemsSource = bindingsource;
            }
            catch (Exception ex) { }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (String.IsNullOrEmpty(Name_.Text))
                {
                    DXMessageBox.Show("يجب تعبئة  الحقل حتى  يتم التعديل على اسم الحساب", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                else if (String.IsNullOrEmpty(Pass.Text))
                {
                    DXMessageBox.Show("يجب تعبئة  الحقل حتى  يتم التعديل على كلمة مرور الحساب", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;

                }
                else if (String.IsNullOrEmpty(State.Text))
                {
                    DXMessageBox.Show("يجب تعبئة  الحقل حتى  يتم التعديل على صلاحية الحساب", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }



                DataTable datatable = new DataTable();
                var a = new Assest.Account();
                a.Show(datatable);
                var names = new List<string>();
                foreach (DataRow item in datatable.Rows)
                {
                    names.Add(item.Field<string>("NAME"));
                }

                if (info >= 2)
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        try
                        {
                            if (Names.Count != 0)
                            {
                                if (Names[Names.Count - 1] == names[i])
                                {
                                    System.Windows.Forms.MessageBox.Show("اسم الحساب مُستخدم ", "خطأ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                                    break;
                                }
                            }

                        }
                        catch (Exception ex) { }
                    }
                    a.Udapting(Name_.Text, Pass.Text, Pass.Text, id.Text, State.Text);
                    Show();
                    Names.Clear();
                }
                else if (info == 0 || info == 1)
                {
                    a.Udapting(Name_.Text, Pass.Text, Pass.Text, id.Text, State.Text);
                    Show();
                    Names.Clear();
                }
                break;
            }
        }

        private void Name_EditValueChanging(object sender, DevExpress.Xpf.Editors.EditValueChangingEventArgs e)
        {
          
        }

        private void Name__EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            Names.Add(Name_.Text);
            info++;
        }
    }
}

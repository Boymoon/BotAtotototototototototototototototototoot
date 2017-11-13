using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ar_Project.Reports
{

    
    public partial class XtraReport5 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport5()
        {

          

            InitializeComponent();

            if (PrintHelper.Print.IsDay_ == true)
            {
                xday.Text = "اليومي";
            }
            else if (PrintHelper.Print.IsMounth_ == true)
            {
                xday.Text = "الشهري";
            }
            else if (PrintHelper.Print.IsYear_ == true)
            {
                xday.Text = "السنوي";
            }

        }
        string result = "";
        private string getprice()
        {
            System.Data.DataTable data = new System.Data.DataTable();
            var a = new ModelMega();
            a.show1(data);
            var cur = new FunctionsOfSum();
            result=cur.sumPrice(data);



            return result;
        }
        private void xrLabel4_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            getprice();
            e.Result = result;
            e.Handled = true;
        }

        private void xrLabel4_SummaryReset(object sender, EventArgs e)
        {
            result = "";
        }

        private void xrLabel4_SummaryRowChanged(object sender, EventArgs e)
        {

        }

        private void xrCheckBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void xrCheckBox1_EvaluateBinding(object sender, BindingEventArgs e)
        {
            e.Value = true;
        }
    }
}

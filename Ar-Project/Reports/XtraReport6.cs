using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;

namespace Ar_Project.Reports
{
    public partial class XtraReport6 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport6()
        {
            InitializeComponent();
        }
        string result = "";
        private string getprice()
        {
            DataTable data = new DataTable();
            var moe = new ModelMega();
            moe.show(data);
            var sum = new FunctionsOfSum();
            result = sum.sumPrice(data);
            return result;
        }
        private void xrLabel4_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            getprice();
            e.Result = result;
            e.Handled = true;
        }

        private void xrCheckBox2_Draw(object sender, DrawEventArgs e)
        {

        }
        int numric = -1;
        List<bool> a = new List<bool>();
        private void Make()
        {
            DataTable data = new DataTable();
            var moe = new ModelMega();
            moe.show(data);
            foreach (DataRow item in data.Rows)
            {
                a.Add((item.Field<bool>("isdone"))?false:true);
            }
        }
   
        private void xrCheckBox2_EvaluateBinding(object sender, BindingEventArgs e)
        {
            numric++;
            if (numric == 0)
            {
                Make();
            }
            e.Value = a[numric];
            
            


        }
    }
}

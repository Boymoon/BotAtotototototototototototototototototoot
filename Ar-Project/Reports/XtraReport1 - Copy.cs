using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Ar_Project
{
    public partial class XtraReport1_ : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1_()
        {
            InitializeComponent();
            if (PrintHelper.Print.IsDay_)
            {
                xrLabel2.Text = "اليومي";
            }else if (PrintHelper.Print.IsMounth_)
            {
                xrLabel2.Text = "الشهري";
            }
            else if (PrintHelper.Print.IsYear_)
            {
                xrLabel2.Text = "السنوي";
            }
        }

        private void BottomMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}

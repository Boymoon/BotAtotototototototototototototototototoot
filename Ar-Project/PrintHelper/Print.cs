using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.Xpf.Printing;

namespace Ar_Project.PrintHelper
{
   public static class Print
    {
        private static bool IsDay=false;
        private static bool IsMounth=false;
        private static bool IsYear=false;
        private static DataTable Datatable;
        public static bool IsDay_
        {
            get { return IsDay; }
            set { IsDay = value; }
        } 
        public static bool IsMounth_
        {
            get { return IsMounth; }
            set { IsMounth = value; }
        }
        public static bool IsYear_
        {
            get { return IsYear; }
            set { IsYear = value; }
        }
        public static DataTable Datatable_
        {
            get { return Datatable; }
            set { Datatable = value; }
        }




    

       
        public static void GET_STRATED()
        {
           
            var DataOprator = new Assest.OrcDataAcess();
           
                if (IsDay == true)
                {
                try
                {
                    foreach (DataRow r in Datatable.Rows)
                    {
                        DataOprator.insert4(r.Field<string>("DAT"),
                            r.Field<string>("NAME"),
                            r.Field<string>("PRICE"),
                            "0",
                            r.Field<string>("PRICE_A"),
                            r.Field<string>("BARCODE"),
                            r.Field<string>("NUMF"),
                            r.Field<string>("DOW"),
                           ("0"));
                    }
                    // DataOprator.Delete4();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Day_Section_Get_Started:" + ex.HResult.ToString());
                }
            }
                else if (IsMounth == true)
                {
                try {
                    foreach (DataRow r in Datatable.Rows)
                    {
                        DataOprator.insert4(r.Field<string>("DAT"),
                               r.Field<string>("NAME"),
                               r.Field<string>("PRICE"),
                               "0",
                               r.Field<string>("PRICE_A"),
                               r.Field<string>("BARCODE"),
                               r.Field<string>("NUMF"),
                               r.Field<string>("DOW"),
                              ("0"));
                    }
                }catch(Exception ex)
                {
                    System.Windows.MessageBox.Show("Month_Section_Get_started:" + ex.HResult.ToString());
                }

                } else if (IsYear == true)
                {
                try { 
                    foreach (DataRow r in Datatable.Rows)
                    {
                        DataOprator.insert4(r.Field<string>("DAT"),
                               r.Field<string>("NAME"),
                               r.Field<string>("PRICE"),
                               "0",
                               r.Field<string>("PRICE_A"),
                               r.Field<string>("BARCODE"),
                               r.Field<string>("NUMF"),
                               r.Field<string>("DOW"),
                              ("0"));
                    }
                }
                catch (Exception ex)
                {
                  
                }

                // DataOprator.Delete4();
            }
          

        }
       
       
    }





}   

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Ar_Project.Assest;
using System.Windows.Data;
using System.Windows.Forms;


namespace Ar_Project
{
  public class Comparsion
    {
       
        /// <summary>
        /// ForFiltring Days And Months and years 
        /// </summary>
        /// <param name="Typesearch"></param>
        /// <returns></returns>
        public  void FieldDataTables(TypeSearch Typesearch,DataTable data)
        {
            List<string> Name = new List<string>();
            List<string> NUMF = new List<string>();
            List<string> Price = new List<string>();
            List<string> Price_a = new List<string>();
            List<string> DOW = new List<string>();
            List<string> Barcode = new List<string>();
            List<string> DAT = new List<string>();

            //-=-=-
            List<string> Name_ = new List<string>();
            List<string> NUMF_ = new List<string>();
            List<string> Price_ = new List<string>();
            List<string> Price_a_ = new List<string>();
            List<string> DOW_ = new List<string>();
            List<string> Barcode_ = new List<string>();
            List<string> DAT_ = new List<string>();

            BindingSource Bind = new BindingSource();
            if (Typesearch == TypeSearch.Day)
            {
             
                DataTable dt = new DataTable();
                var GetTables = new OrcDataAcess();
                GetTables.show3(dt);
                foreach (DataRow item in dt.Rows)
                {
                    Name.Add(item.Field<string>("NAME"));
                    NUMF.Add(item.Field<string>("NUMF"));
                    Price.Add(item.Field<string>("PRICE"));
                    Price_a.Add(item.Field<string>("PRICE_A"));
                    DOW.Add(item.Field<string>("DOW"));
                    Barcode.Add(item.Field<string>("BARCODE"));
                    DAT.Add(item.Field<string>("DAT"));
                }
             
                

                var DayList = new List<string>();
                foreach (var item in SealsFunction.GetDays())
                    DayList.Add(item);//Add Days For Compairing.

                for (int i = 0; i < DayList.Count; i++)
                {
                    if (SealsFunction.ExtractDaysFromDate() == DayList[i]) {
                        Name_.Add(Name[i]);
                        Barcode_.Add(Barcode[i]);
                        Price_.Add(Price[i]);
                        Price_a_.Add(Price_a[i]);
                        DOW_.Add(DOW[i]);
                        DAT_.Add(DAT[i]);
                        NUMF_.Add(NUMF[i]);

                    }
                }
            
                data.Columns.Add("NAME");
                data.Columns.Add("NUMF");
                data.Columns.Add("PRICE");
                data.Columns.Add("PRICE_A");
                data.Columns.Add("DOW");
                data.Columns.Add("BARCODE");
                data.Columns.Add("DAT");
                for (int ii = 0; ii < Name_.Count; ii++)
                {
                    DataRow datarow = data.NewRow();
                    datarow["NAME"] = Name_[ii];
                    datarow["NUMF"] = NUMF_[ii];
                    datarow["PRICE"] = Price_[ii];
                    datarow["PRICE_A"] = Price_a_[ii];
                    datarow["DOW"] = DOW_[ii];
                    datarow["BARCODE"] = Barcode_[ii];
                    datarow["DAT"] = DAT_[ii];
                    data.Rows.Add(datarow);
                }
                PrintHelper.Print.Datatable_ = data;
                PrintHelper.Print.IsDay_ = true;
                PrintHelper.Print.IsMounth_ = false;
                PrintHelper.Print.IsYear_ = false;
            }
            else if (Typesearch == TypeSearch.Month)
            {
            
                DataTable dt = new DataTable();
                var GetTables = new OrcDataAcess();
                GetTables.show3(dt);
                foreach (DataRow item in dt.Rows)
                {
                    Name.Add(item.Field<string>("NAME"));
                    NUMF.Add(item.Field<string>("NUMF"));
                    Price.Add(item.Field<string>("PRICE"));
                    Price_a.Add(item.Field<string>("PRICE_A"));
                    DOW.Add(item.Field<string>("DOW"));
                    Barcode.Add(item.Field<string>("BARCODE"));
                    DAT.Add(item.Field<string>("DAT"));
                }



                var Monthlist = new List<string>();
                foreach (var item in SealsFunction.GetMonths())
                    Monthlist.Add(item);//Add Days For Compairing.

                for (int i = 0; i < Monthlist.Count; i++)
                {
                    if (SealsFunction.ExtractmonthsFromDate() == Monthlist[i])
                    {
                        Name_.Add(Name[i]);
                        Barcode_.Add(Barcode[i]);
                        Price_.Add(Price[i]);
                        Price_a_.Add(Price_a[i]);
                        DOW_.Add(DOW[i]);
                        DAT_.Add(DAT[i]);
                        NUMF_.Add(NUMF[i]);

                    }
                }

                data.Columns.Add("NAME");
                data.Columns.Add("NUMF");
                data.Columns.Add("PRICE");
                data.Columns.Add("PRICE_A");
                data.Columns.Add("DOW");
                data.Columns.Add("BARCODE");
                data.Columns.Add("DAT");
                for (int ii = 0; ii < Name_.Count; ii++)
                {
                    DataRow datarow = data.NewRow();
                    datarow["NAME"] = Name_[ii];
                    datarow["NUMF"] = NUMF_[ii];
                    datarow["PRICE"] = Price_[ii];
                    datarow["PRICE_A"] = Price_a_[ii];
                    datarow["DOW"] = DOW_[ii];
                    datarow["BARCODE"] = Barcode_[ii];
                    datarow["DAT"] = DAT_[ii];
                    data.Rows.Add(datarow);

                }
           

                PrintHelper.Print.Datatable_ = data;
                PrintHelper.Print.IsDay_ = false;
                PrintHelper.Print.IsMounth_ = true;
                PrintHelper.Print.IsYear_ = false;
            }
            else if (Typesearch == TypeSearch.SquareYear)
            {
                DataTable dt = new DataTable();
                var GetTables = new OrcDataAcess();
                GetTables.show3(dt);
                foreach (DataRow item in dt.Rows)
                {
                    Name.Add(item.Field<string>("NAME"));
                    NUMF.Add(item.Field<string>("NUMF"));
                    Price.Add(item.Field<string>("PRICE"));
                    Price_a.Add(item.Field<string>("PRICE_A"));
                    DOW.Add(item.Field<string>("DOW"));
                    Barcode.Add(item.Field<string>("BARCODE"));
                    DAT.Add(item.Field<string>("DAT"));
                }



       
                var MonthList = new List<string>();
          
                foreach (var item in SealsFunction.GetMonths())
                    MonthList.Add(item);//Add Days For Compairing.

                for (int i = 0; i < MonthList.Count; i++)
                {
                    if (DateTime.Now.Day.ToString() == MonthList[i])
                    {
                        Name_.Add(Name[i]);
                        Barcode_.Add(Barcode[i]);
                        Price_.Add(Price[i]);
                        Price_a_.Add(Price_a[i]);
                        DOW_.Add(DOW[i]);
                        DAT_.Add(DAT[i]);
                        NUMF_.Add(NUMF[i]);

                    }
                }

                data.Columns.Add("NAME");
                data.Columns.Add("NUMF");
                data.Columns.Add("PRICE");
                data.Columns.Add("PRICE_A");
                data.Columns.Add("DOW");
                data.Columns.Add("BARCODE");
                data.Columns.Add("DAT");
                for (int ii = 0; ii < Name_.Count; ii++)
                {
                    DataRow datarow = data.NewRow();
                    datarow["NAME"] = Name_[ii];
                    datarow["NUMF"] = NUMF_[ii];
                    datarow["PRICE"] = Price_[ii];
                    datarow["PRICE_A"] = Price_a_[ii];
                    datarow["DOW"] = DOW_[ii];
                    datarow["BARCODE"] = Barcode_[ii];
                    datarow["DAT"] = DAT_[ii];
                    data.Rows.Add(datarow);

                }

            }
            else if (Typesearch == TypeSearch.Year)
            {
          
                DataTable dt = new DataTable();
                var GetTables = new OrcDataAcess();
                GetTables.show3(dt);
                foreach (DataRow item in dt.Rows)
                {
                    Name.Add(item.Field<string>("NAME"));
                    NUMF.Add(item.Field<string>("NUMF"));
                    Price.Add(item.Field<string>("PRICE"));
                    Price_a.Add(item.Field<string>("PRICE_A"));
                    DOW.Add(item.Field<string>("DOW"));
                    Barcode.Add(item.Field<string>("BARCODE"));
                    DAT.Add(item.Field<string>("DAT"));
                }



                var yearlist = new List<string>();
                foreach (var item in SealsFunction.GetYears())
                    yearlist.Add(item);//Add Days For Compairing.

                for (int i = 0; i < yearlist.Count; i++)
                {
                    if (SealsFunction.ExtractyearsFromDate() == yearlist[i])
                    {
                        Name_.Add(Name[i]);
                        Barcode_.Add(Barcode[i]);
                        Price_.Add(Price[i]);
                        Price_a_.Add(Price_a[i]);
                        DOW_.Add(DOW[i]);
                        DAT_.Add(DAT[i]);
                        NUMF_.Add(NUMF[i]);

                    }
                }

                data.Columns.Add("NAME");
                data.Columns.Add("NUMF");
                data.Columns.Add("PRICE");
                data.Columns.Add("PRICE_A");
                data.Columns.Add("DOW");
                data.Columns.Add("BARCODE");
                data.Columns.Add("DAT");
                for (int ii = 0; ii < Name_.Count; ii++)
                {
                    DataRow datarow = data.NewRow();
                    datarow["NAME"] = Name_[ii];
                    datarow["NUMF"] = NUMF_[ii];
                    datarow["PRICE"] = Price_[ii];
                    datarow["PRICE_A"] = Price_a_[ii];
                    datarow["DOW"] = DOW_[ii];
                    datarow["BARCODE"] = Barcode_[ii];
                    datarow["DAT"] = DAT_[ii];
                    data.Rows.Add(datarow);
                }
                PrintHelper.Print.Datatable_ = data;
                PrintHelper.Print.IsDay_ = false;
                PrintHelper.Print.IsMounth_ = false;
                PrintHelper.Print.IsYear_ = true;
            }


        }

        

    }
}

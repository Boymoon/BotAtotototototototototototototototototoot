using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using DevExpress.Xpf.Core;
using System.Windows.Media;
using System.Globalization;

namespace Ar_Project
{
   public class RepairVIEW
    {



















        public static List<string> GetDays()
        {
            UmAlQuraCalendar um = new UmAlQuraCalendar();
            var dt = new DataTable();
            var GetDateFromDatabase = new ModelMega();
            GetDateFromDatabase.show(dt);
            var Result = new List<string>();
            var WholeDate = new List<string>();
            foreach (DataRow item in dt.Rows)
                WholeDate.Add((DateTime.Parse(item.Field<string>("datrec")).Year.ToString()).Contains("143") || DateTime.Parse(item.Field<string>("datrec")).Year.ToString().Contains("144") ?
                                           DateTime.Parse(item.Field<string>("datrec")).Day.ToString() :
                                           um.GetDayOfMonth(DateTime.Parse(item.Field<string>("datrec"))).ToString());





            return WholeDate;
        }

        public static List<string> GetMonths()
        {
            UmAlQuraCalendar um = new UmAlQuraCalendar();
            var dt = new DataTable();
            var GetDateFromDatabase = new ModelMega();
            GetDateFromDatabase.show(dt);
            var Result = new List<string>();
            var WholeDate = new List<string>();
            foreach (DataRow item in dt.Rows)
                WholeDate.Add((DateTime.Parse(item.Field<string>("datrec")).Year.ToString()).Contains("143") || DateTime.Parse(item.Field<string>("datrec")).Year.ToString().Contains("144") ?
                                DateTime.Parse(item.Field<string>("datrec")).Month.ToString() :
                                um.GetMonth(DateTime.Parse(item.Field<string>("datrec"))).ToString());


            return WholeDate;
        }

        public static List<string> GetYears()
        {
            UmAlQuraCalendar um = new UmAlQuraCalendar();  
            var dt = new DataTable();
            var GetDateFromDatabase = new ModelMega();
            GetDateFromDatabase.show(dt);
            var Result = new List<string>();
            var WholeDate = new List<string>();
            foreach (DataRow item in dt.Rows)
                WholeDate.Add((DateTime.Parse(item.Field<string>("datrec")).Year.ToString()).Contains("143") || DateTime.Parse(item.Field<string>("datrec")).Year.ToString().Contains("144") ?
                   DateTime.Parse(item.Field<string>("datrec")).Year.ToString() :
                   um.GetYear(DateTime.Parse(item.Field<string>("datrec"))).ToString());



            return WholeDate;
        }


        private ImageSource GetImage(string path)
        {
            return new System.Windows.Media.Imaging.BitmapImage(new Uri(path, UriKind.Relative));
        }




        /*
        
          ID = item.Field<string>("ID"),
                    conprou = item.Field<string>("conprou"),
                    PRICE = item.Field<string>("PRICE"),
                    DAT = item.Field<string>("DAT"),
                    NAME = item.Field<string>("NAME"),
                    datrec = item.Field<string>("datrec"),
                    discounts = item.Field<string>("discounts"),
                    typeprou = item.Field<string>("typeprou"),
                    isdone = (item.Field<bool>("isdone")) ? GetImage(@"/images/ionicons_2-0-1_ios-timer_23_0_27ae60_none.png") : GetImage(@"/images/material-icons_3-0-1_done_23_0_27ae60_none.png")
        
        
      */
        public void Create(TypeSearch Type, ObservableCollectionCore<Models.RepairView> data)
        {
            var ID = new List<string>();
            var conprou = new List<string>();
            var PRICE = new List<string>();
            var DAT = new List<string>();
            var NAME = new List<string>();
            var datrec = new List<string>();
            var discounts = new List<string>();
            var typeprou = new List<string>();
            var isdone = new List<bool>();

            var ID_ = new List<string>();
            var conprou_ = new List<string>();
            var PRICE_ = new List<string>();
            var DAT_ = new List<string>();
            var NAME_ = new List<string>();
            var datrec_ = new List<string>();
            var discounts_ = new List<string>();
            var typeprou_ = new List<string>();
            var isdone_ = new List<bool>();
            BindingSource bind = new BindingSource();


            if (Type==TypeSearch.Day)
            {
                DataTable dt = new DataTable();
                var gettables = new ModelMega();
                gettables.show(dt);
                foreach (DataRow item in dt.Rows)
                {
                    ID.Add(item.Field<string>("ID"));
                    conprou.Add(item.Field<string>("conprou"));
                    PRICE.Add(item.Field<string>("PRICE"));
                    DAT.Add(item.Field<string>("DAT"));
                    NAME.Add(item.Field<string>("NAME"));
                    datrec.Add(item.Field<string>("datrec"));
                    discounts.Add(item.Field<string>("discounts"));
                    typeprou.Add(item.Field<string>("typeprou"));
                    isdone.Add(item.Field<bool>("isdone"));
                }


                var daylist = new List<string>();
                foreach (var item in GetDays())
                {

                    daylist.Add(item);




                }
                for (int i = 0; i < daylist.Count; i++)
                {
                    if (SealsFunction.ExtractDaysFromDate()==daylist[i])
                    {
                        ID_.Add(ID[i]);
                        conprou_.Add(conprou[i]);
                        PRICE_.Add(PRICE[i]);
                        DAT_.Add(DAT[i]);
                        NAME_.Add(NAME[i]);
                        datrec_.Add(datrec[i]);
                        discounts_.Add(discounts[i]);
                        typeprou_.Add(typeprou[i]);
                        isdone_.Add(isdone[i]);



                    }
                }

                var modelmega = new ModelMega();
                for (int ii = 0; ii < NAME_.Count; ii++)
                {
                    //ID_.Add(ID[i]);
                    //conprou_.Add(conprou[i]);
                    //PRICE_.Add(PRICE[i]);
                    //DAT_.Add(DAT[i]);
                    //NAME_.Add(NAME[i]);
                    //datrec_.Add(datrec[i]);
                    //discounts_.Add(discounts[i]);
                    //typeprou_.Add(typeprou[i]);
                    //isdone_.Add(isdone[i]);

                    if (isdone_[ii])
                    { 
                        data.Add(new Models.RepairView()
                        {
                            ID = ID_[ii],
                            conprou = conprou_[ii],
                            DAT = DAT_[ii],
                            datrec = datrec_[ii],
                            discounts = discounts_[ii],
                            isdone = isdone_[ii]
                            ,
                            NAME = NAME_[ii],
                            PRICE = PRICE_[ii],
                            typeprou = typeprou_[ii]
                        });

                    modelmega.add1(ID_[ii], NAME_[ii], PRICE_[ii], DAT[ii], datrec_[ii], conprou_[ii], typeprou_[ii], discounts_[ii], (isdone_[ii]) ? -1 : 0);

                    }


                    //datarow["ID"] = ID_[ii];
                    //datarow["NAME"] = NAME_[ii];
                    //datarow["DAT"] = DAT_[ii];
                    //datarow["datrec"] = datrec_[ii];
                    //datarow["typeprou"] = typeprou_[ii];
                    //datarow["PRICE"] = PRICE_[ii];
                    //datarow["discounts"] = discounts_[ii];
                    //datarow["conprou"] = conprou_[ii];
                    //datarow["isdone"] = isdone_[ii];
                }


             




            }
            else if (Type == TypeSearch.Year)
            {
                DataTable dt = new DataTable();
                var gettables = new ModelMega();
                gettables.show(dt);
                foreach (DataRow item in dt.Rows)
                {
                    ID.Add(item.Field<string>("ID"));
                    conprou.Add(item.Field<string>("conprou"));
                    PRICE.Add(item.Field<string>("PRICE"));
                    DAT.Add(item.Field<string>("DAT"));
                    NAME.Add(item.Field<string>("NAME"));
                    datrec.Add(item.Field<string>("datrec"));
                    discounts.Add(item.Field<string>("discounts"));
                    typeprou.Add(item.Field<string>("typeprou"));
                    isdone.Add(item.Field<bool>("isdone"));
                }


                var daylist = new List<string>();
                foreach (var item in GetYears())
                {

                    daylist.Add(item);




                }
                for (int i = 0; i < daylist.Count; i++)
                {
                    if (SealsFunction.ExtractyearsFromDate() == daylist[i])
                    {
                        ID_.Add(ID[i]);
                        conprou_.Add(conprou[i]);
                        PRICE_.Add(PRICE[i]);
                        DAT_.Add(DAT[i]);
                        NAME_.Add(NAME[i]);
                        datrec_.Add(datrec[i]);
                        discounts_.Add(discounts[i]);
                        typeprou_.Add(typeprou[i]);
                        isdone_.Add(isdone[i]);



                    }
                }




                var modelmega = new ModelMega();



                for (int ii = 0; ii < NAME_.Count; ii++)
                {



                    if (isdone_[ii])
                    {



                        data.Add(new Models.RepairView()
                        {
                            ID = ID_[ii],
                            conprou = conprou_[ii],
                            DAT = DAT_[ii],
                            datrec = datrec_[ii],
                            discounts = discounts_[ii],
                            isdone = (isdone_[ii]) ?true:false
                            ,
                            NAME = NAME_[ii],
                            PRICE = PRICE_[ii],
                            typeprou = typeprou_[ii]
                        });

                        modelmega.add1(ID_[ii], NAME_[ii], PRICE_[ii], DAT[ii], datrec_[ii], conprou_[ii], typeprou_[ii], discounts_[ii], (isdone_[ii]) ? -1: 0);
                    }
                }







            }
            else
            if (Type == TypeSearch.Month)
            {
                DataTable dt = new DataTable();
                var gettables = new ModelMega();
                gettables.show(dt);
                foreach (DataRow item in dt.Rows)
                {
                    ID.Add(item.Field<string>("ID"));
                    conprou.Add(item.Field<string>("conprou"));
                    PRICE.Add(item.Field<string>("PRICE"));
                    DAT.Add(item.Field<string>("DAT"));
                    NAME.Add(item.Field<string>("NAME"));
                    datrec.Add(item.Field<string>("datrec"));
                    discounts.Add(item.Field<string>("discounts"));
                    typeprou.Add(item.Field<string>("typeprou"));
                    isdone.Add(item.Field<bool>("isdone"));
                }


                var daylist = new List<string>();
                foreach (var item in GetMonths())
                {

                    daylist.Add(item);




                }
                for (int i = 0; i < daylist.Count; i++)
                {
                    if (SealsFunction.ExtractmonthsFromDate() == daylist[i])
                    {
                        ID_.Add(ID[i]);
                        conprou_.Add(conprou[i]);
                        PRICE_.Add(PRICE[i]);
                        DAT_.Add(DAT[i]);
                        NAME_.Add(NAME[i]);
                        datrec_.Add(datrec[i]);
                        discounts_.Add(discounts[i]);
                        typeprou_.Add(typeprou[i]);
                        isdone_.Add(isdone[i]);



                    }
                }

                var modelmega = new ModelMega();
                for (int ii = 0; ii < NAME_.Count; ii++)
                {

                    if (isdone_[ii])
                    {
                        data.Add(new Models.RepairView()
                        {
                            ID = ID_[ii],
                            conprou = conprou_[ii],
                            DAT = DAT_[ii],
                            datrec = datrec_[ii],
                            discounts = discounts_[ii],
                            isdone = isdone_[ii]
                            ,
                            NAME = NAME_[ii],
                            PRICE = PRICE_[ii],
                            typeprou = typeprou_[ii]
                        });

                        modelmega.add1(ID_[ii], NAME_[ii], PRICE_[ii], DAT[ii], datrec_[ii], conprou_[ii], typeprou_[ii], discounts_[ii], (isdone_[ii]) ? -1: 0);
                    }
                    }







            }




        }









    }
}

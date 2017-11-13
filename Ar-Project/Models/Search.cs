using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Core;
using DevExpress.Data;
using DevExpress.Xpf.Core;
using System.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ar_Project

{
    public enum type
    {
        Sales=0,
        salesOfCou=1,
        other=2
    }
   public  class Searchh
    {

     

        public ObservableCollectionCore<Coustomer> Sales(string name)
        {
            var NAME = new List<string>();
            var PRICE = new List<string>();
            var PRICE_A = new List<string>();
            var DAT = new List<string>();
            var QUANTITY = new List<string>();
            var BARCODE = new List<string>();
            var Dis = new List<string>();
            var Price_F = new List<string>();
            var ID = new List<string>();
            DataTable dt = new DataTable();
            var Getdata = new Assest.OrcDataAcess();
            Getdata.Show(dt);
            foreach (DataRow item in dt.Rows)
            {
                NAME.Add(item.Field<String>("NAME"));
                PRICE.Add(item.Field<String>("PRICE"));
                PRICE_A.Add(item.Field<String>("PRICE_A"));
                DAT.Add(item.Field<String>("DAT"));
                QUANTITY.Add(item.Field<String>("QUANTITY"));
                BARCODE.Add(item.Field<String>("BARCODE"));
                Dis.Add(item.Field<String>("Dis"));
                Price_F.Add(item.Field<String>("Price_F"));
                ID.Add(item.Field<String>("ID"));


            }

            ObservableCollectionCore<Coustomer> sales = new ObservableCollectionCore<Coustomer>();

            for (int i = 0; i < NAME.Count; i++)
            {
                if (NAME[i].Contains(name))
                {
                    sales.Add(new Coustomer()
                    {
                        QUANTITY = QUANTITY[i],
                        NAME = NAME[i],
                        BARCODE = BARCODE[i],
                        DAT = DAT[i],
                        PRICE_A = PRICE_A[i],
                        Dis = Dis[i],
                        PRICE = PRICE[i],
                        Price_F = Price_F[i],
                        ID = ID[i],

                    });
                }
              
              
            }
            return sales;

        }



        public ObservableCollectionCore<Models.RepairView> Sales_2(string name)
        {
            var ID = new List<string>();
            var NAME = new List<string>();
            var PRICE = new List<string>();
            var conprou = new List<string>();
            var DAT = new List<string>();
            var datrec = new List<string>();
            var typeprou = new List<string>();
            var discouns = new List<string>();
            var isdone = new List<bool>();

            DataTable dt = new DataTable();
            var Getdata = new ModelMega();
            Getdata.show(dt);
            foreach (DataRow item in dt.Rows)
            {
                NAME.Add(item.Field<String>("NAME"));
                PRICE.Add(item.Field<String>("PRICE"));
                ID.Add(item.Field<String>("ID"));
                DAT.Add(item.Field<String>("DAT"));
                datrec.Add(item.Field<String>("datrec"));
                typeprou.Add(item.Field<String>("typeprou"));
                discouns.Add(item.Field<String>("discounts"));
                conprou.Add(item.Field<String>("conprou"));
                isdone.Add(item.Field<bool>("isdone"));


            }

            ObservableCollectionCore<Models.RepairView> sales = new ObservableCollectionCore<Models.RepairView>();

            for (int i = 0; i < NAME.Count; i++)
            {
                if (NAME[i].Contains(name))
                {
                    sales.Add(new Models.RepairView()
                    {
                       conprou=conprou[i],
                       DAT=DAT[i],
                       datrec=datrec[i],
                       discounts=discouns[i],
                       ID=ID[i],
                       NAME=NAME[i],
                       PRICE=PRICE[i],
                       typeprou=typeprou[i],
                       isdone = isdone[i] ?false:true



                    });
                }


            }
            return sales;

        }



        public ObservableCollectionCore<Clients> Other(string name)
        {
            var ID = new List<string>();
            var NAME = new List<string>();
            var NUM = new List<int>();
           

            DataTable dt = new DataTable();
            var Getdata = new Assest.OrcDataAcess2();
            Getdata.Show(dt);
            foreach (DataRow item in dt.Rows)
            {
                NAME.Add(item.Field<String>("NAME"));
                NUM.Add(item.Field<int>("NUM"));
                ID.Add(item.Field<String>("ID"));
               


            }

            ObservableCollectionCore<Clients> sales = new ObservableCollectionCore<Clients>();

            for (int i = 0; i < NAME.Count; i++)
            {
                if (NAME[i].Contains(name))
                {
                    sales.Add(new Clients()
                    {
                      ID=ID[i],
                      NAME=NAME[i],
                      NUM=NUM[i]



                    });
                }


            }
            return sales;

        }






        private ImageSource GetImage(string path)
        {
            return new BitmapImage(new Uri(path, UriKind.Relative));
        }
    }




}

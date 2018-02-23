using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Ar_Project.Assest;
using DevExpress.Xpf.Core;

namespace Ar_Project
{
    
    public  class FunctionsOfSum
    {
        OrcDataAcess GetPriceAndNumf = new OrcDataAcess();
        public string orignial_Sum()
        {
            DataTable dt = new DataTable();
            var mainclass = new Assest.OrcDataAcess();
            mainclass.show4(dt);
            var Prices = new List<string>();
            var Countier = new List<int>();

            foreach (DataRow item in dt.Rows)
            {
                Prices.Add(item.Field<string>("PRICE").Replace("SAR",""));
            }
            for (int i = 0; i < Prices.Count-1; i++)
            {
                Countier.Add(int.Parse(Prices[i]));
            }
           Double Result = Countier.Sum();
            return "SAR "+Result.ToString("N2");
            
        }
        public string sumPrice()
        {

            var listPrice = new List<string>();
            DataTable dt = new DataTable();
            GetPriceAndNumf.show3(dt);
            foreach (DataRow item in dt.Rows)
            {
                listPrice.Add(item.Field<string>("PRICE"));
           
            }
            double result = 0;
            for (int i = 0; i < listPrice.Count; i++)
            {
              result += double.Parse(listPrice[i].Replace("SAR","").Replace(",",""));
            }
            return "SAR " + result.ToString();

        }

        public string sumPrice(string numf)
        {
        
            var listNumf = new List<string>();
            var listPrice = new List<string>();
            DataTable dt = new DataTable();
            GetPriceAndNumf.show3(dt);
            foreach (DataRow item in dt.Rows)
            {
                listPrice.Add(item.Field<string>("PRICE"));
                listNumf.Add(item.Field<string>("NUMF"));
            }
        Double result= 0;
            for (int i = 0; i < listPrice.Count; i++)
            {
                if (listNumf[i] == numf)
                  result += double.Parse(listPrice[i].Replace("SAR","").Replace(",",""));
            }
                       return "SAR " + result.ToString("N0");

        }

        public string sumPrice_a()
        {
            var listPrice = new List<string>();
            DataTable dt = new DataTable();
                GetPriceAndNumf.show3(dt);
            foreach (DataRow item in dt.Rows)
            {
                listPrice.Add(item.Field<string>("PRICE_A"));
            }
        Double result= 0;
            for (int i = 0; i < listPrice.Count; i++)
            {
              result += int.Parse(listPrice[i].Replace("SAR","").Replace(",",""));
            }
                       return "SAR " + result.ToString("N2");

        }

        public string sumPrice_a(string numf)
        {
            
            
            var listNumf = new List<string>();
            var listPrice = new List<string>();
            DataTable dt = new DataTable();
                GetPriceAndNumf.show3(dt);
            foreach (DataRow item in dt.Rows)
            {
                listPrice.Add(item.Field<string>("PRICE_A"));
                listNumf.Add(item.Field<string>("NUMF"));
            }
           Double result= 0;
            for (int i = 0; i < listPrice.Count; i++)
            {
                if (listNumf[i] == numf)
                    result += int.Parse(listPrice[i].Replace("SAR","").Replace(",",""));
            }
                       return "SAR " + result.ToString("N0");

        }


        public string sumPrice(ObservableCollectionCore<Models.RepairView> collection)
        {
            var megaview = new MegaView();

            var listPrice = new List<string>();

            foreach (DataRow item in megaview.GetAllItemsHasSold().Rows)
            {
                listPrice.Add(item.Field<string>("PRICE"));

            }
            double result = 0;
            for (int i = 0; i < listPrice.Count; i++)
            {
                result += double.Parse(listPrice[i].Replace("SAR", "").Replace(",", ""));
            }
            return "SAR " + result.ToString("N0");

        }


        public string sumPrice(DataTable datatable_)
        {

            var listPrice = new List<string>();
      
            foreach (DataRow item in datatable_.Rows)
            {
                listPrice.Add(item.Field<string>("PRICE"));

            }
            Double result = 0;
            for (int i = 0; i < listPrice.Count; i++)
            {
                result += double.Parse(listPrice[i].Replace("SAR", "").Replace(",", ""));
            }
            return "SAR " + result.ToString("N0");

        }

        public string sumPrice_a(DataTable datatable_)
        {

            var listPrice = new List<string>();

            foreach (DataRow item in datatable_.Rows)
            {
                listPrice.Add(item.Field<string>("PRICE_A"));

            }
           Double result= 0;
            for (int i = 0; i < listPrice.Count; i++)
            {
                result += int.Parse(listPrice[i].Replace("SAR", "").Replace(",", ""));
            }
            return "SAR " + result.ToString("N0");

        }

    }
}

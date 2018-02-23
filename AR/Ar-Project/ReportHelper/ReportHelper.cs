using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Project
{
   public class ReportHelper
    {
        private string GetPrice;

        public string Getprice_
        {
            get { return GetPrice; }
            set { GetPrice = value; }
        }

        public string SumPrice()
        {
            var list = new List<string>();

            DataTable data = new DataTable();
            var irc = new Assest.OrcDataAcess();
            irc.Show_(data);
            Int64 Sumpricee = 0;
            foreach (DataRow r in data.Rows)
            {
           

                Sumpricee += r.Field<Int64>("PRICE");
                
            }

            return Sumpricee.ToString("N0")+" ر.س";
        }

    }
}

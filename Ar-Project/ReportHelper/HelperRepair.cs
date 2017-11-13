using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace Ar_Project
{
   public static class HelperRepair
    {
       

        public static void Add(string id, string name, string price, string date, string darec, string conprou, string typeprou, string discounts,bool isdone,DataTable data)
        {
            var ModelMega = new ModelMega();
           int Booolint = (isdone) ? 0 : -1;

            if (isdone)            
                ModelMega.add(id, name, price, date, darec, conprou, typeprou, discounts, Booolint);

            else
                ModelMega.add(id, name, price, date, darec, conprou, typeprou, discounts, Booolint);

            ModelMega.show(data);

        }
        public static void Edit(string id, string name, string price, string date, string darec, string conprou, string typeprou, string discounts, bool isdone, DataTable data)
        {
            var ModelMega = new ModelMega();
            int Booolint = (isdone) ? 0 : -1;
            if (isdone)
                ModelMega.Edit(id, name, price, date, darec, conprou, typeprou, discounts, Booolint);

            else
                ModelMega.Edit(id, name, price, date, darec, conprou, typeprou, discounts, Booolint);

            ModelMega.show(data);
        }

    }
}

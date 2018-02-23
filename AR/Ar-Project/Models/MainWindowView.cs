using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Ar_Project.Models
{
   public class MainWindowView: INotifyPropertyChanged
    {

        private int flag;

        public int Flag
        {
            get { return flag; }
            set { flag = value; OnPropChanged("Flagtr"); }
        }

        public MainWindowView()
        {
            var datatable = new DataTable();
            var modelmega = new ModelMega();
            modelmega.show(datatable);
            foreach (DataRow item in datatable.Rows)
            {
                if (item.Field<Int64>("isdone")==-1)
                    flag += 1;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
       
        private void OnPropChanged(string propname)
        {
            if (propname != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }
    }

}

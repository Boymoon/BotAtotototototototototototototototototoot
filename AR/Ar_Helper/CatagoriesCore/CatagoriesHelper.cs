using Ar_Helper.ModelView;
using Ar_Helper.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Helper.CatagoriesCore
{
    public class CatagoriesHelper: INotifyPropertyChanged
    {
        private int quantity_;
        public int Quantity{ get { return Catagories.Count; }  set { quantity_ = Catagories.Count;NotifyPropertyChanged(); } }
        //key of this Collection
        public string IDC{ get; set; }
        private ObservableCollection<Catagory> Catagories_;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ObservableCollection<Catagory> Catagories
        {
            get {
                if (Catagories_==null)
                {
                    Catagories_ = new OperationsOfCatagories().GetCatagoriesByIDC(IDC);
                }
                return Catagories_;
            }
            set { NotifyPropertyChanged("Quantity"); Catagories_ = (value == null) ? new ObservableCollection<Catagory>() : value; }
        }
       
    }
}

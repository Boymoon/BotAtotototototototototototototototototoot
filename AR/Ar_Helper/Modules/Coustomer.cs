using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ar_Project
{
    public class Coustomer
    {
        //NAME,NAME2,PRICE,DAT,BARCODE,ID,QUANTITY
        public virtual string PRICE { get; set; }
        public virtual string PRICE_A { get; set; }
        public virtual string NAME { get; set; }
        // public string NAME2 { get; set; }
        public virtual string DAT { get; set; }
        public virtual string QUANTITY { get; set; }
        public virtual string BARCODE { get; set; }
        public virtual string Dis { get; set; }
        public virtual string Price_F { get; set; }
        public virtual string ID { get; set; }
        public virtual bool isdone { get; set; }
        public virtual Button Btn { get; set; }
    }
}

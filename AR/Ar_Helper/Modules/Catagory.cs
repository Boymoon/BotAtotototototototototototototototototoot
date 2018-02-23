using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Helper.Modules
{
   public  class Catagory
    {
        public string QId{ get; set; }

        public string Qname{ get; set; }

        public int Quantity { get; set; }

        public CategoryType categoryType { get; set; }
        public Catagory()
        {
            categoryType = new CategoryType();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Project
{
   public  class HelperData<T>
    {
      public   DevExpress.Xpf.Core.ObservableCollectionCore<T> Fill()
        {

            return new DevExpress.Xpf.Core.ObservableCollectionCore<T>();
        }
      
        
    }
}

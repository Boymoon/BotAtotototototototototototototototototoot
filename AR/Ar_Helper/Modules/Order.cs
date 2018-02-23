using Ar_Helper.CatagoriesCore;
using Ar_Helper.OrderCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Helper.Modules
{
    public class Order
    {
        public CatagoriesHelper OIDC { get; set; }
        public string OId { get; set; }
        //the  location of this order in index
        public int index { get { return (Operations == null || Operations.Catagories == null) ? 0 : Operations.Catagories.Count; } }
        public string Oname { get; set; }
        public string Numberphone1 { get; set; }
        public string Numberphone2 { get; set; }
        public string OnameOfClient { get; set; }
        public string address { get; set; }
        public DateTime DateOfTheOrder { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public OperationsOfCatagories Operations{ get; set; }
        public StagesOfOrder CurrentStage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Helper.OrderCore
{
    public enum StagesOfOrder
    {
        /// <summary>
        /// When user Cancel the order
        /// </summary>
        Canceled=0,
        /// <summary>
        /// when user working on the order
        /// </summary>
        OnProgress=1,
        /// <summary>
        /// when user Delivere the order to client
        /// </summary>
        OnDelivered=2,
        /// <summary>
        /// when user delete the order OnDeleted will work 
        /// <see cref that order should be move to trash Collector.="<<<"/>
        /// </summary>
        OnDeleted = 3,
        /// <summary>
        /// Fired when user haven't set the stage
        /// </summary>
        None=4
    }
}

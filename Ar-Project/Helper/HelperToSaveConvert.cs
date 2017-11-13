using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Project
{
  public class HelperToSaveConvert
    {
        public string LastSloution(String Greg)
        {
            /// Ex:     mounth/day/year               8/29/2017
            string result = "";
            result = Greg.Split('/')[1] + "/" + Greg.Split('/')[0] + "/" + Greg.Split('/')[2];

          //  System.Windows.MessageBox.Show(result);
            return result;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ar_Project.Assest;
namespace Ar_Project
{
   public class CountView
    {


        public String count_All
        {
            get { return Regestir.Counting(type_of_Count.GetAll); }
        
        }

        public String count_isdone
        {
            get { return Regestir.Counting(type_of_Count.Isdone); }

        }

        public String count_isnotDone
        {
            get { return Regestir.Counting(type_of_Count.IsNotDone); }

        }


    }
}

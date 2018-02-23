using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Project
{
  

    public static class Optimize
    {

        public static void NewDB()
        {
            
            Properties.Settings.Default.newdb = true;
            Properties.Settings.Default.Save();


            File.Copy(System.Windows.Forms.Application.StartupPath + "\\dbPascal.db", System.Windows.Forms.Application.StartupPath + "\\Data_Backup.db");
         

        



    }

        public static void NewDB(String path)
        {
            Properties.Settings.Default.path = path;
            Properties.Settings.Default.newdb = false;
            Properties.Settings.Default.Save();



        }



    }
}


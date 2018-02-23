using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Ar_Project
{
    public class DataBaseHelper
    {
        public bool BackUp()
        {
            
            try
            {
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\Data_Backup.db");
                File.Copy(System.Windows.Forms.Application.StartupPath + "\\dbPascal.db", System.Windows.Forms.Application.StartupPath + "\\Data_Backup.db");
                if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\Data_Backup.db"))
                    return true;
                else
                    return false;
            }catch(Exception ex) { return false; }
          
        }
        public bool CheckIfDatabaseExiOrnor()
        {
            if (File.Exists(Properties.Settings.Default.path + "\\dbPascal.db"))
                return true;
            else
                return false;
        }
        public bool ExecuteBackUpDataBase()
        {
            File.Copy(System.Windows.Forms.Application.StartupPath + "\\Data_Backup.db", System.Windows.Forms.Application.StartupPath + "\\dbPascal.db");
            if (!File.Exists(System.Windows.Forms.Application.StartupPath+"\\dbPascal.db")) return false; else return true;

        }

      
     
    }
}

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
                File.Delete(System.Windows.Forms.Application.StartupPath + "\\Data_Backup.accdb");
                File.Copy(System.Windows.Forms.Application.StartupPath + "\\Data.accdb", System.Windows.Forms.Application.StartupPath + "\\Data_Backup.accdb");
                if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\Data_Backup.accdb"))
                    return true;
                else
                    return false;
            }catch(Exception ex) { return false; }
          
        }
        public bool CheckIfDatabaseExiOrnor()
        {
            if (File.Exists(Properties.Settings.Default.path + "\\Data.accdb"))
                return true;
            else
                return false;
        }
        public bool ExecuteBackUpDataBase()
        {
            File.Copy(System.Windows.Forms.Application.StartupPath + "\\Data_Backup.accdb", System.Windows.Forms.Application.StartupPath + "\\Data.accdb");
            if (!File.Exists(System.Windows.Forms.Application.StartupPath+"\\Data.accdb")) return false; else return true;

        }

      
     
    }
}

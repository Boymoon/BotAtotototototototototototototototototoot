using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ar_Project.Assest;
using System.Data;
using System.Globalization;
namespace Ar_Project
{
    public static class SealsFunction
    {

        public static string ExtractDaysFromDate()
        {

            try
            {

           

            string result = "";
                string date = (int.Parse(DateTime.Now.Year.ToString()) < 1600) ? DateTime.Now.Year.ToString()+"/"+DateTime.Now.Month.ToString()+"/"+DateTime.Now.Day.ToString() : convertFromGrtoHij(DateTime.Now.ToString());
                string[] DaysCounter = (date.Contains('/')) ? date.Split('/') : date.Split('-');
                for (int i = 0; i < DaysCounter.Length; i++)
            {
                result = DaysCounter[i + 2];
                break;
            }
       
            return result;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Section_SealsFunction:" + ex.HResult.ToString());
                return null;
            }

        }

        public static string ExtractmonthsFromDate()
        {
            try
            {

           

            string result = "";
                string date = (int.Parse(DateTime.Now.Year.ToString()) < 1600) ? DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() : convertFromGrtoHij(DateTime.Now.ToString());
                string[] DaysCounter = (date.Contains('/')) ? date.Split('/') : date.Split('-');
                for (int i = 0; i < DaysCounter.Length; i++)
            {
                result = DaysCounter[i + 1];
                break;
            }
          
            return result;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Section_SealsFunction:" + ex.HResult.ToString());
                return null;

            }
        }
        private static string convertFromGrtoHij(String input)
        {
            UmAlQuraCalendar um = new UmAlQuraCalendar();
            return um.GetYear(DateTime.Parse(input)).ToString()+"/"+um.GetMonth(DateTime.Parse(input)).ToString()+"/"+um.GetDayOfMonth(DateTime.Parse(input)).ToString();
        }

        public static string ExtractyearsFromDate()
        {
            try
            {
                
         
            string result = "";

                string date = (int.Parse(DateTime.Now.Year.ToString())<1600) ? DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() : convertFromGrtoHij(DateTime.Now.ToString());
                string[] DaysCounter =(date.Contains('/'))? date.Split('/') : date.Split('-');
            for (int i = 0; i < DaysCounter.Length; i++)
            {
                result = DaysCounter[0];
                break;
            }
          
            return result;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Section_SealsFunction:" + ex.HResult.ToString());
                return null;
            }
        }

        public static List<string> GetDays()
        {
            UmAlQuraCalendar um = new UmAlQuraCalendar();
            var dt = new DataTable();
            var GetDateFromDatabase = new OrcDataAcess();
            GetDateFromDatabase.show3(dt);
          
            var WholeDate = new List<string>();
            foreach (DataRow item in dt.Rows)
                WholeDate.Add((DateTime.Parse(item.Field<string>("DAT")).Year.ToString()).Contains("143") || DateTime.Parse(item.Field<string>("DAT")).Year.ToString().Contains("144") ?
                                           DateTime.Parse(item.Field<string>("DAT")).Day.ToString() :
                                           um.GetDayOfMonth(DateTime.Parse(item.Field<string>("DAT"))).ToString());
        


            return WholeDate;
        }

        public static List<string> GetMonths()
        {
            UmAlQuraCalendar um = new UmAlQuraCalendar();
            var dt = new DataTable();
            var GetDateFromDatabase = new OrcDataAcess();
            GetDateFromDatabase.show3(dt);
            var Result = new List<string>();
            var MonthList = new List<string>();
            var WholeDate = new List<string>();
            foreach (DataRow item in dt.Rows)
                WholeDate.Add((DateTime.Parse(item.Field<string>("DAT")).Year.ToString()).Contains("143") || DateTime.Parse(item.Field<string>("DAT")).Year.ToString().Contains("144") ?
                                             DateTime.Parse(item.Field<string>("DAT")).Month.ToString() :
                                             um.GetMonth(DateTime.Parse(item.Field<string>("DAT"))).ToString());

            return WholeDate;
        }

        public static List<string> GetYears()
        {
            UmAlQuraCalendar um = new UmAlQuraCalendar();
            var dt = new DataTable();
            var GetDateFromDatabase = new OrcDataAcess();
            GetDateFromDatabase.show3(dt);
            var Result = new List<string>();
            var YearList = new List<string>();
            var WholeDate = new List<string>();
            foreach (DataRow item in dt.Rows)
                WholeDate.Add((DateTime.Parse(item.Field<string>("DAT")).Year.ToString()).Contains("143") || DateTime.Parse(item.Field<string>("DAT")).Year.ToString().Contains("144") ?
                                             DateTime.Parse(item.Field<string>("DAT")).Year.ToString() :
                                             um.GetYear(DateTime.Parse(item.Field<string>("DAT"))).ToString());



            return WholeDate;
        }
    }
}

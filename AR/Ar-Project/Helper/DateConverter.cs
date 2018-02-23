using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace Ar_Project
{
    public static class DateConverter
    {
        #region Converters

        /// <summary>
        /// لتحويل التاريخ  من ميلادي الى هجري 
        /// </summary>
        /// <param name="TempDateTime">المراد تحويل *برامتر*</param>
        /// <returns>
        /// التاريخ الهجري 
        /// 
        /// </returns>
        public static String ConvertToHijri(String Greg)
        {

            try
            {
                UmAlQuraCalendar umm = new UmAlQuraCalendar();
                if (int.Parse(umm.GetYear(DateTime.Parse(Greg)).ToString())<1600)
                {
                    return Greg;
                }



                UmAlQuraCalendar um = new UmAlQuraCalendar();
                String Temp = "";
                HijriCalendar H = new HijriCalendar();


                GregorianCalendar Gr = new GregorianCalendar(GregorianCalendarTypes.USEnglish);
                DateTime DateTemp = new DateTime(int.Parse(GetYears(Greg)), int.Parse(GetMonths(Greg)), int.Parse(GetDays(Greg)), new GregorianCalendar());
                Temp = (um.GetYear(DateTemp)).ToString() + "/" + um.GetMonth(DateTemp).ToString() + "/" + um.GetDayOfMonth(DateTemp).ToString();
                //System.Windows.MessageBox.Show(Temp);
                //Temp = H.GetYear(DateTemp).ToString() + "/" + H.GetMonth(DateTemp).ToString() + "/" + H.GetDayOfMonth(DateTemp).ToString();
                //DateTime FinallConv = Convert.ToDateTime(Temp);
                //Temp = FinallConv.ToString("yyyy/MM/dd");

                return Temp;
            }
            catch (Exception ex)
            {
                var HelperTSC = new HelperToSaveConvert();
                Greg = HelperTSC.LastSloution(Greg);
                UmAlQuraCalendar um = new UmAlQuraCalendar();
                String Temp = "";
                HijriCalendar H = new HijriCalendar();
                GregorianCalendar Gr = new GregorianCalendar(GregorianCalendarTypes.USEnglish);
                DateTime TempDate = Convert.ToDateTime(Greg);
                DateTime DateTemp = new DateTime(int.Parse(GetYears(Greg)), int.Parse(GetMonths(Greg)), int.Parse(GetDays(Greg)), new GregorianCalendar());
                Temp = (um.GetYear(DateTemp)).ToString() + "/" + um.GetMonth(DateTemp).ToString() + "/" + um.GetDayOfMonth(DateTemp).ToString();
                return Temp;

            }

        }



        /// <summary>                year/m/d
        /// GetDay From Full Date ex:1999/9/9 
        /// </summary>
        /// <param name="input">Full Date </param>
        /// <returns></returns>
        private static string GetMonths(String input)
        {
            String output = "";
            string[] GetDay = (input.Contains("-")) ? input.Split('-') : input.Split('/');
            if (input.Contains("/"))
            {
                output = GetDay[1];
            }
            else
            {
                output = GetDay[0];

            }
            return output;
        }
        private static string GetDays(String input)
        {
            String output = "";
            string[] GetDay = (input.Contains("-")) ? input.Split('-') : input.Split('/');
            if (input.Contains("/"))
            {
                output = GetDay[2];
            }
            else
            {
                output = GetDay[1];

            }

            return output;
        }
        private static string GetYears(String input)
        {

            String output = "";
            string[] GetDay = (input.Contains("-")) ? input.Split('-') : input.Split('/');
            output = GetDay[0].Split(' ')[0];
            return output;
        }
        #endregion
    }
}

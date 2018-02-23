using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ar_Project;
namespace Ar_Helper.FirstSection
{
    public class ReCalculateHelper
    {
        //constant for currency type  to edit it easily when need to do that
        private const string CurrencyType = "SAR ";
        public ObservableCollection<Coustomer> Recalculate(ObservableCollection<Coustomer> collection, string HeaderCaption, Coustomer Coustomer, DataTable dt, string val)
        {
            var Before_ReCalc = dt.Rows.Cast<DataRow>().Where(item_row => item_row.Field<string>("ID") == Coustomer.ID);

            var EditedObserv = new ObservableCollection<Coustomer>(collection);
            var Price_F = (double.Parse(collection.Where(item => item.ID == Coustomer.ID).FirstOrDefault().PRICE.Replace(CurrencyType, "")) * (int.Parse(collection.Where(item => item.ID == Coustomer.ID).FirstOrDefault().QUANTITY)));
            if (HeaderCaption == "الخصم")
            {
                EditedObserv[EditedObserv.IndexOf(EditedObserv.Where(item_row => item_row.ID == Coustomer.ID).FirstOrDefault())].Price_F = CurrencyType + ((Price_F) - (Price_F / 100 * (int.Parse(val.Replace("%", ""))))).ToString();

            }
            else
            {
                EditedObserv[EditedObserv.IndexOf(EditedObserv.Where(item_row => item_row.ID == Coustomer.ID).FirstOrDefault())].Price_F = CurrencyType + ((Price_F) - (Price_F / 100 * (int.Parse(collection.Where(item => item.ID == Coustomer.ID).FirstOrDefault().Dis.Replace("%", ""))))).ToString();

            }
            return EditedObserv;
        }

    }
}

using Ar_Helper.ModelView;
using Ar_Helper.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Helper.CatagoriesCore
{
    public class OperationsOfCatagories : NotifyPropertyChanged
    {
        private Catagory ModelCategory_;

        public Catagory ModelCategory
        {
            get
            {
               
                return (ModelCategory_!=null)?ModelCategory_:new Catagory();
            }

            set
            {
                ModelCategory_ = value;
                OnPropertyChanged();
            }
        }

        public bool IsValied_for_Add
        {
            get
            {
                return
                    !string.IsNullOrEmpty(ModelCategory.Qname) &&
                    !string.IsNullOrEmpty(ModelCategory.categoryType.Categorytype) &&
                    ModelCategory.categoryType.CategoryID > 0;
            }
        }
        public bool IsValied_for_Edit
        {
            get
            {
                return
!string.IsNullOrEmpty(ModelCategory.Qname) &&
!string.IsNullOrEmpty(ModelCategory.categoryType.Categorytype) &&
ModelCategory.categoryType.CategoryID > 0;
            }
        }
        public bool IsValied_for_Remove
        {
            get
            {
                return
!string.IsNullOrEmpty(ModelCategory.Qname) &&
!string.IsNullOrEmpty(ModelCategory.categoryType.Categorytype) &&
ModelCategory.categoryType.CategoryID > 0;
            }
        }

        public RelayCommand AddNewCatagory
        {
            get
            {
                return new RelayCommand(AddNewGroup =>
{
    if (Catagories == null)
    {
        AddNewCatagories(this.SelectedItem);
    }
    else
    {
        InsertCatagoryIntoContainer(this.SelectedItem.IDC, ModelCategory);
    }
}, per => IsValied_for_Add);
            }
        }
        public RelayCommand EditSelectedCatagory { get { return new RelayCommand(EditSelected => { InsertCatagoryIntoContainer(this.SelectedItem.IDC, ModelCategory); }, per => IsValied_for_Edit); } }
        public RelayCommand RemoveSelectedCatagory { get { return new RelayCommand(RemoveSelected => { RemoveSingleCatagory(this.SelectedItem.IDC, ModelCategory); }, per => IsValied_for_Remove); } }

        private CatagoriesHelper SelectedItem;
        private string connectiongStrings = $"Data Source=" + System.Windows.Forms.Application.StartupPath + "\\dbPascal.db;Version=3;";
        private ObservableCollection<CatagoriesHelper> _catagories;
        public ObservableCollection<Catagory> Catagory_TEST { get; set; }
        public ObservableCollection<CatagoriesHelper> Catagories { get { return (_catagories == null) ? _catagories : GetCatagoriesContainer(); } set { _catagories = new ObservableCollection<CatagoriesHelper>(); } }
        public RelayCommand Clone { get; set; }// needs to be done.
        /// <summary>
        /// Selected Collection Of Catagories
        /// </summary>
        public CatagoriesHelper catagories { get; set; }

        public OperationsOfCatagories()
        {
            Catagories = new ObservableCollection<CatagoriesHelper>();
        }
        public void InsertCatagoryIntoContainer(string IDC, Catagory catagory)
        {
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = connectiongStrings;
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand(cn);
            cm.CommandText = $"Insert Into Catagories (IDC,Quantity,QId,Qname) Values('{IDC}',{ catagory.Quantity},'{catagory.QId}','{catagory.Qname}');";
            cm.ExecuteNonQuery();
            cn.Close();
            _catagories = GetCatagoriesContainer();
            Catagories.Where(getsepCatagoryContainer => getsepCatagoryContainer.IDC == IDC).FirstOrDefault().Catagories.Add(catagory);
            SelectedItem.Catagories.Add(catagory);
        }
        public void AddNewCatagories(CatagoriesHelper pcategories)
        {
            //that means there is no any IDC in Categories Table So we will create new idc and add catagories on that IDC.
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = connectiongStrings;
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand(cn);
            cm.CommandText = $"Insert Into Catagories (IDC,Quantity,QId,Qname) Values('{pcategories.IDC}',{pcategories.Quantity},'{pcategories.Catagories[0].QId}','{pcategories.Catagories[0].QId}');";
            cm.ExecuteNonQuery();
            cn.Close();
        }
        public void setSelectedItem(CatagoriesHelper selecteditem__)
        {
            this.SelectedItem = selecteditem__;
        }
        public void RemoveCatagories(CatagoriesHelper catagories)
        {
            Catagories.Remove(catagories);
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = connectiongStrings;
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand(cn);
            cm.CommandText = $"Delete from Catagories Where IDC='{catagories.IDC}';";
            cm.ExecuteNonQuery();
            cn.Close();
            catagories.Catagories.ToList().ForEach(act =>
            {
                SelectedItem.Catagories.Remove(act);
            });
        }
        public void RemoveSingleCatagory(string IDC, Catagory catagory)
        {
            if (SelectedItem.Catagories.Remove(catagory))
            {
                SQLiteConnection cn = new SQLiteConnection();
                cn.ConnectionString = connectiongStrings;
                cn.Open();
                SQLiteCommand cm = new SQLiteCommand(cn);
                cm.CommandText = $"Delete From Catagories Where IDC='{IDC}' And Qname='{catagory.Qname}' And QId='{catagory.QId}'; ";
                cm.ExecuteNonQuery();
                cn.Close();
               

            }

        }
        public string CreateNewIDC()
        {
            string key = "qwerLZXCV34567890";

            string new_idc = new string(Enumerable.Repeat(key, key.Length)
   .Select(s => s[new Random().Next(0, s.Length)]).ToArray());
            var check = Catagories.Where(idc => idc.IDC == new_idc).FirstOrDefault();
            return new_idc;


        }
        public ObservableCollection<Catagory> GetCatagoriesByIDC(string IDC)
        {
            return (new ObservableCollection<Catagory>((Catagories.Where(getsepCatagoryContainer => getsepCatagoryContainer.IDC == IDC).FirstOrDefault() == null || (Catagories.Where(getsepCatagoryContainer => getsepCatagoryContainer.IDC == IDC).FirstOrDefault().Catagories == null) ? new ObservableCollection<Catagory>() : new ObservableCollection<Catagory>((Catagories.Where(getsepCatagoryContainer => getsepCatagoryContainer.IDC == IDC).FirstOrDefault().Catagories)))));
        }
        public ObservableCollection<CatagoriesHelper> GetCatagoriesContainer()
        {
            var CatagoriesContainer = new ObservableCollection<CatagoriesHelper>();
            SQLiteConnection sq = new SQLiteConnection();
            sq.ConnectionString = connectiongStrings;
            sq.OpenAndReturn();
            SQLiteCommand sQm = new SQLiteCommand(sq);
            sQm.CommandText = "Select * From Catagories;";
            SQLiteDataAdapter liteDataAdapter = new SQLiteDataAdapter(sQm);
            var storage = new DataTable();
            liteDataAdapter.Fill(storage);
            foreach (DataRow row in storage.Rows)
            {
                var catagoriesCollection = new ObservableCollection<Catagory>();
                var TempraryCollectionOfRows = storage.Rows.Cast<DataRow>().Where(item => item.Field<string>("IDC") == row.Field<string>("IDC")).ToList();
                foreach (var item in TempraryCollectionOfRows)
                {
                    catagoriesCollection.Add(new Catagory() { QId = item.Field<string>("QId"), Qname = item.Field<string>("Qname") });
                }
                CatagoriesContainer.Add(new CatagoriesHelper() { Catagories = new ObservableCollection<Catagory>(catagoriesCollection.ToList()), IDC = row.Field<string>("IDC"), Quantity = 0 });
            }
            sq.Close();
            return CatagoriesContainer;
        }
        public void setModelCategory(Catagory ModelCategory)
        {
            if (ModelCategory == null)
            {
                return;
            }
            this.ModelCategory = ModelCategory;
        }
    }
}

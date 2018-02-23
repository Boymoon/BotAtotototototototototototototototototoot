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
    /// <summary>
    /// @INcomplete:-
    /// -- when select item this class should set the values to <see cref="PresenterOfCategoryType"/> and put them thier fields.
    /// </summary>
    public class StorageCategories : NotifyPropertyChanged
    {
        protected string connectiongStrings = $"Data Source=" + System.Windows.Forms.Application.StartupPath + "\\dbPascal.db;Version=3;";

        protected CategoryType GetSelectedType { get; set; }

        private ObservableCollection<Catagory> Storage_;
        /// <summary>
        /// storage for categories and thier types and qunatities.
        /// </summary>
        public ObservableCollection<Catagory> Storage
        {
            get { return Storage_; }
            set { Storage_ = value; }
        }
        private OperationsOfCatagories ModelOperationsOfCatagories;
        private PresenterOfCategoryType ModelpresenterOfCategory;
        private Catagory ModelCategory_;

        public Catagory ModelCategory { get => ModelCategory_; set { ModelCategory_ = value; OnPropertyChanged(); } }

        public Catagory SelectedCategory_;

        public Catagory SelectedCategory { get => SelectedCategory_; set { SelectedCategory_ = value; OnPropertyChanged(); } }

        public RelayCommand AddnewCommand { get { return new RelayCommand(Addnew => AddnewCategoryToStorage(Addnew), pre => true); } }
        public RelayCommand EditCommand { get { return new RelayCommand(edit => editCurrentCollection(edit), per => true); } }
        public RelayCommand SelectCommand { get { return new RelayCommand(select => SelectAndSave(select)); } }

        public StorageCategories()
        {
            Storage = GetStorage();
            ModelCategory = new Catagory();
            ModelpresenterOfCategory = new PresenterOfCategoryType();
        }
        private void SelectAndSave(object select)
        {
            ModelCategory = SelectedCategory;
            ModelpresenterOfCategory.SetNewArguments(SelectedCategory.categoryType);
            ModelOperationsOfCatagories.setModelCategory(SelectedCategory);
        }
        private void AddnewCategoryToStorage(object addnew)
        {
            ModelCategory.QId = "TEST_MODE";
            if (ModelCategory == null ||
                string.IsNullOrEmpty(ModelCategory.Qname) ||
                string.IsNullOrEmpty(ModelCategory.QId) ||
                string.IsNullOrEmpty(ModelCategory.categoryType.Categorytype))
            {
                return;
            }
            if (Storage.Where(item => item.Qname == ModelCategory.Qname).FirstOrDefault() != null)
            {
                throw new Exception("The Qname has been used.");
            }
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = connectiongStrings;
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand(cn);
            cm.CommandText = $"Insert Into CateogriesStorage (QId,Qname,Quantity,CategoryType) Values ('{ModelCategory.QId}','{ModelCategory.Qname}',{ModelCategory.Quantity},'{ModelCategory.categoryType.Categorytype}');";
            cm.ExecuteNonQuery();
            cn.Close();
            var copyofcurrentmodel = ModelCategory;
            Storage.Add(copyofcurrentmodel);
        }
        private void editCurrentCollection(object edit)
        {
            if (SelectedCategory == null || ModelCategory == null)
            {
                return;
            }
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = connectiongStrings;
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand(cn);
            cm.CommandText = $"Update CategoriesStorage Set Quantity={ModelCategory.Quantity},Qname='{ModelCategory.Qname}',CategoryType='{ModelCategory.categoryType.Categorytype}' Where QId='{SelectedCategory_.QId}';";
            cm.ExecuteNonQuery();
            cn.Close();
            var index = Storage.IndexOf(Storage.Where(item => item.QId == SelectedCategory.QId).FirstOrDefault());
            Storage[index].Qname = ModelCategory.Qname;
            Storage[index].Quantity = ModelCategory.Quantity;
            Storage[index].categoryType.Categorytype = ModelCategory.categoryType.Categorytype;
        }
        private ObservableCollection<Catagory> GetStorage()
        {
            //container of the storage --
            var _storage = new ObservableCollection<Catagory>();
            var Dtable = new DataTable();
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = connectiongStrings;
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand(cn);
            cm.CommandText = $"Select * from CateogriesStorage;";
            SQLiteDataAdapter Dadapter = new SQLiteDataAdapter(cm);
            Dadapter.Fill(Dtable);
            Dtable.Rows.Cast<DataRow>().ToList().ForEach(GetItems =>
            {
                var presenter = new PresenterOfCategoryType();
                presenter.GetTypesOfCategories();
                _storage.Add(new Catagory()
                {
                    categoryType = new CategoryType()
                    {
                        CategoryID = presenter.TypesOfCategories.Where(item => item.Categorytype == GetItems.Field<string>("CategoryType")).FirstOrDefault().CategoryID,
                        Categorytype = GetItems.Field<string>("CategoryType")
                    },
                    QId = "abc123",
                    Qname = GetItems.Field<string>("Qname"),
                    Quantity = GetItems.Field<int>("Quantity")
                });
            });
            cn.Close();
            return _storage;
        }
        public void SetType(CategoryType categoryType)
        {
            if (categoryType == null)
            {
                return;
            }
            this.GetSelectedType = categoryType;
            ModelCategory.categoryType = this.GetSelectedType;
        }
        public void SetpresenterOfCategory(PresenterOfCategoryType presenter)
        {
            this.ModelpresenterOfCategory = presenter;
        }
        public void SetModelOperationOfCategories(OperationsOfCatagories Selected_operation)
        {
            if (Selected_operation == null)
            {
                return;
            }
            this.ModelOperationsOfCatagories = Selected_operation;
        }

    }
}

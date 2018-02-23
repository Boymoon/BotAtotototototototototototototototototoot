using Ar_Helper.ModelView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Helper.CatagoriesCore
{
    public enum StatesOfEdit
    {
        saved = 0,
        Canceled = 1,
        none = 2
    }
    public class PresenterOfCategoryType : INotifyPropertyChanged
    {

        private string CatagoryType_;

        public string CatagoryType/// for editing
        {
            get { return CatagoryType_; }
            set { CatagoryType_ = value; OnPropChanged(); }
        }
        private string CatagoryID_;

        public string CatagoryID/// for editing
        {
            get { return CatagoryID_; }
            set { CatagoryID_ = value; OnPropChanged(); }
        }
        
        private static StatesOfEdit states;
        private CategoryType perviousCopyOfSelected;
        private CategoryType SelectedCatagoryType_;
        private CategoryType ModelCategoryType_=new CategoryType();
        public CategoryType  ModelCategoryType { get => ModelCategoryType_; set { ModelCategoryType_ = value; ModelStorageCategories.SetType(value); OnPropChanged(); } }
        public CategoryType  SelectedCatagoryType
        {
            get => SelectedCatagoryType_;
            set
            {
                if (value == null)
                {
                    return;
                }
                ModelCategoryType = value;
                OnPropChanged("ModelCategoryType");
                SelectedCatagoryType_ = value;
                CatagoryID = value.CategoryID.ToString();
                CatagoryType = value.Categorytype;
                OnPropChanged("CatagoryID");
                OnPropChanged("CatagoryType");
                ModelStorageCategories.SetType(value);
            }
        }
        protected string connectionstring = $"Data Source=" + System.Windows.Forms.Application.StartupPath + "\\dbPascal.db;Version=3;";
        private ObservableCollection<CategoryType> TypesOfCategories_;
        private StorageCategories ModelStorageCategories { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        //|| string.IsNullOrEmpty(ModelCategoryType_.Categorytype) || ModelCategoryType_.CategoryID < 0 || states == StatesOfEdit.Canceled || states == StatesOfEdit.saved
        public ObservableCollection<CategoryType> TypesOfCategories
        {
            get { return TypesOfCategories_; }
            set
            {
                TypesOfCategories_ = value;
                GetTypesOfCategories();
            }
        }
        public RelayCommand RefreshCommand { get { return new RelayCommand(refresh_param => GetTypesOfCategories(), p => true); } }
        /// <summary>
        /// for applyEditCommand
        /// </summary>
        private bool isvalid_ApplyCommand
        {
            get
            {
                return (SelectedCatagoryType_ != null && ((!string.IsNullOrEmpty(CatagoryType) && (int.Parse(CatagoryID)> 0) && states == StatesOfEdit.none)));
            }
        }
        /// <summary>
        /// for cancelEditCommand
        /// </summary>
        private bool isvalid_CancelCommand
        {
            get
            {
                /*
                 if(selected not equals null And  model.type not equal null ||or|| empty |or| model.Id greater than 0 |or| state not equals Canceled |or| state equals Saved |or| none then return true else false )
                 */
              
                return (SelectedCatagoryType_ != null && ((!string.IsNullOrEmpty(ModelCategoryType.Categorytype) && (ModelCategoryType.CategoryID > 0) && states == StatesOfEdit.saved  && states != StatesOfEdit.Canceled )));
            }
        }
        public PresenterOfCategoryType()
        {
            states = StatesOfEdit.none;
            TypesOfCategories = new ObservableCollection<CategoryType>();
        }
        public RelayCommand ApplyEditCommand
        {
            get
            {
                return new RelayCommand(applyedit => ApplyEdit(applyedit), pre => isvalid_ApplyCommand);
            }
        }
        //public RelayCommand ApplyEditCommand => new RelayCommand(ApplyEditCommand_p => ApplyEdit(ApplyEditCommand_p), (param_func) => { return CanExecute; });

        public RelayCommand OnPressedControl_Z_Command { get { return new RelayCommand(param => { OnPressedControl_Z(param); }, pre => true); } }
        public RelayCommand AddnewTypeCommand
        {
            get
            {
                return new RelayCommand(param =>
                {
                    AddNewType(new CategoryType()
                    {
                        CategoryID = TypesOfCategories.Max(item => item.CategoryID)+1,
                        Categorytype = ModelCategoryType.Categorytype
                    });
                },
            per => (ModelCategoryType != null && !string.IsNullOrEmpty(ModelCategoryType.Categorytype)) );
            }
        }

        public RelayCommand CancelEditCommand { get { return new RelayCommand(cancel_param => cancelEdit(cancel_param), pre => isvalid_CancelCommand); } }
        //new RelayCommand(cancelEdit_param => cancelEdit(cancelEdit_param), (param_func) => { return CanExecute; });
        private void OnPropChanged([CallerMemberName] string propname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }
        //TODO:this method do one simple thing be bring all the types from database.
        public void GetTypesOfCategories()
        {
            if (TypesOfCategories == null)
            {
                TypesOfCategories = new ObservableCollection<CategoryType>();
            }
            TypesOfCategories.Clear();
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = connectionstring;
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand(cn);
            cm.CommandText = "Select * from CategoryTypes;";
            var dt = new DataTable();

            SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cm);
            sQLiteDataAdapter.Fill(dt);
            dt.Rows.Cast<DataRow>().ToList().ForEach(cata =>
            {
                TypesOfCategories.Add(new CategoryType()
                {
                    CategoryID = cata.Field<int>("CategoryID"),
                    Categorytype = cata.Field<string>("Categorytype")
                });
            });
        }
        //runs When user Pressing Ctrl+Z on the specific Field
        private void OnPressedControl_Z(object obj)
        {
            Console.WriteLine((string)obj);
            if ((string)obj == "FieldID")
            {
                CatagoryID = SelectedCatagoryType.CategoryID.ToString();
            }
            else
            {
                CatagoryType = SelectedCatagoryType.Categorytype;
            }
        }
        private void UpdatePerviousSelected(CategoryType categoryType)
        {
            if (categoryType == null || (states == StatesOfEdit.none || states == StatesOfEdit.Canceled))
            {
                return;
            }
            perviousCopyOfSelected = categoryType;
        }
        private void ApplyEdit(object param)
        {
            if (SelectedCatagoryType == null || ModelCategoryType_ == null)
            {
                return;
            }
            CatagoryID = (string.IsNullOrEmpty(CatagoryID)) ? SelectedCatagoryType_.CategoryID.ToString() : CatagoryID;
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = connectionstring;
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand(cn);
            cm.CommandText = $"UPDATE CategoryTypes SET CategoryId=" +
                $"{CatagoryID}" +
                $",CategoryType='{CatagoryType}'" +
                $"WHERE CategoryId={SelectedCatagoryType.CategoryID};";
            cm.ExecuteNonQuery();
            cn.Close();
            states = StatesOfEdit.saved;
            UpdatePerviousSelected(new CategoryType() { CategoryID = SelectedCatagoryType.CategoryID, Categorytype = SelectedCatagoryType.Categorytype });
            var index = TypesOfCategories.IndexOf(TypesOfCategories
                .Where(item => item.CategoryID == SelectedCatagoryType.CategoryID &&
                               item.Categorytype == SelectedCatagoryType.Categorytype).FirstOrDefault());
            TypesOfCategories[index] = new CategoryType() { Categorytype = CatagoryType, CategoryID = int.Parse(CatagoryID) };
            //TypesOfCategories[TypesOfCategories.IndexOf(TypesOfCategories
            //  .Where(item => item.CategoryID == SelectedCatagoryType.CategoryID &&
            //                 item.Categorytype == SelectedCatagoryType.Categorytype).FirstOrDefault())].CategoryID = int.Parse(CatagoryID);
        }
        private void cancelEdit(object param)
        {
            if (SelectedCatagoryType == null || ModelCategoryType_ == null)
            {
                return;
            }
            SQLiteConnection cn = new SQLiteConnection();
            cn.ConnectionString = connectionstring;
            cn.Open();
            SQLiteCommand cm = new SQLiteCommand(cn);
            cm.CommandText = $"Update CategoryTypes Set CategoryId={perviousCopyOfSelected.CategoryID},CategoryType='{perviousCopyOfSelected.Categorytype}' Where CategoryId={CatagoryID} ;";
            cm.ExecuteNonQuery();
            cn.Close();
            ModelCategoryType = perviousCopyOfSelected;
            SelectedCatagoryType = new CategoryType();
            var index = TypesOfCategories.IndexOf(TypesOfCategories.Where(category => category.CategoryID == ModelCategoryType.CategoryID && category.Categorytype == ModelCategoryType.Categorytype).FirstOrDefault());
            TypesOfCategories[index].Categorytype = perviousCopyOfSelected.Categorytype;
            TypesOfCategories[index].CategoryID = perviousCopyOfSelected.CategoryID;
            states = StatesOfEdit.Canceled;
        }
        public void AddNewType(CategoryType type)
        {
            if (type == null)
            {
                return;
            }
            if (TypesOfCategories.Where(item => item.Categorytype== type.Categorytype).FirstOrDefault()!=null)
            {
                Console.WriteLine("The CategoryType is Already exist,do you wanna add more than one type?");
            }
            using (SQLiteConnection cn = new SQLiteConnection())
            {
                cn.ConnectionString = connectionstring;
                cn.Open();
                SQLiteCommand cm = new SQLiteCommand(cn);
                cm.CommandText = $"Insert Into  CategoryTypes(CategoryId,CategoryType) Values({type.CategoryID},'{type.Categorytype}');";
                cm.ExecuteNonQuery();
                cn.Close();
            }
            TypesOfCategories.Add(type);
        }
        public void RemoveType(CategoryType type)
        {
            if (type == null)
            {
                return;
            }
            using (SQLiteConnection cn = new SQLiteConnection())
            {
                cn.ConnectionString = connectionstring;
                cn.Open();
                SQLiteCommand cm = new SQLiteCommand(cn);
                cm.CommandText = $"delete from CategoryTypes where CategoryId={type.CategoryID} And CategoryType='{type.Categorytype}';";
                cm.ExecuteNonQuery();
                cn.Close();
            }
            TypesOfCategories.Remove(type);
        }
        public void SetStorage(StorageCategories storage)
        {
            this.ModelStorageCategories = storage;
        }
        /// <summary>
        /// Arguments that comes from <see cref="StorageCategories"/>
        /// </summary>
        public void SetNewArguments(CategoryType Arguments)
        {
            if (Arguments==null)
            {
                return;
            }
            this.ModelCategoryType = Arguments;
            OnPropChanged("ModelCategoryType");
        }
    }
}

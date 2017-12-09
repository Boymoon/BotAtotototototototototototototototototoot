using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{
   public class SectionViewModel
    {
        /// <summary>
        /// الجدول المحتار
        /// </summary>
        public string  SelectedTableText{ get; set; }
        /// <summary>
        /// القسم الحالي
        /// </summary>
        public static TypesSections CurrentSection { get; set; } = TypesSections.FollowersSection;
        private static ObservableCollection<ModelTable> Model_ = new ObservableCollection<ModelTable>();
        /// <summary>
        /// قائمة الجداول
        /// </summary>
        public static ObservableCollection<ModelTable> modelTable
        {
            get => Model_;
            set => Fill(Model_);
        }


        /// <summary>
        /// الجدول المختار
        /// </summary>
        public ModelTable SelectedTable { get; set; } = new ModelTable();
        public SectionViewModel()
        {
            refresh();
            SelectedTable.Clear = new BaseCommand(Clear);
            SelectedTable.DeleteCurrentTable = new BaseCommand(DeleteCurrentTable);
        }

        private void refresh()
        {
            modelTable = null;
        }

        /// <summary>
        /// حذف جدول محدد بكل عناصرهS
        /// </summary>
        private void DeleteCurrentTable()
        {
           
        }
        /// <summary>
        /// حذف جميع الجداول بكل عناصرها
        /// </summary>
        private void Clear()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// تعبئة الجدول بالبيانات
        /// </summary>
        private static void Fill(ObservableCollection<ModelTable> _collection)
        {
            foreach (var item in HelperSelector.regestirTables.Where(item_ => !string.IsNullOrEmpty(item_.NameOfTheTable)).ToList())
            {
                _collection.Add(new ModelTable()
                {
                    Count = HelperSelector.regestirTables.Where(item_ => !string.IsNullOrEmpty(item_.NameOfTheTable)).ToList().Count,
                    CountOfItems = ((CurrentSection == TypesSections.FollowersSection) ?
                    HelperSelector.ParentOfFollowersTable.Where(__item => __item.GetType()
                    == new ObservableCollection<ModelPost>().GetType()).ToList().Count :
                    (CurrentSection == TypesSections.SearchSection) ?
                    HelperSelector.ParentOfPostsTable.Where(__item => __item.GetType()
                    == new ObservableCollection<ModelPost>().GetType()).ToList().Count : HelperSelector.ParentOfSearchTable.Where(__item => __item.GetType()
                    == new ObservableCollection<ModelPost>().GetType()).ToList().Count),
                    NameOfTheTable = item.NameOfTheTable,
                    typessections = CurrentSection
                });
                var t = _collection.Count;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Instagram.App
{
    public class ModelSearch : BaseViewModel
    {
        /// <summary>
        /// قائمة تحمل متابعين المنشور المحدد او الذين علقو عليه
        /// <see cref="ModelPost"/>
        /// </summary>
        public ObservableCollection<ModelPost> FollowersCollection { get; set; }
        private bool IsMaximumEnabled_;
        /// <summary>
        /// تفعيل  خاصية  اقصى  عدد من المنشورات
        /// </summary>
        public bool IsMaximumEnabled
        {
            get { return IsMaximumEnabled_; }
            set { IsMaximumEnabled_ = value;OnPropertyChanged(); }
        }
        private int MaximumPosts_=500;
        /// <summary>
        /// اقصى حد للمنشورات
        /// </summary>
        public int MaximumPosts
        {
            get { return MaximumPosts_; }
            set { MaximumPosts_ = value;OnPropertyChanged(); }
        }

        private int CountOfVideos_;
        /// <summary>
        /// عدد الفيديوهات
        /// </summary>
        public int CountOfVideos
        {
            get { return CountOfVideos_; }
            set { CountOfVideos_ = value; OnPropertyChanged(); }
        }
        private int CountOfImgs_;
        /// <summary>
        /// عدد الصور
        /// </summary>
        public int CountOfImgs
        {
            get { return CountOfImgs_; }
            set { CountOfImgs_ = value; OnPropertyChanged(); }
        }
        private int CountOfLikes_;
        /// <summary>
        /// عدد المنشورات التي تم عمل اعجاب لها
        /// </summary>
        public int CountOfLikes
        {
            get { return CountOfLikes_; }
            set { CountOfLikes_ = value; OnPropertyChanged(); }
        }
        private int CountOfPosts_;
        /// <summary>
        /// عدد المنشورات
        /// </summary>
        public int CountOfPosts
        {
            get { return CountOfPosts_; }
            set { CountOfPosts_ = value; OnPropertyChanged(); }
        }
        private bool IsGetPosts_;
        /// <summary>
        /// متغير يحمل قيمة تفعيل  جلب المنشورات الاحدث
        /// </summary>
        public bool IsGetPosts
        {
            get { return IsGetPosts_; }
            set { IsGetPosts_ = value; OnPropertyChanged(); }
        }

        private string unitOfGetPosts_;
        /// <summary>
        /// جلب المنشورات حسب الوحدة
        /// <see cref="To"/> <seealso cref="from"/>
        /// </summary>
        public string unitOfGetPosts
        {
            get { return unitOfGetPosts_; }
            set { unitOfGetPosts_ = value; OnPropertyChanged(); }
        }

        private int fromOfGetPosts_;
        /// <summary>
        /// جلب المنشورات من قيمة هذا المتغير الى قيمة المتغير <see cref="To"/>
        /// </summary>
        public int fromOfGetPosts
        {
            get { return fromOfGetPosts_; }
            set { fromOfGetPosts_ = value; OnPropertyChanged(); }
        }

        private int ToOfGetPosts_;
        /// <summary>
        /// جلب المنشورات التي لايقل وقت نشرها عن  الوقت المحدد في هذا المتغير
        /// </summary>
        public int ToOfGetPosts
        {
            get { return ToOfGetPosts_; }
            set { ToOfGetPosts_ = value; OnPropertyChanged(); }
        }
        private bool SearchByLocation_;
        /// <summary>
        /// البحث بإستخدام الموقع
        /// </summary>
        public bool SearchByLocation
        {
            get { return SearchByLocation_; }
            set { SearchByLocation_ = value; OnPropertyChanged(); }
        }
        private bool SearchByTag_;
        /// <summary>
        /// البحث بإستخدام التاق
        /// </summary>
        public bool SearchByTag
        {
            get { return SearchByTag_; }
            set { SearchByTag_ = value; OnPropertyChanged(); }
        }

        private bool IsSleep_;
        /// <summary>
        /// متغير يحمل قيمة تفعيل الفاصل الزمني
        /// </summary>
        public bool IsSleep
        {
            get { return IsSleep_; }
            set { IsSleep_ = value; OnPropertyChanged(); }
        }

        private string unit_;
        /// <summary>
        /// تاخير البرنامج حسب الوحدة
        /// <see cref="To"/> <seealso cref="from"/>
        /// </summary>
        public string unit
        {
            get { return unit_; }
            set { unit_ = value; OnPropertyChanged(); }
        }

        private int from_;
        /// <summary>
        /// تاخير البرنامج من قيمة هذا المتغير الى قيمة المتغير <see cref="To"/>
        /// </summary>
        public int from
        {
            get { return from_; }
            set { from_ = value; OnPropertyChanged(); }
        }

        private int To_;
        /// <summary>
        /// تاخير البرنامج الى قيمة هذا المتغير
        /// </summary>
        public int To
        {
            get { return To_; }
            set { To_ = value; OnPropertyChanged(); }
        }
        private bool UnLike_;
        /// <summary>
        /// متغير يحمل قيمة الخيار المطلوب 
        /// اعجاب -الغاء اعجاب - لاشيء
        /// </summary>
        public bool UnLike
        {
            get { return UnLike_; }
            set { UnLike_ = value; OnPropertyChanged(); }
        }
        private bool None_;
        /// <summary>
        /// متغير يحمل قيمة الخيار المطلوب 
        /// اعجاب -الغاء اعجاب - لاشيء
        /// </summary>
        public bool None
        {
            get { return None_; }
            set { None_ = value; OnPropertyChanged(); }
        }
        private bool Like_;
        /// <summary>
        /// متغير يحمل قيمة الخيار المطلوب 
        /// اعجاب -الغاء اعجاب - لاشيء
        /// </summary>
        public bool Like
        {
            get { return Like_; }
            set { Like_ = value; OnPropertyChanged(); }
        }

        private string Text_;
        /// <summary>
        /// متغير يحمل قيمة النص المراد البحث عنه
        /// </summary>
        public string Text
        {
            get { return Text_; }
            set { Text_ = value; OnPropertyChanged(); }
        }
        private string ParamOfCommand_="readytobegin";
        /// <summary>
        /// نوع الامر 
        /// لزر البحث
        /// </summary>
        public string ParamOfCommand
        {
            get { return ParamOfCommand_; }
            set { ParamOfCommand_= value;OnPropertyChanged(); }
        }
        private string ParamOfCommandTransfer_ = "G2";
        /// <summary>
        /// نوع الامر 
        /// لزر نقل الجداول
        /// </summary>
        public string ParamOfCommandTransfer
        {
            get { return ParamOfCommandTransfer_; }
            set { ParamOfCommandTransfer_ = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// امر البحث
        /// </summary>
        public ICommand SearchCommand { get; set; }

        /// <summary>
        /// الغاء البحث
        /// </summary>
        public ICommand CancelSearchCommand { get; set; }

        /// <summary>
        /// امر حذف العناصر
        /// </summary>
        public ICommand DeleteCommand { get; set; }
        /* ======================================================================================================
         * **************************************** يتطلب  اتصال بقاعدة البانات ********************************* 
         */
        /// <summary>
        /// امر الحفظ في قاعدة البيانات
        /// </summary>
        public ICommand SaveInDataBaseCommand { get; set; }

    }
}

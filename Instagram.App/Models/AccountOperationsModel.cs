using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Instagram.App
{
   public enum TypeOfResponse
    {
        /// <summary>
        /// نوع للحساب الغير مُتابع
        /// </summary>
        Follow=0,
        /// <summary>
        /// نوع للحساب المتابع
        /// </summary>
        Following = 1,
        /// <summary>
        /// نوع للحساب الذي يحتاج موافقة 
        /// </summary>
        Requested = 2,
        /// <summary>
        /// تعذر العثور على القيمة المطلوبة 
        /// </summary>
        None=3
    }

    public class AccountOperations : BaseViewModel
    {
        private bool IsFollowWIthCondition_;
        /// <summary>
        /// كائن يتحقق اذا كان  هناك شروط ام لا
        /// </summary>
        public bool IsFollowWIthCondition
        {
            get => IsFollowWIthCondition_;
            set
            {
                IsFollowWIthCondition_ = value;
            }
        }
        private bool IsGetFollowup_ = true;
        /// <summary>
        /// ارسال واستقبال قيمة الحقل جلب عدد المتابعين
        /// </summary>
        public bool IsGetFollowup
        {
            get => IsGetFollowup_;
            set { IsGetFollowup_ = value; OnPropertyChanged(); }
        }
        private bool FollowAll_;
        /// <summary>
        /// متابعة الجميع بلا إستثناء 
        /// يحصل استثناء عند ضبط الخصائص الاخرى  كخاصية  تحديد عدد المتابعين لحساب معين حتى يتم  متابعته وهكذا  
        /// </summary>
        public bool FollowAll
        {
            get => FollowAll_;
            set { FollowAll_ = value; OnPropertyChanged(); IsFollowWIthCondition = true; }
        }
        private bool UnFollowAll_;
        /// <summary>
        /// الغاء المتابعة
        /// </summary>
        public bool UnFollowAll
        {
            get => UnFollowAll_;
            set { UnFollowAll_ = value; OnPropertyChanged(); IsFollowWIthCondition = true; }
        }
        private bool Warning_;
        /// <summary>
        /// استقبال تحذير مبكر بوجود سبام او ما شابه 
        /// وعليه فان عمليات البرنامج سوف تتوقف حتى ينتهي هذا الحظر المؤقت  او السبام .....
        /// </summary>
        public bool Warning
        {
            get => Warning_;
            set { Warning_ = value; OnPropertyChanged(); IsFollowWIthCondition = true; }
        }
        private bool AdvancedSetting_;
        /// <summary>
        /// ارسال واستقبال الخصائص المتقدمة مثل التحذير الاستباقي والتحذير المبكر
        /// </summary>
        public bool AdvancedSetting
        {
            get => AdvancedSetting_;
            set { AdvancedSetting_ = value; OnPropertyChanged(); IsFollowWIthCondition = true; }
        }
        private bool IsSleep_;
        /// <summary>
        /// ارسال واستقبال تفعيل الفاصل الزمني
        /// </summary>
        public bool IsSleep
        {
            get => IsSleep_;
            set { IsSleep_ = value; OnPropertyChanged(); IsFollowWIthCondition = true; }
        }
        private bool FollowWhohasFollowingFrom_To_;
        /// <summary>
        /// ارسال وإستقبال قيمة الشرط 
        /// اذا  كان مفعل يجب تحديد عدد المتابعين حتى يتم المتابعة  
        /// </summary>
        public bool FollowWhohasFollowingFrom_To
        {
            get => FollowWhohasFollowingFrom_To_;
            set { FollowWhohasFollowingFrom_To_ = value; OnPropertyChanged(); IsFollowWIthCondition = true; }
        }
        private int AmountOfFollowing_ = 0;
        /// <summary>
        /// عدد المُتَابَعون>> للحساب المستهدف
        /// </summary>
        public int AmountOfFollowing
        {
            get => AmountOfFollowing_;
            set { AmountOfFollowing_ = value; OnPropertyChanged(); }
        }
        private int AmountOfFollowers_ = 0;
        /// <summary>
        /// عدد المتابعين  >> للحساب المستهدف
        /// </summary>
        public int AmountOfFollowers
        {
            get => AmountOfFollowers_;
            set { AmountOfFollowers_ = value; OnPropertyChanged(); }
        }
        private int AmountOfRequested_ = 0;
        /// <summary>
        /// عدد طلبات المتابعة التي بحاجة للموافقة  >> للحساب المستهدف
        /// </summary>
        public int AmountOfRequested
        {
            get => AmountOfRequested_;
            set { AmountOfRequested_ = value; OnPropertyChanged(); }
        }
        private int AmountOfNone_ = 0;
        /// <summary>
        /// العدد الكلي للمتابعين والمُتَابَعون  الذين لم يتابعهم البرنامج بسبب مشكلة ما.. >> للحساب المستهدف
        /// </summary>
        public int AmountOfNone
        {
            get => AmountOfNone_;
            set { AmountOfNone_ = value; OnPropertyChanged(); }
        }
        private int Amount_ = 0;
        /// <summary>
        /// العدد الكلي للمتابعين والمُتَابَعون >> للحساب المستهدف
        /// </summary>
        public int Amount
        {
            get => Amount_;
            set { Amount_ = value; OnPropertyChanged(); }
        }
        private int CountofOperations_ = 40;
        /// <summary>
        /// ارسال واستقبال اقصى عدد من العمليات المتاحة في مدة  زمنية محددة
        /// </summary>
        public int CountofOperations
        {
            get => CountofOperations_;
            set { CountofOperations_ = value; OnPropertyChanged(); }
        }
        private int Sleep_ = 10;
        /// <summary>
        /// ارسال  واستقبال فاصل  زمني  
        /// </summary>
        public int Sleep
        {
            get => Sleep_;
            set { Sleep_ = value; OnPropertyChanged(); }
        }
        private string Unit_Sleep_ = "ثواني";
        /// <summary>
        /// ارسال واستقبال وحدة التحقق  
        /// </summary>
        public string Unit_Sleep
        {
            get => Unit_Sleep_;
            set { Unit_Sleep_ = value; OnPropertyChanged(); }
        }      
        private int From_=0;
        /// <summary>
        /// ادنى قيمة متابعين
        /// </summary>
        public int From
        {
            get => From_;
            set { From_ = value; OnPropertyChanged(); }
        }
        private int To_=100;
        /// <summary>
        /// اقصى قيمة متابعين 
        /// </summary>
        public int To
        {
            get => To_;
            set { To_ = value; OnPropertyChanged(); }
        }
        private TypeOfResponse IsFollower_;
        /// <summary>
        /// ارسال واستقبال حالة الحساب متابع ام لا
        /// </summary>
        public TypeOfResponse IsFollower
        { get => IsFollower_; set { IsFollower_ = value; OnPropertyChanged(); } }

        private string Username_;
        /// <summary>
        /// اسم الحساب اللذي يظهر بعد تسجيل الدخول
        /// </summary>
        public string Username
        {
            get => Username_;
            set { Username_ = value; OnPropertyChanged(); }
        }

        private string Follower_;
        /// <summary>
        /// ارسال واستقبال عدد متابعين الحساب المدخل
        /// </summary>
        public string Follower
        {
            get => Follower_;
            set { Follower_ = value; OnPropertyChanged(); }
        }
        private string Uid_;
        /// <summary>
        /// -عنوان الحساب المستهدف -الرابط
        /// </summary>
        public string Uid
        {
            get { return Uid_; }
            set { Uid_ = value; }
        }
        private string ContentbtnLoading_="!!لايوجد اتصال";
        /// <summary>
        /// نص الزر  بعد البدء في تنفيذ العملية <see cref="IsRunning"/>
        /// </summary>
        public string ContentbtnLoading
        {
            get { return ContentbtnLoading_; }
            set { ContentbtnLoading_ = value;OnPropertyChanged(); }
        }
        private bool GetFollowers_=false;
        /// <summary>
        /// جلب المتابعون
        /// </summary>
        public bool GetFollowers
        {
            get { return GetFollowers_; }
            set { GetFollowers_ = value;OnPropertyChanged(); }
        }
        private bool GetFollowings_=true;
        /// <summary>
        /// جلب المتابعين
        /// </summary>
        public bool GetFollowings
        {
            get { return GetFollowings_; }
            set { GetFollowings_ = value; OnPropertyChanged(); }
        }
        private string Following_;
        /// <summary>
        /// ارسال وإستقبال عدد الاشخاص اللذين يتابعهم صاحب الحساب 
        /// </summary>
        public string Following
        {
            get => Following_;
            set { Following_ = value; OnPropertyChanged(); }
        }
        private int Followers_;
        /// <summary>
        /// ارسال واستقبال عدد متابعين لحساب من متابعين الحساب المستهدف  
        /// </summary>
        public int Followers
        {
            get => Followers_;
            set { Followers_ = value; OnPropertyChanged(); }
        }
        private bool IsRunning_=false;
        /// <summary>
        /// اذا بدأت عملية  جلب  المتابعين 
        /// </summary>
        public bool IsRunning
        {
            get { return IsRunning_; }
            set { IsRunning_ = value; OnPropertyChanged(); }
        }
        /// <summary>
        /// امر تسجيل الخروج
        /// </summary>
        public ICommand LogoutCommand { get; set; }
        /// <summary>
        /// امر  متابعة حساب او الغاء المتابعة
        /// </summary>
        public ICommand UnFollow_FollowCommand { get; set; }
        /// <summary>
        /// امر استهداف الحساب المحدد
        /// </summary>
        public ICommand SearchUsingOptionsCommand { get; set; }
        /// <summary>
        /// مسح الكل
        /// </summary>
        public ICommand Clean { get; set; }
        /// <summary>
        /// مسح الكل
        /// </summary>
        public ICommand CleanSelected { get; set; }
        /// <summary>
        ///  متابعة المتابعين المحددين في جدول المتابعين
        /// </summary>
        public ICommand Follow { get; set; }
        /// <summary>
        /// الغاء متابعة المتابعين المحددين في جدول المتابعين
        /// </summary>
        public ICommand UnFollow { get; set; }
        /// <summary>
        /// الغاء العمليات الخاصة بواجهة الحسابات -جلب المتابعين وعملياتها 
        /// <![CDATA[يتم الغاء نوعين  من العمليات فقط ,جلب  المتابعين,متابعة-الغاء متابعة -جلب عدد المتابعين ]]>
        /// </summary>
        public ICommand Cancel { get; set; }
    }
}

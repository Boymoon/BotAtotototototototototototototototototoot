using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Instagram.App
{
    public class CustomButton : BaseViewModel
    {
        
        #region Private Properties
        /// <summary>
        /// متغير يساعدنا في عمل تعديلات على محتوى زر ايقاف/بدأ 
        /// </summary>
        private string Content_;
        /// <summary>
        /// متغير يساعدنا في عمل تعديلات على ايقونة زر ايقاف/بدأ 
        /// </summary>
        private string Icon_;
        /// <summary>
        /// متغير يساعدنا في عمل تعديلات على  زر ايقاف/بدأ 
        /// </summary>
        private string CommandParam_;
        /// <summary>
        /// ننشئ امر لتنفيذ التسجيل الآلي 
        /// </summary>
        private ICommand MultiSignupCommand_;
        #endregion

        #region Public Properties
        /// <summary>
        /// متغير يساعدنا في عمل تعديلات على محتوى زر ايقاف/بدأ 
        /// </summary>
        public string Content { get => Content_; set { Content_ = (String.IsNullOrEmpty(value)?"بدأ":value); OnPropertyChanged(); } }
        /// <summary>
        /// متغير يساعدنا في عمل تعديلات على محتوى زر ايقاف/بدأ 
        /// </summary>
        public string Icon { get => Icon_; set { Icon_ = (String.IsNullOrEmpty(value) ? "Play" : value); OnPropertyChanged(); } }
        /// <summary>
        /// ننشئ امر لتنفيذ التسجيل الآلي 
        /// </summary>
        public ICommand MultiSignupCommand { get => MultiSignupCommand_; set { MultiSignupCommand_ = value;OnPropertyChanged(); } }
         /// <summary>
        /// متغير يساعدنا في عمل تعديلات على محتوى زر ايقاف/بدأ 
        /// </summary>
        public string CommandParam { get => CommandParam_; set { CommandParam_ = (String.IsNullOrEmpty(value)?"بدأ":value);  } }
        #endregion

        public CustomButton(Action ExecuteMultiSignup)
        {
            CommandParam = CommandParam_;
            Icon = Icon_;
            Content = Content_;
            if (CommandParam_ != "توقف") {
                MultiSignupCommand = new BaseCommand(ExecuteMultiSignup);

            }



        }
        public CustomButton()
        {
           


        }
    }
}

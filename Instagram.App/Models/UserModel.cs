using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Instagram.App
{


   public class UserModel:BaseViewModel
    {
        private string CountOfPosts_;
        /// <summary>
        /// عدد المنشورات
        /// </summary>
        public string CountOfPosts
        {
            get { return CountOfPosts_; }
            set
            {
                if (int.Parse(value) > 2)
                {
                    value = $"منشورات {value}";
                }
                else if (int.Parse(value) == 1)
                {
                    value = "منشور";
                }
                else if (int.Parse(value) == 2)
                {
                    value = "منشوران";
                }
                else if (int.Parse(value) == 0)
                {
                    value = "لايوجد منشورات لعرضها";
                }
                CountOfPosts_ = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<ModelPost> Posts_;
        /// <summary>
        /// حاوية تخزين المنشورات
        /// </summary>
        public ObservableCollection<ModelPost> Posts
        {
            get { return Posts_; }
            set { Posts_ = value;OnPropertyChanged(); }
        }
        /// <summary>
        /// تحديث
        /// </summary>
        public ICommand Refresh { get; set; }
        /// <summary>
        /// جلب الحسابات التي قامت بالتعليق
        /// </summary>
        public ICommand GetUsersOfComments { get; set; }
        /// <summary>
        /// جلب الحسابات التي قامت بالاعجاب
        /// </summary>
        public ICommand GetUsersOfLikes { get; set; }

    }
}

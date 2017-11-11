using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{
    public enum TypesOfMedia
    {
        /// <summary>
        /// المحتوى المنشور من نوع فيديو
        /// </summary>
        Video=0,
        /// <summary>
        /// المحتوى المنشور  من نوع صورة
        /// </summary>
        Imgs=1,
        /// <summary>
        /// لم يتم التعرف على  المحتوى المنشور 
        /// </summary>
        none=2
    }
    /// <summary>
    /// *************************************** خصائص المنشور *********************************************
    /// محتوى المنشورالنصي
    /// المحتوى المرئئ
    /// عدد الاعجابات
    /// عدد المشاهدين للفيديو اذا توفر
    /// ****************************************************************************************************
    /// </summary>
    public class ModelPost : BaseViewModel
    {
        private TypesOfMedia TypesOfMedia_;
        /// <summary>
        /// تحديد نوع المحتوى المرئي
        /// </summary>
        public TypesOfMedia TypesOfMedia
        {
            get { return TypesOfMedia_; }
            set
            {
                if (ContextMedia_.Contains("mp4"))
                {
                    TypesOfMedia_ = TypesOfMedia.Video;
                }
                else if(ContextMedia_.Contains("jpg"))
                {
                    TypesOfMedia_ = TypesOfMedia.Imgs;
                }
                OnPropertyChanged("ContextMedia");
            }
        }
        private string UidOfpost_;
        /// <summary>
        /// عنوان المنشور
        /// </summary>
        public string UidOfpost
        {
            get { return UidOfpost_; }
            set { UidOfpost_ = value; OnPropertyChanged(); }
        }

        private string ContextMedia_;
        /// <summary>
        ///  محتوى المنشور المرئي
        /// </summary>
        public string ContextMedia
        {
            get { return ContextMedia_; }
            set { ContextMedia_ = value;
                if (ContextMedia_.Contains("mp4"))
                {
                    TypesOfMedia_ = TypesOfMedia.Video;
                }
                else if (ContextMedia_.Contains("jpg"))
                {
                    TypesOfMedia_ = TypesOfMedia.Imgs;
                }
                OnPropertyChanged(); }
        }
        private string Context_;
        /// <summary>
        /// محتوى المنشور
        /// </summary>
        public string Context
        {
            get { return Context_; }
            set { Context_ = value; OnPropertyChanged(); }
        }
        private string publisher_;
        /// <summary>
        /// اسم الناشر
        /// </summary>
        public string publisher
        {
            get { return publisher_; }
            set { publisher_ = value; OnPropertyChanged(); }
        }
        private string publishedat_;
        /// <summary>
        /// نشر في
        /// </summary>
        public string publishedat
        {
            get { return publishedat_; }
            set { publishedat_ = value; OnPropertyChanged(); }
        }
        private string UidOfpublisher_;
        /// <summary>
        /// عنوان الناشر
        /// </summary>
        public string UidOfpublisher
        {
            get { return UidOfpublisher_; }
            set { UidOfpublisher_ = value; OnPropertyChanged(); }
        }
        private string Likes_;
        /// <summary>
        /// عدد الإعجابات
        /// </summary>
        public string Likes
        {
            get { return Likes_; }
            set { Likes_ = value; OnPropertyChanged(); }
        }
        private string Views_;
        /// <summary>
        /// عدد المشاهدين
        /// </summary>
        public string Views
        {
            get {
                try
                {
                return Views_.Replace("view","");
                }catch(Exception)
                {
                    return "0";
                }
            }
            set { Views_ = value; OnPropertyChanged(); }
        }
    }
}

using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{
    public static class CollectionsHelper
    {
        /// <summary>
        /// جدول المتابعين للحساب المستهدف
        /// </summary>
        public static ObservableCollectionCore<AccountOperations> Followers { get; private set; }
        /// <summary>
        /// جدول المتابعين للحساب المستهدف
        /// </summary>
        public static ObservableCollection<ModelPost> Posts { get; private set; }
        /// <summary>
        /// جدول المنشورات او التعليقات
        /// </summary>
        public static ObservableCollection<ModelComment> Comments { get; private set; }

        public static void Init()
        {
            Posts = new ObservableCollection<ModelPost>();
            Followers = new ObservableCollectionCore<AccountOperations>();
            Comments = new ObservableCollection<ModelComment>();
        }
    }
}

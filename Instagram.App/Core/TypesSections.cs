using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{
    /// <summary>
    /// انواع الاقسام التي تخزن بيانات 
    /// <![CDATA[مثل بيانات المتابعين وبيانات المنشورات المأخوذة من تاق معين]]>
    /// </summary>
    public enum TypesSections
    {
        /// <summary>
        /// قسم الحسابات المستوردة
        /// </summary>
        AccountsSection=0,
        /// <summary>
        /// قسم جلب المتابعين وعملياتهم
        /// </summary>
        FollowersSection=1,
        /// <summary>
        /// قسم البحث بالموقع او الهاشتاق
        /// </summary>
        SearchSection=2,
        /// <summary>
        /// قسم التعليقات والمنشورات 
        /// </summary>
        CommentsAndPostsSection=3
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{
    /// <summary>
    /// انواع العمليات التي ينفذها البرنامج
    /// </summary>
    public enum OperationsTypes
    {
        /// <summary>
        /// جلب المتابعين
        /// </summary>
        GetFollowers = 0,
        /// <summary>
        /// متابعة
        /// </summary>
        DoFollow = 1,
        /// <summary>
        /// الغاء المتابعة
        /// </summary>
        DoUnFollow = 2,
        /// <summary>
        /// تسجيل الدخول
        /// </summary>
        DoLogin = 3,
        /// <summary>
        /// تسجيل الخروج
        /// </summary>
        DoLogout = 8,
        /// <summary>
        /// البحث بإستخدام الموقع
        /// </summary>
        DoSearchUsingLocation = 4,
        /// <summary>
        /// التعليق بدون منشن
        /// </summary>
        DoComment = 5,
        /// <summary>
        /// التعليق لمنشور محدد
        /// </summary>
        DoCommentToTarget = 9,
        /// <summary>
        /// جلب المنشورات 
        /// </summary>
        GetPosts = 10,
        /// <summary>
        /// التعليق مع المنشن
        /// </summary>
        DoCommentWithMention = 6,
        /// <summary>
        /// البحث بإستخدام الهاشتاق
        /// </summary>
        DoSearchUsingHastag = 7,
        /// <summary>
        /// جلب  عدد المتابعين  لحساب محدد
        /// </summary>
        DoGetCountAccount =11,
        /// <summary>
        /// الغاء العملية الحالية
        /// </summary>
        CancelCurrentOperation=12,
        /// <summary>
        /// جلب  عدد المتابعين 
        /// </summary>
        GetCurrentFollowers =13,
        /// <summary>
        /// جلب اسم المستخدم
        /// </summary>
        GetCurrentName=14,
        /// <summary>
        /// جلب عدد المتابعون 
        /// </summary>
        GetCurrentFollwings=15

    }
}

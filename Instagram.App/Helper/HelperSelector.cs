using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Instagram.App
{
    /// <summary>
    /// كلاس يساعد على اختيار جدول من عدة جداول  وعرضها في القسم الصحيح
    /// ***تحت التجربة***
    /// </summary>
    public class HelperSelector:BaseViewModel
    {
        
        public static TypesSections CurrentSection { get; set; } = TypesSections.FollowersSection;
        /// <summary>
        /// الجداول المسجلة
        /// </summary>
        public static ObservableCollection<ModelTable> regestirTables { get; set; }
        private static string s;
        /// <summary>
        /// الجدول المحدد
        /// </summary>
        public static string selectedTable { get { return s; } set { s = value; } }
        /// <summary>
        /// عند تحديد جدول  يمتلئ هذا الكولكشن ببيانات الجدول المحدد 
        /// </summary>
        public static ObservableCollection<ModelSearch> SelectedTableOfP { get { return ParentOfSearchTable[regestirTables.IndexOf(regestirTables.Where(item => item.NameOfTheTable == selectedTable).FirstOrDefault())]; } private set { value = new ObservableCollection<ModelSearch>(); } }
        /// <summary>
        /// عند تحديد جدول  يمتلئ هذا الكولكشن ببيانات الجدول المحدد 
        /// </summary>
        public static ObservableCollection<ModelPost> SelectedTableOfS
        {
            get
            {
                try
                {
                    return ParentOfPostsTable[regestirTables.IndexOf(regestirTables.Where(item => item.NameOfTheTable == selectedTable).FirstOrDefault())];
                }
                catch (Exception)
                {

                    return null;
                }
            }

        }
       
        /// <summary>
        /// عند تحديد جدول  يمتلئ هذا الكولكشن ببيانات الجدول المحدد 
        /// </summary>
        public static ObservableCollection<AccountOperations> SelectedTableOfF
        {
            get { return ParentOfFollowersTable[regestirTables.IndexOf(regestirTables.Where(item => item.NameOfTheTable == selectedTable).FirstOrDefault())]; }

        }
        /// <summary>
        /// يحتوي على جداول قسم المتابعين
        /// </summary>
        public static ObservableCollection<ObservableCollection<AccountOperations>> ParentOfFollowersTable { get; set; }
        /// <summary>
        /// يحتوي على جداول قسم المنشورات والتعليقات
        /// </summary>
        public static ObservableCollection<ObservableCollection<ModelPost>> ParentOfPostsTable { get; set; }
        /// <summary>
        /// يحتوي على جداول قسم البحث
        /// </summary>
        public static ObservableCollection<ObservableCollection<ModelSearch>> ParentOfSearchTable { get; set; }

        public static void Init()
        {
            regestirTables = Fill(CurrentSection);
            ParentOfPostsTable = FillSecondSection();
            ParentOfSearchTable = new ObservableCollection<ObservableCollection<ModelSearch>>();
            ParentOfFollowersTable = FillFirstSection();
            

        }
        /// <summary>
        /// اضافة جدول
        /// </summary>
        /// <param name="_item">الجدول المراد اضافته</param>
        /// <param name="name">اسم الجدول</param>
        public static void AddTable(ObservableCollection<AccountOperations> _item, string name)

        {
            if (_item == null)
            {
                _item = new ObservableCollection<AccountOperations>();
            }
            var Tables = ((PrototypeOfDB)new FollowersDB()).Fill("Tables").Rows.Cast<DataRow>().ToList();
            try
            {
                if (Tables.IndexOf(Tables.Where(item => item.Field<string>("name") == name).FirstOrDefault()) != -1 || string.IsNullOrEmpty(name))
                {
                    DXMessageBox.Show($"اسم الجدول مُستخدم سابقاً", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoggerViewModel.Log($"اسم الجدول مُستخدم سابقاً", TypeOfLog.exclamationcircle);
                    return;
                }
            }
            catch (Exception)
            {

            }

            ParentOfFollowersTable.Add(new ObservableCollection<AccountOperations>(_item));
            regestirTables.Add(new ModelTable()
            {
                typessections = TypesSections.FollowersSection,
                CountOfItems = _item.Count,
                NameOfTheTable = name
            });

            var DB = new FollowersDB();
            Int64 ff = (Int64)new Random().Next(regestirTables.Count + 9621);
            DB.AddTable(name, (Int64)new Random().Next(regestirTables.Count + 9621),TypesSections.FollowersSection);
        }
        /// <summary>
        /// اضافة جدول
        /// </summary>
        /// <param name="_item">الجدول المراد اضافته</param>
        /// <param name="name">اسم الجدول</param>
        public static void AddTable(ObservableCollection<ModelPost> _item, string name)
        {
            if (_item == null)
            {
                _item = new ObservableCollection<ModelPost>();
            }
            var Tables = ((PrototypeOfDB)new PostsDB()).Fill("Tables").Rows.Cast<DataRow>().ToList();

            if (Tables.IndexOf(Tables.Where(item => item.Field<string>("name") == name).FirstOrDefault()) != -1 || string.IsNullOrEmpty(name))
            {
                DXMessageBox.Show($"اسم الجدول مُستخدم سابقاً", "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
                LoggerViewModel.Log($"اسم الجدول مُستخدم سابقاً", TypeOfLog.exclamationcircle);
                return;
            }
            ParentOfPostsTable.Add(new ObservableCollection<ModelPost>(_item));
            regestirTables.Add(new ModelTable()
            {
                CountOfItems=0,
                typessections=TypesSections.CommentsAndPostsSection,
                NameOfTheTable=name
            });
            var DB = new PostsDB();
            Int64 ff = (Int64)new Random().Next(regestirTables.Count + 9621);
            DB.AddTable(name, (Int64)new Random().Next(regestirTables.Count + 9621),TypesSections.CommentsAndPostsSection);
        }
        /// <summary>
        /// حذف جدول محدد
        /// </summary>
        /// <param name="Table">الجدول المراد حذفه</param>
        /// <param name="name">اسم الجدول المراد حذفه</param>
        public static void DeleteTable(ModelTable Table, string name, TypesSections typesSections)
        {
            if (string.IsNullOrEmpty(name) || regestirTables.IndexOf(Table) == -1)
            {
                return;
            }
            try
            {
                switch (typesSections)
                {
                    case TypesSections.FollowersSection:
                        ParentOfFollowersTable.Remove(ParentOfFollowersTable[regestirTables.IndexOf(Table)]);
                        break;
                    case TypesSections.SearchSection:
                        ParentOfSearchTable.Remove(ParentOfSearchTable[regestirTables.IndexOf(Table)]);
                        break;
                    case TypesSections.CommentsAndPostsSection:
                        ParentOfPostsTable.Remove(ParentOfPostsTable[regestirTables.IndexOf(Table)]);
                        break;
                    default:
                        LoggerViewModel.Log($"Cannot delete this table. More Info:Unkown Table", TypeOfLog.exclamationcircle);
                        return;
                }

                regestirTables.Remove(Table);
                new FollowersDB().ResetTable(name);

            }
            catch (Exception ex_err)
            {
                LoggerViewModel.Log($"Cannot delete this table. More Info:{ex_err.Message}", TypeOfLog.exclamationcircle);
            }
        }
        /// <summary>
        /// اضافة عناصر في جدول موجود
        /// </summary>
        /// <param name="name">اسم الجدول</param>
        /// <param name="item">العنصر</param>
        public static void Insert(ObservableCollection<AccountOperations> item, string name = null)
        {
            try
            {
                var Tables = ((PrototypeOfDB)new FollowersDB()).Fill("Tables").Rows.Cast<DataRow>().ToList();
                if (name == null)
                {
                    name = selectedTable;
                }
                if (Tables != null && Tables.IndexOf(Tables.Where(item_ => item_.Field<string>("name") == name
                && item_.Field<string>("section") == TypesSections.FollowersSection.ToString()).FirstOrDefault()) != -1
                && ParentOfFollowersTable.IndexOf(ParentOfFollowersTable[Tables.IndexOf(Tables.Where(item_ => item_.Field<string>("name") == name
                && item_.Field<string>("section") == TypesSections.FollowersSection.ToString()).FirstOrDefault())]) != -1)
                {
                    var temp = (from p in ParentOfFollowersTable[Tables.IndexOf(Tables.Where(item_ => item_.Field<string>("name") == name && item_.Field<string>("section") == TypesSections.FollowersSection.ToString()).FirstOrDefault())]
                                select p).ToList();
                    var tt = item.ToList();
                    tt.AddRange(temp);
                    ParentOfFollowersTable[regestirTables.IndexOf(regestirTables.Where(item_ => item_.NameOfTheTable == name).FirstOrDefault())] = (new ObservableCollection<AccountOperations>(item));
                    update(item, name);
                }
                else if (
                      Tables.IndexOf(Tables.Where(item_ => item_.Field<string>("name") == name
                    && item_.Field<string>("section") == TypesSections.FollowersSection.ToString())
                    .FirstOrDefault()) == -1
                    )
                {
                    ParentOfFollowersTable.Add(item);
                }
                else
                {
                    ParentOfFollowersTable.Add(item);
                }
            }
            catch (Exception)
            {

            }

        }
        /// تغير اسم جدول محدد
        /// </summary>
        /// <param name="name"></param>
        /// <param name="NewName"></param>
        public static void EditTable(string name, string NewName)
        {
            if (CurrentSection == TypesSections.FollowersSection)
            {
                var edit = ((PrototypeOfDB)new FollowersDB()).EditTable(name, NewName);
                if (edit)
                {
                    regestirTables[regestirTables.IndexOf(regestirTables.Where(oldname => oldname.NameOfTheTable == name).FirstOrDefault())].NameOfTheTable = NewName;
                }
            }else if (CurrentSection == TypesSections.CommentsAndPostsSection)
            {
                var edit = ((PrototypeOfDB)new FollowersDB()).EditTable(name, NewName);
                if (edit)
                {
                    regestirTables[regestirTables.IndexOf(regestirTables.Where(oldname => oldname.NameOfTheTable == name).FirstOrDefault())].NameOfTheTable = NewName;
                }
            }
        }
        /// <summary>
        /// تحديث بيانات الجداول
        /// </summary>
        /// <param name="item"></param>
        /// <param name="name"></param>
        private static void update(ObservableCollection<AccountOperations> item, string name)
        {
            if (regestirTables.IndexOf(regestirTables
                .Where(table => table.NameOfTheTable == name).ToList()[0]) == -1)
            {
                return;
            }
            regestirTables[regestirTables.IndexOf(regestirTables.Where(table => table.NameOfTheTable == name).ToList()[0])].CountOfItems = item.Count;

        }
        /// <summary>
        /// جلب جداول القسم الحالي
        /// </summary>
        /// <param name="SelectedSectionType">نوع القسم الحالي</param>
        /// <returns></returns>
        private static List<DataRow> GetTablesOfSelectedSection(TypesSections SelectedSectionType,List<DataRow> Tables)
        {
            try
            {
                Tables.RemoveAll(GetFinalTables => GetFinalTables.Field<string>("section") != SelectedSectionType.ToString());
                return Tables;
            }
            catch (Exception ex_GetTablesOfSelectedSection)
            {

                LoggerViewModel.Log($"Error at GetTablesOfSelectedSection in Helper Selector EX:EX_GetTablesOfSelectedSection More Info:{ex_GetTablesOfSelectedSection.Message}", TypeOfLog.exclamationcircle);
                return Tables;
            }
     
        }
        //https://www.instagram.com/graphql/query/?query_id=17875800862117404&variables=%7B%22tag_name%22%3A%22%D8%A7%D9%84%D8%AA%D8%B9%D9%84%D9%8A%D9%85%22%2C%22first%22%3A8%2C%22before%22%3A%22J0HWiLRnwA
        /// <summary>
        /// اضافة عناصر في جدول موجود
        /// </summary>
        /// <param name="name">اسم الجدول</param>
        /// <param name="item">العنصر</param>
        public static void Insert(ObservableCollection<ModelPost> item, string name = null)
        {
                                              /*  Posts And Comment's Section */
            try
            {
                var Tables = ((PrototypeOfDB)new PostsDB()).Fill("Tables").Rows.Cast<DataRow>().ToList();
                if (name == null)
                {
                    name = selectedTable;
                }
                if (Tables != null && Tables.IndexOf(Tables.Where(item_ => item_.Field<string>("name") == name && item_.Field<string>("section")==TypesSections.CommentsAndPostsSection.ToString()).FirstOrDefault()) != -1)
                {
                    LoggerViewModel.Log($"Count of table before Filtering {Tables.Count}", TypeOfLog.questioncircle);
                    Tables = GetTablesOfSelectedSection(TypesSections.CommentsAndPostsSection, Tables);
                    LoggerViewModel.Log($"Count of table After Filtered {Tables.Count}", TypeOfLog.questioncircle);
                    var temp = (from p in ParentOfPostsTable[Tables.IndexOf(Tables.Where(item_ => item_.Field<string>("name") == name && item_.Field<string>("section") == TypesSections.CommentsAndPostsSection.ToString()).FirstOrDefault())]
                                select p).ToList();
                    ParentOfPostsTable[Tables.IndexOf(Tables.Where(item_ => item_.Field<string>("name") == name
                    && item_.Field<string>("section") == TypesSections.CommentsAndPostsSection.ToString()).FirstOrDefault())] = (new ObservableCollection<ModelPost>(item));
                }
                else if (
                    Tables.IndexOf(Tables.Where(item_ => item_.Field<string>("name") == name
                    && item_.Field<string>("section") == TypesSections.CommentsAndPostsSection.ToString())
                    .FirstOrDefault()) == -1)
                {
                    AddTable(item, name);
                    ParentOfPostsTable.Add(item);
                    ParentOfFollowersTable.Add(new ObservableCollection<AccountOperations>());
                    ParentOfSearchTable.Add(new ObservableCollection<ModelSearch>());
                }
            }
            catch (Exception ex)
            {
                LoggerViewModel.Log($"Unkown error:{ex.Message}",TypeOfLog.exclamationcircle);
            }

        }
        /// <summary>
        /// مسح الجلسة الحالية
        /// </summary>
        public static void ClearCurrentSession()
        {
            Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    try
                    {
                        regestirTables.Clear();
                        ParentOfSearchTable.Clear();
                        ParentOfPostsTable.Clear();
                        ParentOfFollowersTable.Clear();
                    }
                    catch (Exception exx)
                    {
                        LoggerViewModel.Log($"Helper Selector line:213 {exx.Message}", TypeOfLog.exclamationcircle);

                    }

                });

            });


        }
        /// <summary>
        /// نقل الجداول من قاعدة البيانات الى حاوية الجداول
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        private static ObservableCollection<ModelTable> Fill(TypesSections sections)
        {
            try
            {

                var obs = new ObservableCollection<ModelTable>();
                var dt = new DataTable();
                var fillDatatable = new FollowersDB();
                dt = ((PrototypeOfDB)fillDatatable).Fill("Tables");
                foreach (DataRow item in dt.Rows)
                {
                    if (item.Field<string>("section")==sections.ToString())
                    {
                        obs.Add(new ModelTable()
                        {
                            NameOfTheTable = item.Field<string>("name"),
                            CountOfItems = (CurrentSection == TypesSections.FollowersSection) ?
                          fillDatatable.Fill(item.Field<string>("name")).Rows.Count :
                          (CurrentSection == TypesSections.CommentsAndPostsSection) ?
                           new PostsDB().Fill(item.Field<string>("name")).Rows.Count :
                           new SearchDB().Fill(item.Field<string>("name")).Rows.Count
                           ,
                            typessections = CurrentSection
                        });
                    }
                    
                }
              return obs;
            }
            catch (Exception ex_Fill)
            {

                LoggerViewModel.Log($"Error:{ex_Fill.InnerException} Method Fill Class HelperSelector", TypeOfLog.exclamationcircle);
                return new ObservableCollection<ModelTable>();
            }

        }
        /// <summary>
        /// نقل الجداول التي تحتوي على بيانات من قاعدة البيانات الى حاوية الجداول
        /// </summary>
        /// <returns></returns>
        private static ObservableCollection<ObservableCollection<AccountOperations>> FillFirstSection()
        {
            try
            {
                ObservableCollection<ObservableCollection<AccountOperations>> obs = null;
                obs = new ObservableCollection<ObservableCollection<AccountOperations>>();
                for (int i = 0; i < regestirTables.Count; i++)
                {
                    var tt = new ObservableCollection<AccountOperations>();
                    obs.Add(new ObservableCollection<AccountOperations>());
                    obs[i] = tt;
                    var tempList = (from row_ in new FollowersDB().Fill(regestirTables[i].NameOfTheTable).Rows.Cast<DataRow>()
                                    from row_4 in new string[] { row_.Field<string>("username") }

                                    let row_2 = new string[]
                                    {
                                        row_.Field<string>("username"),
                                        row_.Field<string>("Uid"),
                                        row_.Field<string>("Followers"),
                                        row_.Field<string>("IsFollower")
                                    }
                                    select row_2).ToList();
                    int countofItemsinSelectedSection = new FollowersDB().GetCount(new FollowersDB().GetID(regestirTables[i].NameOfTheTable, TypesSections.FollowersSection));
                    for (int ii = 0; ii < countofItemsinSelectedSection; ii++)
                    {
                        tt.Add(new AccountOperations()
                        {
                            Username = tempList[ii][0],
                            Uid = tempList[ii][1],
                            Followers = int.Parse(tempList[ii][2]),
                            IsFollower = (tempList[ii][3] == "Follow") ? TypeOfResponse.Follow :
                            (tempList[ii][3] == "Following") ? TypeOfResponse.Following :
                            (tempList[ii][3] == "Requested") ? TypeOfResponse.Requested : TypeOfResponse.None
                        });
                    }
                }
                return obs;
            }
            catch (Exception ex_fill)
            {
                LoggerViewModel.Log($"Error:{ex_fill.Message} At Fill method,Class HelperSelector", TypeOfLog.exclamationcircle);
                return new ObservableCollection<ObservableCollection<AccountOperations>>();
            }
        }
        /// <summary>
        /// نقل الجداول التي تحتوي على بيانات من قاعدة البيانات الى حاوية الجداول
        /// </summary>
        /// <returns></returns>
        private static ObservableCollection<ObservableCollection<ModelPost>> FillSecondSection()
        {
            try
            {
                ObservableCollection<ObservableCollection<ModelPost>> obs = null;
                obs = new ObservableCollection<ObservableCollection<ModelPost>>();
                for (int i = 0; i < regestirTables.Count; i++)
                {
                    var tt = new ObservableCollection<ModelPost>();
                    obs.Add(new ObservableCollection<ModelPost>());
                    obs[i] = tt;
                    var tempList = (from row_ in new PostsDB().Fill(regestirTables[i].NameOfTheTable).Rows.Cast<DataRow>()
                                    let row_2 = new string[]
                                    {
                                        row_.Field<string>("ContextMedia"),
                                        row_.Field<string>("UidOfpost"),
                                        row_.Field<string>("Context"),
                                        row_.Field<string>("publisher"),
                                        row_.Field<string>("publishedat"),
                                        row_.Field<string>("UidOfPublisher"),
                                        row_.Field<string>("Likes"),
                                        row_.Field<string>("Views")
                                    }
                                    select row_2).ToList();

                    int countofItemsinSelectedSection = new PostsDB().GetCount(new PostsDB().GetID(regestirTables[i].NameOfTheTable, TypesSections.CommentsAndPostsSection));
                    for (int ii = 0; ii < countofItemsinSelectedSection; ii++)
                    {

                        tt.Add(new ModelPost()
                        {
                            ContextMedia = tempList[ii][0],
                            UidOfpost = tempList[ii][1],
                            Context = tempList[ii][2],
                            publisher = tempList[ii][3],
                            publishedat = tempList[ii][4],
                            UidOfpublisher = tempList[ii][5],
                            Likes = tempList[ii][6],
                            Views = tempList[ii][7]
                        });
                    }
                }
                return obs;
            }
            catch (Exception ex_fill)
            {
                LoggerViewModel.Log($"Error:{ex_fill.Message} At Fill method,Class HelperSelector", TypeOfLog.exclamationcircle);
                return new ObservableCollection<ObservableCollection<ModelPost>>();
            }
        }
        /// <summary>
        /// التحقق من وجود جدول
        /// </summary>
        /// <param name="name"></param>
        /// <returns>
        /// *0 -> True 
        /// -1 -> False
        /// </returns>
        public static int check(string name)
        {
            try
            {
                if (regestirTables.IndexOf(regestirTables.Where(item => item.NameOfTheTable == name).FirstOrDefault()) == -1)
                {
                    return -1;
                }
                else
                    return 0;
            }
            catch (Exception)
            {
                return -1;
            }

        }
    }
}


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{

    public class CurrentPostViewModel
    {
        /// <summary>
        /// المنشور الحالي
        /// </summary>
        private CurrentPostModel CurrentPost_ { get; set; }
        public CurrentPostViewModel(CurrentPostModel currentPostModel)
        {
            CurrentPost_ = currentPostModel;
        }



        /// <summary>
        /// حفظ
        /// </summary>
        public void Save(ModelPost post, ObservableCollection<ModelPost> Posts = null)
        {
            if (post == null && Posts==null)
            {
                return;
            }
            bool IsCollection = Posts == null ? false : true;
            var currentpostContainer = new ObservableCollection<ModelPost>();
            if (IsCollection)
            {
                for (int i = 0; i < Posts.Count; i++)
                {
                    post = Posts[i];
                    if (CurrentPost_.IsCustomizeEnable)
                    {
                        if (CurrentPost_.IsSectionAccounts)
                        {
                            bool Match_ = false;
                            
                            for (int ii = 0; ii < CollectionsHelper.Followers.Count; ii++)
                            {
                                if (CollectionsHelper.Followers[ii].Username == post.publisher
                                  && CollectionsHelper.Followers[ii].Uid == post.UidOfpublisher
                                  && CollectionsHelper.Followers[ii].Username != null)
                                {
                                    Match_ = true;
                                    break;
                                }
                            }


                            if (!Match_)
                            {
                                CollectionsHelper.Followers.Add(new AccountOperations()
                                {
                                    Username = post.publisher,
                                    Uid = post.UidOfpublisher
                                });
                            }
                        }
                        if (CurrentPost_.IsSectionComments)
                        {
                            bool Match_ = false;
                            for (int ii = 0; ii < CollectionsHelper.Posts.Count; ii++)
                            {
                                if (post == CollectionsHelper.Posts[ii])
                                {
                                    Match_ = true;
                                }
                                if (Match_)
                                {
                                    break;
                                }
                            }
                            if (!Match_)
                            {
                                //CollectionsHelper.Posts.Add(post);
                                currentpostContainer.Add(post);
                                HelperSelector.Insert(currentpostContainer, CurrentPost_.Tablename);
                                if (CurrentPost_.Tablename == "-")
                                {
                                    CurrentPost_.Tablename = $" {new Random().Next(1, 99999).ToString()} جدول";
                                }
                            }
                        }
                    }

                    bool Match = false;

                    for (int ii = 0; ii < CollectionsHelper.Followers.Count; ii++)
                    {
                        if (CollectionsHelper.Followers[ii].Username == post.publisher
                          && CollectionsHelper.Followers[ii].Uid == post.UidOfpublisher
                          && CollectionsHelper.Followers[ii].Username != null)
                        {
                            Match = true;
                            break;
                        }
                    }


                    if (!Match)
                    {
                        CollectionsHelper.Followers.Add(new AccountOperations()
                        {
                            Username = post.publisher,
                            Uid = post.UidOfpublisher
                        });
                    }

                    Match = false;

                    for (int ii = 0; ii < CollectionsHelper.Posts.Count; ii++)
                    {
                        if (post == CollectionsHelper.Posts[ii])
                        {
                            Match = true;
                        }
                        if (Match)
                        {
                            break;
                        }
                    }
                    if (!Match)
                    {
                        currentpostContainer.Add(post);
                        if (HelperSelector.check(CurrentPost_.Tablename) != -1)
                        {

                            HelperSelector.Insert(currentpostContainer,CurrentPost_.Tablename);
                        }
                        else
                        {
                            HelperSelector.Insert(currentpostContainer, CurrentPost_.Tablename);
                        }
                    }
                }
            }
           


        }
        /// <summary>
        /// تخصيص الحفظ
        /// </summary>
        public void CustomizeSave()
        {
            if (CurrentPost_ == null)
            {
                return;
            }
            CurrentPost_.IsCustomizeEnable = (CurrentPost_.IsCustomizeEnable) ? false : true;
            if (!CurrentPost_.IsCustomizeEnable)
            {
                return;
            }
            CurrentPost_.Tablename = $" {CollectionsHelper.Posts.Count.ToString()} جدول";
        }
        /// <summary>
        /// التعديل على اسم الجدول
        /// </summary>
        public void EditOfTablename()
        {
            if (CurrentPost_ == null)
            {
                return;
            }
            CurrentPost_.IsEditable = (!CurrentPost_.IsEditable) ? true : false;
        }
        /// <summary>
        /// حفظ اسم الجدول
        /// </summary>
        public void SaveOfTablename()
        {
            if (CurrentPost_ == null)
            {
                return;
            }
            CurrentPost_.IsEditable = (CurrentPost_.IsEditable) ? false : true;
        }

    }
}

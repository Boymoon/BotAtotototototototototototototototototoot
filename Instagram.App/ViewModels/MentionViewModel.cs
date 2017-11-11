using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Text;
using System.Linq;
namespace Instagram.App
{
    public class MentionViewModel
    {

        /// <summary>
        /// الجدول المحدد
        /// </summary>
        public ObservableCollection<ModelMention> Selected = new ObservableCollection<ModelMention>();
        /// <summary>
        /// الجدول العام
        /// </summary>
        public ObservableCollection<ModelMention> UserInfo => Fillobs(new ObservableCollection<ModelMention>());

        public ModelMention ModelMention
        {
            set
            {
              
                    //نتأكد من ان الاسم ليس مكرر
                    try
                    {
                        int indexxa = Selected.IndexOf(Selected.Where(searchingfor => searchingfor.Username == value.Username).First());

                        if (Selected[indexxa].Username != value.Username && !modelComment.Tag.Contains(value.Username))
                        {
                            Selected.Add(new ModelMention() { Username = value.Username, Uid = value.Uid, FullMention = "@" + value.Username });
                        }
                    }
                    catch (Exception)
                    {
                    if (modelComment.Tag == null || !modelComment.Tag.Contains(value.Username))
                    {
                        Selected.Add(new ModelMention() { Username = value.Username, Uid = value.Uid, FullMention = "@" + value.Username });
                    }

                    }
             
                    //selected.Add(new ModelMention() { Username = value.Username, Uid = value.Uid, FullMention = "@" + value.Username });

            }
        }
        private ModelMention mmodelMention_;

        public ModelMention mmodelMention
        {
            get { return mmodelMention_; }
            set { mmodelMention_ = value; }
        }
        private ModelComment modelComment;
        private Mention GetMention;
        public MentionViewModel(ModelComment ModelComment_, ModelMention modelMention_,Mention WINmention)
        {
            modelMention_.SaveCommand = new BaseCommand(Save);
            modelComment = ModelComment_;
            mmodelMention = modelMention_;
            GetMention = WINmention;
        }
        /// <summary>
        /// دالة لحفظ كامل المنشن المحدد 
        /// </summary>
        private void Save()
        {
            foreach (var item in Selected)
            {
                modelComment.Tag += item.FullMention;
            }
            GetMention.Close();
        }
        /// <summary>
        /// تعبئة القوائم او الجداول وفق شروط معينة 
        /// </summary>
        /// <param name="Currentitem"></param>
        /// <returns></returns>
        private ObservableCollection<ModelMention> Fillobs(ObservableCollection<ModelMention> Currentitem)
        {

            for (int i = 0; i < ContainerCollection<ObservableCollection<ModelPost>>.Container.Count; i++)
            {
                for (int ii = 0; ii < ContainerCollection<ObservableCollection<ModelPost>>.Container[i].Count; ii++)
                {
                    Currentitem.Add(new ModelMention()
                    {
                        Uid = ContainerCollection<ObservableCollection<ModelPost>>.Container[i][ii].UidOfpublisher,
                        Username = ContainerCollection<ObservableCollection<ModelPost>>.Container[i][ii].publisher
                    });
                }
            }

            return Currentitem;
        }
    }
}

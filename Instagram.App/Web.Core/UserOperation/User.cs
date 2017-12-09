using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.App
{
    public class User
    {
        private string[] Userinfo_;

        public string[] GetUserinfo
        {
            get
            {
                if (Userinfo_ == null)
                {
                    Userinfo_ = UserInfo();
                }
                return Userinfo_;
            }
        }
        /* Display followed_by_count */
        public string followed_by { get { return GetUserinfo[0]; } }
        /* Display follows_count */
        public string follows { get { return GetUserinfo[1]; } }
        /* Display full_name */
        public string full_name { get { return GetUserinfo[2]; } }
        /* Display id */
        public string id { get { return GetUserinfo[3]; } }
        /* Display State of this account */
        public string Is_Private { get { return GetUserinfo[4]; } }
        /* Display userName */
        public string username { get { return GetUserinfo[5]; } }
        /* Display posts_count */
        public string Posts_count { get { return GetUserinfo[6]; } }
        /*  Posts */
        public ObservableCollection<ModelPost> _posts_ { get { return Posts(); } }

        /// <summary>
        /// URL of account
        /// </summary>
        string url = "";
        public User(string url)
        {
            this.url = (string.IsNullOrEmpty(url)) ? "" : url;
        }
        /// <summary>
        /// جلب اسم الحساب المراد
        /// </summary>
        /// <returns></returns>
        private string[] UserInfo()
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url + @"?__a=1");
                webRequest.CookieContainer = KernalWeb.GetCookie();
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0";
                webRequest.Headers.Add("Accept-Language", "en-US,en;q=0.5");
                webRequest.ContentType = "application/x-www-form-urlencoded";
                var resp = (WebResponse)webRequest.GetResponse();
                var reader = new StreamReader(resp.GetResponseStream(), Encoding.Default);
                JObject jObject = JObject.Parse(reader.ReadToEnd());
                string[] CollectionOfUserInfo = null;
                CollectionOfUserInfo = new string[] {
                ((int)jObject["user"]["followed_by"]["count"]).ToString(),
                ((int)jObject["user"]["follows"]["count"]).ToString(),
                (string)jObject["user"]["full_name"],
                (string)jObject["user"]["id"],
                ((bool)jObject["user"]["is_private"]).ToString(),
                (string)jObject["user"]["username"].ToString(),
                ((int)jObject["user"]["media"]["count"]).ToString()
               };
                return CollectionOfUserInfo;
            }
            catch (Exception ex_UserInfo)
            {
                LoggerViewModel.Log($"error at UserInfo Class User Block:(ex_UserInfo) More Info:{ex_UserInfo.Message}", TypeOfLog.exclamationcircle);
                return null;
            }

        }
        private List<string> GetPostID(CookieContainer _cookie)
        {
            var PostIDCollection = new List<string>();
            /* Get PostID */
            var jsonOfUserInfo = GetJsonOfUserInfo(_cookie);
            for (int i = 0; i < int.Parse(Posts_count); i++)
            {
                PostIDCollection.Add((string)jsonOfUserInfo["user"]["media"]["nodes"][i]["code"]);
            }
            return PostIDCollection;
        }
        /* تبقى اضافة الاشخاص الذين قامو بالتعليق  والاعجاب وجلبهم وفرزهم */
        private ObservableCollection<ModelPost> Posts()
        {
            try
            {
                var cookie_ = KernalWeb.GetCookie();
                var _Posts = new ObservableCollection<ModelPost>();
                var PostIDCollection = new List<string>(GetPostID(cookie_));
                for (int postI = 0; postI < PostIDCollection.Count; postI++)
                {
                    string url_ = $"https://www.instagram.com/p/{PostIDCollection[postI]}/?__a=1";
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url_);
                    webRequest.CookieContainer = cookie_;
                    webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0";
                    webRequest.Headers.Add("Accept-Language", "en-US,en;q=0.5");
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    var resp = (WebResponse)webRequest.GetResponse();
                    var reader = new StreamReader(resp.GetResponseStream(), Encoding.Default);
                    JObject jObject = JObject.Parse(reader.ReadToEnd());
                    if (jObject["graphql"]["shortcode_media"]["edge_media_to_caption"]["edges"].Children().ToList().Count >= 1)
                    {
                        _Posts.Add(new ModelPost()
                        {
                            Context = (string)jObject["graphql"]["shortcode_media"]["edge_media_to_caption"]["edges"][0]["node"]["text"],
                            ContextMedia = (string)jObject["graphql"]["shortcode_media"]["display_url"],
                            Views = ((int)jObject["graphql"]["shortcode_media"]["edge_media_to_comment"]["count"]).ToString(),
                            Likes = ((int)jObject["graphql"]["shortcode_media"]["edge_media_preview_like"]["count"]).ToString(),
                            UidOfpublisher = $"https://www.instagram.com/" + (string)jObject["graphql"]["shortcode_media"]["owner"]["username"] + "/",
                            publisher = (string)jObject["graphql"]["shortcode_media"]["owner"]["username"],
                            UidOfpost = "https://www.instagram.com/p/" + (string)jObject["graphql"]["shortcode_media"]["shortcode"] + "/"
                        });
                    }
                    else
                    {
                        _Posts.Add(new ModelPost()
                        {
                            Context = "لايوجد",
                            ContextMedia = (string)jObject["graphql"]["shortcode_media"]["display_url"],
                            Views = ((int)jObject["graphql"]["shortcode_media"]["edge_media_to_comment"]["count"]).ToString(),
                            Likes = ((int)jObject["graphql"]["shortcode_media"]["edge_media_preview_like"]["count"]).ToString(),
                            UidOfpublisher = $"https://www.instagram.com/" + (string)jObject["graphql"]["shortcode_media"]["owner"]["username"] + "/",
                            publisher = (string)jObject["graphql"]["shortcode_media"]["owner"]["username"],
                            UidOfpost = "https://www.instagram.com/p/" + (string)jObject["graphql"]["shortcode_media"]["shortcode"] + "/"
                        });
                    }
                }
                return _Posts;
            }
            catch (Exception ex_GetPostsFromUserInfo)
            {

                LoggerViewModel.Log($"Error At Posts in User More Info: {ex_GetPostsFromUserInfo.Message}", TypeOfLog.exclamationcircle);
                return new ObservableCollection<ModelPost>();
            }


        }

        private JObject GetJsonOfUserInfo(CookieContainer cookie = null)
        {
            if (cookie == null)
            {
                cookie = KernalWeb.GetCookie();
            }
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url + @"?__a=1");
            webRequest.CookieContainer = cookie;
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0";
            webRequest.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            webRequest.ContentType = "application/x-www-form-urlencoded";
            var resp = (WebResponse)webRequest.GetResponse();
            var reader = new StreamReader(resp.GetResponseStream(), Encoding.Default);
            JObject jObject = JObject.Parse(reader.ReadToEnd());
            return jObject;
        }
    }
}

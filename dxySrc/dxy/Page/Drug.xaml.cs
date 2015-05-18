using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Net.Http;
using dxy.Entity;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using dxy.Common;
using System.IO.IsolatedStorage;

namespace dxy.Page
{
    public partial class Drug : PhoneApplicationPage
    {
        private IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        private string id;
        private string name;
        private string url = "http://drugs.dxy.cn/api/v2/detail";
        private drug d;
        private bool isFavor;

        private ObservableCollection<drugThird> bindList = new ObservableCollection<drugThird>();
        public ObservableCollection<drugThird> BindList
        {
            get { return bindList; }
            set {
                if (bindList!=value)
                {
                    bindList = value;
                }
            }
        }
        public Drug()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("id"))
            {
                id = NavigationContext.QueryString["id"];
            }
            if (NavigationContext.QueryString.ContainsKey("name"))
            {
                name = NavigationContext.QueryString["name"];
            }
            base.OnNavigatedTo(e);
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            HttpClient c = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
            FormUrlEncodedContent postData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("id",id),
                        new KeyValuePair<string, string>("category", "1"),
                        new KeyValuePair<string, string>("u", ""),
                        new KeyValuePair<string, string>("mc", "0000000005e6b1d8ffffffff9c1fe4e0"),
                        new KeyValuePair<string, string>("hardName", "ASUS_X002"),
                        new KeyValuePair<string, string>("ac", "d5424fa6-adff-4b0a-8917-4264daf4a348"),
                        new KeyValuePair<string, string>("bv", "2014"),
                        new KeyValuePair<string, string>("vc", "3.5"),
                        new KeyValuePair<string, string>("vs", "4.4.4"),
                        new KeyValuePair<string, string>("hasMedicare", "1"),
                        new KeyValuePair<string, string>("vsNames", ""),
                    }
            );
            request.Content = postData;
            HttpResponseMessage response = await c.SendAsync(request);
            string responseString = await response.Content.ReadAsStringAsync();
            d = JsonConvert.DeserializeObject<drug>(responseString);
            if (d.Success)
            {
                d.Data.Detail.ForEach(a =>
                {
                    bindList.Add(a);
                });
                drugTitle.Text = name;
                if (d.Data.Price != "0")
                {
                    price.Text = d.Data.Price + "元";
                }
                else
                {
                    price.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                MessageHelper.Show("获取数据失败");
            }
            
        }

        /// <summary>
        /// 添加到药箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBar_Click(object sender, EventArgs e)
        {
            if (!settings.Contains("drugbox"))
            {
                settings.Add("drugbox", id);
                saveName(id,name);
                MessageHelper.Show("添加成功");
            }
            else
            {

                string[] titleStr = settings["drugbox"].ToString().Split(';');
                foreach (var s in titleStr)
                {
                    if (s == id)
                    {
                        isFavor = true;
                        MessageHelper.Show("该药品已经添加过");
                        break;
                    }
                }
                if (!isFavor)
                {
                    settings["drugbox"] += ";";
                    settings["drugbox"] += id;

                    saveName(id, name);
                    MessageHelper.Show("添加成功");
                }
            }
            settings.Save();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">药品名称</param>
        private void saveName(string id,string name)
        {
            if (!settings.Contains(id))
            {
                settings.Add(id, name);
            }
            else
            {
                settings[id] = name;
            }
            settings.Save();
        }


    }
}
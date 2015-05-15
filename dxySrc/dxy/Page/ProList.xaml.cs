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

namespace dxy.Page
{
    public partial class ProList : PhoneApplicationPage
    {
        PhoneApplicationService ps = PhoneApplicationService.Current;
        private news tmpnew;

        private bool loaded = false;


        public ObservableCollection<newsSec> bindNews = new ObservableCollection<newsSec>();
        public ObservableCollection<newsSec> BindNews
        {
            get { return bindNews; }
            set
            {
                if (bindNews != value)
                {
                    bindNews = value;
                }
            }
        }


        public ProList()
        {
            InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode== NavigationMode.Back)
            {
                loaded = true;
                return;
            }
            object title;
            object desc;
            if (ps.State.ContainsKey("proTitle") && ps.State.ContainsKey("proDesc"))
            {
                if (ps.State.TryGetValue("proTitle", out title))
                {
                    titleTb.Text = title.ToString();
                }
                if (ps.State.TryGetValue("proDesc", out desc))
                {
                    titleTb.Tag = desc.ToString();
                }
            }
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (loaded)
            {
                return;
            }
            if (!NavigationContext.QueryString.Keys.Contains("id"))
            {
                return;
            }
            string id = NavigationContext.QueryString["id"];
            string url = "http://dxy.com/app/i/columns/article/list?page_index=1&items_per_page=10&order=publishTime&special_id=" + id;
            HttpClient client = new HttpClient();
            var content = await client.GetAsync(url);
            string res = await content.Content.ReadAsStringAsync();
            string tmp = res.Substring(8, res.Length - 9);
            tmpnew = JsonConvert.DeserializeObject<news>(tmp);
            tmpnew.Items.ToList().ForEach(z =>
            {
                bindNews.Add(z);
            });

        }

        /// <summary>
        /// 主题详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid g = sender as Grid;
            string id = g.Tag.ToString();
            NavigationService.Navigate(new Uri("/Page/NewsDetail.xaml?id=" + id, UriKind.Relative));
        }

    }
}
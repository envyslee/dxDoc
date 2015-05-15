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
using Newtonsoft.Json;
using dxy.Entity;
using System.Collections.ObjectModel;

namespace dxy.Page
{
    public partial class Health : PhoneApplicationPage
    {
        private int index = 0;
        private int page = 1;
        private int projectPage = 1;
        private string end = "已经到底了...";

        private bool proLoad = false;
        private HttpClient client = new HttpClient();
        PhoneApplicationService ps = PhoneApplicationService.Current;



        private news resNews = new news();

        public news ResNews
        {
            get { return resNews; }
            set
            {
                if (resNews != value)
                {
                    resNews = value;
                }
            }
        }

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

        private project resPro = new project();

        private ObservableCollection<projectSec> bindPro = new ObservableCollection<projectSec>();
        public ObservableCollection<projectSec> BindPro
        {
            get { return bindPro; }
            set
            {
                if (bindPro != value)
                {
                    bindPro = value;
                }
            }
        }

        public Health()
        {
            InitializeComponent();
        }


        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (healthPivot.SelectedIndex == 1)
            {
                if (!proLoad)
                {
                    GetProject(projectPage);
                    proLoad = true;
                }
                
            }
            else if (healthPivot.SelectedIndex == 2)
            {

            }
        }

        /// <summary>
        /// 获取最新资讯
        /// </summary>
        private async void GetNews(int i)
        {
            string news = "http://dxy.com/app/i/columns/article/list?page_index=" + i + "&items_per_page=10&order=publishTime";


            HttpResponseMessage response = await client.GetAsync(news);
            string responseBody = await response.Content.ReadAsStringAsync();

            string tmp = responseBody.Substring(8, responseBody.Length - 9);
            resNews = JsonConvert.DeserializeObject<news>(tmp);

            resNews.Items.ToList().ForEach(z =>
            {
                bindNews.Add(z);
            });
            if (resNews.Items.Count < 10)
            {
                addMore.Text = end;
                return;
            }
            page++;

        }

        /// <summary>
        /// 获取专题
        /// </summary>
        /// <param name="i"></param>
        private async void GetProject(int i)
        {
            string project = "http://dxy.com/app/i/columns/special/list?page_index=" + i + "&items_per_page=10";
            HttpResponseMessage response = await client.GetAsync(project);
            string responseBody = await response.Content.ReadAsStringAsync();

            string tmp = responseBody.Substring(8, responseBody.Length - 9);
            resPro = JsonConvert.DeserializeObject<project>(tmp);
            resPro.Items.ForEach(z =>
            {
                bindPro.Add(z);
            });
            if (resPro.Items.Count < 10)
            {
                morePro.Text = end;
            }
            projectPage++;

        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            GetNews(page);
        }

        /// <summary>
        /// 进入详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid g = sender as Grid;
            string id = g.Tag.ToString();
            NavigationService.Navigate(new Uri("/Page/NewsDetail.xaml?id=" + id, UriKind.Relative));
        }

        /// <summary>
        /// 加载更多   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GetNews(page);
        }

        private void morePro_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GetProject(projectPage);
        }

        /// <summary>
        /// 进入健康专题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid g = sender as Grid;
            string id = g.Tag.ToString();
            foreach (var item in BindPro)
            {
                if (item.Id == id)
                {
                    ps.State["proTitle"] = item.Name;
                    ps.State["proDesc"] = item.Desc;
                    break;
                }
            }
            NavigationService.Navigate(new Uri("/Page/ProList.xaml?id=" + id, UriKind.Relative));

        }
    }
}
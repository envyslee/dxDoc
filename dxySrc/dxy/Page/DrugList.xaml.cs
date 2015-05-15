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
    public partial class DrugList : PhoneApplicationPage
    {
        private string routeId;
        private string componentId;
        private string name;
        private bool loaded;

        private drugList dl;

        private ObservableCollection<drugListSec> bindList = new ObservableCollection<drugListSec>();
        public ObservableCollection<drugListSec> BindList
        {
            get { return bindList; }
            set
            {
                if (bindList != value)
                {
                    bindList = value;
                }
            }
        }
        public DrugList()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode==NavigationMode.Back)
            {
                loaded = true;
                return;
            }
            if (NavigationContext.QueryString.ContainsKey("routeId") && NavigationContext.QueryString.ContainsKey("componentId") && NavigationContext.QueryString.ContainsKey("name"))
            {
                routeId = NavigationContext.QueryString["routeId"];
                componentId = NavigationContext.QueryString["componentId"];
                name = NavigationContext.QueryString["name"];
                searchTitle.Text = name;
            }
            base.OnNavigatedTo(e);
        }

        

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (loaded)
            {
                return; 
            }
            string url = "http://drugs.dxy.cn/api/v2/search";
            HttpClient c = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
            FormUrlEncodedContent postData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("routeId", routeId),
                        new KeyValuePair<string, string>("category", "1"),
                        new KeyValuePair<string, string>("u", ""),
                        new KeyValuePair<string, string>("mc", "0000000005e6b1d8ffffffff9c1fe4e0"),
                        new KeyValuePair<string, string>("hardName", "ASUS_X002"),
                        new KeyValuePair<string, string>("ac", "d5424fa6-adff-4b0a-8917-4264daf4a348"),
                        new KeyValuePair<string, string>("bv", "2014"),
                        new KeyValuePair<string, string>("vc", "3.5"),
                        new KeyValuePair<string, string>("vs", "4.4.4"),
                        new KeyValuePair<string, string>("componentId", componentId),
                        new KeyValuePair<string, string>("type", "3"),
                    }
            );
            request.Content = postData;
            HttpResponseMessage response = await c.SendAsync(request);
            string responseString = await response.Content.ReadAsStringAsync();
            dl = JsonConvert.DeserializeObject<drugList>(responseString);
            dl.Data.ForEach(z =>
            {
                bindList.Add(z);
            });
        }

        /// <summary>
        /// 进入药品详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid g = sender as Grid;
            string id = g.Tag.ToString();
            NavigationService.Navigate(new Uri("/Page/Drug.xaml?id="+id, UriKind.Relative));
        }



    }
}
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

namespace dxy.Page
{
    public partial class Medical : PhoneApplicationPage
    {
        private string url = "http://drugs.dxy.cn/api/v2/detail";
        private HttpClient c = new HttpClient();
        private string id;

        public Medical()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("id"))
            {
                id = NavigationContext.QueryString["id"];
            }



            base.OnNavigatedTo(e);
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
            FormUrlEncodedContent postData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                    {
                       new KeyValuePair<string, string>("category", "1"),
                        new KeyValuePair<string, string>("u", ""),
                        new KeyValuePair<string, string>("id", id),
                        new KeyValuePair<string, string>("mc", "0000000005e6b1d8ffffffff9c1fe4e0"),
                        new KeyValuePair<string, string>("hardName", "ASUS_X002"),
                        new KeyValuePair<string, string>("ac", "d5424fa6-adff-4b0a-8917-4264daf4a348"),
                        new KeyValuePair<string, string>("bv", "2014"),
                        new KeyValuePair<string, string>("vc", "3.5"),
                        new KeyValuePair<string, string>("vs", "4.4.4"),
                        new KeyValuePair<string, string>("vsNames", ""),
                         new KeyValuePair<string, string>("hasMedicare", "1")
                    }
            );
            request.Content = postData;
            HttpResponseMessage response = await c.SendAsync(request);
            string responseString = await response.Content.ReadAsStringAsync();
            //dis = JsonConvert.DeserializeObject<disease>(responseString);
        }


    }
}
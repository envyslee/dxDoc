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
using System.Threading.Tasks;

namespace dxy.Page
{
    public partial class KindDetail : PhoneApplicationPage
    {

        private HttpClient c = new HttpClient();
        private string id;
        private string kind;

        public KindDetail()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("id") && NavigationContext.QueryString.ContainsKey("kind"))
            {
                id = NavigationContext.QueryString["id"];
                kind = NavigationContext.QueryString["kind"];
            }
            base.OnNavigatedTo(e);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string url = "http://drugs.dxy.cn/api/v2/detail";
            switch (kind)
            {
                case "qa":

                    break;

                case "disease":
                  string res=  GetData(url).Result;
                    break;
                default:
                    break;
            }
        }

        private async Task<string> GetData(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
            FormUrlEncodedContent postData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                    {
                       new KeyValuePair<string, string>("category", "3"),
                        new KeyValuePair<string, string>("u", ""),
                        new KeyValuePair<string, string>("keywords", key),
                        new KeyValuePair<string, string>("mc", "0000000005e6b1d8ffffffff9c1fe4e0"),
                        new KeyValuePair<string, string>("page", "1"),
                        new KeyValuePair<string, string>("hardName", "ASUS_X002"),
                        new KeyValuePair<string, string>("ac", "d5424fa6-adff-4b0a-8917-4264daf4a348"),
                        new KeyValuePair<string, string>("bv", "2014"),
                        new KeyValuePair<string, string>("vc", "3.5"),
                        new KeyValuePair<string, string>("vs", "4.4.4"),
                        new KeyValuePair<string, string>("type", "1")
                    }
            );
            request.Content = postData;
            HttpResponseMessage response = await c.SendAsync(request);
            string responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }


    }
}
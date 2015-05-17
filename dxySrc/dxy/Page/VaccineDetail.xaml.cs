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
using dxy.Common;
using Newtonsoft.Json;
using dxy.Entity;

namespace dxy.Page
{
    public partial class VaccineDetail : PhoneApplicationPage
    {
        private string id;
        public VaccineDetail()
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
            string url = "http://drugs.dxy.cn/api/v2/vaccines-detail";
            string timestamp = TimeChange.ToUnix(DateTime.Now);
            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
            FormUrlEncodedContent postData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                    {
                         new KeyValuePair<string, string>("id",id),
                       new KeyValuePair<string, string>("timestamp",timestamp),
                        new KeyValuePair<string, string>("u", ""),
                        new KeyValuePair<string, string>("noncestr", "ND7DBOM651JA4ODXLDPI37ASZKCBC32I"),
                        new KeyValuePair<string, string>("mc", "0000000005e6b1d8ffffffff9c1fe4e0"),
                        new KeyValuePair<string, string>("appuid", ""),
                        new KeyValuePair<string, string>("hardName", "ASUS_X002"),
                        new KeyValuePair<string, string>("ac", "d5424fa6-adff-4b0a-8917-4264daf4a348"),
                        new KeyValuePair<string, string>("bv", "2014"),
                        new KeyValuePair<string, string>("vc", "3.5"),
                        new KeyValuePair<string, string>("vs", "4.4.4"),
                        new KeyValuePair<string, string>("appsign", "12c56931c985342d94058da7e5772b4b")
                    }
            );
            request.Content = postData;
            HttpResponseMessage response = await client.SendAsync(request);
            string responseString = await response.Content.ReadAsStringAsync();
            vaccineDetail v = JsonConvert.DeserializeObject<vaccineDetail>(responseString);
            if (v.Success)
            {
                var tmp = v.Data;
                name.Text = tmp.AliasName;
                num.Text = tmp.InjectionNumber;
                eff.Text = tmp.Effect;
                tips.Text = tmp.Introduction;
                forman.Text = tmp.Vaccination;
                if (!string.IsNullOrEmpty(tmp.Precautions))
                {
                    attention.Text = tmp.Precautions;
                }
                else
                {
                    attentionLabel.Visibility = Visibility.Collapsed;
                    attention.Visibility = Visibility.Collapsed;
                }
                if (!string.IsNullOrEmpty(tmp.Contraindications))
                {
                    forbidden.Text = tmp.Contraindications;
                }
                else
                {
                    forbiddenLabel.Visibility = Visibility.Collapsed;
                    forbidden.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                MessageHelper.Show("获取数据失败");
            }
        }
    }
}
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
using dxy.Common;
using dxy.Entity;
using System.Collections.ObjectModel;

namespace dxy.Page
{
    public partial class Vaccine : PhoneApplicationPage
    {
        private string url = "http://drugs.dxy.cn/api/v2/vaccines-list";
        private bool loaded;
        private vaccine va;
        private ObservableCollection<vaccineSec> vList = new ObservableCollection<vaccineSec>();

        private ObservableCollection<Group<vaccineSec>> group = new ObservableCollection<Group<vaccineSec>>();

        public ObservableCollection<Group<vaccineSec>> Group
        {
            get { return group; }
            set
            {
                group = value;
            }
        }
        public Vaccine()
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
            base.OnNavigatedTo(e);
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (loaded)
            {
                return;
            }
            string timestamp = TimeChange.ToUnix(DateTime.Now);
            //string longtime = TimeChange.ToLongUnix(DateTime.Now);
            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
            FormUrlEncodedContent postData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                    {
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
            va = JsonConvert.DeserializeObject<vaccine>(responseString);
            if (va.Success)
            {
                va.Data.ForEach(z =>
                {
                    vList.Add(z);
                });
                Group<vaccineSec>.GetItemGroups(vList, i => i.Months).ForEach(p => group.Add(p));
            }
            else
            {
                MessageHelper.Show("获取数据失败");
            }
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid g = sender as Grid;
            string id = g.Tag.ToString();
            NavigationService.Navigate(new Uri("/Page/VaccineDetail.xaml?id="+id, UriKind.Relative));
        }


    }
}
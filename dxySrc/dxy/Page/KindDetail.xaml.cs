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
using dxy.Entity;
using System.Collections.ObjectModel;
using System.Text;

namespace dxy.Page
{
    public partial class KindDetail : PhoneApplicationPage
    {
       // PhoneApplicationService ps = PhoneApplicationService.Current;
        private HttpClient c = new HttpClient();
        private string id;
        private string kind;

        private composite com;
        //private compositeSec comSec;

        private ObservableCollection<compositeThird> bindCom = new ObservableCollection<compositeThird>();
        public ObservableCollection<compositeThird> BindCom
        {
            get { return bindCom; }
            set {
                if (bindCom!=value)
                {
                    bindCom = value;
                }
            }
        }

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

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string url = "http://drugs.dxy.cn/api/v2/detail";
            switch (kind)
            {
                case "qa":

                    break;

                case "disease":
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
                    FormUrlEncodedContent postData = new FormUrlEncodedContent(
                        new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("id", id),
                        new KeyValuePair<string, string>("category", "4"),
                        new KeyValuePair<string, string>("u", ""),
                        new KeyValuePair<string, string>("mc", "0000000005e6b1d8ffffffff9c1fe4e0"),
                        new KeyValuePair<string, string>("page", "1"),
                        new KeyValuePair<string, string>("hardName", "ASUS_X002"),
                        new KeyValuePair<string, string>("ac", "d5424fa6-adff-4b0a-8917-4264daf4a348"),
                        new KeyValuePair<string, string>("bv", "2014"),
                        new KeyValuePair<string, string>("vc", "3.5"),
                        new KeyValuePair<string, string>("vs", "4.4.4")
                    }
                    );
                    request.Content = postData;
                    HttpResponseMessage response = await c.SendAsync(request);
                    string responseString = await response.Content.ReadAsStringAsync();
                    com = JsonConvert.DeserializeObject<composite>(responseString);
                    if (com.Success=="True")
                    {
                        wb.NavigateToString(ConvertExtendedASCII(com.Data.Definition + com.Data.Therapy));
                        pwb.Header = com.Data.CnName;
                        com.Data.Components.ForEach(z =>
                        {
                            bindCom.Add(z);
                        });
                    }
                    else
                    {
                        
                    }
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// 解决中文乱码
        /// </summary>
        /// <param name="HTML"></param>
        /// <returns></returns>
        public  string ConvertExtendedASCII(string HTML)
        {
            StringBuilder str = new StringBuilder();
            char c;
            for (int i = 0; i < HTML.Length; i++)
            {
                c = HTML[i];
                if (Convert.ToInt32(c) > 127)
                {
                    str.Append("&#" + Convert.ToInt32(c) + ";");
                }
                else
                {
                    str.Append(c);
                }
            }
            return str.ToString();
        }


        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid g=sender as Grid;
            string routeId=g.Tag.ToString();
            TextBlock tb = g.Children[0] as TextBlock;
            string componentId = tb.Tag.ToString();
            string name = tb.Text;
            NavigationService.Navigate(new Uri("/Page/DrugList.xaml?routeId=" + routeId + "&componentId=" + componentId + "&name=" + name, UriKind.Relative));

        }


    }
}
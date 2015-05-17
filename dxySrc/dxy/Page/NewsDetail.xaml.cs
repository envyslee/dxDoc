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
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace dxy.Page
{
    public partial class NewsDetail : PhoneApplicationPage, INotifyPropertyChanged
    {
        private string doc_id = string.Empty;


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string str)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }

        private HttpClient client = new HttpClient();

        private newDetail news;


        public NewsDetail()
        {
            InitializeComponent();
           
        }



        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (NavigationContext.QueryString.Keys.Contains("id"))
            {
                string i = NavigationContext.QueryString["id"];
                string url = "http://dxy.com/app/i/columns/article/single?id=" + i;
                HttpResponseMessage response = await client.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();
                string tmp = responseBody.Substring(8, responseBody.Length - 9);
                news = JsonConvert.DeserializeObject<newDetail>(tmp);

                var tmpRes=news.Items.First();
                //BitmapImage bitmap = new BitmapImage(new Uri(tmpRes.Cover,UriKind.RelativeOrAbsolute));
                //titleImg.Source = bitmap;
                titleTb.Text = tmpRes.Title;
                doctorName.Text = tmpRes.Author;
                doc_id = tmpRes.Author_id;
                conWb.NavigateToString(tmpRes.Content);
            }
        }

        private void doctorName_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!string.IsNullOrEmpty(doc_id))
            {
                
                NavigationService.Navigate(new Uri("/Page/Doctor.xaml?doc_id=" + doc_id, UriKind.Relative));
            }
        }


    }
}
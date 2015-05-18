using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using dxy.Resources;
using System.Net.Http;
using dxy.Entity;
using Newtonsoft.Json;
using System.Windows.Media.Imaging;
using dxy.Common;

namespace dxy
{
    public partial class MainPage : PhoneApplicationPage
    {
        HttpClient client = new HttpClient();
        PhoneApplicationService ps = PhoneApplicationService.Current;

        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

        private void Health_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page/Health.xaml", UriKind.Relative));
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page/Disease.xaml", UriKind.Relative));
        }

        private void Grid_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page/Vaccine.xaml", UriKind.Relative));
        }

       

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (ps.State.ContainsKey("uname"))
            {
                bodyTitle.Text = ps.State["uname"].ToString();
            }
            string url = "http://dxy.com/app/i/columns/article/list?page_index=1&order=publishTime&items_per_page=1";
            var content = await client.GetAsync(url);
            var res =await content.Content.ReadAsStringAsync();
            string articleTmp = res.Substring(8, res.Length - 9);
            news tmp = JsonConvert.DeserializeObject<news>(articleTmp);
            BitmapImage img = new BitmapImage(new Uri(tmp.Items[0].Cover, UriKind.RelativeOrAbsolute));
            TileImg.Source = img;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (ps.State.ContainsKey("uid"))
            {
                MessageHelper.Show("您已经登录");
            }

            NavigationService.Navigate(new Uri("/Page/Login.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page/About.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {

        }

        private void Grid_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page/AlarmList.xaml", UriKind.Relative));
        }

        private void Grid_Tap_3(object sender, System.Windows.Input.GestureEventArgs e)
        {

            //NavigationService.Navigate(new Uri("/Page/Exposure.xaml", UriKind.Relative));
            //return;
            //if (ps.State.ContainsKey("uid")&&ps.State.ContainsKey("uname"))
            //{
            //    NavigationService.Navigate(new Uri("/Page/Exposure.xaml", UriKind.Relative));
               
            //}
            //else
            //{
            //    MessageHelper.Show("请先登录");
            //}
        }

        private void Grid_Tap_4(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page/Medical.xaml", UriKind.Relative));
        }


    }
}
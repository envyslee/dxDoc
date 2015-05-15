using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using dxy.Common;
using System.Net.Http;
using dxy.Entity;
using Newtonsoft.Json;

namespace dxy.Page
{
    public partial class Login : PhoneApplicationPage
    {
        PhoneApplicationService ps = PhoneApplicationService.Current;
        public Login()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ps.State.ContainsKey("uid")&&!string.IsNullOrEmpty(ps.State["uid"].ToString()))
            {
                MessageHelper.Show("您已经登录");
                return;
            }
            if (string.IsNullOrEmpty(account.Text))
            {
                MessageHelper.Show("请输入账号");
                return;
            }
            if (string.IsNullOrEmpty(pass.Password))
            {
                MessageHelper.Show("请输入密码");
                return;
            }
            if (pass.Password.Length < 8 || pass.Password.Length > 16)
            {
                MessageHelper.Show("请输入正确的密码");
                return;
            }

            string loginUrl = "http://dxy.com/login/forapp";
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(loginUrl));
            FormUrlEncodedContent postData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                    {
                       new KeyValuePair<string, string>("account", account.Text),
                        new KeyValuePair<string, string>("mc", "0000000005e6b1d8ffffffff9c1fe4e0"),
                        new KeyValuePair<string, string>("password", pass.Password),
                        new KeyValuePair<string, string>("ac", "d5424fa6-adff-4b0a-8917-4264daf4a348"),
                    }
            );
            request.Content = postData;
            HttpResponseMessage response = await client.SendAsync(request);
            string responseString = await response.Content.ReadAsStringAsync();
            register res = JsonConvert.DeserializeObject<register>(responseString);
            if (res.Success == "False")
            {
                MessageHelper.Show("登录失败，" + res.Message);
                return;
            }
            if (res.Success == "True")
            {
                MessageHelper.Show("登录成功");
                ps.State["uid"] = res.Appuid;
                NavigationService.GoBack();
            }
        }



        private void account_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(account.Text))
            {
                 waterAcc.Visibility = Visibility.Collapsed;
            }
            else
            {
                waterAcc.Visibility = Visibility.Visible;
            }
        }
    }
}
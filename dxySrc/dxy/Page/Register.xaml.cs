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
using System.Text.RegularExpressions;
using System.Net.Http;
using Newtonsoft.Json;
using dxy.Entity;

namespace dxy.Page
{
    public partial class Register : PhoneApplicationPage
    {
        PhoneApplicationService ps = PhoneApplicationService.Current;


        public Register()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 提交注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (email.Text == "")
            {
                MessageHelper.Show("请输入邮箱");
                return;
            }
            string regex = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            Regex r = new Regex(regex);
            Match m = r.Match(email.Text);
            if (!m.Success)
            {
                MessageHelper.Show("请输入正确的邮箱");
                return;
            }
            if (name.Text == "")
            {
                MessageHelper.Show("请输入用户名");
                return;
            }
            if (name.Text.Length < 4 || name.Text.Length > 16)
            {
                MessageHelper.Show("用户名长度为4-16位");
                return;
            }
            if (password.Password == "")
            {
                MessageHelper.Show("请输入密码");
                return;
            }
            if (password.Password.Length < 8 || password.Password.Length > 16)
            {
                MessageHelper.Show("密码长度为8-16位");
                return;
            }
            string p = @"^[A-Za-z0-9]+$";
            Regex pr = new Regex(p);
            Match pm = pr.Match(password.Password);
            if (!pm.Success)
            {
                MessageHelper.Show("密码不可全为数字或字母");
                return;
            }
           

            string registerUrl = "http://dxy.com/register/forapp/email";
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(registerUrl));
            FormUrlEncodedContent postData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                    {
                       new KeyValuePair<string, string>("pwdcheck", password.Password),
                        new KeyValuePair<string, string>("username",name.Text),
                        new KeyValuePair<string, string>("email", email.Text),
                        new KeyValuePair<string, string>("mc", "0000000005e6b1d8ffffffff9c1fe4e0"),
                        new KeyValuePair<string, string>("password", password.Password),
                        new KeyValuePair<string, string>("ac", "d5424fa6-adff-4b0a-8917-4264daf4a348"),
                    
                    }
            );
            request.Content = postData;
            HttpResponseMessage response = await client.SendAsync(request);
            string responseString = await response.Content.ReadAsStringAsync();
            register res = JsonConvert.DeserializeObject<register>(responseString);
            if (!res.Success)
            {
                MessageHelper.Show("注册失败，"+res.Message);
                return;
            }
            if (res.Success)
            {
                MessageHelper.Show("恭喜注册成功");
                ps.State["uid"] = res.Appuid;
            }
        }


  

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(password.Password))
            {
                passTb.Visibility = Visibility.Collapsed;
            }
            else
            {
                passTb.Visibility = Visibility.Visible;
            }
        }
    }
}
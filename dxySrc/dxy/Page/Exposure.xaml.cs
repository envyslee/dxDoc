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
    public partial class Exposure : PhoneApplicationPage
    {

        PhoneApplicationService ps = PhoneApplicationService.Current;
        public Exposure()
        {
            InitializeComponent();
        }

        private async void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (!ps.State.ContainsKey("uid"))
            {
                MessageHelper.Show("请先登录");
                return;
            }
            if (string.IsNullOrEmpty(productName.Text))
            {
                MessageHelper.Show("产品名称不能为空");
                return;
            }

            if (string.IsNullOrEmpty(productMedia.Text))
            {
                MessageHelper.Show("发布媒体不能为空");
                return;
            }

            string timestamp = TimeChange.ToUnix(DateTime.Now);
            string uid = ps.State["uid"].ToString();

            string responseString;

            HttpClient client = new HttpClient();
            string url = "http://dxy.com/api/fake/drugs/report";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));

            if (string.IsNullOrEmpty(productIntro.Text))
            {
                FormUrlEncodedContent postData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                    {
                       new KeyValuePair<string, string>("timestamp",timestamp),
                        new KeyValuePair<string, string>("u", ""),
                        new KeyValuePair<string, string>("noncestr", "EB2QZM8OBYK7DE2WX65DBMYKLA6F60MK"),
                        new KeyValuePair<string, string>("mc", "0000000005e6b1d8ffffffff9c1fe4e0"),
                        new KeyValuePair<string, string>("appuid", uid),
                        new KeyValuePair<string, string>("hardName", "ASUS_X002"),
                        new KeyValuePair<string, string>("ac", "d5424fa6-adff-4b0a-8917-4264daf4a348"),
                        new KeyValuePair<string, string>("bv", "2014"),
                        new KeyValuePair<string, string>("vc", "3.5"),
                        new KeyValuePair<string, string>("vs", "4.4.4"),
                        new KeyValuePair<string, string>("appsign", "22865937d06dd46505c68538ee91b56b"),
                        new KeyValuePair<string, string>("meida", productMedia.Text),
                        new KeyValuePair<string, string>("productName", productName.Text)
                    });
                request.Content = postData;
                HttpResponseMessage response = await client.SendAsync(request);
                responseString = await response.Content.ReadAsStringAsync();
            }
            else
            {
                FormUrlEncodedContent postData = new FormUrlEncodedContent(
               new List<KeyValuePair<string, string>>
                    {
                       new KeyValuePair<string, string>("timestamp",timestamp),
                        new KeyValuePair<string, string>("u", ""),
                        new KeyValuePair<string, string>("noncestr", "ND7DBOM651JA4ODXLDPI37ASZKCBC32I"),
                        new KeyValuePair<string, string>("mc", "0000000005e6b1d8ffffffff9c1fe4e0"),
                        new KeyValuePair<string, string>("appuid", uid),
                        new KeyValuePair<string, string>("hardName", "ASUS_X002"),
                        new KeyValuePair<string, string>("ac", "d5424fa6-adff-4b0a-8917-4264daf4a348"),
                        new KeyValuePair<string, string>("bv", "2014"),
                        new KeyValuePair<string, string>("vc", "3.5"),
                        new KeyValuePair<string, string>("vs", "4.4.4"),
                        new KeyValuePair<string, string>("appsign", "12c56931c985342d94058da7e5772b4b"),
                        new KeyValuePair<string, string>("meida", productMedia.Text),
                        new KeyValuePair<string, string>("productName", productName.Text),
                        new KeyValuePair<string, string>("remark", productIntro.Text)
                    });
                request.Content = postData;
                HttpResponseMessage response = await client.SendAsync(request);
                responseString = await response.Content.ReadAsStringAsync();
            }

            if (!string.IsNullOrEmpty(responseString))
            {
                exposureRes res = JsonConvert.DeserializeObject<exposureRes>(responseString);
                if (res.Success)
                {
                    MessageHelper.Show("提交成功");
                }
                else
                {
                    MessageHelper.Show("提交失败，"+res.Message);
                }
            }
            else
            {
                MessageHelper.Show("网络异常，请稍后再试");
            }
        }
    }
}
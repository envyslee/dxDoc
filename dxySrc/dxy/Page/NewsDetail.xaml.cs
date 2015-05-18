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
using UmengSocialSDK;
using System.IO;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using dxy.Common;
using Microsoft.Phone.Tasks;

namespace dxy.Page
{
    public partial class NewsDetail : PhoneApplicationPage, INotifyPropertyChanged
    {
        private string doc_id = string.Empty;
        private string linkImgUrl = string.Empty;
        private string linkTitle = string.Empty;
        private string saveContent = string.Empty;
        private byte[] images;

        private string umengKey = "55593751e0f55abec00035b5";

        private string weixinAppID = "wx23c4db6d0d03d3f9";
        private string weixinAppSecret = "4ba778273836510af3bd7349664096b6";

        private IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;


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

                var tmpRes = news.Items.First();
                titleTb.Text = tmpRes.Title;
                doctorName.Text = tmpRes.Author;
                doc_id = tmpRes.Author_id;

                linkImgUrl = tmpRes.Cover_small;
                linkTitle = tmpRes.Title;
                string tmpContent = ConvertExtendedASCII(tmpRes.Content);
                conWb.NavigateToString(tmpContent);
                saveContent = tmpContent;
            }

            //邀请评价
            if (!settings.Contains("hasReviewed"))
            {
                OpenTitleStoryboard.Begin();
            }
            
        }

        private void doctorName_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!string.IsNullOrEmpty(doc_id))
            {

                NavigationService.Navigate(new Uri("/Page/Doctor.xaml?doc_id=" + doc_id, UriKind.Relative));
            }
        }


        /// <summary>
        /// 解决中文乱码
        /// </summary>
        /// <param name="HTML"></param>
        /// <returns></returns>
        private string ConvertExtendedASCII(string HTML)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
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

        /// <summary>
        /// 分享
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {

            UmengLink link = new UmengLink();
            link.Url = @"http://www.windowsphone.com/zh-cn/search?q=MangoStudio";
            link.Type = LinkType.Picture;
            link.Title = "丁香医生";
            link.Text = linkTitle + "    快来下载《丁香医生》查看吧~";
            GetPicBuffer();
            link.ThumbnailImage = images;//只对微信有效

            List<UmengClient> clients = new List<UmengClient>()
            {
                new SinaWeiboClient(umengKey),
                new RenrenClient(umengKey),
                new QzoneClient(umengKey),
                new TencentWeiboClient(umengKey),
                new DoubanClient(umengKey),
                new WeixinClient(umengKey, weixinAppID)     
            };
            UmengClient umengClient = new MultiClient(clients);
            var res = await umengClient.ShareLinkAsync(link);
        }



        /// <summary>
        /// 收藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            bool isFavor = false;
            if (!settings.Contains("Titles"))
            {
                settings.Add("Titles", linkTitle);
                settings.Save();
                SaveStringToIsolatedStorage(linkTitle, saveContent);
                MessageHelper.Show("收藏成功");
            }
            else
            {
                string[] titleStr = settings["Titles"].ToString().Split(';');
                foreach (var s in titleStr)
                {
                    if (s == linkTitle)
                    {
                        isFavor = true;
                        MessageHelper.Show("该资讯已经收藏过");
                        break;
                    }
                }
                if (!isFavor)
                {
                    settings["Titles"] += ";";
                    settings["Titles"] += linkTitle;

                    settings.Save();
                    SaveStringToIsolatedStorage(linkTitle, saveContent);
                    MessageHelper.Show("收藏成功");
                }
            }
        }


        /// <summary>
        /// 图片url转为byte
        /// </summary>
        /// <param name="result"></param>
        public void GetPicBuffer()
        {
            WebRequest request = HttpWebRequest.Create(linkImgUrl);//创建WebRequest类  
            request.BeginGetResponse(ResponseCallback, request);//返回异步操作的状态  
        }


        /// <summary>
        /// 图片url转为byte
        /// </summary>
        /// <param name="result"></param>
        private void ResponseCallback(IAsyncResult result)
        {
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;//获取异步操作返回的的信息  
            WebResponse response = request.EndGetResponse(result);//结束对 Internet 资源的异步请求  
            using (Stream stream = response.GetResponseStream())
            {
                //using (StreamReader reader = new StreamReader(stream))
                //{
                //    string contents = reader.ReadToEnd();

                //}
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    byte[] buffer = new byte[32 * 1024];
                    int bytes;
                    while ((bytes = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        memoryStream.Write(buffer, 0, bytes);
                    }
                    images = memoryStream.GetBuffer();
                }
            }
        }

        /// <summary>
        /// 將網頁字串儲存至 IsolatedStorage
        /// </summary>
        /// <param name="strWebContent"></param>
        private void SaveStringToIsolatedStorage(string fileName, string strWebContent)
        {
            //取得使用者範圍隔離儲存區
            IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();

            //刪除先前的檔案
            if (isolatedStorageFile.FileExists(fileName))
            {
                isolatedStorageFile.DeleteFile(fileName);
            }

            // 儲存至 isolated Storage
            StreamResourceInfo streamResourceInfo = new StreamResourceInfo(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(strWebContent)), "html/text");
            using (BinaryReader binaryReader = new BinaryReader(streamResourceInfo.Stream))
            {
                var data = binaryReader.ReadBytes((int)streamResourceInfo.Stream.Length);
                using (BinaryWriter binaryWriter = new BinaryWriter(isolatedStorageFile.CreateFile(fileName)))
                {
                    binaryWriter.Write(data);
                }
            }
        }




        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (TopPopGrid.Visibility == Visibility.Visible)
            {
                TopPopGrid.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 去评价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!settings.Contains("hasReviewed"))
            {
                settings.Add("hasReviewed", true);
            }
            else
            {
                settings["hasReviewed"] = true;
            }
            settings.Save();
            MarketplaceReviewTask reviewTask = new MarketplaceReviewTask();
            reviewTask.Show();
        }

        /// <summary>
        /// 拒绝评价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            CloseTitleStoryboard.Begin();
        }

    }
}
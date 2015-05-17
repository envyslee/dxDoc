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
using dxy.Entity;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace dxy.Page
{
    public partial class Search : PhoneApplicationPage
    {
        HttpClient c = new HttpClient();
        private string key = string.Empty;

        private qa qa;
        private article art;
        private disease dis;
        private medicine med;

        private bool loaded = false;



        private ObservableCollection<searchEnd> se = new ObservableCollection<searchEnd>();
        public ObservableCollection<searchEnd> Se
        {
            get { return se; }
            set
            {
                if (se != value)
                {
                    se = value;
                }
            }
        }


        public Search()
        {
            InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                loaded = true;
                return;
            }
            if (NavigationContext.QueryString.ContainsKey("key"))
            {
                key = NavigationContext.QueryString["key"];
                searchTitle.Text = key;
            }
            base.OnNavigatedTo(e);
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //if ((Application.Current as App).BindSearchEnd!=null&&(Application.Current as App).BindSearchEnd.Count != 0)
            //{
            //    (Application.Current as App).BindSearchEnd.ToList().ForEach(a =>
            //    {
            //        se.Add(a);
            //    });
            //    loading.Visibility = Visibility.Collapsed;
            //    return;
            //}
            if (loaded)
            {
                return;
            }
            if (!string.IsNullOrEmpty(key))
            {
                //相关疾病post
                string diseaseUrl = "http://drugs.dxy.cn/api/v2/search";
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(diseaseUrl));
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
                dis = JsonConvert.DeserializeObject<disease>(responseString);
                se.Add(new searchEnd { Name = "相关疾病", Color = "Grey", Kind = "disease" });
                if (dis.Data != null)
                {
                    if (dis.Data.Count < 2)
                    {
                        se.Add(new searchEnd { Id = dis.Data[0].Id, Name = dis.Data[0].ShowName, Color = "White", Kind = "disease" });
                    }
                    else
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            se.Add(new searchEnd { Id = dis.Data[i].Id, Name = dis.Data[i].ShowName, Color = "White", Kind = "disease" });
                        }
                    }
                }

                //相关问答
                string disease = "http://dxy.com/app/i/faq/qa/related?items_per_page=1000&q=" + key;

                HttpResponseMessage msg = await c.GetAsync(disease);
                var content = await msg.Content.ReadAsStringAsync();
                if (!content.Contains("error"))
                {
                    string tmp = content.Substring(8, content.Length - 9);
                    qa = JsonConvert.DeserializeObject<qa>(tmp);
                    se.Add(new searchEnd { Name = "相关疾病问答", Color = "Grey", Kind = "qa" });
                    if (qa.Items != null)
                    {
                        if (qa.Items.Count < 2)
                        {
                            se.Add(new searchEnd { Id = qa.Items[0].Id, Name = qa.Items[0].Title, Color = "White", Kind = "qa", ArticleId = qa.Items[0].Article_id, DiseaseName = qa.Items[0].Disease_name });
                        }
                        else
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                se.Add(new searchEnd { Id = qa.Items[i].Id, Name = qa.Items[i].Title, Color = "White", Kind = "qa", ArticleId = qa.Items[i].Article_id, DiseaseName = qa.Items[i].Disease_name });
                            }
                        }
                    }
                }




                //相关科普文章
                string article = "http://dxy.com/app/i/columns/article/related?q=" + key;
                HttpResponseMessage articleMsg = await c.GetAsync(article);
                var articleCon = await articleMsg.Content.ReadAsStringAsync();
                string articleTmp = articleCon.Substring(8, articleCon.Length - 9);
                art = JsonConvert.DeserializeObject<article>(articleTmp);
                se.Add(new searchEnd { Name = "相关科普文章", Color = "Grey", Kind = "article" });
                if (art.Items != null)
                {
                    if (art.Items.Count < 2)
                    {
                        se.Add(new searchEnd { Id = art.Items[0].Id, Name = art.Items[0].Article_title, Color = "White", Kind = "article" });
                    }
                    else
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            se.Add(new searchEnd { Id = art.Items[i].Id, Name = art.Items[i].Article_title, Color = "White", Kind = "article" });
                        }
                    }
                }



                //相关药品
                request = new HttpRequestMessage(HttpMethod.Post, new Uri(diseaseUrl));
                postData = new FormUrlEncodedContent(
                   new List<KeyValuePair<string, string>>
                    {
                       new KeyValuePair<string, string>("category", "1"),
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
                response = await c.SendAsync(request);
                responseString = await response.Content.ReadAsStringAsync();
                med = JsonConvert.DeserializeObject<medicine>(responseString);
                se.Add(new searchEnd { Name = "相关药品", Color = "Grey", Kind = "medicine" });
                if (med.Data != null)
                {
                    if (med.Data.Count < 2)
                    {
                        se.Add(new searchEnd { Id = med.Data[0].Id, Name = med.Data[0].ShowName, Color = "White", Kind = "medicine" });
                    }
                    else
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            se.Add(new searchEnd { Id = med.Data[i].Id, Name = med.Data[i].ShowName, Color = "White", Kind = "medicine" });
                        }
                    }
                }

                (Application.Current as App).BindQa = new ObservableCollection<qaSec>();
                if (qa!=null&& qa.Items != null)
                {
                    qa.Items.ForEach(z =>
                    {
                        (Application.Current as App).BindQa.Add(z);
                    });
                }


                (Application.Current as App).BindArticle = new ObservableCollection<articleSec>();
                if (art != null && art.Items != null)
                {
                    art.Items.ForEach(z =>
                    {
                        (Application.Current as App).BindArticle.Add(z);
                    });
                }

                (Application.Current as App).BindDisease = new ObservableCollection<diseaseSec>();
                if (dis!= null &&dis.Data != null)
                {
                    dis.Data.ForEach(z =>
                    {
                        (Application.Current as App).BindDisease.Add(z);
                    });
                }

                (Application.Current as App).BindMedicine = new ObservableCollection<medicineSec>();
                if (med!= null &&med.Data != null)
                {
                    med.Data.ForEach(z =>
                    {
                        (Application.Current as App).BindMedicine.Add(z);
                    });
                }


                //(Application.Current as App).BindSearchEnd = new ObservableCollection<searchEnd>();
                //se.ToList().ForEach(z =>
                //{
                //    (Application.Current as App).BindSearchEnd.Add(z);
                //});
                loading.Visibility = Visibility.Collapsed;

            }
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid g = sender as Grid;
            TextBlock tb = g.Children.First() as TextBlock;
            TextBlock tbco = g.Children[1] as TextBlock;
            //点击进入分类
            if (tb.Tag == null)
            {
                if (g.Tag.ToString() == "qa")
                {
                    NavigationService.Navigate(new Uri("/Page/SearchKind.xaml?key=" + key + "&kind=qa", UriKind.Relative));
                }
                else if (g.Tag.ToString() == "disease")
                {
                    NavigationService.Navigate(new Uri("/Page/SearchKind.xaml?key=" + key + "&kind=disease", UriKind.Relative));
                }
                else if (g.Tag.ToString() == "article")
                {
                    NavigationService.Navigate(new Uri("/Page/SearchKind.xaml?key=" + key + "&kind=article", UriKind.Relative));
                }
                else
                {
                    NavigationService.Navigate(new Uri("/Page/SearchKind.xaml?key=" + key + "&kind=medicine", UriKind.Relative));
                }
            }
            //点击进入详情
            else
            {
                string id = tb.Tag.ToString();

                if (g.Tag.ToString() == "qa")
                {
                    NavigationService.Navigate(new Uri("/Page/QuestionExpand.xaml?articleid=" + tbco.Text + "&diseasename=" + tbco.Tag.ToString(), UriKind.Relative));
                }
                else if (g.Tag.ToString() == "disease")
                {
                    NavigationService.Navigate(new Uri("/Page/KindDetail.xaml?kind=disease&id=" + id, UriKind.Relative));
                }
                else if (g.Tag.ToString() == "article")
                {
                    NavigationService.Navigate(new Uri("/Page/NewsDetail.xaml?id=" + id, UriKind.Relative));
                }
                else
                {
                    NavigationService.Navigate(new Uri("/Page/Drug.xaml?id=" + id + "&name=" + tb.Text, UriKind.Relative));
                }
            }
        }
    }
}
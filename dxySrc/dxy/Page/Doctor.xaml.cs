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
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
namespace dxy.Page
{
    public partial class Doctor : PhoneApplicationPage
    {
        private bool loaded = false;
        private string doc_id;
        private ObservableCollection<newDetailSec> bindList = new ObservableCollection<newDetailSec>();
        public ObservableCollection<newDetailSec> BindList
        {
            get { return bindList; }
            set
            {
                if (bindList != value)
                {
                    bindList = value;
                }
            }
        }
        public Doctor()
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
            if (NavigationContext.QueryString.ContainsKey("doc_id"))
            {
                doc_id = NavigationContext.QueryString["doc_id"];
            }


            base.OnNavigatedTo(e);
        }


        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (loaded)
            {
                return;
            }
            string doctorUrl = "http://dxy.com/app/i/columns/article/list?page_index=1&items_per_page=10&order=publishTime&author_id=" + doc_id;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(doctorUrl);
            string responseBody = await response.Content.ReadAsStringAsync();
            string tmp = responseBody.Substring(8, responseBody.Length - 9);
            newDetail n = JsonConvert.DeserializeObject<newDetail>(tmp);
            BitmapImage img = new BitmapImage(new Uri(n.Items.FirstOrDefault().Author_avatar, UriKind.Absolute));
            docImg.Source = img;
            docName.Text = n.Items.FirstOrDefault().Author;
            docIntroduction.Text = n.Items.FirstOrDefault().Author_remarks;
            n.Items.ForEach(a =>
            {
                bindList.Add(a);
            });
            loading.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// 进入详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            Grid g = sender as Grid;
            string id = g.Tag.ToString();
            NavigationService.Navigate(new Uri("/Page/NewsDetail.xaml?id=" + id, UriKind.Relative));
        }
    }

}
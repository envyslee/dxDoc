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
using dxy.Common;
using System.IO.IsolatedStorage;
using System.Collections.ObjectModel;
using dxy.Entity;
using System.Collections;

namespace dxy.Page
{
    public partial class Medical : PhoneApplicationPage
    {
        private IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        private string url = "http://drugs.dxy.cn/api/v2/detail";
        private HttpClient c = new HttpClient();
        private string id;


        ApplicationBarIconButton select;
        ApplicationBarIconButton delete;


        private ObservableCollection<searchEnd> bindList = new ObservableCollection<searchEnd>();

        public ObservableCollection<searchEnd> BindList
        {
            get { return bindList; }
            set {
                bindList = value;
            }
        }

        public Medical()
        {
            InitializeComponent();
            CreateEmailApplicationBarItems();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("id"))
            {
                id = NavigationContext.QueryString["id"];
            }



            base.OnNavigatedTo(e);
        }

        private  void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            BindList.Clear();
            if (settings.Contains("drugbox"))
            {
                string[] str = settings["drugbox"].ToString().Split(';');
                foreach (var item in str)
                {
                    bindList.Add(new searchEnd { Name = settings[item].ToString(), Id = item });
                }
            }
        }

        /// <summary>
        /// 点击搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void PhoneTextBox_ActionIconTapped(object sender, EventArgs e)
        {
            //string key = searchKey.Text;
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
            //FormUrlEncodedContent postData = new FormUrlEncodedContent(
            //    new List<KeyValuePair<string, string>>
            //        {
            //           new KeyValuePair<string, string>("category", "1"),
            //            new KeyValuePair<string, string>("u", ""),
            //            new KeyValuePair<string, string>("keywords", key),
            //            new KeyValuePair<string, string>("mc", "0000000005e6b1d8ffffffff9c1fe4e0"),
            //            new KeyValuePair<string, string>("hardName", DeviceFlag.GetDeviceFlag()),
            //            new KeyValuePair<string, string>("ac", "d5424fa6-adff-4b0a-8917-4264daf4a348"),
            //            new KeyValuePair<string, string>("bv", "2014"),
            //            new KeyValuePair<string, string>("vc", "3.5"),
            //            new KeyValuePair<string, string>("vs", "4.4.4"),
            //            new KeyValuePair<string, string>("vsNames", ""),
            //            new KeyValuePair<string, string>("type", "1")
            //        }
            //);
            //request.Content = postData;
            //HttpResponseMessage response = await c.SendAsync(request);
            //string responseString = await response.Content.ReadAsStringAsync();
            //dis = JsonConvert.DeserializeObject<disease>(responseString);
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid g = sender as Grid;
            string id = g.Tag.ToString();
            TextBlock tb=g.Children[0] as TextBlock;
            string name=tb.Text;
            if (!string.IsNullOrEmpty(id))
            {
                NavigationService.Navigate(new Uri("/Page/Drug.xaml?id=" + id + "&name=" + name, UriKind.Relative));
            }
        }

        private void LongListMultiSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateEmailApplicationBar();
        }

        private void UpdateEmailApplicationBar()
        {
            if (EmailList.IsSelectionEnabled)
            {
                bool hasSelection = ((EmailList.SelectedItems != null) && (EmailList.SelectedItems.Count > 0));
                delete.IsEnabled = hasSelection;
               
            }
        }

        private void CreateEmailApplicationBarItems()
        {
            select = new ApplicationBarIconButton();
            select.IconUri = new Uri("/Image/check.png", UriKind.RelativeOrAbsolute);
            select.Text = "选择";
            select.Click += OnSelectClick;

            delete = new ApplicationBarIconButton();
            delete.IconUri = new Uri("/Image/delete.png", UriKind.RelativeOrAbsolute);
            delete.Text = "删除";
            delete.Click += OnDeleteClick;

           
        }

        void OnSelectClick(object sender, EventArgs e)
        {
            EmailList.IsSelectionEnabled = true;
        }

        void OnDeleteClick(object sender, EventArgs e)
        {
            MessageHelper.Show("del");
            IList source = EmailList.ItemsSource as IList;
            while (EmailList.SelectedItems.Count > 0)
            {
                searchEnd se = (searchEnd)EmailList.SelectedItems[0];
                string[] str = settings["drugbox"].ToString().Split(';');
                var newStr = str.Where(x => x == id).ToArray();
                string endStr=newStr.s
                settings["drugbox"].ToString().Remove(id);
                settings.Remove(id);
               
                source.Remove((searchEnd)EmailList.SelectedItems[0]);
            }
        }

        private void SetupEmailApplicationBar()
        {
            ClearApplicationBar();

            if (EmailList.IsSelectionEnabled)
            {
                ApplicationBar.Buttons.Add(delete);
                UpdateEmailApplicationBar();
            }
            else
            {
                ApplicationBar.Buttons.Add(select);
            }
            ApplicationBar.IsVisible = true;
        }

        private void EmailList_IsSelectionEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetupEmailApplicationBar();
        }

        void ClearApplicationBar()
        {
            while (ApplicationBar.Buttons.Count > 0)
            {
                ApplicationBar.Buttons.RemoveAt(0);
            }

        }
    }
}
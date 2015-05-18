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
            select.IconUri = new Uri("/Image/list.png", UriKind.RelativeOrAbsolute);
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
            IList source = EmailList.ItemsSource as IList;
            while (EmailList.SelectedItems.Count > 0)
            {
                searchEnd se = (searchEnd)EmailList.SelectedItems[0];
                string seid = se.Id;
                string[] str = settings["drugbox"].ToString().Split(';');
                var newStr = str.Where(x => x != seid).ToArray();
                string endStr = string.Empty ;
                if (newStr.Count()!=0)
                {
                    newStr.ToList().ForEach(z =>
                    {
                        endStr += z + ";";
                    });
                    settings["drugbox"] = endStr.Remove(endStr.Length - 1, 1);
                }
                else
                {
                    settings.Remove("drugbox");
                }
                settings.Remove(seid);
                settings.Save();
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
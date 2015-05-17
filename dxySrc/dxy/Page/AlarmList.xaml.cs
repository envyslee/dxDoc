using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using dxy.Entity;
using System.Collections.ObjectModel;
using Microsoft.Phone.Scheduler;


namespace dxy.Page
{
    public partial class AlarmList : PhoneApplicationPage
    {


        private IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        private ObservableCollection<searchEnd> bindList = new ObservableCollection<searchEnd>();
        public ObservableCollection<searchEnd> BindList
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
        public AlarmList()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page/AlarmSet.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            LoadData();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            string id = item.Tag.ToString();
            if (ScheduledActionService.Find(id) != null)
            {
                ScheduledActionService.Remove(id);
                settings.Remove(id);
                LoadData();
            }


        }

        private void LoadData()
        {
            BindList.Clear();
            if (settings != null)
            {
                settings.ToList().ForEach(a =>
                {
                    if (a.Key.Length == 36)
                    {
                        bindList.Add(new searchEnd { Name = a.Value.ToString(), Id = a.Key.ToString() });
                    }

                });
            }
        }
    }
}
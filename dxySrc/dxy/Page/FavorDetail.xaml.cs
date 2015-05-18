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
using System.IO;

namespace dxy.Page
{
    public partial class FavorDetail : PhoneApplicationPage
    {

        private string file;

        //private IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        public FavorDetail()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            file = NavigationContext.QueryString["file"];
        }


        private string ReadFile(string fileName)
        {
            string text;
            using (IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isolatedStorageFileStream = isolatedStorageFile.OpenFile(fileName, FileMode.Open))
                {
                    using (StreamReader streamReader = new StreamReader(isolatedStorageFileStream))
                    {
                        text = streamReader.ReadToEnd();
                    }
                }
            }

            return text;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            titleTb.Text = file;
            string tmpstr = ReadFile(file);
            FavorWebBrowser.NavigateToString(tmpstr);
        }
    }
}
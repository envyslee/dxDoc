using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.IO.IsolatedStorage;

namespace dxy.Page
{
    public partial class About : PhoneApplicationPage
    {

         private IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        public About()
        {
            InitializeComponent();
        }

        private void Evaluate_OnClick(object sender, EventArgs e)
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

        private void Email_OnClick(object sender, EventArgs e)
        {
            EmailComposeTask composeTask = new EmailComposeTask();
            composeTask.To = "leebin20@sina.cn";
            composeTask.Subject = "丁香医生";
            composeTask.Show();
        }

        private void Promote_OnClick(object sender, EventArgs e)
        {
            MarketplaceSearchTask searchTask = new MarketplaceSearchTask();
            searchTask.SearchTerms = "MangoStudio";
            searchTask.Show();
        }
    }
}
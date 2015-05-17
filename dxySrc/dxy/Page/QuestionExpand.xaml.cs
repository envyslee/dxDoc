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
    public partial class QuestionExpand : PhoneApplicationPage
    {
        private string id;
        private string q;


        private ObservableCollection<questionSec> qList = new ObservableCollection<questionSec>();
        public ObservableCollection<questionSec> QList
        {
            get { return qList; }
            set { qList = value; }
        }
        public QuestionExpand()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("articleid") && NavigationContext.QueryString.ContainsKey("diseasename"))
            {
                id = NavigationContext.QueryString["articleid"];
                q = NavigationContext.QueryString["diseasename"];   
            }

            base.OnNavigatedTo(e);
        }


        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string url = "http://dxy.com/app/i/faq/qa/related/single?items_per_page=1000&article_id="+id+"&q="+q;
            HttpClient client = new HttpClient();
            var content = await client.GetAsync(url);
            var res = await content.Content.ReadAsStringAsync();
            string articleTmp = res.Substring(8, res.Length - 9);
            question tmp = JsonConvert.DeserializeObject<question>(articleTmp);
            tmp.Items.ForEach(z=>{
                qList.Add(z);
            });
        }


    }
}
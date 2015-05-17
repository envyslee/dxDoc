using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using dxy.Entity;

namespace dxy.Page
{
    public partial class SearchKind : PhoneApplicationPage
    {
        private string key;
        private string kind;


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
        public SearchKind()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("key") && NavigationContext.QueryString.ContainsKey("kind"))
            {
                key = NavigationContext.QueryString["key"];
                kind = NavigationContext.QueryString["kind"];
            }
            base.OnNavigatedTo(e);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            searchTitle.Text = key;
            switch (kind)
            {
                case "qa":
                    var tmp = (Application.Current as App).BindQa;
                    tmp.ToList().ForEach(z =>
                    {
                        se.Add(new searchEnd { Name = z.Title, Id = z.Id, Kind = "qa", ArticleId = z.Article_id, DiseaseName = z.Disease_name });
                    });
                    break;
                case "disease":
                    var dtmp = (Application.Current as App).BindDisease;
                    dtmp.ToList().ForEach(z =>
                    {
                        se.Add(new searchEnd { Name = z.ShowName, Id = z.Id, Kind = "disease" });
                    });
                    break;
                case "medicine":
                    var mtmp = (Application.Current as App).BindMedicine;
                    mtmp.ToList().ForEach(z =>
                    {
                        se.Add(new searchEnd { Name = z.ShowName, Id = z.Id, Kind = "medicine" });
                    });
                    break;
                case "article":
                    var atmp = (Application.Current as App).BindArticle;
                    atmp.ToList().ForEach(z =>
                    {
                        se.Add(new searchEnd { Name = z.Article_title, Id = z.Id, Kind = "article" });
                    });
                    break;
                default:
                    break;
            }
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid g = sender as Grid;
            string kind = g.Tag.ToString();
            TextBlock tb = g.Children[0] as TextBlock;
            string id = tb.Tag.ToString();
            switch (kind)
            {
                case "qa":
                    TextBlock tbco = g.Children[1] as TextBlock;
                    NavigationService.Navigate(new Uri("/Page/QuestionExpand.xaml?articleid=" + tbco.Text + "&diseasename=" + tbco.Tag.ToString(), UriKind.Relative));
                    break;

                case "disease":
                    NavigationService.Navigate(new Uri("/Page/KindDetail.xaml?kind=disease&id=" + id, UriKind.Relative));
                   
                    break;
                case "medicine":
                    NavigationService.Navigate(new Uri("/Page/Drug.xaml?id=" + id + "&name=" + tb.Text, UriKind.Relative));
                    break;
                case "article":
                    NavigationService.Navigate(new Uri("/Page/NewsDetail.xaml?id=" + id, UriKind.Relative));
                    break;
                default:
                    break;
            }
        }


    }
}
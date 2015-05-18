using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MicroMsg.sdk;
using dxy.Common;

namespace dxy.Page
{
    public partial class WeixinPage : WXEntryBasePage

    {
        public WeixinPage()
        {
            InitializeComponent();
        }

         void On_SendMessageToWX_Response(SendMessageToWX.Resp response)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                NavigationService.RemoveBackEntry();
            }

            //if (!string.IsNullOrEmpty(response.ErrStr))
            //{
            //    MessageHelper.Show("微信分享失败，"+response.ErrStr);
            //}

        }
    }
}
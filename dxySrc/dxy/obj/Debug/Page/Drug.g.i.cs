﻿#pragma checksum "D:\document\visual studio 2013\Projects\dxy\trunk\dxySrc\dxy\Page\Drug.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A37590C81C0DFC07BEE0B3882CB04A6D"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace dxy.Page {
    
    
    public partial class Drug : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock drugTitle;
        
        internal System.Windows.Controls.TextBlock price;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton addBar;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/dxy;component/Page/Drug.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.drugTitle = ((System.Windows.Controls.TextBlock)(this.FindName("drugTitle")));
            this.price = ((System.Windows.Controls.TextBlock)(this.FindName("price")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.addBar = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("addBar")));
        }
    }
}


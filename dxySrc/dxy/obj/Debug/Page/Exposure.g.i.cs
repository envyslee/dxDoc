﻿#pragma checksum "D:\documents\visual studio 2013\Projects\dxy\trunk\dxySrc\dxy\Page\Exposure.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "65763752FA7FA40D1833252004871AD3"
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
    
    
    public partial class Exposure : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.PhoneTextBox productName;
        
        internal Microsoft.Phone.Controls.PhoneTextBox productMedia;
        
        internal Microsoft.Phone.Controls.PhoneTextBox productIntro;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/dxy;component/Page/Exposure.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.productName = ((Microsoft.Phone.Controls.PhoneTextBox)(this.FindName("productName")));
            this.productMedia = ((Microsoft.Phone.Controls.PhoneTextBox)(this.FindName("productMedia")));
            this.productIntro = ((Microsoft.Phone.Controls.PhoneTextBox)(this.FindName("productIntro")));
        }
    }
}


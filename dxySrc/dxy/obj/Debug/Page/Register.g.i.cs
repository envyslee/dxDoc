﻿#pragma checksum "D:\document\visual studio 2013\Projects\dxy\trunk\dxySrc\dxy\Page\Register.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CF03D6141EF5E3C2EAC38EA150456B7C"
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
    
    
    public partial class Register : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox email;
        
        internal Microsoft.Phone.Controls.PhoneTextBox name;
        
        internal System.Windows.Controls.PasswordBox password;
        
        internal System.Windows.Controls.TextBlock passTb;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/dxy;component/Page/Register.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.email = ((System.Windows.Controls.TextBox)(this.FindName("email")));
            this.name = ((Microsoft.Phone.Controls.PhoneTextBox)(this.FindName("name")));
            this.password = ((System.Windows.Controls.PasswordBox)(this.FindName("password")));
            this.passTb = ((System.Windows.Controls.TextBlock)(this.FindName("passTb")));
        }
    }
}


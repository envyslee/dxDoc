﻿#pragma checksum "D:\document\visual studio 2013\Projects\dxy\trunk\dxySrc\dxy\Page\Doctor.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3D84BBDD159C237601FBB56C5B9A10D7"
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
using dxy.Control;


namespace dxy.Page {
    
    
    public partial class Doctor : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image docImg;
        
        internal System.Windows.Controls.TextBlock docName;
        
        internal System.Windows.Controls.TextBlock docIntroduction;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock morePro;
        
        internal dxy.Control.Loading loading;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/dxy;component/Page/Doctor.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.docImg = ((System.Windows.Controls.Image)(this.FindName("docImg")));
            this.docName = ((System.Windows.Controls.TextBlock)(this.FindName("docName")));
            this.docIntroduction = ((System.Windows.Controls.TextBlock)(this.FindName("docIntroduction")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.morePro = ((System.Windows.Controls.TextBlock)(this.FindName("morePro")));
            this.loading = ((dxy.Control.Loading)(this.FindName("loading")));
        }
    }
}


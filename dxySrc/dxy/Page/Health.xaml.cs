using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace dxy.Page
{
    public partial class Health : PhoneApplicationPage
    {
        public Health()
        {
            InitializeComponent();
        }

        
        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (healthPivot.SelectedIndex==0)
            {
                
            }
            else if (healthPivot.SelectedIndex == 1)
            {

            }
            else if (healthPivot.SelectedIndex == 2)
            {

            }
        }
    }
}
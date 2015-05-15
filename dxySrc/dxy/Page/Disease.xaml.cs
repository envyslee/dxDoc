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
    public partial class Disease : PhoneApplicationPage
    {
        public Disease()
        {
            InitializeComponent();
        }

        private void ListBoxItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (wholeBody.Visibility == Visibility.Collapsed)
            {
                foot.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxItem_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (skin.Visibility == Visibility.Collapsed)
            {
                foot.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxItem_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (head.Visibility == Visibility.Collapsed)
            {
                foot.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxItem_Tap_3(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (eyeear.Visibility == Visibility.Collapsed)
            {
                foot.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxItem_Tap_4(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (mouth.Visibility == Visibility.Collapsed)
            {
                foot.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxItem_Tap_5(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (threat.Visibility == Visibility.Collapsed)
            {
                foot.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxItem_Tap_6(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (chest.Visibility == Visibility.Collapsed)
            {
                foot.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxItem_Tap_7(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (hand.Visibility == Visibility.Collapsed)
            {
                foot.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxItem_Tap_8(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (waist.Visibility == Visibility.Collapsed)
            {
                foot.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxItem_Tap_9(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (stomach.Visibility == Visibility.Collapsed)
            {
                foot.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxItem_Tap_10(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (woman.Visibility == Visibility.Collapsed)
            {
                foot.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxItem_Tap_11(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (sex.Visibility == Visibility.Collapsed)
            {
                foot.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxItem_Tap_12(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (hips.Visibility == Visibility.Collapsed)
            {
                foot.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxItem_Tap_13(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (leg.Visibility == Visibility.Collapsed)
            {
                foot.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxItem_Tap_14(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (foot.Visibility == Visibility.Collapsed)
            {
                leg.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                foot.Visibility = Visibility.Visible;
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (foot.Visibility == Visibility.Visible || leg.Visibility == Visibility.Visible || hips.Visibility == Visibility.Visible || sex.Visibility == Visibility.Visible || woman.Visibility == Visibility.Visible || stomach.Visibility == Visibility.Visible || waist.Visibility == Visibility.Visible || hand.Visibility == Visibility.Visible || chest.Visibility == Visibility.Visible || threat.Visibility == Visibility.Visible || mouth.Visibility == Visibility.Visible || eyeear.Visibility == Visibility.Visible || skin.Visibility == Visibility.Visible || wholeBody.Visibility == Visibility.Visible || head.Visibility == Visibility.Visible)
            {
                foot.Visibility = Visibility.Collapsed;
                leg.Visibility = Visibility.Collapsed;
                hips.Visibility = Visibility.Collapsed;
                sex.Visibility = Visibility.Collapsed;
                woman.Visibility = Visibility.Collapsed;
                stomach.Visibility = Visibility.Collapsed;
                waist.Visibility = Visibility.Collapsed;
                hand.Visibility = Visibility.Collapsed;
                chest.Visibility = Visibility.Collapsed;
                threat.Visibility = Visibility.Collapsed;
                mouth.Visibility = Visibility.Collapsed;
                eyeear.Visibility = Visibility.Collapsed;
                skin.Visibility = Visibility.Collapsed;
                wholeBody.Visibility = Visibility.Collapsed;
                head.Visibility = Visibility.Collapsed;
                e.Cancel = true;
            }
            base.OnBackKeyPress(e);
        }


        /// <summary>
        /// 进入关键词搜索页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid g = sender as Grid;
            TextBlock tb = g.Children.First() as TextBlock;
            string txt = tb.Text;
            NavigationService.Navigate(new Uri("/Page/Search.xaml?key=" + txt, UriKind.Relative));
        }


    }
}
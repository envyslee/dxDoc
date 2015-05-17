using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Scheduler;

namespace dxy.Page
{
    public partial class AlarmSet : PhoneApplicationPage
    {
        private IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        public AlarmSet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 次数选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void number_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (number == null)
            {
                return;
            }
            switch (number.SelectedIndex)
            {
                case 0:
                    timepickerCollection.Children.Clear();
                    TimePicker t = new TimePicker();
                    t.Foreground = new SolidColorBrush(Colors.Black);
                    timepickerCollection.Children.Add(t);
                    break;
                case 1:
                    timepickerCollection.Children.Clear();
                    TimePicker one1 = new TimePicker();
                    TimePicker one2 = new TimePicker();
                    one1.Foreground = new SolidColorBrush(Colors.Black);
                    one2.Foreground = new SolidColorBrush(Colors.Black);
                    timepickerCollection.Children.Add(one1);
                    timepickerCollection.Children.Add(one2);
                    break;
                case 2:
                    timepickerCollection.Children.Clear();
                    TimePicker two1 = new TimePicker();
                    TimePicker two2 = new TimePicker();
                    TimePicker two3 = new TimePicker();
                    two1.Foreground = new SolidColorBrush(Colors.Black);
                    two2.Foreground = new SolidColorBrush(Colors.Black);
                    two3.Foreground = new SolidColorBrush(Colors.Black);
                    timepickerCollection.Children.Add(two1);
                    timepickerCollection.Children.Add(two2);
                    timepickerCollection.Children.Add(two3);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 周期选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// 取消设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        /// <summary>
        /// 完成设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            string text = string.Empty;
            string patientStr = patient.Text;
            string medicalStr = medical.Text;
            int repetIndex = repet.SelectedIndex;
            int count =timepickerCollection.Children.Count ;
           
            if (count > 1)
            {
                for (int i = 0; i < count; i++)
                {
                    string name = Guid.NewGuid().ToString();
                    Alarm a = new Alarm(name);
                    TimePicker tmptime = timepickerCollection.Children[i] as TimePicker;
                    a.BeginTime = DateTime.Parse(tmptime.Value.ToString());
                    a.Content = patientStr + "请及时服药";
               
                    switch (repetIndex)
                    {
                        case 0:
                            a.RecurrenceType = RecurrenceInterval.Daily;
                            text = patientStr + "每天" + a.BeginTime.ToShortTimeString() + "服用" + medicalStr;
                            break;
                        case 2:
                            a.RecurrenceType = RecurrenceInterval.Monthly;
                            text = patientStr + "每周" + a.BeginTime.ToShortTimeString() + "服用" + medicalStr;
                            break;
                        case 1:
                            a.RecurrenceType = RecurrenceInterval.Weekly;
                            text = patientStr + "每月" + a.BeginTime.ToShortTimeString() + "服用" + medicalStr;
                            break;
                        default:
                            break;
                    }
                    ScheduledActionService.Add(a);
                    settings.Add(name, text);
                    settings.Save();
                }
                NavigationService.GoBack();
            }
            else
            {
                string name = Guid.NewGuid().ToString();
                Alarm a = new Alarm(name);
                TimePicker tmptime = timepickerCollection.Children[0] as TimePicker;
                a.BeginTime = DateTime.Parse(tmptime.Value.ToString());
                a.Content = patientStr + "请及时服药";
                switch (repetIndex)
                {
                    case 0:
                        a.RecurrenceType = RecurrenceInterval.Daily;
                        text = patientStr + "每天" + a.BeginTime.ToShortTimeString() + "服用" + medicalStr;
                        break;
                    case 2:
                        a.RecurrenceType = RecurrenceInterval.Monthly;
                        text = patientStr + "每周" + a.BeginTime.ToShortTimeString() + "服用" + medicalStr;
                        break;
                    case 1:
                        a.RecurrenceType = RecurrenceInterval.Weekly;
                        text = patientStr + "每月" + a.BeginTime.ToShortTimeString() + "服用" + medicalStr;
                        break;
                    default:
                        break;
                }
                ScheduledActionService.Add(a);
                settings.Add(name, text);
                settings.Save();
                NavigationService.GoBack();
            }

        }
    }
}
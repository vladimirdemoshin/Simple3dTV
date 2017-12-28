using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace Semestr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        private static int countPauseClicks = 0;
        private static bool isPlayClicked = false;
       
        public MainWindow()
        {
            InitializeComponent();
            mediaElement.LoadedBehavior = MediaState.Stop;

        }

        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            slider.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalSeconds;
            DispatcherTimer dt = new DispatcherTimer();
            dt.Tick += new EventHandler(Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            dt.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            // LabelTime.Content = mediaElement.Position.TotalSeconds();
            slider.Value = mediaElement.Position.TotalSeconds;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.LoadedBehavior = MediaState.Play;
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            countPauseClicks++;
            if (countPauseClicks % 2 == 0)
            {
                mediaElement.LoadedBehavior = MediaState.Pause;
            }
            else mediaElement.LoadedBehavior = MediaState.Play;
        }

        private void Pause_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            countPauseClicks = 0;
            mediaElement.LoadedBehavior = MediaState.Stop;
            
        }

        //private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<T> e)
        //{

        //}

        private void slider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void slider_LostMouseCapture(object sender, MouseEventArgs e)
        {
            TimeSpan time = new TimeSpan(0, 0, Convert.ToInt32(Math.Round(slider.Value)));
            mediaElement.Position = time;
        }
    }
}

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

namespace TV_Shayhilislamov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Classes.TV TV = new Classes.TV();

        public MainWindow()
        {
            InitializeComponent();
            VideoPlayer.Source = new Uri(TV.Channels[TV.ActiveChannel].Src);
            VideoPlayer.Play();
        }

        private void BackChannel(object sender, RoutedEventArgs e)
        {
            TV.BlackChannel(VideoPlayer, NameChannel);
        }

        private void NextChannel(object sender, RoutedEventArgs e)
        {
            TV.NextChannel(VideoPlayer, NameChannel);
        }
        private void DownSound(object sender, RoutedEventArgs e)
        {
            TV.DownSound(VideoPlayer);
        }
        private void UpSound(object sender, RoutedEventArgs e)
        {
            TV.UpSound(VideoPlayer);
        }

        private void SearchChannel_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox channelNumber = sender as TextBox;
            if (channelNumber != null)
            {
                if (int.TryParse(channelNumber.Text, out int channel))
                {
                    if (channel >= 0)
                    {
                        if (channel <= TV.Channels.Count - 1)
                        {
                            TV.SetChannel(VideoPlayer, NameChannel, channel);
                        }
                    }
                }
            }
        }
    }
}

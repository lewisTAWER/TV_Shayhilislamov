using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TV_Shayhilislamov.Classes
{
    public class TV
    {
        private int activeChannel;
        private double activeVolume = 1.0;

        public int ActiveChannel
        {
            get
            {
                return activeChannel;
            }
            set
            {
                if (activeChannel < Channels.Count - 1)
                    activeChannel = value;
                else
                    activeChannel = 0;
                if (activeChannel < 0)
                    activeChannel = Channels.Count - 1;
            }
        }

        public double ActiveVolume
        {
            get
            {
                return activeVolume;
            }
            set
            {
                if (value >= 0.0)
                {
                    if (value <= 1.0)
                    {
                        activeVolume = value;
                    }
                }
            }
        }
        public List<Channel> Channels = new List<Channel>();

        public TV()
        {
            Channels.Add(new Channel()
            {
                Name = "Практическая работа №3 Объявление классов и создание объектов в С#.mp4",
                Src = @"F:\5 семестр\МДК_05.02\5 ПР\TV_Shayhilislamov\Видео\1.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Практическая работа №4 Использование методов в ООП Разница между простыми и статическими методами.mp4",
                Src = @"F:\5 семестр\МДК_05.02\5 ПР\TV_Shayhilislamov\Видео\2.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Практическая работа №5 Конструкторы в ООП.mp4",
                Src = @"F:\5 семестр\МДК_05.02\5 ПР\TV_Shayhilislamov\Видео\3.mp4"
            });
        }
        public void SwapChanell(MediaElement _MediaElement, Label _NameChannel)
        {
            DoubleAnimation StartAnimtion = new DoubleAnimation();
            StartAnimtion.From = 1;
            StartAnimtion.To = 0;
            StartAnimtion.Duration = TimeSpan.FromSeconds(0.6);
            StartAnimtion.Completed += delegate
            {
                _MediaElement.Source = new Uri(this.Channels[this.ActiveChannel].Src);
                _MediaElement.Play();
                DoubleAnimation EndAnimation = new DoubleAnimation();
                EndAnimation.From = 0;
                EndAnimation.To = 1;
                EndAnimation.Duration = TimeSpan.FromSeconds(0.6);

                _MediaElement.BeginAnimation(MediaElement.OpacityProperty, EndAnimation);
            };
            _MediaElement.BeginAnimation(MediaElement.OpacityProperty, StartAnimtion);
            _NameChannel.Content = this.Channels[this.ActiveChannel].Name;
            _MediaElement.Volume = activeVolume;

        }
        public void NextChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            ActiveChannel++;
            SwapChanell(_MediaElement, _NameChannel);
        }
        public void BlackChannel(MediaElement _MediaElement, Label _NameChannel)
        {
            ActiveChannel--;
            SwapChanell(_MediaElement, _NameChannel);
        }

        public void UpSound(MediaElement _MediaElement)
        {
            ActiveVolume += 0.1;
            _MediaElement.Volume = ActiveVolume;
        }

        public void DownSound(MediaElement _MediaElement)
        {
            ActiveVolume -= 0.1;
            _MediaElement.Volume = ActiveVolume;
        }

        public void SetChannel(MediaElement _MediaElement, Label _NameChannel, int Channel)
        {
            ActiveChannel = Channel;
            SwapChanell(_MediaElement, _NameChannel);
        }
    }
}

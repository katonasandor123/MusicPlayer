using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MediaPlayer MediaPlayer = new MediaPlayer();
        List<string> zene = new List<string>();
        StreamWriter sw;
        public void Lejatszo()
        {
            InitializeComponent();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|WAV files (*.wav)|*.wav|MPEG-4 files (*.m4a)|*.m4a|FLAC files (*.flac)|*.flac|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                MediaPlayer.Open(new Uri(openFileDialog.FileName));
                ListBoxItem item = new ListBoxItem();
                var name = openFileDialog.FileName;
                var safeName = openFileDialog.SafeFileName;

                zene.Add(Convert.ToString(name));

                listBox.Items.Add(safeName);
            }
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.5);
            timer.Tick += sliderTimeline_Tick;
            timer.Start();
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void gombStart_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItems.Count != 0)
            {
                MediaPlayer.Open(new Uri(zene[listBox.SelectedIndex]));
            }
            MediaPlayer.Play();
        }

        private void gombPause_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Pause();
        }

        private void gombStop_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Stop();
        }

        private void gombBack_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItems.Count != 0)
            {
                MediaPlayer.Open(new Uri(zene[listBox.SelectedIndex - 1]));
                timelineSlide.Minimum = 0;
                timelineSlide.Maximum = Convert.ToDouble(MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds);
                timelineSlide.Value = Convert.ToDouble(MediaPlayer.Position.TotalSeconds);
            }
            else
            {
                MediaPlayer.Stop();
                MediaPlayer.Play();
            }
            MediaPlayer.Play();
        }

        private void gombNext_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItems.Count != 0)
            {
                if (listBox.SelectedIndex == listBox.Items.Count)
                {
                    MediaPlayer.Open(new Uri(zene[0]));
                    timelineSlide.Minimum = 0;
                    timelineSlide.Maximum = Convert.ToDouble(MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds);
                    timelineSlide.Value = Convert.ToDouble(MediaPlayer.Position.TotalSeconds);
                }
                else
                {
                    MediaPlayer.Open(new Uri(zene[listBox.SelectedIndex + 1]));
                }
            }
            MediaPlayer.Play();
        }

        private void gombBetoltes_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "playlist (*.pls)|*.pls|playlist (*.m3u)|*.m3u|playlist (*.xspf)|*.xspf";
            ofd.ShowDialog();
            StreamReader sr = new StreamReader(ofd.FileName);
            zene.Clear();
            listBox.Items.Clear();
            while (!sr.EndOfStream)
            {
                var sounds = sr.ReadLine().Split(';');
                zene.Add(sounds[0]);
                listBox.Items.Add(sounds[1]);
            }
            sr.Close();
        }

        private void gombMentes_Click(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.CreatePrompt = false;
            sfd.OverwritePrompt = true;
            sfd.Filter = "playlist (*.pls)|*.pls|playlist (*.m3u)|*.m3u|playlist (*.xspf)|*.xspf";
            sfd.ShowDialog();
            sw = new StreamWriter(sfd.FileName);
            for (int i = 0; i < zene.Count; i++)
            {
                sw.WriteLine($"{zene[i]};{listBox.Items[i]}");

            }
            sw.Close();
        }

        private void gombHozzaadas_Click(object sender, RoutedEventArgs e)
        {
            Lejatszo();
        }

        private void gombEltavolitas_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItems.Count != 0)
            {
                while (listBox.SelectedIndex != -1)
                {
                    listBox.Items.RemoveAt(listBox.SelectedIndex);
                }
            }
        }

        void sliderTimeline_Tick(object sender, EventArgs e)
        {
            if ((MediaPlayer.Source != null) && (MediaPlayer.NaturalDuration.HasTimeSpan))
            {
                timelineSlide.Minimum = 0;
                timelineSlide.Maximum = Convert.ToDouble(MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds);
                timelineSlide.Value = Convert.ToDouble(MediaPlayer.Position.TotalSeconds);
                if (MediaPlayer.Position.TotalSeconds == MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds)
                {
                    MediaPlayer.Position = TimeSpan.FromSeconds(0);
                }
            }
        }

        private void sliderTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            timeLabel.Content = TimeSpan.FromSeconds(timelineSlide.Value).ToString(@"hh\:mm\:ss");
            MediaPlayer.Position = TimeSpan.FromSeconds(timelineSlide.Value);
        }

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer.Volume = volumeSlide.Value;
        }  
    }
}
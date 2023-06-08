using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.WebRequestMethods;

namespace lab_pkt2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Data> datas = new ObservableCollection<Data>();
        public string? fileName;

        private bool userIsDraggingSlider = false;
        private bool isVideoPlaying = false;
        private TimeSpan maxTime;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_Tick;
            timer.Start();

            DataContext = datas;

            DataGrid.Items.SortDescriptions.Add(new SortDescription(DataGrid.Columns[0].SortMemberPath, ListSortDirection.Ascending));
        }

        // https://wpf-tutorial.com/audio-video/how-to-creating-a-complete-audio-video-player/
        private void timer_Tick(object sender, EventArgs e)
        {
            if ((MediaPlayer.Source != null) && (MediaPlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                TotalTimeLabel.Content = MediaPlayer.NaturalDuration.TimeSpan.ToString("hh\\:mm\\:ss\\.fff");

                videoSlider.Minimum = 0;
                videoSlider.Maximum = MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                videoSlider.Value = MediaPlayer.Position.TotalSeconds;
                maxTime = MediaPlayer.NaturalDuration.TimeSpan;

                var currentTime = MediaPlayer.Position;
                List<Data> currentSubTitles = new List<Data>();

                //if(Translation.IsChecked == false)
                //{
                //    currentSubTitles = datas.Where(sub => (sub.ShowTime <= currentTime && currentTime <= sub.HideTime)).Select(sub => sub.Text).ToList();
                //}
                //else
                //{
                //    currentSubTitles = datas.Where(sub => (sub.ShowTime <= currentTime && currentTime <= sub.HideTime)).Select(sub => sub.Translation).ToList();
                //}

                //if(currentSubTitles.Count == 0)
                //{
                //    SubTitleTextBox.Visibility = Visibility.Collapsed;
                //}
                //else
                //{
                //    SubTitleTextBox.Visibility = Visibility.Visible;
                //}

                //string s = String.Join('\n', currentSubTitles);
                
                //SubTitleTextBox.Text = s;

                currentSubTitles = datas.Where(sub => (sub.ShowTime <= currentTime && currentTime <= sub.HideTime)).ToList();

                string text = "";

                for (int i = 0; i < currentSubTitles.Count; i++)
                {
                    if (Translation.IsChecked == false)
                    {
                        if (i == currentSubTitles.Count - 1)
                        {
                            text += currentSubTitles[i].Text;
                            break;
                        }
                        text += currentSubTitles[i].Text + '\n';
                    }
                    else
                    {
                        if (i == currentSubTitles.Count - 1)
                        {
                            text += currentSubTitles[i].Translation;
                            break;
                        }
                        text += currentSubTitles[i].Translation + '\n';
                    }
                }
                SubTitleTextBox.Visibility = Visibility.Visible;
                SubTitleTextBox.Text = text;

                if (currentSubTitles.Count == 0)
                {
                    SubTitleTextBox.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void videoSlider_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void videoSlider_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            MediaPlayer.Position = TimeSpan.FromSeconds(videoSlider.Value);
        }

        private void Exit_MenuItemClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void About_MenuItemClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Subtitle Composer", "Subtitle Composer", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Translation_MenuItemClick(object sender, RoutedEventArgs e)
        {
            if (Translation.IsChecked == true)
            {
                DataGrid.Columns[3].Visibility = Visibility.Visible;
                TranslationGroupBox.Visibility = Visibility.Visible;
                TranslationGroupBox.Width = 500;
            }
            else
            {
                DataGrid.Columns[3].Visibility = Visibility.Collapsed;
                TranslationGroupBox.Visibility = Visibility.Collapsed;
            }
        }

        private void Open_MenuItemClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP4 Files (*.mp4)|*.mp4;*.MOV";
            if (openFileDialog.ShowDialog() == true)
            {
                fileName = openFileDialog.FileName;
                MediaPlayer.Source = new Uri(fileName);
                MediaPlayer.Play();
                isVideoPlaying = true;
                MediaPlayer.Volume = 0.5;
            }

        }

        private void Play_ButtonClik(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Play();
            isVideoPlaying = true;
            timer.Start();
        }

        private void Pause_ButtonClik(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Pause();
            isVideoPlaying = false;
            timer.Stop();
        }

        private void Stop_ButtonClik(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Stop();
            isVideoPlaying = false;
            videoSlider.Value = MediaPlayer.Position.TotalSeconds;
            timer.Stop();
        }

        private void videoSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CurrentTimeLabel.Content = TimeSpan.FromSeconds(videoSlider.Value).ToString("hh\\:mm\\:ss\\.fff");
        }

        private void MediaElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isVideoPlaying)
            {
                MediaPlayer.Pause();
                isVideoPlaying = false;
                timer.Stop();
            }
            else
            {
                MediaPlayer.Play();
                isVideoPlaying = true;
                timer.Start();
            }
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (MediaPlayer.Volume <= 0.1 && e.Delta <= 0)
            {
                MediaPlayer.Volume = 0;
            }
            if (MediaPlayer.Volume >= 0.9 && e.Delta >= 0)
            {
                MediaPlayer.Volume = 1;
            }

            MediaPlayer.Volume += (e.Delta > 0) ? 0.1 : -0.1;
        }


        //https://www.codeproject.com/Questions/5301041/Get-from-WPF-datagrid-the-row-column-and-value-on
        private void DataDrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            DataGrid grid = sender as DataGrid;
            if (grid.SelectedItem != null)
            {
                Data rowview = grid.SelectedItem as Data;
                if (rowview != null)
                    MediaPlayer.Position = rowview.ShowTime;
            }
        }

        private void Add_DataGridMenuClick(object sender, RoutedEventArgs e)
        {
            TimeSpan currentMax =  datas.Max(x => x.HideTime);
            Data d = new Data();
            d.ShowTime = currentMax;
            d.HideTime = currentMax;
            datas.Add(d);
            //datas.Add(new Data(currentMax, currentMax, "", ""));
        }

        private void Delete_DataGridClick(object sender, RoutedEventArgs e)
        {
           var rowsToDelete = DataGrid.SelectedItems;
           while(rowsToDelete.Count > 0)
           {
                if(rowsToDelete[0].GetType() != typeof(Data))
                {
                    rowsToDelete.RemoveAt(0);
                    if(rowsToDelete.Count == 0)
                        break;
                }

                if (rowsToDelete[0].GetType() == typeof(Data))
                {
                    datas.Remove((Data)rowsToDelete[0]);
                }
            }
        }

        private void Add_After_DataGridMenuClick(object sender, RoutedEventArgs e)
        {
            var rowsToDelete = DataGrid.SelectedItems;
            TimeSpan maxHideTime = new TimeSpan(0);

            foreach (var row in rowsToDelete)
            {
                if(row.GetType() != typeof(Data))
                {
                    continue;
                }    
                Data r = (Data)row;
                if(maxHideTime < r.HideTime)
                {
                    maxHideTime = r.HideTime;
                }
            }
            Data d = new Data();
            d.ShowTime = maxHideTime;
            d.HideTime = maxHideTime;
            datas.Add(d);
            //datas.Add(new Data(maxHideTime, maxHideTime, "", ""));
        }

        private void DataGrid_InitializeNewItem(object sender, InitializingNewItemEventArgs e)
        {
            Data d = e.NewItem as Data;
            if (d != null)
            {
                if(datas.Count > 0)
                {
                    d.HideTime = datas.Max(x => x.HideTime);
                }
            }
        }
    }


    public class Data
    {
        public TimeSpan ShowTime { get; set; }
        public TimeSpan HideTime { get; set; }
        public string? Text {get; set; }
        public string? Translation { get; set; }

        //public Data() { }
        //public Data(TimeSpan showTime, TimeSpan hideTime, string? text, string? translation)
        //{
        //    ShowTime = showTime;
        //    HideTime = hideTime;
        //    Text = text;
        //    Translation = translation;
        //}
    }

    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                return null;
            }

            bool b = (bool)value;

            if(b == false)
            {
                return Visibility.Hidden;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}


using System;
using System.ComponentModel;
using System.Windows.Controls;
using MusicPlayer.Controller;

namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for LoadingPage.xaml
    /// </summary>
    public partial class LoadingPage : Page
    {
        public LoadingPage()
        {
            InitializeComponent();
            SetupBackgroundWorker();
        }

        private void SetupBackgroundWorker()
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(WorkerBuildMusicCollection);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                NavigateToAlbumPage);
            backgroundWorker.RunWorkerAsync();
        }

        private void NavigateToAlbumPage(object sender, RunWorkerCompletedEventArgs e)
        {
            var loadingPageUri = new Uri("UI/MainMenuPage.xaml", UriKind.Relative);
            NavigationService.Navigate(loadingPageUri);
        }

        private void WorkerBuildMusicCollection(object sender, DoWorkEventArgs e)
            => MusicLoader.BuildMusicCollection();
    }
}
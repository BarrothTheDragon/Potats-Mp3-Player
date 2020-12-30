using MusicPlayer.RepositoryControl;
using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for TitlePage.xaml
    /// </summary>
    public partial class TitlePage : Page
    {
        private readonly DispatcherTimer pageTimer = new DispatcherTimer();

        public TitlePage()
        {
            InitializeComponent();
            StartTimer();
        }

        private void StartTimer()
        {
            pageTimer.Interval = TimeSpan.FromSeconds(3);
            pageTimer.Tick += new EventHandler(NavigateToAppropriatePage);
            pageTimer.Start();
        }

        private void NavigateToAppropriatePage(object sender, EventArgs e)
        {
            pageTimer.Stop();

            var sourceFileRepository = RepositoryController.GetSourceFileRepository;

            Uri nextPageUri = sourceFileRepository.IsSourceDirectoryEmpty()
                ? new Uri("UI/SelectMusicSourcePage.xaml", UriKind.Relative) : new Uri("UI/LoadingPage.xaml", UriKind.Relative);
            NavigationService.Navigate(nextPageUri);
        }
    }
}
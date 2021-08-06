using MusicPlayer.RepositoryControl;
using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using MusicPlayer.MusicPlayerElements;

namespace MusicPlayer.UI
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        readonly MusicCollectionRepository musicCollectionRepository = RepositoryController.GetMusicCollectionRepository;

        public MainMenuPage()
        {
            InitializeComponent();
            m_albumCollectionItemsControl.ItemsSource = musicCollectionRepository.AlbumCollection;
        }

        private void OnClickNavigateToAlbumPage(object sender, EventArgs e)
        {
            if (sender != null && sender is Button)
            {
                var albumTitle = ((Button)sender).DataContext;
                NavigationService.Navigate(new AlbumPage((Album)albumTitle));
            }
        }
    }
}
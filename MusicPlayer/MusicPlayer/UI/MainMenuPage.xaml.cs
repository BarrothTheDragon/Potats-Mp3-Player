using MusicPlayer.RepositoryControl;
using System.Windows.Controls;

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
    }
}
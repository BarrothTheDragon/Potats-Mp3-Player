using MusicPlayer.RepositoryControl;
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
using MusicPlayer.RepositoryControl;
using System.IO;

namespace MusicPlayer.UI
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        readonly MusicCollectionRepository musicCollectionRepository = RepositoryController.GetMusicCollectionRepository;
        private static BitmapImage DefaultAlbumCoverW = GetDefaultAlbumCover();
        public BitmapImage DefaultAlbumCover { get { return DefaultAlbumCoverW; } }

        public MainMenuPage()
        {
            InitializeComponent();
            m_albumCollectionItemsControl.ItemsSource = musicCollectionRepository.AlbumCollection;
        }

        private static BitmapImage GetDefaultAlbumCover()
        {
            var pathToDefaultImage = System.IO.Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, "Assets\\WelcomePotat.png");
            var cover = new BitmapImage(new System.Uri(pathToDefaultImage));
            cover.Freeze();
            return cover;
        }
    }
}

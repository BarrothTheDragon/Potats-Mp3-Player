using System.Windows.Controls;
using MusicPlayer.RepositoryControl;

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
            RepositoryController.GetMusicCollectionRepository.BuildMusicCollection();
        }
    }
}
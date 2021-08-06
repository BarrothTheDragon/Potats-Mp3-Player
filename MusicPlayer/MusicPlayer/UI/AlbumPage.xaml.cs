using MusicPlayer.MusicPlayerElements;
using System.Windows.Controls;

namespace MusicPlayer.UI
{
    /// <summary>
    /// Interaction logic for AlbumPage.xaml
    /// </summary>
    public partial class AlbumPage : Page
    {
        public AlbumPage(Album album)
        {
            InitializeComponent();
            m_albumInformation.DataContext = album;
        }
    }
}

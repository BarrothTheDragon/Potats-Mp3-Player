using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace MusicPlayer.MusicPlayerElements
{
    public class Album
    {
        public List<MusicFile> SongList { get; set; }
        public string Title { get; set; }
        public string[] Artists { get; set; }
        public string[] Genre { get; set; }

        //TODO get cover art
        public byte[] CoverArt { get; set; }
        public BitmapImage Cover { get; set; }

        public Album(MusicFile musicFile, TagLib.File tagFile)
        {
            Title = musicFile.AlbumTitle;
            Artists = musicFile.AlbumArtist;
            Genre = musicFile.Genre;

            if (tagFile.Tag.Pictures.Length >= 1)
            {
                CoverArt = (byte[])(tagFile.Tag.Pictures[0].Data.Data);
                Cover = LoadImage(CoverArt);
                //PreviewPictureBox.Image = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(100, 100, null, IntPtr.Zero);
            }

            SongList = new List<MusicFile>();
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}

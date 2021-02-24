using System.Collections.Generic;

namespace MusicPlayer.MusicPlayerElements
{
    public class Album
    {
        public List<MusicFile> SongList { get; set; }
        public string Title { get; set; }
        public string[] Artists { get; set; }
        public string[] Genre { get; set; }

        //TODO get cover art
        //public something CoverArt { get; set; }

        public Album(MusicFile musicFile)
        {
            Title = musicFile.AlbumTitle;
            Artists = musicFile.AlbumArtist;
            Genre = musicFile.Genre;
            SongList = new List<MusicFile>();
        }
    }
}

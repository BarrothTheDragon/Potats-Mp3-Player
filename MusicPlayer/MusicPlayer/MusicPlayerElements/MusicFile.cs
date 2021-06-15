using System;

namespace MusicPlayer.MusicPlayerElements
{
    public class MusicFile
    {
        public string Path { get; set; }
        public string AlbumTitle { get; set; }
        public string[] AlbumArtist { get; set; }
        public string SongTitle { get; set; }
        public string[] SongArtist { get; set; }
        public string[] Genre { get; set; }
        public int Year { get; set; }
        public int Disk { get; set; }
        public int Track { get; set; }
        public TimeSpan Duration { get; set; }

        public MusicFile(string path)
            => Path = path;

        public MusicFile(TagLib.File musicFile)
        {
            Path = musicFile.Name;
            AlbumTitle = DefaultAlbumResources.GetValidAlbumTitle(musicFile.Tag.Album);
            AlbumArtist = DefaultAlbumResources.GetValidAlbumArtists(musicFile.Tag.AlbumArtists, musicFile.Tag.Performers);
            SongTitle = musicFile.Tag.Title ?? System.IO.Path.GetFileNameWithoutExtension(musicFile.Name);
            SongArtist = DefaultAlbumResources.GetValidArtists(musicFile.Tag.Performers);
            Genre = DefaultAlbumResources.GetValidGenre(musicFile.Tag.Genres);
            Year = (int)musicFile.Tag.Year;
            Disk = (int)musicFile.Tag.Disc;
            Track = (int)musicFile.Tag.Track;
            Duration = musicFile.Properties.Duration;
        }
    }
}

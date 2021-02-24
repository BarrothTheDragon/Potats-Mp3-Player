using System;

namespace MusicPlayer.MusicPlayerElements
{
    public class MusicFile
    {
        private const string DefaultAlbumTitle = "Potat's Album";
        private readonly string[] DefaultArtist = new string[] { "Potat" };
        private readonly string[] DefaultGenre = new string[] { "Potat's Music" };

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
        {
            Path = path;
        }

        public MusicFile(TagLib.File musicFile)
        {
            Path = musicFile.Name;
            AlbumTitle = GetValidAlbumTitle(musicFile.Tag.Album);
            AlbumArtist = GetValidAlbumArtists(musicFile.Tag.AlbumArtists, musicFile.Tag.Performers);
            SongTitle = musicFile.Tag.Title ?? System.IO.Path.GetFileNameWithoutExtension(musicFile.Name);
            SongArtist = GetValidArtists(musicFile.Tag.Performers);
            Genre = GetValidGenre(musicFile.Tag.Genres);
            Year = (int)musicFile.Tag.Year;
            Disk = (int)musicFile.Tag.Disc;
            Track = (int)musicFile.Tag.Track;
            Duration = musicFile.Properties.Duration;
        }

        private string GetValidAlbumTitle(string currentAlbumTitle)
            => (currentAlbumTitle == null || currentAlbumTitle == "Unknown Album") ? DefaultAlbumTitle : currentAlbumTitle;

        private string[] GetValidAlbumArtists(string[] albumArtists, string[] songArtist)
        {
            if (GetValidArtists(albumArtists) != DefaultArtist)
            {
                return albumArtists;
            }
            else if (GetValidArtists(songArtist) != DefaultArtist)
            {
                return songArtist;
            }

            return DefaultArtist;
        }


        private string[] GetValidArtists(string[] currentArtists)
        {
            if (currentArtists == null || currentArtists.Length == 0 || currentArtists[0] == "Unknown Artist")
            {
                return DefaultArtist;
            }

            return currentArtists;
        }

        private string[] GetValidGenre(string[] currentGenre)
        {
            if (currentGenre == null || currentGenre.Length == 0 || currentGenre[0] == "Unknown Genre")
            {
                return DefaultGenre;
            }

            return currentGenre;
        }
    }
}


namespace MusicPlayer.MusicPlayerElements
{
    class DefaultAlbumResources
    {
        private static readonly string DefaultAlbumTitle = "Potat's Album";
        private static readonly string[] DefaultArtist = new string[] { "Potat" };
        private static readonly string[] DefaultGenre = new string[] { "Potat's Music" };

        internal static string GetValidAlbumTitle(string currentAlbumTitle)
            => (currentAlbumTitle == null || currentAlbumTitle == "Unknown Album") ? DefaultAlbumTitle : currentAlbumTitle;

        internal static string[] GetValidAlbumArtists(string[] albumArtists, string[] songArtist)
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


        internal static string[] GetValidArtists(string[] currentArtists)
        {
            if (currentArtists == null || currentArtists.Length == 0 || currentArtists[0] == "Unknown Artist")
            {
                return DefaultArtist;
            }

            return currentArtists;
        }

        internal static string[] GetValidGenre(string[] currentGenre)
        {
            if (currentGenre == null || currentGenre.Length == 0 || currentGenre[0] == "Unknown Genre")
            {
                return DefaultGenre;
            }

            return currentGenre;
        }
    }
}

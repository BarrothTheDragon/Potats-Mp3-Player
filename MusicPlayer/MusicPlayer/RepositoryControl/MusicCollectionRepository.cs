using MusicPlayer.MusicPlayerElements;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlayer.RepositoryControl
{
    public class MusicCollectionRepository : IRepositoryController
    {
        public static HashSet<Album> AlbumCollection { get; private set; }

        public MusicCollectionRepository()
        {
            AlbumCollection = new HashSet<Album>();
        }

        public void CreateNewRepository()
            => AlbumCollection = new HashSet<Album>();

        public void AddEntry(string entry)
        {
            var musicFile = ConvertToMusicFile(entry);
            var album = GetAlbumByTitle(musicFile.AlbumTitle) ?? InitializeNewAlbum(musicFile);
            album.SongList.Add(musicFile);
        }

        public Album GetAlbumByTitle(string title)
            => AlbumCollection.Where(albumEntry => albumEntry.Title == title).FirstOrDefault();

        public void RemoveEntry(string entry)
        {
            var musicFile = ConvertToMusicFile(entry);
            var album = GetAlbumByTitle(musicFile.AlbumTitle);
            if(album != null)
            {
                album.SongList.Remove(musicFile);
            }
        }

        public void RemoveAllEntries()
            => AlbumCollection = new HashSet<Album>();

        private MusicFile ConvertToMusicFile(string musicPath)
        {
            var musicTag = TagLib.File.Create(musicPath);
            return new MusicFile(musicTag);
        }

        private Album InitializeNewAlbum(MusicFile file)
        {
            var album = new Album(file);
            AlbumCollection.Add(album);
            return album;
        }
    }
}

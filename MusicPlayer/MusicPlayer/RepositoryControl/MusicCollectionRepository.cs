using MusicPlayer.MusicPlayerElements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlayer.RepositoryControl
{
    public class MusicCollectionRepository
    {
        public static HashSet<Album> AlbumCollection { get; private set; }

        public MusicCollectionRepository()
        {
            AlbumCollection = new HashSet<Album>();
        }

        public void DeleteAlbumCollection()
            => AlbumCollection = new HashSet<Album>();

        public Album GetAlbumByTitle(string title)
            => AlbumCollection.Where(albumEntry => albumEntry.Title == title).FirstOrDefault();

        public void BuildMusicCollection()
        {
            var musicPaths = new MusicFileExtractor().GetAllMusicFiles();
            var musicFiles = ConvertToMusicFileList(musicPaths);
            CreateAlbumCollection(musicFiles);
        }

        private void CreateAlbumCollection(List<MusicFile> musicFiles)
        {
            foreach (MusicFile musicFile in musicFiles)
            {
                var album = GetAlbumByTitle(musicFile.AlbumTitle) ?? InitializeNewAlbum(musicFile);
                album.SongList.Add(musicFile);
            }
        }

        private Album InitializeNewAlbum(MusicFile file)
        {
            var album = new Album(file);
            AlbumCollection.Add(album);
            return album;
        }

        private List<MusicFile> ConvertToMusicFileList(List<string> musicPaths)
        {
            var musicFiles = new List<MusicFile>();
            musicPaths.ForEach(entry => musicFiles.Add(ConvertToMusicFile(entry)));
            return musicFiles;
        }

        private MusicFile ConvertToMusicFile(string musicPath)
        {
            var musicTag = TagLib.File.Create(musicPath);
            return new MusicFile(musicTag);
        }
    }
}

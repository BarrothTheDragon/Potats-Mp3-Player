using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.MusicPlayerElements;

namespace MusicPlayer.RepositoryControl
{
    public static class MusicCollectionRepository
    {
        public static HashSet<Album> AlbumCollection { get; set; }

        /*private string ExtractSongMetadata(string songDirectory)
        {
            return string.Empty;

            var a = new FileInfo("C:\\Users\\Pegasus\\Desktop\\Test Music\\Disc 1\\1.01 Phoenix Wright- Ace Attorney - Prologue.mp3");
            var file1 = TagLib.File.Create("C:\\Users\\Pegasus\\Desktop\\Test Music\\Disc 1\\1.01 Phoenix Wright- Ace Attorney - Prologue.mp3");
            var t1 = file1.Tag.Copyright;
            var t2 = file1.Tag.Album;
            var t3 = file1.Tag.AlbumArtists;
            var t4 = file1.Tag.Title;
            var t5 = file1.Tag.Comment;
            var t6 = file1.Tag.Composers;
            var t7 = file1.Tag.Conductor;
            var t8 = file1.Tag.Grouping;
            //var t9 = file.Tag.Artists;
        }*/
    }
}

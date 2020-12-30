using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.MusicPlayerElements
{
    public class MusicFile
    {
        public string Title { get; set; }
        public string AlbumTitle { get; set; }
        public string AlbumArtist { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Disk { get; set; }
        public int Track { get; set; }
        public string Folder { get; set; }

        public MusicFile(string title, string folder)
        {
            Title = title;
            Folder = folder;
            AlbumTitle = "Potat's Album";
            AlbumArtist = "Potat";
            Genre = "Potat's Music";
            Year = 2020;
            Disk = 0;
            Track = 0;
        }
    }
}

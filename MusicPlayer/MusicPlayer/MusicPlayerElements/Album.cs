using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MusicPlayer.MusicPlayerElements
{
    public class Album
    {
        public List<MusicFile> SongList { get; set; }
        public string Title { get; set; }
        public string[] Artists { get; set; }
        public string[] Genre { get; set; }
        public byte[] Cover { get; set; }

        public Album(MusicFile musicFile, TagLib.File tagFile)
        {
            Title = musicFile.AlbumTitle;
            Artists = musicFile.AlbumArtist;
            Genre = musicFile.Genre;
            SongList = new List<MusicFile>();
            Cover = (tagFile.Tag.Pictures.Length >= 1) ? CreateThumbnail(tagFile.Tag.Pictures[0].Data.Data, 200) : null;
        }

        //credits to Gary Frank
        //https://social.msdn.microsoft.com/Forums/vstudio/en-US/e2d8bd99-1af4-404a-a6bd-5fae9f540c2d/how-to-resize-an-image-in-byte-?forum=csharpgeneral
        public static byte[] CreateThumbnail(byte[] PassedImage, int LargestSide)
        {
            byte[] ReturnedThumbnail;

            using (MemoryStream StartMemoryStream = new MemoryStream(),
                                NewMemoryStream = new MemoryStream())
            {
                // write the string to the stream  
                StartMemoryStream.Write(PassedImage, 0, PassedImage.Length);

                // create the start Bitmap from the MemoryStream that contains the image  
                var startBitmap = new Bitmap(StartMemoryStream);

                // set thumbnail height and width proportional to the original image.  
                int newHeight;
                int newWidth;
                double HW_ratio;
                if (startBitmap.Height > startBitmap.Width)
                {
                    newHeight = LargestSide;
                    HW_ratio = (double)((double)LargestSide / (double)startBitmap.Height);
                    newWidth = (int)(HW_ratio * (double)startBitmap.Width);
                }
                else
                {
                    newWidth = LargestSide;
                    HW_ratio = (double)((double)LargestSide / (double)startBitmap.Width);
                    newHeight = (int)(HW_ratio * (double)startBitmap.Height);
                }

                // create a new Bitmap with dimensions for the thumbnail.  
                var newBitmap = new Bitmap(newWidth, newHeight);

                // Copy the image from the START Bitmap into the NEW Bitmap.  
                // This will create a thumnail size of the same image.  
                newBitmap = ResizeImage(startBitmap, newWidth, newHeight);

                // Save this image to the specified stream in the specified format.  
                newBitmap.Save(NewMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);

                // Fill the byte[] for the thumbnail from the new MemoryStream.  
                ReturnedThumbnail = NewMemoryStream.ToArray();
            }

            // return the resized image as a string of bytes.  
            return ReturnedThumbnail;
        }

        // Resize a Bitmap  
        private static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            var resizedImage = new Bitmap(width, height);
            using (var gfx = Graphics.FromImage(resizedImage))
            {
                gfx.DrawImage(image, new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            return resizedImage;
        }
    }
}

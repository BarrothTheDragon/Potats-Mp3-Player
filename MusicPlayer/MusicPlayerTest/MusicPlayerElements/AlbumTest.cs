using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPlayer.MusicPlayerElements;

namespace MusicPlayerTest.MusicPlayerElements
{
    [TestClass]
    public class AlbumTest
    {
        private const string ValidMp3FilePath = @"RepositoryControl/Kecap Tuyul - a simple dream.mp3";
        private const string InvalidMp3FilePath = @"RepositoryControl/Kecap Tuyul - the light always comes too late.mp3";

        [TestMethod]
        [DeploymentItem(@ValidMp3FilePath, "RepositoryControl")]
        public void WithAlbum_GivenValidMp3File_WhenCreatingAlbumObject_ThenAllParametersAreFilledAccordingly()
        {
            //Arrange
            var tagFile = TagLib.File.Create(ValidMp3FilePath);

            //Act
            var album = new Album(tagFile);

            //Assert
            album.Title.Should().Be("My other shadow");
            album.Artists.Length.Should().Be(1);
            album.Artists[0].Should().Be("Kecap Tuyul");
            album.Genre.Length.Should().Be(1);
            album.Genre[0].Should().Be("Experimental");
            album.SongList.Should().NotBeNull();
            album.SongList.Count.Should().Be(0);
            album.Cover.Should().NotBeNull();
        }

        [TestMethod]
        [DeploymentItem(@InvalidMp3FilePath, "RepositoryControl")]
        public void WithAlbum_GivenInvalidMp3File_WhenCreatingAlbumObject_ThenDefaultParametersAreFilledAccordingly()
        {
            //Arrange
            var tagFile = TagLib.File.Create(InvalidMp3FilePath);

            //Act
            var album = new Album(tagFile);

            //Assert
            album.Title.Should().Be("Potat's Album");
            album.Artists.Length.Should().Be(1);
            album.Artists[0].Should().Be("Potat");
            album.Genre.Length.Should().Be(1);
            album.Genre[0].Should().Be("Potat's Music");
            album.SongList.Should().NotBeNull();
            album.SongList.Count.Should().Be(0);
            album.Cover.Should().NotBeNull();
        }
    }
}

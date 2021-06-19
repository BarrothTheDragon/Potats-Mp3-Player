using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using MusicPlayer.MusicPlayerElements;

namespace MusicPlayerTest.MusicPlayerElements
{
    [TestClass]
    public class MusicFileTest
    {
        private const string ValidMp3FilePath = @"RepositoryControl/Kecap Tuyul - a simple dream.mp3";
        private const string InvalidMp3FilePath = @"RepositoryControl/Kecap Tuyul - the light always comes too late.mp3";

        [TestMethod]
        [DeploymentItem(@ValidMp3FilePath, "RepositoryControl")]
        public void WithMusicFile_GivenValidMp3File_WhenCreatingAMusicFileObject_ThenAllParametersAreFilledAccordingly()
        {
            //Arrange
            var musicTag = TagLib.File.Create(ValidMp3FilePath);

            //Act
            var musicFile = new MusicFile(musicTag);

            //Assert 
            musicFile.Path.Should().Be(ValidMp3FilePath);
            musicFile.AlbumTitle.Should().Be("My other shadow");
            musicFile.SongTitle.Should().Be("a simple dream");
            musicFile.SongArtist.Length.Should().Be(1);
            musicFile.SongArtist[0].Should().Be("Kecap Tuyul");
            musicFile.Year.Should().Be(2012);
            musicFile.Disk.Should().Be(0);
            musicFile.Track.Should().Be(4);
            musicFile.Duration.Minutes.Should().Be(0);
            musicFile.Duration.Seconds.Should().Be(55);
        }

        [TestMethod]
        [DeploymentItem(@InvalidMp3FilePath, "RepositoryControl")]
        public void WithMusicFile_GivenInvalidMp3File_WhenCreatingAMusicFileObject_ThenDefaultParametersAreFilledAccordingly()
        {
            //Arrange
            var musicTag = TagLib.File.Create(InvalidMp3FilePath);

            //Act
            var musicFile = new MusicFile(musicTag);

            //Assert 
            musicFile.Path.Should().Be(InvalidMp3FilePath);
            musicFile.AlbumTitle.Should().Be("Potat's Album");
            musicFile.SongTitle.Should().Be("Kecap Tuyul - the light always comes too late");
            musicFile.SongArtist.Length.Should().Be(1);
            musicFile.SongArtist[0].Should().Be("Potat");
            musicFile.Year.Should().Be(0);
            musicFile.Disk.Should().Be(0);
            musicFile.Track.Should().Be(0);
            musicFile.Duration.Minutes.Should().Be(3);
            musicFile.Duration.Seconds.Should().Be(1);
        }
    }
}

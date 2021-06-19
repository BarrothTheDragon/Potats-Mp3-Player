using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPlayer.RepositoryControl;
using FluentAssertions;

namespace MusicPlayerTest.RepositoryControl
{
    [TestClass]
    [DeploymentItem(@"RepositoryControl/Kecap Tuyul - a simple dream.mp3", "RepositoryControl")]
    [DeploymentItem(@"RepositoryControl/Kecap Tuyul - the light always comes too late.mp3", "RepositoryControl")]
    public class MusicCollectionRepositoryTest
    {
        private const string ValidMp3FilePath = @"RepositoryControl/Kecap Tuyul - a simple dream.mp3";
        private const string InvalidMp3FilePath = @"RepositoryControl/Kecap Tuyul - the light always comes too late.mp3";

        private const string ValidAlbumTitle = "My other shadow";
        private const string InvalidAlbumTitle = "Potat's Album";

        private const string ValidSongTitle = "a simple dream";
        private const string InvalidSongTitle = "Kecap Tuyul - the light always comes too late";

        /*
         * CreateNewRepository Test
         */
        [TestMethod]
        public void WithMusicCollectionRepository_GivenNonEmptyAlbumCollection_WhenCreatingNewRepository_ThenAlbumCollectionIsEmpty()
        {
            //Arrange
            var musicCollectionRepository = new MusicCollectionRepository();
            musicCollectionRepository.AddEntry(ValidMp3FilePath);
            musicCollectionRepository.AddEntry(InvalidMp3FilePath);

            //Act
            musicCollectionRepository.CreateNewRepository();

            //Assert
            musicCollectionRepository.AlbumCollection.Should().BeEmpty();
        }

        /*
         * AddEntry Tests
         */
        [TestMethod]
        public void WithMusicCollectionRepository_GivenEmptyAlbumCollection_WhenAddingOneValidEntry_ThenEntryIsAddedToCorrespondingAlbum()
        {
            //Arrange
            var musicCollectionRepository = new MusicCollectionRepository();

            //Act
            musicCollectionRepository.AddEntry(ValidMp3FilePath);

            //Assert
            musicCollectionRepository.AlbumCollection.Count.Should().Be(1);
            musicCollectionRepository.GetAlbumByTitle(ValidAlbumTitle).Should().NotBeNull();
            musicCollectionRepository.GetAlbumByTitle(ValidAlbumTitle).SongList[0].SongTitle.Should().Be(ValidSongTitle);
        }

        [TestMethod]
        public void WithMusicCollectionRepository_GivenEmptyAlbumCollection_WhenAddingOneInvalidEntry_ThenEntryIsAddedToDefaultAlbum()
        {
            //Arrange
            var musicCollectionRepository = new MusicCollectionRepository();

            //Act
            musicCollectionRepository.AddEntry(InvalidMp3FilePath);

            //Assert
            musicCollectionRepository.AlbumCollection.Count.Should().Be(1);
            musicCollectionRepository.GetAlbumByTitle(InvalidAlbumTitle).Should().NotBeNull();
            musicCollectionRepository.GetAlbumByTitle(InvalidAlbumTitle).SongList[0].SongTitle.Should().Be(InvalidSongTitle);
        }

        [TestMethod]
        public void WithMusicCollectionRepository_GivenNonEmptyAlbumCollection_WhenAddingSongFromSameAlbum_ThenAlbumSongListFromAlbumCollectionIsUpdated()
        {
            //Arrange
            var musicCollectionRepository = new MusicCollectionRepository();
            musicCollectionRepository.AddEntry(ValidMp3FilePath);

            //Act
            musicCollectionRepository.AddEntry(ValidMp3FilePath);

            //Assert
            musicCollectionRepository.AlbumCollection.Count.Should().Be(1);
            musicCollectionRepository.GetAlbumByTitle(ValidAlbumTitle).Should().NotBeNull();
            musicCollectionRepository.GetAlbumByTitle(ValidAlbumTitle).SongList[0].SongTitle.Should().Be(ValidSongTitle);
            musicCollectionRepository.GetAlbumByTitle(ValidAlbumTitle).SongList[1].SongTitle.Should().Be(ValidSongTitle);
        }

        [TestMethod]
        public void WithMusicCollectionRepository_GivenNonEmptyAlbumCollection_WhenAddingSongDifferentSameAlbum_ThenNewAlbumIsAddedToAlbumCollection()
        {
            //Arrange
            var musicCollectionRepository = new MusicCollectionRepository();
            musicCollectionRepository.AddEntry(ValidMp3FilePath);

            //Act
            musicCollectionRepository.AddEntry(InvalidMp3FilePath);

            //Assert
            musicCollectionRepository.AlbumCollection.Count.Should().Be(2);
            musicCollectionRepository.GetAlbumByTitle(ValidAlbumTitle).Should().NotBeNull();
            musicCollectionRepository.GetAlbumByTitle(InvalidAlbumTitle).Should().NotBeNull();
            musicCollectionRepository.GetAlbumByTitle(ValidAlbumTitle).SongList[0].SongTitle.Should().Be(ValidSongTitle);
            musicCollectionRepository.GetAlbumByTitle(InvalidAlbumTitle).SongList[0].SongTitle.Should().Be(InvalidSongTitle);
        }

        /*
         * GetAlbumByTitle Tests
         */
        [TestMethod]
        public void WithMusicCollectionRepository_GivenAlbumCollectionContainsTheAlbum_WhenGettingAlbumByTitle_ThenAlbumIsReturned()
        {
            //Arrange
            var musicCollectionRepository = new MusicCollectionRepository();
            musicCollectionRepository.AddEntry(ValidMp3FilePath);

            //Act
            var album = musicCollectionRepository.GetAlbumByTitle(ValidAlbumTitle);

            //Assert
            album.Title.Should().Be(ValidAlbumTitle);
        }

        [TestMethod]
        public void WithMusicCollectionRepository_GivenAlbumCollectionDoesNotContainTheAlbum_WhenGettingAlbumByTitle_ThenNullIsReturned()
        {
            //Arrange
            var musicCollectionRepository = new MusicCollectionRepository();

            //Act
            var album = musicCollectionRepository.GetAlbumByTitle(ValidAlbumTitle);

            //Assert
            album.Should().Be(null);
        }

        /*
         * RemoveEntry Tests
         */
        [TestMethod]
        public void WithMusicCollectionRepository_GivenAlbumCollectionContainsEntry_WhenRemovingEntry_ThenEntryIsRemoved()
        {
            //Arrange
            var musicCollectionRepository = new MusicCollectionRepository();
            musicCollectionRepository.AddEntry(ValidMp3FilePath);

            //Act
            musicCollectionRepository.RemoveEntry(ValidMp3FilePath);

            //Assert
            musicCollectionRepository.AlbumCollection.Count.Should().Be(1);
            musicCollectionRepository.GetAlbumByTitle(ValidAlbumTitle).SongList.Should().BeEmpty();
        }

        [TestMethod]
        public void WithMusicCollectionRepository_GivenAlbumCollectionDoesNotContainEntry_WhenRemovingEntry_ThenNoChangeIsMade()
        {
            //Arrange
            var musicCollectionRepository = new MusicCollectionRepository();
            musicCollectionRepository.AddEntry(ValidMp3FilePath);

            //Act
            musicCollectionRepository.RemoveEntry(InvalidMp3FilePath);

            //Assert
            musicCollectionRepository.AlbumCollection.Count.Should().Be(1);
            musicCollectionRepository.GetAlbumByTitle(ValidAlbumTitle).SongList.Should().NotBeEmpty();
        }

        /*
         * RemoveAllEntries Test
         */
        [TestMethod]
        public void WithMusicCollectionRepository_GivenNonEmptyAlbumCollection_WhenRemovingAllEntries_ThenAlbumCollectionIsEmpty()
        {
            //Arrange
            var musicCollectionRepository = new MusicCollectionRepository();
            musicCollectionRepository.AddEntry(ValidMp3FilePath);
            musicCollectionRepository.AddEntry(InvalidMp3FilePath);

            //Act
            musicCollectionRepository.RemoveAllEntries();

            //Assert
            musicCollectionRepository.AlbumCollection.Should().BeEmpty();
        }
    }
}

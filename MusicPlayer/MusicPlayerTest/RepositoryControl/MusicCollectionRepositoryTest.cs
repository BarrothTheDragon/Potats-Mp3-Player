using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPlayer.RepositoryControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayerTest.RepositoryControl
{
    [TestClass]
    class MusicCollectionRepositoryTest
    {
        private const string ValidMp3FilePath = "Kecap Tuyul - a simple dream.mp3";
        private const string InvalidMp3FilePath = "Kecap Tuyul - the light always comes too late.mp3";

        [TestMethod]
        public void WithMusicCollectionRepository_GivenEmptyAlbumCollection_WhenBuildingMusicCollection_ThenTwoEntriesAreAddedToAlbumCollection()
        {
            //Arrange
            var musicCollectionRepository = new MusicCollectionRepository();

            //Act
            musicCollectionRepository.BuildMusicCollection();

            //Assert
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPlayer.RepositoryControl;
using AutoFixture;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;

namespace MusicPlayerTest.RepositoryControl
{
    [TestClass]
    [DeploymentItem(@"RepositoryControl/SourceFileRepoTextFile.json", "RepositoryControl")]
    public class SourceFileRepositoryTest
    {
        private const string FilePath = @"RepositoryControl/SourceFileRepoTextFile.json";
        private readonly Fixture fixture = new Fixture();

        /*
         * AddEntry Tests
         */
        [TestMethod]
        public void WithSourceFileRepository_GivenNoEntries_WhenEntryIsAdded_ThenSourceDirectoriesIsUpdated()
        {
            //Arrange
            var sourceFileRepository = InitializeSourceFileRepositoryWithEmptySourceDirectories();

            //Act
            string someSourceFileEntry = fixture.Create<string>();
            sourceFileRepository.AddEntry(someSourceFileEntry);

            //Assert 
            sourceFileRepository.SourceDirectories.Count.Should().Be(1);
            sourceFileRepository.SourceDirectories.Should().Contain(someSourceFileEntry);
        }

        [TestMethod]
        public void WithSourceFileRepository_GivenOneEntry_WhenNewUniqueEntryIsAdded_ThenSourceDirectoriesIsUpdated()
        {
            //Arrange
            string someEntry = "entry1";
            string someUniqueEntry = "entry2";

            var sourceFileRepository = InitializeSourceFileRepositoryWithEmptySourceDirectories();
            sourceFileRepository.AddEntry(someEntry);

            //Act
            sourceFileRepository.AddEntry(someUniqueEntry);

            //Assert
            sourceFileRepository.SourceDirectories.Count.Should().Be(2);
            sourceFileRepository.SourceDirectories.Should().Contain(someEntry);
            sourceFileRepository.SourceDirectories.Should().Contain(someUniqueEntry);
        }

        [TestMethod]
        public void WithSourceFileRepository_GivenOneEntry_WhenSameEntryIsAdded_ThenSourceDirectoriesIsNotUpdated()
        {
            //Arrange
            string someEntry = fixture.Create<string>();

            var sourceFileRepository = InitializeSourceFileRepositoryWithEmptySourceDirectories();
            sourceFileRepository.AddEntry(someEntry);

            //Act
            sourceFileRepository.AddEntry(someEntry);

            //Assert
            sourceFileRepository.SourceDirectories.Count.Should().Be(1);
            sourceFileRepository.SourceDirectories.Should().Contain(someEntry);
        }

        /*
        * RemoveEntry Tests
        */
        [TestMethod]
        public void WithSourceFileRepository_GivenOneEntry_WhenExistantEntryIsRemoved_ThenSourceDirectoriesIsUpdated()
        {
            //Arrange
            string someEntry = fixture.Create<string>();

            var sourceFileRepository = InitializeSourceFileRepositoryWithEmptySourceDirectories();
            sourceFileRepository.AddEntry(someEntry);

            //Act
            sourceFileRepository.RemoveEntry(someEntry);

            //Assert
            sourceFileRepository.SourceDirectories.Should().BeEmpty();
        }

        [TestMethod]
        public void WithSourceFileRepository_GivenThreeEntries_WhenExistantEntryIsRemoved_ThenSourceDirectoriesIsUpdated()
        {
            //Arrange
            string entry1 = "entry1";
            string entry2 = "entry2";
            string entry3 = "entry3";

            var sourceFileRepository = InitializeSourceFileRepositoryWithEmptySourceDirectories();
            sourceFileRepository.AddEntry(entry1);
            sourceFileRepository.AddEntry(entry2);
            sourceFileRepository.AddEntry(entry3);

            //Act
            sourceFileRepository.RemoveEntry(entry2);

            //Assert
            sourceFileRepository.SourceDirectories.Count.Should().Be(2);
            sourceFileRepository.SourceDirectories.Should().Contain(entry1);
            sourceFileRepository.SourceDirectories.Should().NotContain(entry2);
            sourceFileRepository.SourceDirectories.Should().Contain(entry3);
        }

        [TestMethod]
        public void WithSourceFileRepository_GivenOneEntry_WhenNonExistantEntryIsRemoved_ThenSourceDirectoriesIsNotUpdated()
        {
            //Arrange
            string someValidEntry = "someValidEntry";
            string someInvalidEntry = "someInvalidEntry";

            var sourceFileRepository = InitializeSourceFileRepositoryWithEmptySourceDirectories();
            sourceFileRepository.AddEntry(someValidEntry);

            //Act
            sourceFileRepository.RemoveEntry(someInvalidEntry);

            //Assert
            sourceFileRepository.SourceDirectories.Count.Should().Be(1);
            sourceFileRepository.SourceDirectories.Should().Contain(someValidEntry);
            sourceFileRepository.SourceDirectories.Should().NotContain(someInvalidEntry);
        }

        /*
        * RemoveAllEntries Tests
        */
        [TestMethod]
        public void WithSourceFileRepository_GivenTwoEntries_WhenRemovingAllEntries_ThenSourceDiresctoriesIsEmpty()
        {
            //Arrange
            string someEntry1 = fixture.Create<string>();
            string someEntry2 = fixture.Create<string>();

            var sourceFileRepository = CreateEmptySourceFileRepository();
            sourceFileRepository.AddEntry(someEntry1);
            sourceFileRepository.AddEntry(someEntry2);

            //Act
            sourceFileRepository.RemoveAllEntries();

            //Assert
            sourceFileRepository.SourceDirectories.Should().BeEmpty();
        }

        /*
         * IsSourceDirectoryEmpty Tests
         */
        [TestMethod]
        public void WithSourceFileRepository_GivenNoEntries_WhenCheckingIfSourceDirectoryIsEmpty_ThenIsTrue()
        {
            //Arrange
            var sourceFileRepository = InitializeSourceFileRepositoryWithEmptySourceDirectories();

            //Act
            bool isSourceDirectoryEmpty = sourceFileRepository.IsSourceDirectoryEmpty();

            //Assert
            isSourceDirectoryEmpty.Should().BeTrue();
            sourceFileRepository.SourceDirectories.Should().BeEmpty();
        }

        [TestMethod]
        public void WithSourceFileRepository_GivenOneEntry_WhenCheckingIfSourceDirectoryIsEmpty_ThenIsFalse()
        {
            //Arrange
            string someValidEntry = fixture.Create<string>();
            var sourceFileRepository = InitializeSourceFileRepositoryWithEmptySourceDirectories();
            sourceFileRepository.AddEntry(someValidEntry);

            //Act
            bool isSourceDirectoryEmpty = sourceFileRepository.IsSourceDirectoryEmpty();

            //Assert
            isSourceDirectoryEmpty.Should().BeFalse();
            sourceFileRepository.SourceDirectories.Should().NotBeEmpty();
        }

        /*
         * SaveFile Tests
         */
        [TestMethod]
        public void WithSourceFileRepository_GivenAnOutdatedExistingFile_WhenSavingChanges_ThenFileIsUpdated()
        {
            // Arrange
            var sourceFileRepository = CreateEmptySourceFileRepository();
            string someSourceFileEntry = fixture.Create<string>();
            sourceFileRepository.AddEntry(someSourceFileEntry);

            // Act
            sourceFileRepository.SaveFile();

            // Assert
            var fileData = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(FilePath));
            fileData.Should().BeEquivalentTo(new List<string>() { someSourceFileEntry });
        }

        private SourceFileRepository CreateEmptySourceFileRepository()
        {
            string absoluteFilePath = Path.GetFullPath(FilePath);
            if (File.Exists(absoluteFilePath))
            {
                File.Delete(absoluteFilePath);
            }

            return new SourceFileRepository(absoluteFilePath);
        }

        private SourceFileRepository InitializeSourceFileRepositoryWithEmptySourceDirectories()
        {
            string absoluteFilePath = Path.GetFullPath(@"RepositoryControl/SourceFileRepoTextFile.json");
            var sourceFileRepository = new SourceFileRepository(absoluteFilePath);
            sourceFileRepository.RemoveAllEntries();

            return sourceFileRepository;
        }
    }
}

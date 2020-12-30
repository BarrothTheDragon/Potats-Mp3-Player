using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlayer.RepositoryControl
{
    public class MusicFileExtractor
    {
        readonly SourceFileRepository sourceFileRepository = RepositoryController.GetSourceFileRepository;

        public static int totalNumberOfSubdirectories = 0;
        public static int searchedSubdirectories = 0;
        public static int totalNumberOfSongs = 0;

        private const string Mp3Extension = ".mp3";
        private const string FlacExtension = ".flac";
        private readonly static List<string> AcceptedFileExtensions = new List<string> {
            Mp3Extension,
            FlacExtension,
        };

        public List<string> GetAllMusicFiles()
        {
            var subDirectories = ExtractSubdirectories();
            totalNumberOfSubdirectories = subDirectories.Count;
            return ExtractMusicFiles(subDirectories);
        }

        private List<string> ExtractSubdirectories()
        {
            var subFolderSet = new HashSet<string>();
            sourceFileRepository.SourceDirectories.ForEach(entry => subFolderSet.UnionWith(GetAllFolderSubDirectories(entry)));
            return subFolderSet.ToList();
        }

        private List<string> ExtractMusicFiles(List<string> subFolderSet)
        {
            var musicFile = new List<string>();
            foreach (string folderEntry in subFolderSet)
            {
                var musicFilesInSubdirectories = GetAllSupportedFilesInDirectory(folderEntry);
                musicFile.AddRange(musicFilesInSubdirectories);

                UpdateProgressCounters(musicFilesInSubdirectories);
            }
            return musicFile;
        }

        private void UpdateProgressCounters(List<string> musicFilesInSubdirectories)
        {
            searchedSubdirectories++;
            totalNumberOfSongs += musicFilesInSubdirectories.Count;
        }

        private IEnumerable<string> GetAllFolderSubDirectories(string rootDirectory)
            => Directory.EnumerateDirectories(rootDirectory, "*", SearchOption.AllDirectories);

        private List<string> GetAllSupportedFilesInDirectory(string directory)
            => Directory.EnumerateFiles(directory, ".", SearchOption.TopDirectoryOnly).Where(file => AcceptedFileExtensions.Any(file.EndsWith)).ToList();
    }
}

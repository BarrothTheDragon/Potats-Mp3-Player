using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlayer.RepositoryControl
{
    public class MusicFileExtractor
    {
        readonly SourceFileRepository sourceFileRepository = RepositoryController.GetSourceFileRepository;

        private const string Mp3Extension = ".mp3";
        private readonly static List<string> AcceptedFileExtensions = new List<string> {
            Mp3Extension,
        };

        public List<string> GetAllMusicFiles()
        {
            var subDirectories = ExtractSubdirectories();
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
            }
            return musicFile;
        }

        private IEnumerable<string> GetAllFolderSubDirectories(string rootDirectory)
            => Directory.EnumerateDirectories(rootDirectory, "*", SearchOption.AllDirectories);

        private List<string> GetAllSupportedFilesInDirectory(string directory)
            => Directory.EnumerateFiles(directory, ".", SearchOption.TopDirectoryOnly).Where(file => AcceptedFileExtensions.Any(file.EndsWith)).ToList();
    }
}

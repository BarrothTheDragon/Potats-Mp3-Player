using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


namespace MusicPlayer.RepositoryControl
{
    public class SourceFileRepository : IRepositoryController
    {
        public List<string> SourceDirectories { get; private set; }
        private readonly string FilePath;

        public SourceFileRepository(string filePath)
        {
            FilePath = filePath;
            InitializeRepository();
        }

        public void CreateNewRepository()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            File.Create(FilePath).Dispose();
        }

        public void AddEntry(string entry)
        {
            if (!SourceDirectories.Contains(entry))
            {
                SourceDirectories.Add(entry);
            }
        }

        public void RemoveEntry(string entry)
        {
            if (SourceDirectories.Contains(entry))
            {
                SourceDirectories.Remove(entry);
            }
        }

        public void RemoveAllEntries()
            => SourceDirectories = new List<string>();

        public void SaveFile()
            => SerializeSourceDirectories();

        public bool IsSourceDirectoryEmpty()
            => SourceDirectories.Count == 0;

        private void InitializeRepository()
        {
            if (!File.Exists(FilePath))
            {
                CreateNewRepository();
            }

            SourceDirectories = DeserializeSourceDirectories() ?? new List<string>();
        }

        private void SerializeSourceDirectories()
            => File.WriteAllText(FilePath, JsonConvert.SerializeObject(SourceDirectories));

        private List<string> DeserializeSourceDirectories()
            => JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(FilePath));
    }
}
using MusicPlayer.RepositoryControl;

namespace MusicPlayer.Controller
{
    class MusicLoader
    {
        readonly static MusicCollectionRepository sourceFileRepository = RepositoryController.GetMusicCollectionRepository;

        public static void BuildMusicCollection()
        {
            foreach (string filePath in new MusicFileExtractor().GetAllMusicFiles())
            {
                sourceFileRepository.AddEntry(filePath);
            }
        }
    }
}

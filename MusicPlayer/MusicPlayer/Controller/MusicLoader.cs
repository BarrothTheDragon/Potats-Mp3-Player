using MusicPlayer.RepositoryControl;

namespace MusicPlayer.Controller
{
    class MusicLoader
    {
        readonly static MusicCollectionRepository sourceFileRepository = RepositoryController.GetMusicCollectionRepository;

        public static void BuildMusicCollection()
            => new MusicFileExtractor().GetAllMusicFiles().ForEach(filePath => sourceFileRepository.AddEntry(filePath));
    }
}

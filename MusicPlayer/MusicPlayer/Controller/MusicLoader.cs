using MusicPlayer.RepositoryControl;

namespace MusicPlayer.Controller
{
    class MusicLoader
    {
        readonly static MusicCollectionRepository musicCollectionRepository = RepositoryController.GetMusicCollectionRepository;

        public static void BuildMusicCollection()
            => new MusicFileExtractor().GetAllMusicFiles().ForEach(filePath => musicCollectionRepository.AddEntry(filePath));
    }
}

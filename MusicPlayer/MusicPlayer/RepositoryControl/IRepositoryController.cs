namespace MusicPlayer.RepositoryControl
{
    interface IRepositoryController
    {
        void CreateNewFile();
        void AddEntry(string entry);
        void RemoveEntry(string entry);
        void RemoveAllEntries();
    }
}

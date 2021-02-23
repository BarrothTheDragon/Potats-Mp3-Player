namespace MusicPlayer.RepositoryControl
{
    interface IRepositoryController
    {
        void CreateNewRepository();
        void AddEntry(string entry);
        void RemoveEntry(string entry);
        void RemoveAllEntries();
    }
}

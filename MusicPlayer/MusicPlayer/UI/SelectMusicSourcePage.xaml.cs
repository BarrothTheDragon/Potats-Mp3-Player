using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using MusicPlayer.RepositoryControl;

namespace MusicPlayer.UI
{
    /// <summary>
    /// Interaction logic for SelectMusicSourcePage.xaml
    /// </summary>
    public partial class SelectMusicSourcePage : Page
    {
        readonly SourceFileRepository sourceFileRepository = RepositoryController.GetSourceFileRepository;
        
        public SelectMusicSourcePage()
        {
            InitializeComponent();
            m_sourceDirectoriesListBox.ItemsSource = sourceFileRepository.SourceDirectories;
            UpdateListboxDependantPageElements();
        }

        private void OnClickAdd(object sender, RoutedEventArgs e)
        {
            using var dialog = new FolderBrowserDialog
            {
                Description = "Select the folder that contains your music.",
                ShowNewFolderButton = false,
                RootFolder = Environment.SpecialFolder.MyComputer
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sourceFileRepository.AddEntry(dialog.SelectedPath);
                RefreshListBox();
            }
        }

        private void OnClickDelete(object sender, RoutedEventArgs e)
        {
            var selectedItem = (ListBoxItem)m_sourceDirectoriesListBox.ItemContainerGenerator
                .ContainerFromItem(((System.Windows.Controls.Button)sender).DataContext);
            sourceFileRepository.RemoveEntry(selectedItem.Content.ToString());

            RefreshListBox();
        }

        private void OnClickDone(object sender, RoutedEventArgs e)
        {
            sourceFileRepository.SaveFile();
            var loadingPageUri = new Uri("UI/LoadingPage.xaml", UriKind.Relative);
            NavigationService.Navigate(loadingPageUri);
        }

        private void RefreshListBox()
        {
            m_sourceDirectoriesListBox.Items.Refresh();
            UpdateListboxDependantPageElements();
        }

        private void UpdateListboxDependantPageElements()
        {
            if (m_sourceDirectoriesListBox.Items.Count > 0)
            {
                ShowListboxDependantPageElements();
            }
            else
            {
                HideListboxDependantPageElements();
            }
        }

        private void HideListboxDependantPageElements()
        {
            m_sourceDirectoriesListBox.Visibility = Visibility.Hidden;
            m_nextButton.Visibility = Visibility.Hidden;
        }

        private void ShowListboxDependantPageElements()
        {
            m_sourceDirectoriesListBox.Visibility = Visibility.Visible;
            m_nextButton.Visibility = Visibility.Visible;
        }
    }
}

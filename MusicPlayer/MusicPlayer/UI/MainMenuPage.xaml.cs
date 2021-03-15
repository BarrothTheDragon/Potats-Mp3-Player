﻿using MusicPlayer.RepositoryControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MusicPlayer.RepositoryControl;

namespace MusicPlayer.UI
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        readonly MusicCollectionRepository musicCollectionRepository = RepositoryController.GetMusicCollectionRepository;

        public MainMenuPage()
        {
            InitializeComponent();
            m_albumCollectionListBox.ItemsSource = musicCollectionRepository.AlbumCollection;
        }
    }
}

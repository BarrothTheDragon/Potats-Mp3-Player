﻿using System;
using System.IO;

namespace MusicPlayer.RepositoryControl
{
    public class RepositoryController
    {
        private static readonly Lazy<SourceFileRepository> sourceFileRepository =
            new Lazy<SourceFileRepository>(() => new SourceFileRepository(GetSourceDirectoryFileAbsolutePath()));

        public static SourceFileRepository GetSourceFileRepository
        {
            get
            {
                return sourceFileRepository.Value;
            }
        }

        // https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/

        private static string GetSourceDirectoryFileAbsolutePath()
            => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Potat\'s Music Player", "SourceDirectories.json");
    }
}

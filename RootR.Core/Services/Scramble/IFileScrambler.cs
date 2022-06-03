using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rootr.Core.Services.Scramble
{
    internal interface IFileScrambler
    {
        void ScrambleFiles(IEnumerable<FileInfo> targets, DirectoryInfo destination);
    }

    internal class FileScrambler : IFileScrambler
    {
        private readonly IShuffle<FileInfo> fileShuffler;
        private readonly IShuffle<DirectoryInfo> directoryShuffler;

        public FileScrambler(IShuffle<FileInfo> fileShuffler, IShuffle<DirectoryInfo> directoryShuffler)
        {
            this.fileShuffler = fileShuffler;
            this.directoryShuffler = directoryShuffler;
        }

        public void ScrambleFiles(IEnumerable<FileInfo> targets, DirectoryInfo destination)
        {
            FileInfo[] filesThatDontExist = targets.Where(e => !e.Exists).ToArray();
            if (filesThatDontExist.Any())
            {
                string fileNames = string.Join(Environment.NewLine, filesThatDontExist.Select(e => e.FullName));
                throw new FileNotFoundException(fileNames);
            }

            fileShuffler.Shuffle(targets.ToArray(), RandomProvider.Random);

            DirectoryInfo[] subDirectories = destination.GetDirectories();

            // no need to scramble if no subdirectories are found in destination
            if (!subDirectories.Any())
                return;

            directoryShuffler.Shuffle(subDirectories.ToArray(), RandomProvider.Random);


        }

        public IEnumerable<DirectoryInfo> GetDirectoryInfos(DirectoryInfo directoryInfo)
        {
            return directoryInfo.GetDirectories();
        }

        public int GetMaximumFilesPerDirectory(int numberOfFiles, int numberOfSubdirectories)
        {
            // No files, maximum is 0 per directory.
            if (numberOfFiles < 1)
                return 0;

            // No directory, maximum is 0 per directory.
            if (numberOfSubdirectories < 1)
                return 0;

            if (numberOfFiles < numberOfSubdirectories)
                return numberOfFiles;
            int per = numberOfFiles / numberOfSubdirectories;

            return per;
        }
    }
}

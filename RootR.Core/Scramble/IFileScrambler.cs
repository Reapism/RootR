using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Rootr.Core.Services;

namespace Rootr.Core.Scramble
{
    interface IShuffle<T>
        where T : class
    {
        void Shuffle(T[] array, Random random);
    }

    class Scrambler<T> : IShuffle<T>
        where T : class
    {
        public void Shuffle(T[] array, Random random)
        {
            KnuthShuffle(array, random);
        }

        /// <summary>
        /// Performs a Knuth Shuffle on the <typeparamref name="T"/> array.
        /// </summary>
        /// <typeparam name="T">A Type array.</typeparam>
        /// <param name="array">An array of type <typeparamref name="T"/>.</param>
        /// <param name="random">The <see cref="Random"/> provider.</param>
        private void KnuthShuffle(T[] array, Random random)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var j = random.Next(i, array.Length); // Don't select from the entire array on subsequent loops
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }

    interface IFileScrambler
    {
        void ScrambleFiles(IEnumerable<FileInfo> targets, DirectoryInfo destination);
    }

    class FileScrambler : IFileScrambler
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
            var filesThatDontExist = targets.Where(e => !e.Exists).ToArray();
            if (filesThatDontExist.Any())
            {
                var fileNames = string.Join(Environment.NewLine, filesThatDontExist.Select(e => e.FullName));
                throw new FileNotFoundException(fileNames);
            }

            fileShuffler.Shuffle(targets.ToArray(), RandomProvider.Random);

            var subDirectories = destination.GetDirectories();

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
            var per = numberOfFiles / numberOfSubdirectories;

            return per;
        }
    }
}

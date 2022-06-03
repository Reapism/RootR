using System.Collections.Generic;
using System.IO;

namespace Rootr.Core.Extensions
{
    public static class DirectoryExtensions
    {
        public static IEnumerable<DirectoryInfo> GetDirectories(this DirectoryInfo directoryInfo)
        {
            return GetDirectories(directoryInfo.FullName);
        }

        public static IEnumerable<DirectoryInfo> GetDirectories(string path)
        {
            string[] directories = System.IO.Directory.GetDirectories(path);

            foreach (string dir in directories)
            {
                yield return new DirectoryInfo(dir);
            }
        }

        public static DirectoryInfo AsDirectoryInfo(this string path)
        {
            return new DirectoryInfo(path);
        }
    }
}

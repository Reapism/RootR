using System;
using System.Collections.Generic;
using System.IO;

namespace Rootr.Core.Cleaner
{
    public interface IDirectoryCrud
    {
        void Create(DirectoryInfo directoryInfo);
        void Create(IEnumerable<DirectoryInfo> directoryInfos);

        void Update(DirectoryInfo directoryInfo, IEnumerable<FileInfo> fileInfos);

        void Delete(IEnumerable<DirectoryInfo> directoryInfos);

        IEnumerable<FileInfo> Read(DirectoryInfo directoryInfo);
    }

    public class DirectoryCrudBase : IDirectoryCrud
    {
        public void Create(DirectoryInfo directoryInfo)
        {
            directoryInfo.Create();
        }

        public void Create(IEnumerable<DirectoryInfo> directoryInfos)
        {
            foreach (var directoryInfo in directoryInfos)
                directoryInfo.Create();
        }

        public void Delete(IEnumerable<DirectoryInfo> directoryInfos)
        {
            foreach (var dir in directoryInfos)
            {
                if (dir.Exists)
                    dir.Delete();
            }
        }

        public IEnumerable<FileInfo> Read(DirectoryInfo directoryInfo)
        {
            return directoryInfo.EnumerateFiles();
        }

        public void Update(DirectoryInfo directoryInfo, IEnumerable<FileInfo> fileInfos)
        {
            throw new NotImplementedException();
        }
    }
}

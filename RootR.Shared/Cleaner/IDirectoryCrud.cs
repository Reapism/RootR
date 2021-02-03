using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rootr.Shared.Cleaner
{
    interface IDirectoryCrud
    {
        void Create(DirectoryInfo directoryInfo);
        void Create(IEnumerable<DirectoryInfo> directoryInfos);

        void Update(DirectoryInfo fileInfo, IEnumerable<FileInfo> fileInfos);

        void Delete(IEnumerable<DirectoryInfo> directoryInfos);
        IEnumerable<FileInfo> Read(DirectoryInfo directoryInfo);
    }
    class DirectoryCrudBase : IDirectoryCrud
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
            throw new NotImplementedException();
        }

        public IEnumerable<FileInfo> Read(DirectoryInfo directoryInfo)
        {
            throw new NotImplementedException();
        }

        public void Update(DirectoryInfo fileInfo, IEnumerable<FileInfo> fileInfos)
        {
            throw new NotImplementedException();
        }
    }
}

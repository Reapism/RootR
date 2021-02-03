using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rootr.Shared.Files
{
    internal class FileCrudBase : IFileCrud
    {
        public FileStream Create(FileInfo fileInfo)
        {
            var doesFileExist = fileInfo.Exists;

            if (doesFileExist)
                return (FileStream)Stream.Null;

            return fileInfo.Create();
        }

        public IEnumerable<FileStream> Create(IEnumerable<FileInfo> fileInfos)
        {
            foreach (var fileInfo in fileInfos)
                yield return fileInfo.Create();
        }

        public void Delete(IEnumerable<FileInfo> fileInfos)
        {
            foreach (var fileInfo in fileInfos)
                fileInfo.Delete();
        }

        public string Read(FileInfo fileInfo)
        {
            if (!fileInfo.Exists)
                return string.Empty;

            var fileStream = fileInfo.OpenRead();
            if (!fileStream.CanRead)
                throw new Exception("Cannot read file");

            using var streamReader = new StreamReader(fileStream);

            return streamReader.ReadToEnd();
        }

        public FileStream Update(FileInfo fileInfo, string fileContents)
        {
            if (!fileInfo.Exists)
                throw new FileNotFoundException();

            var fileStream = fileInfo.Create();
            using var streamWriter = new StreamWriter(fileStream);

            streamWriter.Write(fileContents);
            streamWriter.Flush();

            return fileStream;
        }
    }
}

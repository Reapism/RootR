using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rootr.Core.Files
{
    interface IFileCrud
    {
        FileStream Create(FileInfo fileInfo);
        IEnumerable<FileStream> Create(IEnumerable<FileInfo> fileInfos);

        FileStream Update(FileInfo fileInfo, string fileContents);
        //IEnumerable<FileStream> Update(IEnumerable<FileInfo> fileInfos);

        void Delete(IEnumerable<FileInfo> fileInfos);
        string Read(FileInfo fileInfo);
    }
}

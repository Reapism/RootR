using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rootr.Core.Files
{
    interface IVirtualFile
    {
        FileInfo FileInfo { get; set; }
        string FileContents { get; set; }
    }
}

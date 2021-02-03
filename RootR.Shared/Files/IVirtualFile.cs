using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rootr.Shared.Files
{
    interface IVirtualFile
    {
        FileInfo FileInfo { get; set; }
        string FileContents { get; set; }
    }
}

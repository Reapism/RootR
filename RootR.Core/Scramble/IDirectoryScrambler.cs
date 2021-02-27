using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rootr.Core.Scramble
{
    interface IDirectoryScrambler
    {
        void ScrambleDirectory(DirectoryInfo target, DirectoryInfo destination);
        void ScrambleDirectories(IEnumerable<DirectoryInfo> targets, DirectoryInfo destination);
    }
}

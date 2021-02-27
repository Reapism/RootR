using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rootr.Core.Obfuscation
{
    interface IFileObfuscator
    {
        void Obfuscate(FileInfo fileInfo);
        void Deobfuscate(FileInfo fileInfo);
    }
    class FileObfuscator
    {
        
        public void Deobfuscate()
        {
            throw new NotImplementedException();
        }

        public void Obfuscate()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rootr.Core.Cryptography
{
    interface IFileCryptography
    {
        void EncryptFile(FileInfo fileInfo);
        void DecryptFile(FileInfo fileInfo);
    }

}

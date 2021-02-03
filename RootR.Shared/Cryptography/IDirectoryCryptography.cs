﻿using System.IO;

namespace Rootr.Shared.Cryptography
{
    interface IDirectoryCryptography
    {
        void EncryptDirectory(DirectoryInfo directoryInfo);
        void DecryptDirectory(DirectoryInfo directoryInfo);
    }
    class DirectoryCryptographyBase : IDirectoryCryptography
    {
        public void DecryptDirectory(DirectoryInfo directoryInfo)
        {
            throw new System.NotImplementedException();
        }

        public void EncryptDirectory(DirectoryInfo directoryInfo)
        {
            throw new System.NotImplementedException();
        }
    }
}

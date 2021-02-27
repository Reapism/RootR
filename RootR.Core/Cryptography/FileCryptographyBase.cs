using System.IO;

namespace Rootr.Core.Cryptography
{
    public class FileCryptographyBase : IFileCryptography
    {
        public void EncryptFile(FileInfo fileInfo)
        {
            if (!fileInfo.Exists)
                throw new FileNotFoundException();
            
            fileInfo.Encrypt();
        }

        public void DecryptFile(FileInfo fileInfo)
        {
            if (!fileInfo.Exists)
                throw new FileNotFoundException();

            fileInfo.Decrypt();
        }
    }
}

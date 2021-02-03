using System.IO;

namespace Rootr.Shared.Cryptography
{
    public class FileSecureBase : IFileCryptography
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

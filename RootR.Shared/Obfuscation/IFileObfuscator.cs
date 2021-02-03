using System;
using System.Collections.Generic;
using System.Text;

namespace Rootr.Shared.Obfuscation
{
    interface IFileObfuscator
    {
        void Obfuscate();
        void Deobfuscate();
    }
}

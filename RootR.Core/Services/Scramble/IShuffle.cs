using System;

namespace Rootr.Core.Services.Scramble
{
    internal interface IShuffle<T>
        where T : class
    {
        void Shuffle(T[] array, Random random);
    }
}

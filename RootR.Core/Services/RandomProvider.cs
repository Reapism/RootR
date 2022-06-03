using System;

namespace Rootr.Core.Services
{
    public static class RandomProvider
    {
        public static Random Random { get; } = Random.Shared;
    }
}

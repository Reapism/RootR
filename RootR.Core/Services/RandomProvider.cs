using System;
using System.Collections.Generic;
using System.Text;

namespace Rootr.Core.Services
{
    public static class RandomProvider
    {
        public static Random Random { get; } = new Random();
    }
}

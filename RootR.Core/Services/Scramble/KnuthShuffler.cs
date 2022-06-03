using System;

namespace Rootr.Core.Services.Scramble
{
    internal class KnuthShuffler<T> : IShuffle<T>
        where T : class
    {
        public void Shuffle(T[] array, Random random)
        {
            KnuthShuffle(array, random);
        }

        /// <summary>
        /// Performs a Knuth Shuffle on the <typeparamref name="T"/> array.
        /// </summary>
        /// <typeparam name="T">A Type array.</typeparam>
        /// <param name="array">An array of type <typeparamref name="T"/>.</param>
        /// <param name="random">The <see cref="Random"/> provider.</param>
        private void KnuthShuffle(T[] array, Random random)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int j = random.Next(i, array.Length); // Don't select from the entire array on subsequent loops
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}

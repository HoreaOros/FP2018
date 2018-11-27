using System.Collections.Generic;

namespace _2711
{
    internal class DescComparer<T> : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y)
            {
                return -1;
            }
            else if (x < y)
            {
                return 1;
            }
            else
                return 0;
        }
    }
}
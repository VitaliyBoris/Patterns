using System;
using System.Collections.Generic;

namespace Patterns.Strategy.OrderStrategy
{
    public static class ComparerFactory
    {
        public static IComparer<T> Create<T>(Comparison<T> comparer)
        {
            return new DelegateComparer<T>(comparer);
        }

        private class DelegateComparer<T> : IComparer<T>
        {
            private readonly Comparison<T> _comparer;

            public DelegateComparer(Comparison<T> comparer)
            {
                _comparer = comparer;
            }

            public int Compare(T x, T y)
            {
                return _comparer(x, y);
            }
        }
    }
}
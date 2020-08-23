using System.Collections.Generic;

namespace AlkarInjector.Utilities
{
    public static class KeyValuePairUtility
    {
        public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> self, out TKey key, out TValue value)
        {
            key = self.Key;
            value = self.Value;
        }
    }
}
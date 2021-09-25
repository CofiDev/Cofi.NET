using System.ComponentModel;
using System.Collections.Generic;

namespace Cofi
{
    public static class IDictionaryExtensions
    {
        public static IDictionary<TKey, TValue> FluentAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            dictionary.Add(key, value);
            return dictionary;
        }

        public static IDictionary<TKey, TValue> FluentAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> item)
        {
            dictionary.Add(item);
            return dictionary;
        }
    }
}
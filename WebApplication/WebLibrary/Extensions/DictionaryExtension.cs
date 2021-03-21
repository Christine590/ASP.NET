using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WebLibrary.Extensions
{
    public static class DictionaryExtension // 擴充都加上 static 宣告為全域
    {
        public static ReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dic)
        {
            return new ReadOnlyDictionary<TKey, TValue>(dic);
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key) => GetValueOrDefault(dic, key, default);

        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, TValue defaultValue)
        {
            return dic.TryGetValue(key, out var value) ? value : defaultValue;
        }
    }
}

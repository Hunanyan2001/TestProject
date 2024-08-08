using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class DocumentDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IDocumentDictionary<TKey, TValue>
    {
        public void Add<T>(string key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (key is not T)
                throw new ArgumentException("The key type does not match the specified type parameter.", nameof(key));

            TKey typedKey = (TKey)(object)key;
            this.Add(typedKey, value);
        }

        public bool Contains<T>(string key)
        {
            if(key == null) throw new ArgumentNullException(nameof(key));

            if (typeof(TKey) != typeof(T))
                throw new ArgumentException("The key type does not match the specified type parameter.", nameof(T));

            TKey typedKey = (TKey)(object)key;
            return this.ContainsKey(typedKey);
        }

        public TValue GetByKey<T>(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            if (typeof(TKey) != typeof(T))
                throw new ArgumentException("The key type does not match the specified type parameter.", nameof(T));

            TKey typedKey = (TKey)(object)key;
            if (this.TryGetValue(typedKey, out TValue value)) return value;

            throw new KeyNotFoundException("The specified key was not found in the dictionary.");
        }

        public void Remove<T>(string key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (key is not T)
                throw new ArgumentException("The key type does not match the specified type parameter.", nameof(key));

            TKey typedKey = (TKey)(object)key;
            if (this.ContainsKey(typedKey))
            {
                this.Remove(typedKey);
            }
        }
    }

    public class GenericList<T>
    {
        private List<T> list = new List<T>();

        public void AddList(T item)
        {
            list.Add(item);
        }

        public T Get(int index)
        {
            return list[index];
        }
    }
}

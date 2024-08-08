namespace WebApplication1.Interfaces
{
    public interface IDocumentDictionary<TKey,TValue>
    {
        void Add<T> (string key, TValue value);
        void Remove<T> (string key, TValue value);
        bool Contains<T>(string key);
        TValue GetByKey<T> (string key);
    }
}

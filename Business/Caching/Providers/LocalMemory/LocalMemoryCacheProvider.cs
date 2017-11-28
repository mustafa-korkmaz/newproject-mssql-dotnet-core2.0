using System;
using Microsoft.Extensions.Caching.Memory;
namespace Business.Caching.Providers.LocalMemory
{
    public class LocalMemoryCacheProvider : ICacheProvider
    {
        /// <summary>
        /// local memory cache object
        /// </summary>
        private MemoryCache _cache;

        #region singleton definition

        private static readonly LocalMemoryCacheProvider _instance = new LocalMemoryCacheProvider();

        private readonly object _padlock = new object();

        public static LocalMemoryCacheProvider Instance => _instance;

        private LocalMemoryCacheProvider()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        #endregion singleton definition

        #region ICacheProvider implementation

        public void Add(string key, object item, int expireInMinutes)
        {
            lock (_padlock)
            {
                if (expireInMinutes == 0)
                {
                    _cache.Set(key, item, DateTimeOffset.MaxValue);
                }
                else
                {
                    var absoluteExpiration = new TimeSpan(0, 0, expireInMinutes, 0);
                    _cache.Set(key, item, DateTimeOffset.Now.Add(absoluteExpiration));
                }
            }
        }

        public T Get<T>(string key)
        {
            lock (_padlock)
            {
                return (T)_cache.Get(key); //_cache[key];
            }
        }

        public void Remove(string key)
        {
            lock (_padlock)
            {
                _cache.Remove(key);
            }
        }

        public void RemoveAll()
        {
            lock (_padlock)
            {
                _cache.Dispose();
                _cache = new MemoryCache(new MemoryCacheOptions());
            }
        }

        #endregion ICacheProvider implementation
    }
}

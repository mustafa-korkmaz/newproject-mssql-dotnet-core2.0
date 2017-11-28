using ServiceStack.Redis;
using System;

namespace Business.Caching.Providers.Redis
{
    /// <summary>
    /// redis cahce provider by using serviceStack.Redis 
    /// 
    /// </summary>
    public class RedisCacheProvider : ICacheProvider
    {
        /*
            //In most scenarios you want to be using a thread safe connection factory
            which acts very much like a database connection pool.So whenever you want to access the RedisClient works like:
             usage:
             var redisManager = new PooledRedisClientManager("localhost:6379");
            using (var redis = redisManager.GetClient())
            {
                var allItems = redis.As<Person>().Lists["urn:names:current"].GetAll();
            }
            Note: .As < T > is a shorter alias for .GetTypedClient < T > Another convenient short - cut to execute a typed client from a redisManager is:
            var allItems = redisManager.ExecAs<Person>(r => r.Lists["urn:names:current"].GetAll());
      */

        private static readonly RedisCacheProvider _instance = new RedisCacheProvider();
        private readonly PooledRedisClientManager _redisClientManager;

        public static RedisCacheProvider Instance => _instance;

        private RedisCacheProvider()
        {
            _redisClientManager = new PooledRedisClientManager("localhost:6379"); //read this section from appSetting.keys section
        }

        public void Add(string key, object item, int expireInMinutes)
        {

            using (var redis = _redisClientManager.GetClient())
            {
                if (expireInMinutes == 0)
                {
                    redis.Set(key, item);
                }
                else
                {
                    var absoluteExpiration = new TimeSpan(0, 0, expireInMinutes, 0);

                    redis.Set(key, item, absoluteExpiration);
                }
            }
        }

        public T Get<T>(string key)
        {
            using (var redis = _redisClientManager.GetClient())
            {
                return redis.Get<T>(key);
            }
        }

        public void RemoveAll()
        {
            using (var redis = _redisClientManager.GetClient())
            {
                var keys = redis.GetAllKeys();
                redis.RemoveAll(keys);
            }
        }

        public void Remove(string key)
        {
            using (var redis = _redisClientManager.GetClient())
            {
                redis.Remove(key);
            }
        }
    }
}

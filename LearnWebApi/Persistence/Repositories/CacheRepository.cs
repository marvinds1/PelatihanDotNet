using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Persistence.Repositories
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDatabase _database;

        public RedisCacheService(ConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public bool CheckActive()
        {
            try
            {
                _database.Ping();
                return true;
            }
            catch (RedisConnectionException)
            {
                return false;
            }
        }

        public void Add(string key, object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            _database.StringSet(key, jsonData, TimeSpan.FromMinutes(10));
        }

        public bool Any(string key)
        {
            return _database.KeyExists(key);
        }

        public List<T>? Get<T>(string key)
        {
            if (Any(key) && CheckActive())
            {
                string jsonData = _database.StringGet(key);
                return JsonConvert.DeserializeObject<List<T>>(jsonData);
            }

            return default;
        }

        public void Remove(string key)
        {
            _database.KeyDelete(key);
        }

        public void Clear()
        {
            var server = _database.Multiplexer.GetServer(_database.Multiplexer.GetEndPoints()[0]);
            server.FlushDatabase();
        }
    }
}

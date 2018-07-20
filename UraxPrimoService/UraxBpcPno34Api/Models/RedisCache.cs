using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraxBpcPno34Api.Models
{
    public class RedisCache : ICache
    {
        static readonly RedisCache _instance = new RedisCache();
        static readonly IDatabase _cache;

        public static RedisCache Instance
        {

            get
            {
                return _instance;
            }
        }
        static RedisCache()
        {
            _cache = Connection.GetDatabase();
        }


        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            try
            {
                return ConnectionMultiplexer.Connect(Environment.GetEnvironmentVariable("RedisCacheKey"));

            }
            catch (Exception ex)
            {
                //log...
                new Microsoft.ApplicationInsights.TelemetryClient().TrackException(ex);
                throw;
            }
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
        /// <summary>
        /// Get Cache key and value from Redis cache with Asunc Task
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string key)
        {
            try
            {
                key = $"{Helper.KeyPrefix};{key}";
                if (_cache == null)
                {
                    return default(T);
                }
                var jsonEntity = await _cache.StringGetAsync(key);

                if (string.IsNullOrEmpty(jsonEntity))
                {
                    return default(T);
                }
                var entity = await Task.FromResult(JsonConvert.DeserializeObject<T>(jsonEntity));
                return entity;
            }
            catch (Exception ex)
            {
                //log...
                new Microsoft.ApplicationInsights.TelemetryClient().TrackException(ex);
                throw;
            }
        }
        /// <summary>
        /// Get Cache key and value from Redis cache 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetCache<T>(string key)
        {
            try
            {
                key = $"{Helper.KeyPrefix};{key}";
                if (_cache == null)
                {
                    return default(T);
                }
                var jsonEntity = _cache.StringGet(key);

                if (string.IsNullOrEmpty(jsonEntity))
                {
                    return default(T);
                }
                var entity = JsonConvert.DeserializeObject<T>(jsonEntity);
                return entity;
            }
            catch (Exception ex)
            {
                //log...
                new Microsoft.ApplicationInsights.TelemetryClient().TrackException(ex);
                throw;
            }
        }
        /// <summary>
        /// Add Cache key and value to Redis cache with Asunc Task
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync<T>(string key, T entity)
        {
            try
            {
                key = $"{Helper.KeyPrefix};{key}";
                if (entity != null && _cache != null)
                {
                    var jsonEntity = JsonConvert.SerializeObject(entity, Formatting.None, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    await _cache.StringSetAsync(key, jsonEntity, TimeSpan.FromDays(1));
                }
            }
            catch (Exception ex)
            {
                //log...
                new Microsoft.ApplicationInsights.TelemetryClient().TrackException(ex);
                throw;
            }

        }
        /// <summary>
        /// Add Cache key and value to Redis cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="entity"></param>
        public static void AddCache<T>(string key, T entity, int days = 1)
        {
            try
            {
                key = $"{Helper.KeyPrefix};{key}";
                if (entity != null && _cache != null)
                {
                    var jsonEntity = JsonConvert.SerializeObject(entity, Formatting.None, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    _cache.StringSetAsync(key, jsonEntity, TimeSpan.FromDays(days));
                }
            }
            catch (Exception ex)
            {
                //log...
                new Microsoft.ApplicationInsights.TelemetryClient().TrackException(ex);
                throw;
            }
        }
        /// <summary>
        /// TO remove specific kay from redis cache
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            _cache.KeyDelete(key);
        }
        /// <summary>
        /// Clear Redis DB
        /// </summary>
        public void ClearRedisDB()
        {
            //  var conn = ConnectionMultiplexer.Connect("localhost,allowAdmin=true");
            var _connectionMultiplexer = ConnectionMultiplexer.Connect(Environment.GetEnvironmentVariable("RedisCacheKey"));
            var endpoints = _connectionMultiplexer.GetEndPoints(true);
            foreach (var endpoint in endpoints)
            {
                var server = _connectionMultiplexer.GetServer(endpoint);
                //  server.FlushAllDatabases();
                server.FlushDatabase();
            }
        }


    }
}

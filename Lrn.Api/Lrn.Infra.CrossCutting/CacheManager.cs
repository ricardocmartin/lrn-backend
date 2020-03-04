using Lrn.Infra.CrossCutting.Log;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lrn.Infra.CrossCutting
{
    public static class CacheManager
    {
        private static IDistributedCache _distributedCache;
        private static readonly bool _cacheEnable = true;

        public static void Configure(IDistributedCache distributedCache)
        {
            try
            {
                _distributedCache = distributedCache ?? throw new ArgumentException("cache");
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message);
            }
        }

        public static byte[] Get(string key)
        {
            return _distributedCache?.Get(key);
        }

        public static async Task<byte[]> GetAsync(string key)
        {
            try
            {
                if (_cacheEnable)
                    return await _distributedCache?.GetAsync(key);
                else
                    return null;
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message);
                return null;
            }
        }

        public static void Remove(string key)
        {
            _distributedCache?.Remove(key);
        }

        public static async Task RemoveAsync(string key)
        {
            await _distributedCache?.RemoveAsync(key);
        }

        private static void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            if (_cacheEnable)
                _distributedCache?.Set(key, value, options);
        }

        private static async Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            if (_cacheEnable)
                await _distributedCache?.SetAsync(key, value, options);
        }

        public static async Task SetAsync(string key, byte[] value, int minutes)
        {
            var options = new DistributedCacheEntryOptions();
            options.SetSlidingExpiration(TimeSpan.FromMinutes(minutes));

            await SetAsync(key, value, options);
        }

        public static void Set(string key, byte[] value, int minutes)
        {
            var options = new DistributedCacheEntryOptions();
            options.SetSlidingExpiration(TimeSpan.FromMinutes(minutes));

            Set(key, value, options);
        }
    }
}

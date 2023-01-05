using Newtonsoft.Json;
using SSO.Core.Definitions;
using StackExchange.Redis;
using System.Text;

namespace SSO.Infrastructure.Cache
{
    public class RedisCacheStore : ICacheStore
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisCacheStore(IConnectionMultiplexer _multiplexer)
        {
            _connectionMultiplexer = _multiplexer;
        }

        public Task<T> Get<T>(string key)
        {
            var item = _connectionMultiplexer.GetDatabase().StringGet(key);
            if (!item.HasValue)
                return Task.FromResult(Activator.CreateInstance<T>());
            var deserializeObject = JsonConvert.DeserializeObject<T>(item);
            return Task.FromResult(deserializeObject);
        }

        public Task Refresh(string key)
        {
            return Task.CompletedTask;
        }

        public Task Remove(string key)
        {
            _connectionMultiplexer.GetDatabase().KeyDelete(key);
            return Task.CompletedTask;
        }

        public Task Set(string key, object item, int expirationInMinutes = 5)
        {
            var serializeObject = JsonConvert.SerializeObject(item);
            var data = Encoding.UTF8.GetBytes(serializeObject);
            _connectionMultiplexer.GetDatabase().StringSet(key, serializeObject);
            return Task.CompletedTask;
        }

        public async Task Set(string key, object item)
        {
            await Set(key, item, 5);
        }
    }
}

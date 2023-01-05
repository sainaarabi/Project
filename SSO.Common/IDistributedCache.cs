using System;

namespace SSO.Common
{
    public interface IDistributedCache
    {
        public T Get<T>(string key);
        public T Get<T>(Guid key);
        public byte[] Get(string key);
        public void Refresh(string key);
        public void Remove(string key);
        public void Set(string key, byte[] value);
    }
}

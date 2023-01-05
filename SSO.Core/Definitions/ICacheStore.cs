using System.Threading.Tasks;

namespace SSO.Core.Definitions
{
    public interface ICacheStore
    {
        Task Set(string key, object item);
        Task Refresh(string key);
        Task Remove(string key);
        Task<T> Get<T>(string key);

    }
}

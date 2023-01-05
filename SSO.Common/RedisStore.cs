using StackExchange.Redis;
using System;
using System.Configuration;

namespace SSO.Common
{
    public class RedisStore
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        static RedisStore()
        {
            //var configurationOptions = new ConfigurationOptions
            //{
            //    EndPoints = { ConfigurationManager.AppSettings["RedisIP"] },
            //    Password = ConfigurationManager.AppSettings["RedisPassword"],
            //    AbortOnConnectFail = false,
            //    AllowAdmin = true
            //};
            ConfigurationOptions configurationOptions = new ConfigurationOptions();
            if (Environment.GetEnvironmentVariable("RedisServerName") != null)
            {
                configurationOptions.EndPoints.Add(Environment.GetEnvironmentVariable("RedisServerName"));
                configurationOptions.Ssl = false;
                //configurationOptions.Password = "a`123456";
                configurationOptions.AbortOnConnectFail = false;
                configurationOptions.AllowAdmin = true;
            }
            else
            {
                configurationOptions.EndPoints.Add("127.0.0.1:6379");
                configurationOptions.Ssl = false;
                configurationOptions.Password = "a`123456";
                configurationOptions.AbortOnConnectFail = false;
                configurationOptions.AllowAdmin = true;
            }
            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }

        public static ConnectionMultiplexer Connection => LazyConnection.Value;

        public static IDatabase RedisCache => Connection.GetDatabase();
        public static IServer RedisServer => Environment.GetEnvironmentVariable("RedisServerName") != null ?
            Connection.GetServer(Environment.GetEnvironmentVariable("RedisServerName")) : Connection.GetServer("127.0.0.1:6379");
    }
}

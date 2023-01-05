using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SSO.Common; 
using StackExchange.Redis;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SSO.Core.ExtentionMethods
{
    public static class Session
    {
        private static readonly IDatabase _redis = RedisStore.RedisCache;
 
        public static bool IsDigit(this string val)
        {
            try
            {
                return Regex.IsMatch(val, @"\d");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

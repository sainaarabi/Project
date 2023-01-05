using System.Text.RegularExpressions;

namespace SSO.Api.ExtensionMethods
{
    public static class ObjectIdExtensions
    {
        public static Guid ToGuid(this string val)
        {
            if (Guid.TryParse(val, out var objectId))
                return objectId;
            return Guid.Empty;
        }
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

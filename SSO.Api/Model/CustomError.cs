using System.Text.Json;

namespace SSO.Api.Model
{
    public class CustomError
    {

        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

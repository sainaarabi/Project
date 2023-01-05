namespace SSO.Application
{
    public class Enums
   {
        public enum CommandResultStatus
        {
            Pending,
            Success,
            Fail
        }
        public enum QueryResultStatus
        {
            Pending,
           // Success,
            Fail= '0' ,
           // NotFound,
            Success = 1 ,
            Error = 500,
            UnAuthorize = 401,
            Forbidden = 403,
            NotFound = 404,
            BadRequest = 400,
            Validation = 402
        }
    }
}

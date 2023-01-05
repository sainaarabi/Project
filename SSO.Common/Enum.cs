namespace SSO.Common
{
    public enum AppExceptionBaseType
    {
        Null = -1,
        Bussiness = 400,
        Unauthorized = 401,
        NotFound = 404,
        Forbidden = 403,
        DataAccess = 406,
        ExternalService = 503,
        Internal = 500
    }
    public enum UserType
    {
        Null,
        SuperAdmin,
        Admin,
        User,
        Developer
    }
}

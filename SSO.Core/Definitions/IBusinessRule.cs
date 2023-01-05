namespace SSO.Core.Definitions
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
        string ErrorCode { get; }

    }
}

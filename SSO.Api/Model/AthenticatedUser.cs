namespace SSO.Api.Model
{
    public class AthenticatedUser
    {
        public string FullName { get; set; }
        public long UserId { get; set; }
        public string MobileNo { get; set; }
        public List<string> Roles { get; set; }
        public AthenticatedUser()
        {

        }
        public AthenticatedUser(string fullName, long userId,
            string mobileNo, List<string> roles = null)
        {
            FullName = fullName;
            UserId = userId;
            MobileNo = mobileNo;
            Roles = roles;
        }
    }
}

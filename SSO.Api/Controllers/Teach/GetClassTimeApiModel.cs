namespace SSO.Api.Controllers.Teach
{
    public class GetClassTimeApiModel
    {
        public int TeacherId { get;   set; }
        public List<int> CourseId { get;   set; }
    }
}

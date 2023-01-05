using SSO.Core.Domain.Applications;
using SSO.Application.Applications.DTO; 
namespace SSO.Application.Applications
{
    public static class Extensions
    {
        public static App AsEntity(this AppDto appDto)
            => new App();
        public static AppDto AsDto(this App app)
            => app == null ? null : new AppDto()
            {
                Title = app.Title,
                Code = app.Code,
                Link = app.Link,
               
            };
  
        public static EditApplicationMenuDto AsAppDto(this App app)
         => app == null ? null : new EditApplicationMenuDto()
         {
             Title = app.Title,
             Code = app.Code,
             Link = app.Link
         };
  
        public static List<AppDto> AsDtos(this List<App> applications)
           => applications.Select(AsDto).ToList();
        public static List<EditApplicationMenuDto> AsAppDtos(this IEnumerable<App> applications)
            => applications.Select(AsAppDto).ToList();

    }
}

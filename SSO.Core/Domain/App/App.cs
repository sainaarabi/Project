using SSO.Core.Definitions; 
using SSO.Core.Domain.Applications.Rules.Code;
using SSO.Core.Domain.Applications.Rules.Link;
using SSO.Core.Domain.Applications.Rules.Title;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.Core.Domain.Applications
{
    public class App : Entity, IAggregateRoot
    {
        public  int  ID { get; set; }
        public string Title { get; private set; }
        public string Code { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Link { get; private set; }
        public bool? IsEmailRequired { get; private set; }
    
        //public virtual ICollection<ApplicationMenu.ApplicationMenu> ApplicationMenus { get; private set; }
        //public virtual ICollection<ApplicationPolicie> ApplicationPolicies { get;  set; }
        //public virtual ICollection<CustomerApplications.CustomerApplications> CustomerApplications { get; private set; }
        //public virtual ICollection<ApplicationModule.ApplicationModule> ApplicationModules { get; private set; }
        [NotMapped]
        public string FullTitle => $"[{Code}]-{Title}";
        
        public App() { }
        public App(
                  string title
                , string code
                , DateTime createDate
                , string link)
        {
            //For Application Code
            CheckRule(new ApplicationCodeMustHaveValidLengthRule(applicationCode: code,
                                                             minLength: 0,
                                                             maxLength: 100));
            CheckRule(new ApplicationCodeMustNotContaintRegularExpressionRule(code));
            CheckRule(new ApplicationMustHaveCodeRule(code));
            Code = code;
            //For Application Link
            CheckRule(new ApplicationLinkMustHaveValidLengthRule(applicationLink: link,
                                                             minLength: 0,
                                                             maxLength: 150));
            CheckRule(new ApplicationLinkMustNotContaintRegularExpressionRule(link));
            Link = link;
            //For Application Title  
            CheckRule(new ApplicationTitleMustHaveValidLengthRule(applicationTitle: title,
                                                              minLength: 5,
                                                              maxLength: 100));
            CheckRule(new ApplicationTitleMustNotContaintRegularExpressionRule(title));
            CheckRule(new ApplicationMustHaveTitleRule(title));
            Title = title;

            CreateDate = createDate;
        }

        public void ChangeLink(string link)
        {
            CheckRule(new ApplicationLinkMustHaveValidLengthRule(applicationLink: link,
                                                            minLength: 0,
                                                            maxLength: 150));
            CheckRule(new ApplicationLinkMustNotContaintRegularExpressionRule(link));
            Link = link;
        }

        public void ChangeTitle(string title)
        {
            CheckRule(new ApplicationTitleMustHaveValidLengthRule(applicationTitle: title,
                                                     minLength: 5,
                                                     maxLength: 100));
            CheckRule(new ApplicationTitleMustNotContaintRegularExpressionRule(title));
            CheckRule(new ApplicationMustHaveTitleRule(title));
            Title = title;
        }

        public void ChangeCode(string code)
        {
            CheckRule(new ApplicationCodeMustHaveValidLengthRule(applicationCode: code,
                                                      minLength: 0,
                                                      maxLength: 100));
            CheckRule(new ApplicationCodeMustNotContaintRegularExpressionRule(code));
            CheckRule(new ApplicationMustHaveCodeRule(code));
            Code = code;
        }
        public static App Create( string title
                                , string code
                                , string link)
        {
            var application = new App(title: title
                                    , code: code
                                    , createDate: DateTime.Now
                                    , link: link);
            return application;
        }
    }
}

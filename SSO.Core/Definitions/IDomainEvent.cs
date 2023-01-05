using System;

namespace SSO.Core.Definitions
{
    public interface IDomainEvent //: INotification
    {
        DateTime OccurredOn { get; }
    }
}

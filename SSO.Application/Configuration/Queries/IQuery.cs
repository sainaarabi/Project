using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Application.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}

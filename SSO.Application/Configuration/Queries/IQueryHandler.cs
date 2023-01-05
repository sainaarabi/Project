using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Application.Configuration.Queries
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {

    }
}

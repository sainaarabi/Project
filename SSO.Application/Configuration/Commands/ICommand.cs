using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Application.Configuration.Commands
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
    } 

    public interface ICommand : IRequest
    {
    }
}

using MediatR;
using MyBookify.Domain.Abstractions;

namespace MyBookify.Application.Abstractions.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}


using MediatR;

namespace Music_app.Domain.Commons.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
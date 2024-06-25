using MediatR;

namespace Music_app.Domain.Commons.Commands;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
    Guid id { get; }
}

public interface ICommand : IRequest
{
    Guid id { get; }
}
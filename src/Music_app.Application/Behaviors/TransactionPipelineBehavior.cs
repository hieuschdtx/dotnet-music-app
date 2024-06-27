using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Music_app.Infrastructure.Data;
using Serilog.Context;

namespace Music_app.Application.Behaviors
{
    public class TransactionPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly MusicDbContext _context;
        private readonly ILogger<TransactionPipelineBehavior<TRequest, TResponse>> _logger;

        public TransactionPipelineBehavior(ILogger<TransactionPipelineBehavior<TRequest, TResponse>> logger,
            MusicDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            TResponse response = default!;

            try
            {
                if (_context.HasActiveTransaction)
                {
                    return await next();
                }

                var strategy = _context.Database.CreateExecutionStrategy();
                await strategy.ExecuteAsync(async () =>
                {
                    Guid transactionId;

                    await using var transaction = await _context.BeginTransactionAsync();
                    using (LogContext.PushProperty("TransactionContext", transaction.TransactionId))
                    {
                        _logger.LogInformation("----- Begin transaction {TransactionId} for {CommandName} ({@Command})",
                            transaction.TransactionId, typeof(TRequest).Name, request);

                        response = await next();

                        _logger.LogInformation("----- Commit transaction {TransactionId} for {CommandName}",
                            transaction.TransactionId, typeof(TRequest).Name);

                        await _context.CommitTransactionAsync(transaction, cancellationToken);
                        transactionId = transaction.TransactionId;
                    }
                });

                return response;
            }
            catch (Exception ex)
            {
                // if (_context.HasActiveTransaction)
                // {
                //     _context.RollbackTransaction();
                // }
                _logger.LogError(ex, "ERROR Handling transaction for {CommandName} ({@Command})", typeof(TRequest).Name,
                    request);
                throw;
            }
        }
    }
}
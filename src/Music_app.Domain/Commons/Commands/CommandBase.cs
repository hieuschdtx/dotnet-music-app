namespace Music_app.Domain.Commons.Commands;

public class CommandBase : ICommand
{
    public CommandBase()
    {
        id = Guid.NewGuid();
    }

    public CommandBase(Guid id)
    {
        this.id = id;
    }

    public Guid id { get; }
}

public abstract class CommandBase<TResponse> : ICommand<TResponse>
{
    protected CommandBase()
    {
        id = Guid.NewGuid();
    }

    protected CommandBase(Guid id)
    {
        this.id = id;
    }

    public Guid userId { get; private set; }
    public Guid id { get; private set; }

    public void SetUserId(Guid userId)
    {
        this.userId = userId;
    }

    public void SetId(Guid id)
    {
        this.id = id;
    }
}
using Music_app.Domain.Extensions;

namespace Music_app.Domain.Commons.Commands
{
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

        public void SetUserId(string userId)
        {
            this.userId = GuidExtension.GetGuid(userId);
        }

        public void SetId(string id)
        {
            this.id = GuidExtension.GetGuid(id);
        }
    }
}
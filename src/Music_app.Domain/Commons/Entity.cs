namespace Music_app.Domain.Commons
{
    public abstract class Entity
    {
        private Guid _id;

        public virtual Guid id
        {
            get => _id;
            protected set => _id = value;
        }

        public DateTime created_at { get; private set; }
        public DateTime modified_at { get; private set; }

        public void UpdateModifiedTime()
        {
            modified_at = DateTime.Now;
        }

        public void CreateTime()
        {
            created_at = DateTime.Now;
        }

        public static DateTime SetDateTimeWithoutTimeZone(DateTime dateTime)
        {
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
        }
        // public static DateOnly ParsedDob(string date) => DateOnly.Parse(date);
    }
}
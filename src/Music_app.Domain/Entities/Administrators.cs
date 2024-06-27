using Music_app.Domain.Commons;

namespace Music_app.Domain.Entities
{
    public class Administrators : Entity
    {
        public Administrators()
        {
            #region Generated Constructor

            #endregion
        }

        #region Generated Relationships

        public virtual Roles role_Roles { get; set; }

        #endregion

        #region Generated Properties

        public string user_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateOnly dob { get; set; }
        public bool gender { get; set; }
        public string avatar_url { get; set; }
        public string password { get; set; }
        public string permission { get; set; }
        public DateTime? lockout_end { get; set; }
        public int? access_failed_count { get; set; }
        public Guid role_id { get; set; }
        public bool lock_acc { get; set; }

        #endregion
    }
}
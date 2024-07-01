using System.Text.Json.Serialization;
using Music_app.Domain.Commons;
using Music_app.Domain.Enums;

namespace Music_app.Domain.Entities
{
    public class Roles : Entity
    {
        public Roles()
        {
            #region Generated Constructor

            role_Administrators = new HashSet<Administrators>();
            role_Users = new HashSet<Users>();

            CreateTime();
            #endregion
        }

        public Roles(Guid id, RoleTypeEnum name, string description, bool disable) : this()
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.disable = disable;
            CreateTime();
        }

        #region Generated Properties

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RoleTypeEnum name { get; private set; }
        public string description { get; private set; }
        public bool disable { get; private set; }

        #endregion

        #region Generated Relationships

        public virtual ICollection<Administrators> role_Administrators { get; set; }
        public virtual ICollection<Users> role_Users { get; set; }

        #endregion
    }
}
using Music_app.Domain.Commons;

namespace Music_app.Domain.Entities;

public class Roles : Entity
{
    private Roles()
    {
        #region Generated Constructor
        role_Administrators = new HashSet<Administrators>();
        role_Users = new HashSet<Users>();

        CreateTime();
        #endregion
    }

    #region Generated Properties
    public string name { get; private set; }
    public string description { get; private set; }
    public bool disable { get; private set; }
    #endregion

    #region Generated Relationships
    public virtual ICollection<Administrators> role_Administrators { get; set; }
    public virtual ICollection<Users> role_Users { get; set; }
    #endregion

    public Roles(Guid id, string name, string description, bool disable) : this()
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.disable = disable;
        CreateTime();
    }
}
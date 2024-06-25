namespace Music_app.Domain.Entities;

public class UsersFollowAlbums
{
    public UsersFollowAlbums()
    {
        #region Generated Constructor

        #endregion
    }

    #region Generated Properties

    public Guid user_id { get; set; }
    public Guid album_id { get; set; }

    #endregion

    #region Generated Relationships

    public virtual Albums album_Albums { get; set; }
    public virtual Users user_Users { get; set; }

    #endregion
}
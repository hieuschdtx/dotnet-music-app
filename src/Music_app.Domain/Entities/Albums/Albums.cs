using Music_app.Domain.Commons;

namespace Music_app.Domain.Entities;

public class Albums : Entity
{
    public Albums()
    {
        #region Generated Constructor

        album_AlbumsArtists = new HashSet<AlbumsArtists>();
        album_Songs = new HashSet<Songs>();
        album_UsersFollowAlbums = new HashSet<UsersFollowAlbums>();

        #endregion
    }

    #region Generated Properties

    public string name { get; set; }
    public string alias { get; set; }
    public string avatar_url { get; set; }
    public DateOnly release_date { get; set; }
    public string description { get; set; }
    public string tag { get; set; }
    public string producer { get; set; }
    public bool disable { get; set; }
    public decimal duration { get; set; }

    #endregion

    #region Generated Relationships

    public virtual ICollection<AlbumsArtists> album_AlbumsArtists { get; set; }
    public virtual ICollection<Songs> album_Songs { get; set; }
    public virtual ICollection<UsersFollowAlbums> album_UsersFollowAlbums { get; set; }

    #endregion
}
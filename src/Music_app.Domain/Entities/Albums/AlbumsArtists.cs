namespace Music_app.Domain.Entities;

public class AlbumsArtists
{
    public AlbumsArtists()
    {
        #region Generated Constructor

        #endregion
    }

    #region Generated Properties

    public Guid album_id { get; set; }
    public Guid artist_id { get; set; }

    #endregion

    #region Generated Relationships

    public virtual Albums album_Albums { get; set; }
    public virtual Artists artist_Artists { get; set; }

    #endregion
}
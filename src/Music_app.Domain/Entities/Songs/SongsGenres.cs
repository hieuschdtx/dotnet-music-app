namespace Music_app.Domain.Entities;

public class SongsGenres
{
    public SongsGenres()
    {
        #region Generated Constructor

        #endregion
    }

    #region Generated Properties

    public Guid song_id { get; set; }
    public Guid genre_id { get; set; }

    #endregion

    #region Generated Relationships

    public virtual Genres genre_Genres { get; set; }
    public virtual Songs song_Songs { get; set; }

    #endregion
}
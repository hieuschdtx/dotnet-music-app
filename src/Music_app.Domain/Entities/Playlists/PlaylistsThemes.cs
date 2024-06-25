namespace Music_app.Domain.Entities;

public class PlaylistsThemes
{
    public PlaylistsThemes()
    {
        #region Generated Constructor

        #endregion
    }

    #region Generated Properties

    public Guid playlist_id { get; set; }
    public Guid theme_id { get; set; }

    #endregion

    #region Generated Relationships

    public virtual Playlists playlist_Playlists { get; set; }
    public virtual Themes theme_Themes { get; set; }

    #endregion
}
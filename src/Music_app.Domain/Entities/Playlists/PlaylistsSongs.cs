namespace Music_app.Domain.Entities;

public class PlaylistsSongs
{
    public PlaylistsSongs()
    {
        #region Generated Constructor

        #endregion
    }

    #region Generated Properties

    public Guid playlist_id { get; set; }
    public Guid song_id { get; set; }

    #endregion

    #region Generated Relationships

    public virtual Playlists playlist_Playlists { get; set; }
    public virtual Songs song_Songs { get; set; }

    #endregion
}
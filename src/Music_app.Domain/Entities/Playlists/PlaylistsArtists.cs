namespace Music_app.Domain.Entities
{
    public class PlaylistsArtists
    {
        public PlaylistsArtists()
        {
            #region Generated Constructor

            #endregion
        }

        #region Generated Properties

        public Guid artist_id { get; set; }
        public Guid playlist_id { get; set; }

        #endregion

        #region Generated Relationships

        public virtual Artists artist_Artists { get; set; }
        public virtual Playlists playlist_Playlists { get; set; }

        #endregion
    }
}
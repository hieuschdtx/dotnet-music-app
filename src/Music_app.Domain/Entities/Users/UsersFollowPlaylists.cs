namespace Music_app.Domain.Entities
{
    public class UsersFollowPlaylists
    {
        public UsersFollowPlaylists()
        {
            #region Generated Constructor

            #endregion
        }

        #region Generated Properties

        public Guid user_id { get; set; }
        public Guid playlist_id { get; set; }

        #endregion

        #region Generated Relationships

        public virtual Playlists playlist_Playlists { get; set; }
        public virtual Users user_Users { get; set; }

        #endregion
    }
}
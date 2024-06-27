namespace Music_app.Domain.Entities
{
    public class UsersFollowArtists
    {
        public UsersFollowArtists()
        {
            #region Generated Constructor

            #endregion
        }

        #region Generated Properties

        public Guid user_id { get; set; }
        public Guid artist_id { get; set; }

        #endregion

        #region Generated Relationships

        public virtual Artists artist_Artists { get; set; }
        public virtual Users user_Users { get; set; }

        #endregion
    }
}
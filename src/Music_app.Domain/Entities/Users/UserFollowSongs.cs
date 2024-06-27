namespace Music_app.Domain.Entities
{
    public class UserFollowSongs
    {
        public UserFollowSongs()
        {
            #region Generated Constructor

            #endregion
        }

        #region Generated Properties

        public Guid user_id { get; set; }
        public Guid song_id { get; set; }

        #endregion

        #region Generated Relationships

        public virtual Songs song_Songs { get; set; }
        public virtual Users user_Users { get; set; }

        #endregion
    }
}
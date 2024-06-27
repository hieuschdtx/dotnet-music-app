using Music_app.Domain.Commons;

namespace Music_app.Domain.Entities
{
    public class Users : Entity
    {
        public Users()
        {
            #region Generated Constructor

            user_UserFollowSongs = new HashSet<UserFollowSongs>();
            user_UsersFollowAlbums = new HashSet<UsersFollowAlbums>();
            user_UsersFollowArtists = new HashSet<UsersFollowArtists>();
            user_UsersFollowPlaylists = new HashSet<UsersFollowPlaylists>();

            #endregion
        }

        #region Generated Properties

        public string user_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateOnly dob { get; set; }
        public bool gender { get; set; }
        public string avatar_url { get; set; }
        public string password { get; set; }
        public DateTime? lockout_end { get; set; }
        public int? access_failed_count { get; set; }
        public Guid role_id { get; set; }
        public bool lock_acc { get; set; }

        #endregion

        #region Generated Relationships

        public virtual Roles role_Roles { get; set; }
        public virtual ICollection<UserFollowSongs> user_UserFollowSongs { get; set; }
        public virtual ICollection<UsersFollowAlbums> user_UsersFollowAlbums { get; set; }
        public virtual ICollection<UsersFollowArtists> user_UsersFollowArtists { get; set; }
        public virtual ICollection<UsersFollowPlaylists> user_UsersFollowPlaylists { get; set; }

        #endregion
    }
}
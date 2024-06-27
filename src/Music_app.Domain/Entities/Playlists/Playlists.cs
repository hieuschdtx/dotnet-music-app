using Music_app.Domain.Commons;

namespace Music_app.Domain.Entities
{
    public class Playlists : Entity
    {
        public Playlists()
        {
            #region Generated Constructor

            playlist_PlaylistsArtists = new HashSet<PlaylistsArtists>();
            playlist_PlaylistsSongs = new HashSet<PlaylistsSongs>();
            playlist_PlaylistsThemes = new HashSet<PlaylistsThemes>();
            playlist_UsersFollowPlaylists = new HashSet<UsersFollowPlaylists>();

            #endregion
        }

        #region Generated Properties

        public string name { get; set; }
        public string alias { get; set; }
        public string avatar_url { get; set; }
        public DateOnly release_date { get; set; }
        public string description { get; set; }
        public bool disable { get; set; }
        public string tag { get; set; }

        #endregion

        #region Generated Relationships

        public virtual ICollection<PlaylistsArtists> playlist_PlaylistsArtists { get; set; }
        public virtual ICollection<PlaylistsSongs> playlist_PlaylistsSongs { get; set; }
        public virtual ICollection<PlaylistsThemes> playlist_PlaylistsThemes { get; set; }
        public virtual ICollection<UsersFollowPlaylists> playlist_UsersFollowPlaylists { get; set; }

        #endregion
    }
}
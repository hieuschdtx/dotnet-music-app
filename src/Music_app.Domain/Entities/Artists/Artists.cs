using Music_app.Domain.Commons;

namespace Music_app.Domain.Entities
{
    public class Artists : Entity
    {
        public Artists()
        {
            #region Generated Constructor

            artist_AlbumsArtists = new HashSet<AlbumsArtists>();
            artist_ArtistsSongs = new HashSet<ArtistsSongs>();
            artist_PlaylistsArtists = new HashSet<PlaylistsArtists>();
            artist_UsersFollowArtists = new HashSet<UsersFollowArtists>();

            #endregion
        }

        #region Generated Properties

        public string name { get; set; }
        public string alias { get; set; }
        public string avatar_url { get; set; }
        public string thumbnail_url { get; set; }
        public string description { get; set; }
        public int? reward { get; set; }
        public DateOnly? dob { get; set; }
        public string country { get; set; }
        public bool disable { get; set; }

        #endregion

        #region Generated Relationships

        public virtual ICollection<AlbumsArtists> artist_AlbumsArtists { get; set; }
        public virtual ICollection<ArtistsSongs> artist_ArtistsSongs { get; set; }
        public virtual ICollection<PlaylistsArtists> artist_PlaylistsArtists { get; set; }
        public virtual ICollection<UsersFollowArtists> artist_UsersFollowArtists { get; set; }

        #endregion
    }
}
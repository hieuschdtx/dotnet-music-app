using Music_app.Domain.Commons;

namespace Music_app.Domain.Entities;

public class Songs : Entity
{
    public Songs()
    {
        #region Generated Constructor

        song_ArtistsSongs = new HashSet<ArtistsSongs>();
        song_PlaylistsSongs = new HashSet<PlaylistsSongs>();
        song_SongsGenres = new HashSet<SongsGenres>();
        song_UserFollowSongs = new HashSet<UserFollowSongs>();

        #endregion
    }

    #region Generated Properties

    public string name { get; set; }
    public string alias { get; set; }
    public string avatar_url { get; set; }
    public DateOnly release_date { get; set; }
    public long view { get; set; }
    public string description { get; set; }
    public int duration { get; set; }
    public string lyric { get; set; }
    public Guid album_id { get; set; }
    public string language { get; set; }
    public bool disable { get; set; }

    #endregion

    #region Generated Relationships

    public virtual Albums album_Albums { get; set; }
    public virtual ICollection<ArtistsSongs> song_ArtistsSongs { get; set; }
    public virtual ICollection<PlaylistsSongs> song_PlaylistsSongs { get; set; }
    public virtual ICollection<SongsGenres> song_SongsGenres { get; set; }
    public virtual ICollection<UserFollowSongs> song_UserFollowSongs { get; set; }

    #endregion
}
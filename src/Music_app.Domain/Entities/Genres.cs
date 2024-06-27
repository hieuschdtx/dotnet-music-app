using Music_app.Domain.Commons;

namespace Music_app.Domain.Entities
{
    public class Genres : Entity
    {
        public Genres()
        {
            #region Generated Constructor

            genre_SongsGenres = new HashSet<SongsGenres>();

            #endregion
        }

        #region Generated Relationships

        public virtual ICollection<SongsGenres> genre_SongsGenres { get; set; }

        #endregion

        #region Generated Properties

        public string name { get; set; }
        public string alias { get; set; }
        public bool disable { get; set; }

        #endregion
    }
}
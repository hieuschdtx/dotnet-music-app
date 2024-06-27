using Music_app.Domain.Commons;

namespace Music_app.Domain.Entities
{
    public class Themes : Entity
    {
        public Themes()
        {
            #region Generated Constructor

            theme_PlaylistsThemes = new HashSet<PlaylistsThemes>();

            #endregion
        }

        #region Generated Relationships

        public virtual ICollection<PlaylistsThemes> theme_PlaylistsThemes { get; set; }

        #endregion

        #region Generated Properties

        public string name { get; set; }
        public string alias { get; set; }
        public bool disable { get; set; }

        #endregion
    }
}
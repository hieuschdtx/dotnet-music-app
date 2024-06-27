namespace Music_app.Domain.Entities
{
    public class ArtistsSongs
    {
        public ArtistsSongs()
        {
            #region Generated Constructor

            #endregion
        }

        #region Generated Properties

        public Guid artist_id { get; set; }
        public Guid song_id { get; set; }

        #endregion

        #region Generated Relationships

        public virtual Artists artist_Artists { get; set; }
        public virtual Songs song_Songs { get; set; }

        #endregion
    }
}
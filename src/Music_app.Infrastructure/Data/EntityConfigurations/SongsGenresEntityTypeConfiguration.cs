using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music_app.Domain.Entities;

namespace Music_app.Infrastructure.Data.EntityConfigurations
{
    public class SongsGenresEntityTypeConfiguration
        : IEntityTypeConfiguration<SongsGenres>
    {
        public void Configure(EntityTypeBuilder<SongsGenres> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("songs_genres", "public");

            // key
            builder.HasKey(t => new { t.song_id, t.genre_id });

            // properties
            builder.Property(t => t.song_id)
                .IsRequired()
                .HasColumnName("song_id")
                .HasColumnType("uuid");

            builder.Property(t => t.genre_id)
                .IsRequired()
                .HasColumnName("genre_id")
                .HasColumnType("uuid");

            // relationships
            builder.HasOne(t => t.song_Songs)
                .WithMany(t => t.song_SongsGenres)
                .HasForeignKey(d => d.song_id)
                .HasConstraintName("fk_songs_genres_song_id");

            builder.HasOne(t => t.genre_Genres)
                .WithMany(t => t.genre_SongsGenres)
                .HasForeignKey(d => d.genre_id)
                .HasConstraintName("fk_songs_genres_genre_id");

            #endregion
        }
    }
}
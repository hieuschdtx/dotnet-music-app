using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music_app.Domain.Entities;

namespace Music_app.Infrastructure.Data.EntityConfigurations;

public class ArtistsSongsEntityTypeConfiguration
    : IEntityTypeConfiguration<ArtistsSongs>
{
    public void Configure(EntityTypeBuilder<ArtistsSongs> builder)
    {
        #region Generated Configure

        // table
        builder.ToTable("artists_songs", "public");

        // key
        builder.HasKey(t => new { t.artist_id, t.song_id });

        // properties
        builder.Property(t => t.artist_id)
            .IsRequired()
            .HasColumnName("artist_id")
            .HasColumnType("uuid");

        builder.Property(t => t.song_id)
            .IsRequired()
            .HasColumnName("song_id")
            .HasColumnType("uuid");

        // relationships
        builder.HasOne(t => t.artist_Artists)
            .WithMany(t => t.artist_ArtistsSongs)
            .HasForeignKey(d => d.artist_id)
            .HasConstraintName("fk_artists_songs_artist_id");

        builder.HasOne(t => t.song_Songs)
            .WithMany(t => t.song_ArtistsSongs)
            .HasForeignKey(d => d.song_id)
            .HasConstraintName("fk_artists_songs_song_id");

        #endregion
    }

    #region Generated Constants

    public struct Table
    {
        public const string Schema = "public";
        public const string Name = "artists_songs";
    }

    public struct Columns
    {
        public const string artist_id = "artist_id";
        public const string song_id = "song_id";
    }

    #endregion
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music_app.Domain.Entities;

namespace Music_app.Infrastructure.Data.EntityConfigurations
{
    public class PlaylistsArtistsEntityTypeConfiguration
        : IEntityTypeConfiguration<PlaylistsArtists>
    {
        public void Configure(EntityTypeBuilder<PlaylistsArtists> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("playlists_artists", "public");

            // key
            builder.HasKey(t => new { t.artist_id, t.playlist_id });

            // properties
            builder.Property(t => t.artist_id)
                .IsRequired()
                .HasColumnName("artist_id")
                .HasColumnType("uuid");

            builder.Property(t => t.playlist_id)
                .IsRequired()
                .HasColumnName("playlist_id")
                .HasColumnType("uuid");

            // relationships
            builder.HasOne(t => t.artist_Artists)
                .WithMany(t => t.artist_PlaylistsArtists)
                .HasForeignKey(d => d.artist_id)
                .HasConstraintName("fk_playlists_artists_artist_id");

            builder.HasOne(t => t.playlist_Playlists)
                .WithMany(t => t.playlist_PlaylistsArtists)
                .HasForeignKey(d => d.playlist_id)
                .HasConstraintName("fk_playlists_artists_playlist_id");

            #endregion
        }
    }
}
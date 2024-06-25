using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music_app.Domain.Entities;

namespace Music_app.Infrastructure.Data.EntityConfigurations;

public class UsersFollowPlaylistsEntityTypeConfiguration
    : IEntityTypeConfiguration<UsersFollowPlaylists>
{
    public void Configure(EntityTypeBuilder<UsersFollowPlaylists> builder)
    {
        #region Generated Configure

        // table
        builder.ToTable("users_follow_playlists", "public");

        // key
        builder.HasKey(t => new { t.user_id, t.playlist_id });

        // properties
        builder.Property(t => t.user_id)
            .IsRequired()
            .HasColumnName("user_id")
            .HasColumnType("uuid");

        builder.Property(t => t.playlist_id)
            .IsRequired()
            .HasColumnName("playlist_id")
            .HasColumnType("uuid");

        // relationships
        builder.HasOne(t => t.user_Users)
            .WithMany(t => t.user_UsersFollowPlaylists)
            .HasForeignKey(d => d.user_id)
            .HasConstraintName("fk_users_follow_playlists_user_id");

        builder.HasOne(t => t.playlist_Playlists)
            .WithMany(t => t.playlist_UsersFollowPlaylists)
            .HasForeignKey(d => d.playlist_id)
            .HasConstraintName("fk_users_follow_playlists_playlist_id");

        #endregion
    }
}
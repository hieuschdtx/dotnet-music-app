using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music_app.Domain.Entities;

namespace Music_app.Infrastructure.Data.EntityConfigurations
{
    public class UsersFollowArtistsEntityTypeConfiguration
        : IEntityTypeConfiguration<UsersFollowArtists>
    {
        public void Configure(EntityTypeBuilder<UsersFollowArtists> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("users_follow_artists", "public");

            // key
            builder.HasKey(t => new { t.user_id, t.artist_id });

            // properties
            builder.Property(t => t.user_id)
                .IsRequired()
                .HasColumnName("user_id")
                .HasColumnType("uuid");

            builder.Property(t => t.artist_id)
                .IsRequired()
                .HasColumnName("artist_id")
                .HasColumnType("uuid");

            // relationships
            builder.HasOne(t => t.user_Users)
                .WithMany(t => t.user_UsersFollowArtists)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("fk_users_follow_artists_user_id");

            builder.HasOne(t => t.artist_Artists)
                .WithMany(t => t.artist_UsersFollowArtists)
                .HasForeignKey(d => d.artist_id)
                .HasConstraintName("fk_users_follow_artists_artist_id");

            #endregion
        }
    }
}
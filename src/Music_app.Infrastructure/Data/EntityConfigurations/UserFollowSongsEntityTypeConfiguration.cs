using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music_app.Domain.Entities;

namespace Music_app.Infrastructure.Data.EntityConfigurations
{
    public class UserFollowSongsEntityTypeConfiguration
        : IEntityTypeConfiguration<UserFollowSongs>
    {
        public void Configure(EntityTypeBuilder<UserFollowSongs> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("user_follow_songs", "public");

            // key
            builder.HasKey(t => new { t.user_id, t.song_id });

            // properties
            builder.Property(t => t.user_id)
                .IsRequired()
                .HasColumnName("user_id")
                .HasColumnType("uuid");

            builder.Property(t => t.song_id)
                .IsRequired()
                .HasColumnName("song_id")
                .HasColumnType("uuid");

            // relationships
            builder.HasOne(t => t.user_Users)
                .WithMany(t => t.user_UserFollowSongs)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("fk_user_follow_songs_user_id");

            builder.HasOne(t => t.song_Songs)
                .WithMany(t => t.song_UserFollowSongs)
                .HasForeignKey(d => d.song_id)
                .HasConstraintName("fk_user_follow_songs_song_id");

            #endregion
        }
    }
}
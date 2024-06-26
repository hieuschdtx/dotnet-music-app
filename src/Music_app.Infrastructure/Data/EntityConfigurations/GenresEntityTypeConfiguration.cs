using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music_app.Domain.Entities;

namespace Music_app.Infrastructure.Data.EntityConfigurations;

public class GenresEntityTypeConfiguration
    : IEntityTypeConfiguration<Genres>
{
    public void Configure(EntityTypeBuilder<Genres> builder)
    {
        #region Generated Configure

        // table
        builder.ToTable("genres", "public");

        // key
        builder.HasKey(t => t.id);

        // properties
        builder.Property(t => t.id)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("uuid");

        builder.Property(t => t.name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("character varying(255)")
            .HasMaxLength(255);

        builder.Property(t => t.alias)
            .IsRequired()
            .HasColumnName("alias")
            .HasColumnType("character varying(255)")
            .HasMaxLength(255);

        builder.Property(t => t.disable)
            .IsRequired()
            .HasColumnName("disable")
            .HasColumnType("boolean");

        builder.Property(t => t.created_at)
            .HasColumnName("created_at")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(t => t.modified_at)
            .HasColumnName("modified_at")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // relationships

        #endregion
    }
}
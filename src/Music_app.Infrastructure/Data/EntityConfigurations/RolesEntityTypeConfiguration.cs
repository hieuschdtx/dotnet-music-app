using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music_app.Domain.Entities;
using Music_app.Domain.Enums;

namespace Music_app.Infrastructure.Data.EntityConfigurations
{
    public class RolesEntityTypeConfiguration
        : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("roles", "public");

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
                .HasConversion(v => v.ToString(), v => (RoleTypeEnum)System.Enum.Parse(typeof(RoleTypeEnum), v))
                .HasColumnType("character varying(255)");

            builder.Property(t => t.description)
                .HasColumnName("description")
                .HasColumnType("character varying(255)")
                .HasMaxLength(255)
                .HasDefaultValueSql("'Đang cập nhật'::character varying");

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
}
﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Music_app.Domain.Entities;

namespace Music_app.Infrastructure.Data.EntityConfigurations
{
    public class AdministratorsEntityTypeConfiguration :
        IEntityTypeConfiguration<Administrators>
    {
        public void Configure(EntityTypeBuilder<Administrators> builder)
        {
            #region Generated Configure

            // table
            builder.ToTable("administrators", "public");

            // key
            builder.HasKey(t => t.id);

            // properties
            builder.Property(t => t.id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("uuid");

            builder.Property(t => t.user_name)
                .IsRequired()
                .HasColumnName("user_name")
                .HasColumnType("character varying(255)")
                .HasMaxLength(255);

            builder.Property(t => t.email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("character varying(255)")
                .HasMaxLength(255);

            builder.Property(t => t.phone_number)
                .IsRequired()
                .HasColumnName("phone_number")
                .HasColumnType("character varying(11)")
                .HasMaxLength(11);

            builder.Property(t => t.dob)
                .IsRequired()
                .HasColumnName("dob")
                .HasColumnType("date");

            builder.Property(t => t.gender)
                .IsRequired()
                .HasColumnName("gender")
                .HasColumnType("boolean");

            builder.Property(t => t.avatar_url)
                .HasColumnName("avatar_url")
                .HasColumnType("text");

            builder.Property(t => t.password)
                .IsRequired()
                .HasColumnName("password")
                .HasColumnType("text");

            builder.Property(t => t.permission)
                .IsRequired()
                .HasColumnName("permission")
                .HasColumnType("jsonb");

            builder.Property(t => t.lockout_end)
                .HasColumnName("lockout_end")
                .HasColumnType("timestamp without time zone");

            builder.Property(t => t.access_failed_count)
                .HasColumnName("access_failed_count")
                .HasColumnType("integer")
                .HasDefaultValueSql("0");

            builder.Property(t => t.created_at)
                .HasColumnName("created_at")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(t => t.modified_at)
                .HasColumnName("modified_at")
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(t => t.role_id)
                .IsRequired()
                .HasColumnName("role_id")
                .HasColumnType("uuid");

            builder.Property(t => t.lock_acc)
                .IsRequired()
                .HasColumnName("lock_acc")
                .HasColumnType("boolean");

            // relationships
            builder.HasOne(t => t.role_Roles)
                .WithMany(t => t.role_Administrators)
                .HasForeignKey(d => d.role_id)
                .HasConstraintName("fk_administrators_role_id");

            #endregion
        }
    }
}
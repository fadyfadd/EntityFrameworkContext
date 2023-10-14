﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkContext;

public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.ToTable("actor");
        builder.HasKey(a=>a.ActorId);
        builder.Property(a=>a.ActorId).HasColumnName("actor_id").ValueGeneratedOnAdd();
        builder.Property(a=>a.FirstName).HasColumnName("first_name");
        builder.Property(a=>a.LastName).HasColumnName("last_name");
        builder.Property(a=>a.LastUpdate).HasColumnName("last_update");
    }
}
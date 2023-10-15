using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkContext;

public class ActorFilmConfiguration : IEntityTypeConfiguration<ActorFilm>
{
    public void Configure(EntityTypeBuilder<ActorFilm> builder)
    {
        builder.ToTable("film_actor");
        builder.HasKey(af=>new {af.FilmId , af.ActorId});
        builder.Property(af=>af.FilmId).HasColumnName("film_id");
        builder.Property(af=>af.ActorId).HasColumnName("actor_id");
        builder.Property(af=>af.LastUpdate).HasColumnName("last_update");
    }
}

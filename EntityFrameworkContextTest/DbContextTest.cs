using EntityFrameworkContext;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkContextTest;

public class ApplicationTest : IDisposable
{
    private String sakilaConnectionString = "Server=127.0.0.1;Database=sakila;uid=root;pwd=quLRYP22;";
    private SakilaDataContext sakilaDataContext;
    public ApplicationTest()
    {
        this.sakilaDataContext = new SakilaDataContext(this.sakilaConnectionString);
    }

    [Fact]
    public void FilmsDbSet()
    {
            var films = this.sakilaDataContext.Films.ToList();
    }

    [Fact]
    public void ActorFilmsDbSet()
    {
        var actorFilms = this.sakilaDataContext.ActorFilms.ToList();
    }

    [Fact]
    public void ActorsDbSet()
    {
        List<Actor> actors = this.sakilaDataContext.Actors.ToList();
    }

    [Fact]
    public void GetActorsWithFilms()
    {
        List<Actor> actors = sakilaDataContext.Actors.Include(a=>a.ActorFilms).ThenInclude(af=>af.Film).ToList();
    }

    [Fact]
    public void GetFilmsWithActors() {
        List<Film> films = sakilaDataContext.Films.Include(f => f.ActorFilms).ThenInclude(af => af.Actor).ToList();
    }

    public void Dispose()
    {
        if (this.sakilaDataContext != null)
            this.sakilaDataContext.Dispose();
    }
}

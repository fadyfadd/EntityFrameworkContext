using EntityFrameworkContext;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkContextTest;

public class ApplicationTest : IDisposable
{
    private string sakilaConnectionString = "Server=127.0.0.1;Database=sakila;uid=root;pwd=quLRYP22;";
    private SakilaDataContext sakilaDataContext;
    public ApplicationTest()
    {
        this.sakilaDataContext = new SakilaDataContext(this.sakilaConnectionString);
    }

    private void Cleanup() {
            
            var a = sakilaDataContext.ActorFilms.Where(af=>af.ActorId > 200 || af.FilmId > 1000);
            sakilaDataContext.RemoveRange(a);
            var actors = sakilaDataContext.Actors.Where(a=>a.ActorId > 200);
            var films = sakilaDataContext.Films.Where(f=>f.FilmId > 1000);
            sakilaDataContext.RemoveRange(actors);
            sakilaDataContext.RemoveRange(films);
            sakilaDataContext.SaveChanges(); 
    }
    [Fact]
    public void FilmsDbSet()
    {       Cleanup(); 
            var films = this.sakilaDataContext.Films.ToList();
    }

    [Fact]
    public void ActorFilmsDbSet()
    {      Cleanup();
           var filmActors = this.sakilaDataContext.ActorFilms
            .Include(af=>af.Actor)
            .Include(af=>af.Film).ToList();
    }

    [Fact]
    public void ActorsDbSet()
    {
        Cleanup();
        List<Actor> actors = this.sakilaDataContext.Actors.ToList();
    }

    [Fact]
    public void GetActorsWithFilms()
    {
        Cleanup();
        List<Actor> actors = sakilaDataContext.Actors.Include(a=>a.ActorFilms).ThenInclude(af=>af.Film).ToList();
    }

    [Fact]
    public void GetFilmsWithActors() {
        Cleanup();
        List<Film> films = sakilaDataContext.Films.Include(f => f.ActorFilms).ThenInclude(af => af.Actor).ToList();
    }

    [Fact]
    public void InsertActor() {
        Cleanup();
        Actor actor = new Actor() { ActorId = 0 , FirstName="John" , LastName="Zirotti"};
        sakilaDataContext.Add(actor);
        sakilaDataContext.SaveChanges();
    }

    [Fact]
    public void InsertActorAndFilms() {

        Actor actor = new Actor() { ActorId = 0 , FirstName="John" , LastName="Zirotti"};
       
        Film film = new Film() { FilmId = 0 , Description = "for kids" , LanguageId = 1
        , Length = 30 , OriginalLanguageId = 1 , Rating = "R" , RentalDuration=4 ,  Title = "John and the Giants",
        ReleaseYear = 1996 , RentalRate = 10 , ReplacementCost = 10 , SpecialFeatures = "Trailers" , LastUpdate = DateTime.Now};

        ActorFilm actorFilm = new ActorFilm() {Actor = actor , Film = film , LastUpdate = DateTime.Now};
        sakilaDataContext.ActorFilms.Add(actorFilm);
        
        sakilaDataContext.SaveChanges();

    }

    [Fact]
    public void InsertFilm() {
          Cleanup();
          Film film = new Film() { FilmId = 0 , Description = "for kids" , LanguageId = 1
          , Length = 30 , OriginalLanguageId = 1 , Rating = "R" , RentalDuration=4 ,  Title = "John and the Giants",
          ReleaseYear = 1996 , RentalRate = 10 , ReplacementCost = 10 , SpecialFeatures = "Trailers" , LastUpdate = DateTime.Now};
          sakilaDataContext.Add(film);
          sakilaDataContext.SaveChanges(); 
    }

    public void Dispose()
    {
            this.sakilaDataContext.Dispose();
    }
}

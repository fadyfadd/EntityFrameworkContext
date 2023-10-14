using EntityFrameworkContext;

namespace EntityFrameworkContextTest;

public class SakilaDataContextTest : IDisposable
{

    private String sakilaConnectionString = "Server=127.0.0.1;Database=sakila;uid=root;pwd=quLRYP22;";
    private SakilaDataContext sakilaDataContext;

    public SakilaDataContextTest() {
        sakilaDataContext = new SakilaDataContext(this.sakilaConnectionString);
    } 

    [Fact]
    public void ActorsDbSet()
    {
        var actors = sakilaDataContext.Actors;
        Console.WriteLine(actors);
    }

    [Fact]
    public void ActorFilmsDbSet()
    {
       var actorFilms = sakilaDataContext.ActorFilms;
        Console.WriteLine(actorFilms);
    }

    public void Dispose()
    {
        if (sakilaDataContext != null)
            this.sakilaDataContext.Dispose();
    }
}

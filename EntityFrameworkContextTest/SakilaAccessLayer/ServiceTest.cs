using EntityFrameworkContext;

namespace EntityFrameworkContextTest;

public class ServiceTest : IDisposable
{

    private String sakilaConnectionString = "Server=127.0.0.1;Database=sakila;uid=root;pwd=quLRYP22;";
    private SakilaDataContext sakilaDataContext;
    public ServiceTest() {
        this.sakilaDataContext = new SakilaDataContext(this.sakilaConnectionString);
    }

    public void Dispose()
    {
        if (sakilaDataContext != null)
            this.sakilaDataContext.Dispose();   
    }

    [Fact]
    public void GetActors_1() {
       var list = new Service(this.sakilaDataContext).GetActors();
       Console.WriteLine(list);

    }




}

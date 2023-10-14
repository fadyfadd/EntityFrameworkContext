using System.Dynamic;

namespace EntityFrameworkContext;

public class ActorFilm
{
   public Int32 ActorId {set; get;} 
   public Int32 FilmId {set; get;}
   public DateTime LastUpdate {set; get;}
   public Actor? Actor {set; get;}= null; 
   public Film? Film  {set; get;} = null;
}

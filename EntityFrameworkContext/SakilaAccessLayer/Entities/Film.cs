using Org.BouncyCastle.Utilities;

namespace EntityFrameworkContext;

public class Film
{
    public Int32? FilmId { set; get; }
    public String? Title { set; get; }
    public String? Description { set; get; }
    public Int32? ReleaseYear { set; get; }
    public Int32? LanguageId { set; get; }
    public Int32? OriginalLanguageId { set; get; }
    public Int32? RentalDuration { set; get; }
    public Int32? RentalRate { set; get; }
    public Int32? Length { set; get; }
    public Int32? ReplacementCost { set; get; }
    public String? Rating { set; get; }
    //public String? SpecialRating { set; get; }
    public String? SpecialFeatures {set; get;}
    public DateTime LastUpdate { set; get; }
}

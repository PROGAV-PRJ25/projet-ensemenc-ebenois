public class Magasin
{
    public List<Legume> ListLegumes {get; set;}

    public Magasin()
    {
        ListLegumes = new List<Legume>();
        ListLegumes.Add(new Patate(1));
        ListLegumes.Add(new Champignon(1));
    }
}
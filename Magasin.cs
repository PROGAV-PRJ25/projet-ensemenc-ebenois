public class Magasin
{
    public List<Plante> ListLegumes {get; set;}

    public Magasin()
    {
        ListLegumes = new List<Plante>();
        ListLegumes.Add(new Ail(1));
        ListLegumes.Add(new Carotte(1));
        ListLegumes.Add(new Champignon(1));
        ListLegumes.Add(new Mais(1));
        ListLegumes.Add(new Oignon(1));
        ListLegumes.Add(new Patate(1));
        ListLegumes.Add(new Piment(1));
        ListLegumes.Add(new Tomate(1));
    }
}
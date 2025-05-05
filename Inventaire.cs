public class Inventaire
{
    public int Argent;
    public List<Legume> ListLegumes {get; set;}

    public Inventaire()
    {
        ListLegumes = new List<Legume>();
        Argent = 200;
    }

    public void RetirerLegume(Legume legume)
    {
        ListLegumes.Remove(legume);
    }

    //Ajouter dans l'inventaire un légume
    public void Ajouter(string nom,int nombre)
    {
        if (TrouverLegume(nom)!=null)
        {
            TrouverLegume(nom).Graine+=nombre;
        }
        else 
        {
            switch (nom)
                {
                    case "Patate":
                        ListLegumes.Add(new Patate(nombre));
                        break;
                    case "Champignon":
                        ListLegumes.Add(new Champignon(nombre));
                        break;
                }
            }
    }

    public Legume TrouverLegume(string nom)
    {
        foreach (Legume legume in ListLegumes)
        {
            if(legume.Nom==nom && legume.Graine!=0) {return legume;}
        }
        return null;
    }

    public override string ToString(){
        string message = $"▪ Argent: {Argent}$\n";
        return message;
    }
}
public class Inventaire
{
    public int Argent;
    public List<Plante> ListLegumes;
    public int Engrais;
    public int Serre;
    public Inventaire()
    {
        ListLegumes = new List<Plante>();
        Argent = 50;
        Engrais = 3;
        Serre = 3;
    }

    public void RetirerLegume(Plante legume)
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
                case "Tomate":
                    ListLegumes.Add(new Tomate(nombre));
                    break;
                case "Ail":
                    ListLegumes.Add(new Ail(nombre));
                    break;
                case "Carotte":
                    ListLegumes.Add(new Carotte(nombre));
                    break;
                case "Maïs":
                    ListLegumes.Add(new Mais(nombre));
                    break;
                case "Oignon":
                    ListLegumes.Add(new Oignon(nombre));
                    break;
                case "Piment":
                    ListLegumes.Add(new Piment(nombre));
                    break;                     
                }
            }
    }

    public Plante TrouverLegume(string nom)
    {
        foreach (Plante legume in ListLegumes)
        {
            if(legume.Nom==nom && legume.Graine!=0) {return legume;}
        }
        return null;
    }

    public override string ToString()
    {
        string message = $"▪ Argent: {Argent}$\n▪ Engrais: {Engrais}$\n";
        return message;
    }
}
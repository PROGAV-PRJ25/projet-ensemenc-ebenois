public class Inventaire
{
    public int Argent {get; private set;}
    public List<Legume> ListLegumes {get; set;}

    public Inventaire()
    {
        ListLegumes = new List<Legume>();
        Argent = 20;
    }

    public void AfficherLegumes(int size, int titreLength)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("▌");
        for (int i = 0; i < size + titreLength; i++) {Console.Write(" ");}
        Console.Write("▐\n");
        if (ListLegumes.Count()!=0)
        {
            foreach (Legume legume in ListLegumes)
            {
                Console.Write("▌");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" ▪ Type: {legume.Nom} {legume.Image[0]} - Nombre de graines: {legume.Graine}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                for (int i = 0; i < size + titreLength - ($" ▪ Type: {legume.Nom} {legume.Image[0]} - Nombre de graines: {legume.Graine}")?.Length; i++) {Console.Write(" ");}
                Console.Write("▐\n");
            }
        }
        else
        {
            Console.Write("▌   ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Vous n'avez rien dans votre inventaire");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < size + titreLength - $"   Vous n'avez rien dans votre inventaire"?.Length; i++) {Console.Write(" ");}
            Console.Write("▐\n");
        }
    }

    public void RetirerLegume(Legume legume)
    {
        ListLegumes.Remove(legume);
    }

    public bool AGraine(string nom)
    {
        bool aGraine = false;
        foreach (Legume legume in ListLegumes)
        {
            if(legume.Nom==nom && legume.Graine!=0) {aGraine=true;}
        }
        return(aGraine);
    }

    //Ajouter dans l'inventaire un légume
    public void Ajouter(string nom,int nombre)
    {
        bool aGraine = false;
        foreach (Legume legume in ListLegumes)
        {
            if(legume.Nom==nom && legume.Graine!=0) {aGraine=true;}
        }
        if (aGraine)
        {
            foreach (Legume legume in ListLegumes)
                {
                    if(legume.Nom==nom && legume.Graine!=0) {legume.Graine+=nombre;}
                }
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
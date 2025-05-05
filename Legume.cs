public abstract class Legume
{
    public abstract string[] Image { get;}
    public abstract int Prix { get;}
    public abstract string GoûtTerrain { get;}
    public abstract int TempératureDePousse { get;}
    public int NombreDeFuits { get;}
    public int NombreDeJourNonArrosé { get; private set;}
    public abstract string Nom { get;}
    public abstract int TempsCroissance { get;}
    public int Croissance {get; private set;}
    public string? Etat {get; private set;}
    public bool Arrosé {get; private set;}
    public bool Engrais {get; private set;}
    public int Graine;
    public Legume(int nombre)
    {
        Random rand = new Random();
        NombreDeFuits = rand.Next(1, 5);
        NombreDeJourNonArrosé=0;
        Croissance=0;
        Graine=nombre;
        UpdateEtat();
        Arrosé = false;
    }
    public void UpdateEtat()
    {
        if (Croissance==0)
        {
            Etat="graine";
        }
        else if (Croissance>=TempsCroissance)
        {
            Etat="adulte";
        }
        else
        {
            Etat="jeune";
        }
    }
    public virtual string EtatImage() {return "";}
    public virtual string[] ActionPossible() {return [""];}
    public void Grandir(Terrain terrain)
    {
        if (Croissance < TempsCroissance)
        {
            // Si le légume est arrosé, il grandit
            if (Arrosé)
            {
                Croissance += 1;  // Incrémentation de la croissance
                // Si le terrain correspond à son goût, il grandit encore plus
                if (terrain.Type == GoûtTerrain)
                {
                    Croissance += 1;  // Incrémentation supplémentaire si le terrain lui convient
                }
                // Si le légume a reçu de l'engrais, il grandit encore plus
                if (Engrais && Croissance < TempsCroissance)
                {
                        Croissance += 1;  // Incrémentation supplémentaire si engrais  
                }
               
            }
            else
            {
                if(NombreDeJourNonArrosé>=3)
                {
                    terrain.Deterrer();
                    NombreDeJourNonArrosé=0;
                } else{
                    NombreDeJourNonArrosé+=1;
                }
            }
        }
        
        // Mise à jour de l'état du légume après la croissance
        UpdateEtat();

        // Réinitialisation des états
        Engrais = false;
        Arrosé = false;
    }

    public void Arroser()
    {
        Arrosé = true;
    }
    public void MettreEngrais()
    {
        Engrais = true;
    }

    /*public string Image()
    {
        string image="";
        switch (Type)
        {
            case "brocoli":
                image = "🥦";
                break;
            case "tomate":
                image = "🍅";
                break;
            case "maïs":
                image = "🌽";
                break;
            case "aubergine":
                image = "🍆";
                break;
            case "patate":
                image = "🥔";
                break;
            case "carotte":
                image = "🥕";
                break;
            case "champignon":
                image = "🍄";
                break;
            case "pousse":
                image = "🌱";
                break;
        }
        return image;
    }*/
}
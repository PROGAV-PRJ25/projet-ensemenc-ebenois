public abstract class Plante
{
    public abstract string[] Image { get; }
    public abstract int Prix { get; }
    public int JourAvantPourri = 1;
    public abstract string GoûtTerrain { get; }
    public abstract int TempératureDePousse { get; }
    public abstract bool Vivace { get; }
    public abstract int NombreDeFuits { get; }
    public int NombreDeJourNonArrosé { get; private set; }
    public abstract string Nom { get; }
    public abstract int TempsCroissance { get; }
    public int Croissance { get; private set; }
    public string? Etat { get; private set; }
    public bool Arrosé { get; private set; }
    public bool Engrais { get; private set; }
    public bool Protege { get; private set; }
    public int Graine;
    public Plante(int nombre)
    {
        NombreDeJourNonArrosé = 0;
        Croissance = 0;
        Graine = nombre;
        UpdateEtat();
        Arrosé = false;
        Engrais = false;
        Protege = false;
    }
    public void UpdateEtat()
    {
        if (Croissance == 0)
        {
            Etat = "graine";
        }
        else if (Croissance >= TempsCroissance)
        {
            Etat = "adulte";
        }
        else
        {
            Etat = "jeune";
        }
    }
    public virtual string EtatImage() { return ""; }
    public string[] ActionPossible(Inventaire inventaire, Climat climat)
    {
        if (inventaire.Engrais != 0)
        {
            if (climat.Urgence == true)
            {
                return ["Deterrer", "Arroser", "Engrais","Proteger", "Recolter", "Faire du bruit","Quitter"];
            }
            else
            {
                return ["Deterrer", "Arroser", "Engrais", "Recolter", "Faire du bruit","Quitter"];
            }
        }
        else
        {
            if (climat.Urgence == true)
            {
                return ["Deterrer", "Arroser","Proteger", "Faire du bruit", "Recolter","Quitter"];
            }
            else
            {
                return ["Deterrer", "Arroser", "Recolter", "Faire du bruit","Quitter"];
            }
        }
    }
    public void Grandir(Terrain terrain, Climat climat)
    {
        if (Croissance == TempsCroissance)
        {
            if (JourAvantPourri == 0)
            {
                terrain.Deterrer();
                JourAvantPourri = 1;
            }
            else
            {
                JourAvantPourri -= 1;
            }
        }
        if (Croissance < TempsCroissance)
        {
            // Si le légume est arrosé, il grandit
            if (Arrosé)
            {
                Croissance += 1;  // Incrémentation de la croissance
                                  // Si le terrain correspond à son goût, il grandit encore plus
                if (terrain.Type == GoûtTerrain && Croissance < TempsCroissance)
                {
                    Croissance += 1;  // Incrémentation supplémentaire si le terrain lui convient
                }
                if (climat.Temperature[climat.SaisonActuelle] > TempératureDePousse - 3 && climat.Temperature[climat.SaisonActuelle] < TempératureDePousse + 3 && Croissance < TempsCroissance)
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
                if (NombreDeJourNonArrosé > 1)
                {
                    terrain.Deterrer();
                    NombreDeJourNonArrosé = 0;
                }
                else
                {
                    NombreDeJourNonArrosé += 1;
                }
            }
        }

        // Mise à jour de l'état du légume après la croissance
        UpdateEtat();

        // Réinitialisation des états
        Engrais = false;
        Arrosé = false;
        Protege = false;
    }

    public void Arroser()
    {
        Arrosé = true;
    }

    public void Recolter()
    {
        NombreDeJourNonArrosé = 0;
        Croissance = 0;
        UpdateEtat();
        Arrosé = false;
        Engrais = false;
        Protege = false;
    }
    public void MettreEngrais()
    {
        Engrais = true;
    }
    public void Proteger()
    {
        Protege = true;
    }
}
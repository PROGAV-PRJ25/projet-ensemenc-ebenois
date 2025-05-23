public abstract class Terrain
{
    public bool Rongeur { get; set; }
    public Plante Legume { get; set; }
    public int Pluviometrie { get; protected set; }
    public abstract string Type { get; }
    public abstract string Image { get; }
    public int[] Coordonnées { get; private set; }

    public Terrain(int[] coordonnées)
    {
        Coordonnées = coordonnées;
        Legume = null;
        Rongeur = false;
    }
    //Le terrain a 1chance sur 5 d'être attaqué par un rongeur
    public void Attaque()
    {
        Random rand = new Random();
        switch (rand.Next(5))
        {
            case 1:
                Rongeur = true;
                break;
        }
    }
    public override string ToString()
    {
        string message = "";
        if (Legume == null || Legume.Etat == "graine")
        {
            message = Image;
        }
        else
        {
            message = Legume.EtatImage() + " ";
        }
        return message.PadRight(2);
    }
    //Plante un légume sur le terrain
    public void Planter(string legume)
    {
        switch (legume)
        {
            case "Patate":
                Legume = new Patate(0);
                break;
            case "Champignon":
                Legume = new Champignon(0);
                break;
            case "Tomate":
                Legume = new Tomate(0);
                break;
            case "Ail":
                Legume = new Ail(0);
                break;
            case "Oignon":
                Legume = new Oignon(0);
                break;
            case "Piment":
                Legume = new Piment(0);
                break;
            case "Carotte":
                Legume = new Carotte(0);
                break;
            case "Maïs":
                Legume = new Mais(0);
                break;
        }
    }
    //Vérifie si le terrain est libre
    public bool EmplacementLibre()
    {
        if (Legume != null) { return (false); }
        else { return (true); }
    }
    //Arrose un légume
    public void Arroser()
    {
        Legume.Arroser();
    }
    //Deterre un légume
    public void Deterrer()
    {
        Legume = null;
    }
    //Recolte le légume
    public void Recolter()
    {
        if (!Legume.Vivace)
        {
            Legume = null;
        }
        else
        {
            Legume.Recolter();
        }
    }
    //Protege le légume
    public void Proteger()
    {
        Legume.Proteger();
    }
    //Met de l'engrais sur un légume
    public void MettreEngrais()
    {
        Legume.MettreEngrais();
    }
}

public abstract class Terrain
{
    public Legume Legume {get; set;}
    public int Pluviometrie {get; protected set;}
    public abstract string Type { get;}
    public abstract string Image { get;}
    public int[] Coordonnées {get; private set;}

    public Terrain(int[] coordonnées){
        Coordonnées = coordonnées;
        Legume = null;
    }

    public override string ToString()
    {
        string message = "";
        if (Legume==null || Legume.Etat=="graine")
        {
            message=Image;
        } 
        else 
        {
            message=Legume.EtatImage();
        }
        return message.PadRight(2);
    }

    public void Planter(string legume)
    {
        switch (legume)
        {
            case "Patate":
                Legume =new Patate(0);
                break;
            case "Champignon":
                Legume =new Champignon(0);
                break;
        }
    }

    public bool EmplacementLibre()
    {
        if(Legume!=null) {return(false);}
        else {return(true);}
    }

     //Arrose un légume
    public void Arroser()
    {
        Legume.Arroser();
    }

    //Deterre un légume
    public void Deterrer()
    {
        Legume=null;
    }

    //Met de l'engrais sur un légume
    public void MettreEngrais()
    {
        Legume.MettreEngrais();
    }


}

public abstract class Terrain
{
    public Legume Legume {get; set;}
    public int Pluviometrie {get; protected set;}
    public abstract string Type { get;}
    public abstract string Image { get;}
    public bool Engrais {get; protected set;}
    public int[] Coordonnées {get; private set;}

    public Terrain(int[] coordonnées){
        Coordonnées = coordonnées;
        Engrais=false;
    }
    public override string ToString()
    {
        string message = "";
        if (Legume==null){
            message=Image;
        } else {
            message=Legume.EtatImage();
        }
        return message;
    }
}
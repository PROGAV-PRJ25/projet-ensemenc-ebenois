public abstract class Legume
{
    public abstract string[] Image { get;}
    public abstract string Nom { get;}
    public abstract int TempsCroissance { get;}
    public int X {get; protected set;}
    public int Y {get; protected set;}
    public int Croissance {get; private set;}
    public string? Etat {get; private set;}
    public int Graine;
    public Legume(int x,int y, int nombre)
    {
        X=x;
        Y=y;
        Croissance=0;
        Graine=nombre;
        UpdateEtat();
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
    public void Grandir(int engrais)
    {
        if (Croissance<TempsCroissance){
            Croissance+=1+engrais;
            UpdateEtat();
        }
    }
    public override string ToString()
    {
        string message = "";
        if (Graine==0) {message = $" ▪ Coordonnées: ({X},{Y}) - Type: {Nom} {Image[0]} - Croissance: {Croissance*100/TempsCroissance} % - Etat: {Etat}";}
        else {message = $" ▪ Type: {Nom} {Image[0]} - Nombre de graines: {Graine}";}
        return message;
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
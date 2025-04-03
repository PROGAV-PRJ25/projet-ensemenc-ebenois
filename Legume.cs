public abstract class Legume
{
    public abstract string Image { get;}
    public int X {get; private set;}
    public int Y {get; private set;}
    public int Croissance {get; private set;}
    public string Etat {get; private set;}
    public Legume(int x,int y)
    {
        X=x;
        Y=y;
        Croissance=100;
        Etat=UpdateEtat();
    }
    public string UpdateEtat()
    {
        if (Croissance==0)
        {
            return("graine");
        }
        else if (Croissance==100)
        {
            return("adulte");
        }
        else
        {
            return("jeune");
        }
    }
    public virtual string EtatImage()
    {
        string image ="";
        return image;
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
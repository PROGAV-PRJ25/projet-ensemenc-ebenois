public abstract class Legume
{
    public abstract string[] ActionPossible { get;}
    public abstract string[] Image { get;}
    public abstract string Nom { get;}
    public abstract int TempsCroissance { get;}
    public int Croissance {get; private set;}
    public string? Etat {get; private set;}
    public bool Arrosé {get; private set;}
    public bool Engrais {get; private set;}
    public int Graine;
    public Legume(int nombre)
    {
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
    public void Grandir()
    {
        if (Croissance<TempsCroissance && Arrosé==true){
            if (Engrais && Croissance+1<TempsCroissance) {Croissance+=2;}
            else {Croissance+=1;}
            UpdateEtat();
            Engrais=false;
            Arrosé=false;
        }
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
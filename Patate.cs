public class Patate:Legume
{
    public override string Image => "🥔";
    string Name = "Patate";
    public Patate(int x,int y):base( x, y)
    {
    }
    public override string EtatImage()
    {
        string image ="";
        switch (Croissance)
        {
            case 0:
                image ="🟫";
                break;
            case >0:
                image ="🌱";
                break;
        }
        return image;
    }
    public override string ToString()
    {
        string message = $"Coordonnées: ({X},{Y}) - Type: {Name} {Image} - Croissance: {Croissance} % - Etat: {Etat}";
        return message;
    }
}
public class Champignon:Legume
{
    public override string[] Image => ["🍄","🟫"];
    public override string Nom => "Champignon";
    public override int TempsCroissance => 12;
    public Champignon(int nombre):base(nombre){}
    public override string EtatImage()
    {
        switch (Croissance)
        {
            case <2:
                return(Image[1]);
            default :
                return(Image[0]);
        }
    }
}
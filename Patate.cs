public class Patate:Legume
{
    public override string[] Image => ["🥔","🟫","🌱"];
    public override string Nom => "Patate";
    public override int TempsCroissance => 8;
    public Patate(int nombre):base(nombre){}
    public override string EtatImage()
    {
        switch (Croissance)
        {
            case <1:
                return(Image[1]);
            default:
                return(Image[2]);
        }
    }
}
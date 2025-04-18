public class Patate:Legume
{
    public override string[] Image => ["🥔","🌱"];
    public override string[] ActionPossible => ["Deterrer","Arroser","Engrais"];
    public override string Nom => "Patate";
    public override int TempsCroissance => 8;
    public Patate(int nombre):base(nombre){}
    public override string EtatImage()
    {
        switch (Croissance)
        {
            default:
                return(Image[1]);
        }
    }
}
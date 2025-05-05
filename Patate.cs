public class Patate:Legume
{
    public override string[] Image => ["🥔","🌱"];
    public override string GoûtTerrain => "Terre";
    public override int Prix => 10;
    public override int TempératureDePousse => 10;
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
    public override string[] ActionPossible()
    {
        if (Croissance==TempsCroissance)
        {
            return ["Deterrer","Arroser","Engrais","Recolter"];
        } else {
           return ["Deterrer","Arroser","Engrais"];
        }
    }
}
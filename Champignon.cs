public class Champignon:Legume
{
    public override string[] Image => ["🍄"];
    public override string GoûtTerrain => "Sable";
    public override int Prix => 15;
    public override string Nom => "Champignon";
    public override int TempératureDePousse => 10;
    public override int TempsCroissance => 12;
    public Champignon(int nombre):base(nombre){}
    public override string EtatImage()
    {
        switch (Croissance)
        {
            default :
                return(Image[0]);
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
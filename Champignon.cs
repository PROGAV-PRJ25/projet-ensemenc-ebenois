public class Champignon:Plante
{
    public override string[] Image => ["🍄"];
    public override string GoûtTerrain => "Sable";
    public override int Prix => 15;
    public override string Nom => "Champignon";
    public override int TempératureDePousse => 10;
    public override int NombreDeFuits => 1;
    public override int TempsCroissance => 12;
    public override bool Vivace => true;
    public Champignon(int nombre) : base(nombre)   {}
    public override string EtatImage()
    {
        switch (Croissance)
        {
            default :
                return(Image[0]);
        }
    }
}
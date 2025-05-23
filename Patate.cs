public class Patate : Plante
{
    public override string[] Image => ["🥔", "🌱"];
    public override string GoûtTerrain => "Terre";
    public override bool Vivace => false;
    public override int Prix => 10;
    public override int TempératureDePousse => 15;
    public override int NombreDeFuits => 3;
    public override string Nom => "Patate";
    public override int TempsCroissance => 8;
    public Patate(int nombre) : base(nombre) { }
    public override string EtatImage()
    {
        switch (Croissance)
        {
            default:
                return (Image[1]);
        }
    }
}
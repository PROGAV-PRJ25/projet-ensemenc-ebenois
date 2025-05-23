public class Tomate : Plante
{
    public override string[] Image => ["🍅", "🌱"];
    public override string GoûtTerrain => "Terre";
    public override int Prix => 12;
    public override string Nom => "Tomate";
    public override int TempératureDePousse => 12;
    public override int NombreDeFuits => 2;
    public override int TempsCroissance => 10;
    public override bool Vivace => true;
    public Tomate(int nombre) : base(nombre) { }
    public override string EtatImage()
    {
        switch (Croissance)
        {
            default:
                return (Image[1]);
        }
    }
}
public class Mais : Plante
{
    public override string[] Image => ["🌽"];
    public override string GoûtTerrain => "Terre";
    public override bool Vivace => false;
    public override int Prix => 10;
    public override int TempératureDePousse => 16;
    public override int NombreDeFuits => 1;
    public override string Nom => "Maïs";
    public override int TempsCroissance => 10;
    public Mais(int nombre) : base(nombre) { }
    public override string EtatImage()
    {
        switch (Croissance)
        {
            default:
                return (Image[0]);
        }
    }
}
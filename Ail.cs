public class Ail : Plante
{
    public override string[] Image => ["🧄", "🌱"];
    public override string GoûtTerrain => "Argile";
    public override bool Vivace => false;
    public override int Prix => 16;
    public override int TempératureDePousse => 13;
    public override int NombreDeFuits => 2;
    public override string Nom => "Ail";
    public override int TempsCroissance => 9;
    public Ail(int nombre) : base(nombre) { }
    public override string EtatImage()
    {
        switch (Croissance)
        {
            default:
                return (Image[1]);
        }
    }
}
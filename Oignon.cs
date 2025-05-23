public class Oignon : Plante
{
    public override string[] Image => ["🧅", "🌱"];
    public override string GoûtTerrain => "Argile";
    public override bool Vivace => false;
    public override int Prix => 14;
    public override int TempératureDePousse => 16;
    public override int NombreDeFuits => 1;
    public override string Nom => "Oignon";
    public override int TempsCroissance => 10;
    public Oignon(int nombre) : base(nombre) { }
    public override string EtatImage()
    {
        switch (Croissance)
        {
            default:
                return (Image[1]);
        }
    }
}
public class Carotte:Plante
{
    public override string[] Image => ["🥕","🌱"];
    public override string GoûtTerrain => "Sable";
    public override bool Vivace => false;
    public override int Prix => 7;
    public override int TempératureDePousse => 13;
    public override int NombreDeFuits => 1;
    public override string Nom => "Carotte";
    public override int TempsCroissance => 10;
    public Carotte(int nombre):base(nombre){}
    public override string EtatImage()
    {
        switch (Croissance)
        {
            default:
                return(Image[1]);
        }
    }
}
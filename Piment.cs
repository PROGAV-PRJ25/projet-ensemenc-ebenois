public class Piment:Plante
{
    public override string[] Image => ["🌶","🌱"];
    public override string GoûtTerrain => "Sable";
    public override bool Vivace => false;
    public override int Prix => 11;
    public override int TempératureDePousse => 20;
    public override int NombreDeFuits => 3;
    public override string Nom => "Piment";
    public override int TempsCroissance => 9;
    public Piment(int nombre):base(nombre){}
    public override string EtatImage()
    {
        switch (Croissance)
        {
            default:
                return(Image[1]);
        }
    }
}
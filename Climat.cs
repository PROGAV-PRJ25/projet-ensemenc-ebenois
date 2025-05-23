public abstract class Climat
{
    public abstract string[] Image { get; }
    public abstract string Pays { get; }
    public abstract int[] Temperature { get; }
    public abstract string[] Saison { get; }
    public abstract int SaisonDuree { get; }
    public int MeteoActuelle { get; private set; }
    public bool Urgence { get; private set; }
    public int SaisonActuelle { get; private set; }
    public Climat() {Urgence = false;}
    public void Actualisation(int date)
    {
        SaisonActuelle = (date / SaisonDuree) % 4;

    }
    public void NouvelleMeteo()
    {
        Urgence = false; 
        Random rand = new Random();
        switch (rand.Next(20))
        {
            case 1:
                MeteoActuelle = Image.Length - 1;
                Urgence = true;
                break;
            default:
                MeteoActuelle = rand.Next(Image.Length - 1);
                break;
        }
    }
    public override string ToString()
    {
        string message = $"Pays: {Pays} - Saison: {Saison[SaisonActuelle]} - Météo: {Image[MeteoActuelle]} - Température: {Temperature[SaisonActuelle]}°C";
        return message;
    }
}

public abstract class Climat
{
    public abstract string[] Image { get;}
    public abstract string Pays { get;}
    public abstract int[] Temperature { get;}
    public abstract int[] Pluviometrie { get;}
    public abstract string[] Saison { get;}
    public abstract int SaisonDuree { get;}
    public int SaisonActuelle { get; private set;}
    public Climat(){}
    public void Actualisation(int date)
    {
        SaisonActuelle=(date/SaisonDuree)%4;
    }
    public override string ToString()
    {
        string message = $"Pays: {Pays} - Saison: {Saison[SaisonActuelle]} - Météo: {Image[0]} - Température: {Temperature[SaisonActuelle]}°C - Pluviométrie: {Pluviometrie[SaisonActuelle]}mm";
        return message;
    }
}

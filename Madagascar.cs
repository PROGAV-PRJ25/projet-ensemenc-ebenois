public class Madagascar : Climat
{
    public override string Pays => "Madagascar";
    public override string[] Saison => ["Saison humide", "Saison sec"];
    public override string[] Image => ["Nuageux ⛅", "Ensoleillé ☀ ", "Pluvieux ☔", "Ouragan 🌀"];
    public override int[] Temperature => [30, 22];
    public override int SaisonDuree => 8;
    public Madagascar() : base() { }
}
public class Placinland : Climat
{
    public override string Pays => "Placinland";
    public override string[] Saison => ["Printemps", "Automne"];
    public override string[] Image => ["Nuageux ⛅", "Ensoleillé ☀ ", "Pluvieux ☔", "Grèle 🌨"];
    public override int[] Temperature => [16, 10];
    public Placinland() : base() { }
    public override int SaisonDuree => 8;
}
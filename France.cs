public class France:Climat{
    public override string Pays => "France";
    public override int[] Temperature => [12,12,12,12];
    public override string[] Image => ["Nuageux ⛅","Ensoleillé 🌞","Pluvieux ☔","Orageux ⚡","Neigeux ❄"];
    public override string[] Saison => ["Printemps","Ete","Automne","Hiver"];
    public override int[] Pluviometrie => [164,164,164,164];
    public override int SaisonDuree => 2;
    public France():base(){}
}
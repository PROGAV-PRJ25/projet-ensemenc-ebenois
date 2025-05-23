public class France:Climat{
    public override string Pays => "France";
    public override int[] Temperature => [14,17,12,8];
    public override string[] Image => ["Nuageux ⛅","Ensoleillé ☀ ","Pluvieux ☔","Orage ⚡"];
    public override string[] Saison => ["Printemps","Ete","Automne","Hiver"];
    public override int SaisonDuree => 4;
    public France():base(){}
}
public class Placinland:Climat{
    public override string Pays => "Placinland";
    public override string[] Saison => ["Printemps","Automne"];
    public override string[] Image => ["⛅","🌞","☔","⚡"];
    public override int[] Temperature => [15];
    public override int[] Pluviometrie => [70];
    public Placinland():base(){}
    public override int SaisonDuree => 4;
}
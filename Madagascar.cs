public class Madagascar:Climat{
    public override string Pays => "Madagascar";
    public override string[] Saison => ["Saison humide","Saison sec"];
    public override string[] Image => ["⛅","🌞","🌀","☔","⚡"];
    public override int[] Temperature => [22];
    public override int[] Pluviometrie => [52];
    public override int SaisonDuree => 4;
    public Madagascar():base(){}
}
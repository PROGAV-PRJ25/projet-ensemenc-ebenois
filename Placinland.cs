public class Placinland:Climat{
    public override string[] Saison => ["Printemps","Automne"];

    public override int[] Temperature => [15];
    public override int Pluviometrie => 70;
    public Placinland():base(){}
    public override string ChangementSaison(int date)
    {
        return Saison[date%4];
    }
}
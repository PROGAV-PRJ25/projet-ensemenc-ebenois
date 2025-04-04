public class France:Climat{
    public override int[] Temperature => [12];
    public override string[] Saison => ["Printemps","Ete","Automne","Hiver"];
    public override int Pluviometrie => 164;
    public France():base(){}
    public override string ChangementSaison(int date)
    {
        return Saison[date%4];
    }
}
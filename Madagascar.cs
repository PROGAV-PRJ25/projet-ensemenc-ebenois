public class Madagascar:Climat{
    public override string[] Saison => ["Saison humide","Saison sec"];

    public override int[] Temperature => [22];
    public override int Pluviometrie => 52;
    public Madagascar():base(){}
    public override string ChangementSaison(int date)
    {
        return Saison[date%2];
    }
}
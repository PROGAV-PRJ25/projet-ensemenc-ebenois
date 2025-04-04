public abstract class Climat
{
    public abstract int[] Temperature { get;}
    public abstract int Pluviometrie { get;}
    public abstract string[] Saison { get;}
    public Climat(){}
    public virtual string ChangementSaison(int date){return "";}
}

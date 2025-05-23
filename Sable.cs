public class Sable : Terrain
{
    public override string Type => "Sable";
    public override string Image => "🟨";

    public Sable(int[] coordonnées) : base(coordonnées) { }
}
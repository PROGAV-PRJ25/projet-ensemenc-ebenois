public class Terre:Terrain{
    public override string Type => "Terre";
    public override string Image => "🟫";

    public Terre(int[] coordonnées):base(coordonnées){} 
}
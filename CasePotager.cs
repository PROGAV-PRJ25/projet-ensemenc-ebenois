public class CasePotager
{
    public Legume? Nom { get; set; }
    public int Pluviometrie { get; set; }
    

    public CasePotager()
    {
        Pluviometrie = 0; 
    }

    public void Arroser()
    {
        Pluviometrie += 20; 
        Console.WriteLine($"{Pluviometrie}");

        
    }


}

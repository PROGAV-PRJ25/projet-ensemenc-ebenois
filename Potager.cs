using System.Security.Claims;

public class Potager
{
    public int Numero {get; private set;}
    public static int NumeroSuivant = 1;
    public int[] Size {get; private set;}
    public string[,] PotagerGrille;
    public List<Legume> ListLegumes {get; private set;}
    public int Jour {get; private set;}
    public Climat? Climat { get; private set; }
    public Potager(int[] size, string pays)
    {
        Size = size;
        PotagerGrille = new string[size[0],size[1]];
        ListLegumes = new List<Legume>();
        Jour = 1;
        Numero = NumeroSuivant;
        NumeroSuivant++;
        switch (pays)
        {
            case "France":
                Climat = new France();
                break;
            case "Madagascar":
                Climat = new Madagascar();
                break;
            case "Placinland":
                Climat = new Placinland();
                break;
        }
        Initialiser();
    }
    public void Initialiser()
    {
        for (int i = 0; i<Size[0]; i++)
        {
            for (int j = 0; j<Size[1]; j++)
            {
                PotagerGrille[i,j]="";
            }
        }
    }
    public void Information()
    {
        int size = 70;
        //▛ ▜ ▟ ▙ ▀ ▄ ▌▐
        Console.ForegroundColor = ConsoleColor.Gray;
        string message ="▛";
        string titre = $"RECAPITULATIF - JOUR {Jour}";
        for (int i = 0; i<size/2; i++) {message+="▀";}
        message+=titre;
        for (int i = 0; i<size/2; i++) {message+="▀";}
        message+="▜\n";
        foreach (Legume legume in ListLegumes)
        {
            message+= "▌";
            Console.Write(message);
            Console.Write(legume);
            Console.ForegroundColor = ConsoleColor.Gray;
            message="";
            for (int i = 0; i < size + titre.Length - legume.ToString()?.Length; i++) { message += " "; }
            message+= "▐\n";
        }  
        message+="▙"; 
        for (int i = 0; i<size+titre.Length; i++) {message+="▄";}
        message+="▟\n"; 
        Console.WriteLine(message);
    }
    public void Planter(string nom,int x,int y)
    {
        switch (nom)
        {
            case "Patate":
                ListLegumes.Add(new Patate(x,y));
                break;
            case "Champignon":
                ListLegumes.Add(new Champignon(x,y));
                break;
        }
    }
    public void NouveauJour()
    {
        Jour+=1;
        foreach (Legume legume in ListLegumes)
        {
            legume.Grandir(1);
        }
        Console.WriteLine(this);
    }
    public void Afficher()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Votre Potager:");
        bool emplacementVide = true;
        Console.ForegroundColor = ConsoleColor.DarkGray;
        string message = "o";
        for (int x = 0; x < Size[0]; x++){
                message+="--";
            }
        message+="-o\n";  
        for (int y = 0; y < Size[1]; y++)
        {    
            message += "¦";     
            for (int x = 0; x < Size[0]; x++)
            {
                foreach (Legume legume in ListLegumes)
                {
                    if (legume.X==x && legume.Y==y)
                    {
                        message+=legume.EtatImage();
                        emplacementVide=false;
                    }
                }
                if (emplacementVide)
                {
                    message+="🟫";
                }
                emplacementVide=true;
            }
            message+=" ¦\n";
        }
        message+="o";
        for (int x = 0; x < Size[0]; x++){
                message+="--";
            }
        message+="-o\n";
        Console.WriteLine(message);
    }
    public override string ToString()
    {
        Afficher();
        Information();
        return "";
    }
}
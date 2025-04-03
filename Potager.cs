public class Potager
{
    public int Numero {get; private set;}
    public static int NumeroSuivant = 1;
    public int Temperature {get; private set;}
    public int Pluviometrie {get; private set;}
    public string Pays;
    public int[] Size {get; private set;}
    public string[,] PotagerGrille;
    public string Saison {get; private set;}
    public List<Legume> ListLegumes {get; private set;}
    public Potager(int[] size, string pays)
    {
        Size = size;
        PotagerGrille = new string[size[0],size[1]];
        ListLegumes = new List<Legume>();
        Pays=pays;
        Saison="printemps";
        Temperature = 0;
        Pluviometrie = 0; 
        Numero = NumeroSuivant;
        NumeroSuivant++;
        Initialiser();
    }
    public void ChangementSaison()
    {
        switch (Pays)
        {
            case "France":
                switch (Saison)
                {
                    case "printemps":
                        Temperature = 12;
                        Pluviometrie = 164;
                        break;
                }
                break;
            case "Madagascar":
                switch (Saison)
                {
                    case "printemps":
                        Temperature = 22;
                        Pluviometrie = 52;
                        break;
                }
                break;
            case "PlacinLand":
                switch (Saison)
                {
                    case "printemps":
                        Temperature = 15;
                        Pluviometrie = 70;
                        Saison = "automne";
                        break;
                    case "automne":
                        Temperature = 15;
                        Pluviometrie = 70;
                        Saison = "printemps";
                        break;
                }
                break;
        }
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
    public void Ajouter(Legume legume)
    {
        ListLegumes.Add(legume);
    }
    public void Information()
    {
        int size = 70;
        //▛ ▜ ▟ ▙ ▀ ▄ ▌▐
        Console.ForegroundColor = ConsoleColor.Gray;
        string message ="▛";
        for (int i = 0; i<size/2; i++) {message+="▀";}
        message+="RECAPITULATIF";
        for (int i = 0; i<size/2; i++) {message+="▀";}
        message+="▜\n";
        foreach (Legume legume in ListLegumes)
        {
            message+= "▌";
            Console.Write(message);
            Console.Write(legume);
            Console.ForegroundColor = ConsoleColor.Gray;
            message="";
            for (int i = 0; i<size+13-legume.ToString().Length; i++) {message+=" ";}
            message+= "▐\n";
        }  
        message+="▙"; 
        for (int i = 0; i<size+13; i++) {message+="▄";}
        message+="▟\n"; 
        Console.WriteLine(message);
    }
    public override string ToString()
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
        return message;
    }
}
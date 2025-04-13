using System.Reflection.Metadata;
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
    public Inventaire? Inventaire { get; private set; }

    public Potager(int[] size, string pays)
    {
        Size = size;
        PotagerGrille = new string[size[0],size[1]];
        ListLegumes = new List<Legume>();
        Jour = 0;
        Inventaire = new Inventaire();
        Climat = CreateClimat(pays);
        Initialiser();
        Numero = NumeroSuivant;
        NumeroSuivant++;
    }

    private Climat CreateClimat(string pays)
    {
        return pays switch
        {
            "France" => new France(),
            "Madagascar" => new Madagascar(),
            "Placinland" => new Placinland(),
        };
    }

    //crée un potager vide
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

    //Affiche un récapitulatif de divers informations
    public void AfficherRecapitulatif()
    {
        int size = 100;
        string titre = $"RECAPITULATIF - JOUR {Jour+1}";

        AfficherBordure(titre, size);

        //Informations sur la météo
        Climat?.Actualisation(Jour);
        AfficherInfo(Climat.ToString(), size, titre.Length);

        //Informations sur les légumes
        AfficherLegumes("Légumes", size, titre.Length);

        //Informations sur l'inventaire
        AfficherLegumes("Inventaire", size, titre.Length);

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("▙");
        for (int i = 0; i < size + titre.Length; i++) Console.Write("▄");
        Console.Write("▟\n");
    }

    private void AfficherBordure(string titre, int size)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("▛");
        for (int i = 0; i<size/2; i++) {Console.Write("▀");}
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write(titre);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        for (int i = 0; i<size/2; i++) {Console.Write("▀");}
        Console.Write("▜\n▌");
    }

    //Informations sur la météo
    private void AfficherInfo(string value, int size, int titreLength)
    {
        Console.ForegroundColor = ConsoleColor.White;
        int padding = (size+titreLength-(value.Length))/2;
        for (int i = 0; i<padding; i++) {Console.Write(" ");}
        Console.Write(value);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        if (2*padding+value.Length!=size+titreLength){
            for (int i = 0; i<padding; i++) {Console.Write(" ");}
        } else {
            for (int i = 0; i<padding-1; i++) {Console.Write(" ");}
        }
        Console.Write("▐\n");
    }

    //Informatons sur les légumes
    private void AfficherLegumes(string label, int size, int titreLength)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("▌");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(label + ":");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        for (int i = 0; i < size + titreLength - label.Length - 1; i++) {Console.Write(" ");}
        Console.Write("▐\n");

        foreach (Legume legume in ListLegumes)
        {
            if (legume.Graine!=0 && label=="Inventaire")
            {
                Console.Write("▌");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(legume);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                for (int i = 0; i < size + titreLength - legume.ToString()?.Length; i++) {Console.Write(" ");}
                Console.Write("▐\n");
            }
            if (legume.Graine==0 && label=="Légumes")
            {
                Console.Write("▌");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(legume);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                for (int i = 0; i < size + titreLength - legume.ToString()?.Length; i++) {Console.Write(" ");}
                Console.Write("▐\n");
            }
        }

        Console.Write("▌");
        for (int i = 0; i < size + titreLength; i++) {Console.Write(" ");}
        Console.Write("▐\n");
    }

    //Ajouter dans l'inventaire un légume
    public void Ajouter(string nom,int nombre)
    {
        bool aGraine = false;
        foreach (Legume legume in ListLegumes)
        {
            if(legume.Nom==nom && legume.Graine!=0) {aGraine=true;}
        }
        if (aGraine)
        {
            foreach (Legume legume in ListLegumes)
                {
                    if(legume.Nom==nom && legume.Graine!=0) {legume.Graine+=nombre;}
                }
        }
        else 
        {
            switch (nom)
                {
                    case "Patate":
                        ListLegumes.Add(new Patate(0,0,nombre));
                        break;
                    case "Champignon":
                        ListLegumes.Add(new Champignon(0,0,nombre));
                        break;
                }
            }
    }

    //Plante un légume
    public void Planter(string nom,int x,int y)
    {
        bool estPlanté = false;
        bool emplacementLibre = true;
        bool aGraine = false;
        foreach (Legume legume in ListLegumes)
        {
            if(legume.Nom==nom && legume.Graine!=0) {aGraine=true;}
        }
        if (aGraine)
        {
            foreach (Legume legume in ListLegumes)
            {
                if(legume.Nom==nom && x==legume.X && y==legume.Y && legume.Graine==0) {emplacementLibre=false;}
            }
            if (emplacementLibre)
            {
                foreach (Legume legume in ListLegumes)
                {
                    if(legume.Nom==nom && legume.Graine!=0) 
                    {
                        switch (nom)
                        {
                            case "Patate":
                                if (legume.Graine==1) {ListLegumes.Remove(legume);}
                                else {legume.Graine-=1;}
                                ListLegumes.Add(new Patate(x,y,0));
                                estPlanté=true;
                                break;
                            case "Champignon":
                                if (legume.Graine==1) {ListLegumes.Remove(legume);}
                                else {legume.Graine-=1;}
                                ListLegumes.Add(new Champignon(x,y,0));
                                estPlanté=true;
                                break;
                        }
                    }
                    if (estPlanté) {break;}
                }
            }
        }
    }

    //Passe à la journée suivante
    public void NouveauJour()
    {
        Jour+=1;
        foreach (Legume legume in ListLegumes)
        {
            if (legume.Graine==0) {legume.Grandir(0);}
        }
    }

    //Affiche le potager
    public void AfficherPotager()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Votre Potager:");
        bool emplacementVide = true;
        Console.ForegroundColor = ConsoleColor.DarkGray;
        string message = "o";
        for (int x = 0; x < Size[0]; x++){
            message+="--";
            }
        message += "-o\n";

        for (int y = 0; y < Size[1]; y++)
        {
            message += "¦";
            for (int x = 0; x < Size[0]; x++)
            {
                emplacementVide = true;
                foreach (Legume legume in ListLegumes)
                {
                    if (legume.X==x && legume.Y==y && legume.Graine==0)
                    {
                        message+=legume.EtatImage();
                        emplacementVide=false;
                    }
                }
                if (emplacementVide)
                {
                    message+="🟫";
                }
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

    //Affiche le potager et le récapitulatif
    public override string ToString()
    {
        Console.Clear();
        AfficherPotager();
        AfficherRecapitulatif();
        Console.WriteLine("Utilise les flèches ↑ ↓ pour naviguer, Entrée pour sélectionner :\n");
        return "";
    }
}
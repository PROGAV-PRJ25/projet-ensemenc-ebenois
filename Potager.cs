using System.Reflection.Metadata;
using System.Security.Claims;

public class Potager
{
    public int[] Size { get; private set; }
    public List<Terrain> ListTerrains {get; private set;}
    public int Jour {get; private set;}
    public Climat? Climat { get; private set; }
    public Inventaire? Inventaire { get; private set; }

    public Potager(int[] size, string pays)
    {
        Size=size;
        ListTerrains = new List<Terrain>();
        Jour = 0;
        Inventaire = new Inventaire();
        CreateClimat(pays,size);
    }

    private void CreateClimat(string pays, int[] size)
    {
        switch (pays)
        {
            case "France":
                Climat = new France();
                for (int i = 0; i<size[0]; i++)
                {
                    for (int j = 0; j<size[1]; j++)
                    {
                        ListTerrains.Add(new Terre([i,j]));
                    }
                }
                break;
            case "Madagascar":
                Climat = new Madagascar();
                for (int i = 0; i<size[0]; i++)
                {
                    for (int j = 0; j<size[1]; j++)
                    {
                        ListTerrains.Add(new Sable([i,j]));
                    }
                }
                break;
            case "Placinland":
                Climat = new Placinland();
                for (int i = 0; i<size[0]; i++)
                {
                    for (int j = 0; j<size[1]; j++)
                    {
                        ListTerrains.Add(new Argile([i,j]));
                    }
                }
                break;
        };
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
        AfficherLegumes(size, titre.Length);

        //Informations sur l'inventaire
        Inventaire.AfficherLegumes(size, titre.Length);

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
    private void AfficherLegumes(int size, int titreLength)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("▌");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Légumes:");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        for (int i = 0; i < size + titreLength - "Légumes:".Length; i++) {Console.Write(" ");}
        Console.Write("▐\n");

        foreach (Terrain terrain in ListTerrains)
        {
            if(terrain.Legume!=null){
                Console.Write("▌");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" ▪ Coordonnées: ({terrain.Coordonnées[0]},{terrain.Coordonnées[1]}) - Type: {terrain.Legume.Nom} {terrain.Legume.Image[0]} - Croissance: {terrain.Legume.Croissance*100/terrain.Legume.TempsCroissance}% - Etat: {terrain.Legume.Etat}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                for (int i = 0; i < size + titreLength - $" ▪ Coordonnées: ({terrain.Coordonnées[0]},{terrain.Coordonnées[1]}) - Type: {terrain.Legume.Nom} {terrain.Legume.Image[0]} - Croissance: {terrain.Legume.Croissance*100/terrain.Legume.TempsCroissance}% - Etat: {terrain.Legume.Etat}".ToString()?.Length; i++) {Console.Write(" ");}
                Console.Write("▐\n");
            }
        }
        Console.Write("▌");
        for (int i = 0; i < size + titreLength; i++) {Console.Write(" ");}
        Console.Write("▐\n");
    }

    //Plante un légume
    public void Planter(string nom,int x,int y)
    {
        bool estPlanté = false;
        bool emplacementLibre = true;
        bool aGraine = false;
        foreach (Legume legume in Inventaire.ListLegumes)
        {
            if(legume.Nom==nom && legume.Graine!=0) {aGraine=true;}
        }
        if (aGraine)
        {
            foreach (Legume legume in Inventaire.ListLegumes)
            {
                if(x<0 || x>=Size[0] || y<0 || y>=Size[1]) {emplacementLibre=false;}
                foreach (Terrain terrain in ListTerrains)
                {
                    if(terrain.Legume!=null) {emplacementLibre=false;}
                }
            }
            if (emplacementLibre)
            {
                foreach (Legume legume in Inventaire.ListLegumes)
                {
                    if(legume.Nom==nom && legume.Graine!=0) 
                    {
                        foreach (Terrain terrain in ListTerrains)
                        {
                            if (terrain.Coordonnées[0]==x && terrain.Coordonnées[1]==y){
                                switch (nom)
                                {
                                    case "Patate":
                                        if (legume.Graine==1) {Inventaire.ListLegumes.Remove(legume);}
                                        else {legume.Graine-=1;}
                                        terrain.Legume =new Patate(0);
                                        estPlanté=true;
                                        break;
                                    case "Champignon":
                                        if (legume.Graine==1) {Inventaire.ListLegumes.Remove(legume);}
                                        else {legume.Graine-=1;}
                                        terrain.Legume =new Champignon(0);
                                        estPlanté=true;
                                        break;
                                }
                            }
                        }
                    }
                    if (estPlanté) {break;}
                }
            }
        }
    }

    //Affiche le potager
    public void AfficherPotager()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Votre Potager:");
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
                foreach (Terrain terrain in ListTerrains){
                    if (terrain.Coordonnées[0]== x && terrain.Coordonnées[1]==y) {message+=terrain.ToString();}
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
        Console.ForegroundColor=ConsoleColor.White;
        Console.WriteLine("Utilise les flèches ↑ ↓ pour naviguer, Entrée pour sélectionner :\n");
        return "";
    }
}
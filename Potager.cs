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
        CreateClimat(pays);
        GénérateurDeTerrain(pays,size);
    }

    private void CreateClimat(string pays)
    {
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
        };
    }

    //Affiche un récapitulatif de divers informations
    public int AfficherAction(int positionInitial)
    {
        int size = 100;
        string titre = $"ACTION - JOUR {Jour+1}";
        int selectedIndex = positionInitial;
        //Bordure
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("▛");
        for (int i = 0; i<size/2; i++) {Console.Write("▀");}
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write(titre);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        for (int i = 0; i<size/2; i++) {Console.Write("▀");}
        Console.Write("▜\n▌");
        for (int i = 0; i < size + titre.Length; i++) {Console.Write(" ");}
        Console.Write("▐\n");
        
        string[] actionPossible = ["planter"];
        for (int i = 0; i < actionPossible.Length; i++)
        {
            if (i==selectedIndex)
            {
                // Met en surbrillance l'élément sélectionné
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(actionPossible[i]);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(actionPossible[i]);
            }
        }

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("▙");
        for (int i = 0; i < size + titre.Length; i++) Console.Write("▄");
        Console.Write("▟\n");
        return(selectedIndex);
    }

    public void AfficherInformation()
    {
        int size = 100;
        string titre = $"INVENTAIRE - JOUR {Jour+1}";
        //Bordure
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("▛");
        for (int i = 0; i<size/2; i++) {Console.Write("▀");}
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write(titre);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        for (int i = 0; i<size/2; i++) {Console.Write("▀");}
        Console.Write("▜\n▌");

        //Informations sur la météo
        Climat?.Actualisation(Jour);
        AfficherMeteo(Climat.ToString(), size, titre.Length);
        //Informations sur l'inventaire
        Inventaire.AfficherLegumes(size, titre.Length);
            
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("▙");
        for (int i = 0; i < size + titre.Length; i++) Console.Write("▄");
        Console.Write("▟\n");
    }

    public void AfficherLegume(int[] selectedIndex, int ligne)
    {
        if (ligne == 0)
        {
            foreach (Terrain terrain in ListTerrains)
            {
                if(selectedIndex[0]==terrain.Coordonnées[0] && selectedIndex[1]==terrain.Coordonnées[1] && terrain.Legume!=null){
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($" ▪ Type: {terrain.Legume.Nom} {terrain.Legume.Image[0]} - Croissance: {terrain.Legume.Croissance*100/terrain.Legume.TempsCroissance}% - Etat: {terrain.Legume.Etat}");
                }
            }
        }
        Console.Write("\n");
    }

    //Informations sur la météo
    private void AfficherMeteo(string value, int size, int titreLength)
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

    //Plante un légume
    public void Planter(string nom,int[] position)
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
                if(position[0]<0 || position[0]>=Size[0] || position[1]<0 || position[1]>=Size[1]) {emplacementLibre=false;}
                foreach (Terrain terrain in ListTerrains)
                {
                    if(terrain.Coordonnées[0]==position[0] && terrain.Coordonnées[1]==position[1] && terrain.Legume!=null) {emplacementLibre=false;}
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
                            if (terrain.Coordonnées[0]==position[0] && terrain.Coordonnées[1]==position[1]){
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

    public void AfficherPotager(int[] selectedIndex)
    {
        Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Votre Potager:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("o");
            for (int x = 0; x < Size[0]; x++){Console.Write("--");}
            Console.Write("-o\n");
            for (int y = 0; y < Size[1]; y++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("¦");
                for (int x = 0; x < Size[0]; x++)
                {
                    foreach (Terrain terrain in ListTerrains)
                    {
                        if (x==terrain.Coordonnées[0] && y==terrain.Coordonnées[1])
                        {
                            if (x==selectedIndex[0] && y==selectedIndex[1])
                            {
                                // Met en surbrillance l'élément sélectionné
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write(terrain.ToString());
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(terrain.ToString());
                            }
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(" ¦");
                AfficherLegume(selectedIndex, y);
            }
            Console.Write("o");
            for (int x = 0; x < Size[0]; x++){
                Console.Write("--");
            }
            Console.WriteLine("-o\n");
    }

    //Affiche le potager
    public int[] PotagerEtInventaire(int[] positionInitiale)
    {
        ConsoleKey key;
        int[] selectedIndex = positionInitiale;
        do
        {
            AfficherPotager(selectedIndex);
            AfficherInformation();
            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex[1] = (selectedIndex[1] == 0) ? Size[1] - 1 : selectedIndex[1] - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex[1] = (selectedIndex[1] + 1) % Size[1];
                    break;
                case ConsoleKey.LeftArrow:
                    selectedIndex[0] = (selectedIndex[0] == 0) ? Size[0] - 1 : selectedIndex[0] - 1;
                    break;
                case ConsoleKey.RightArrow:
                    selectedIndex[0] = (selectedIndex[0] + 1) % Size[0];
                    break;
                case ConsoleKey.Enter:
                    break;
            }
        } while (key != ConsoleKey.Enter);
        return (selectedIndex);
        }

        public int PotagerEtAction(int[] positionInitiale)
    {
        ConsoleKey key;
        int selectedIndex = 0;
        do
        {
            AfficherPotager(positionInitiale);
            selectedIndex = AfficherAction(selectedIndex);
            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    selectedIndex = (selectedIndex == 0) ? 3 - 1 : selectedIndex - 1;
                    break;
                case ConsoleKey.RightArrow:
                    selectedIndex = (selectedIndex + 1) % 3;
                    break;
                case ConsoleKey.Enter:
                    break;
            }
        } while (key != ConsoleKey.Enter);
        return (selectedIndex);
        }

    public void GénérateurDeTerrain(string pays, int[] size)
    {
        Random rand = new Random();
        int etendue;
        /*switch (pays){
            case "France":
            for (int i = 0; i<size[0]; i++)
                {
                    for (int j = 0; j<size[1]; j++)
                    {
                        ListTerrains.Add(new Terre([i,j]));
                    }
                }
                break;
        }*/
        
        // Étape 1 : initialisation avec des valeurs aléatoires aux bords
        for (int x = 0; x < size[0]; x++)
        {
            etendue = rand.Next(1, 3);
            switch(rand.Next(0, 3)){
                case 0:
                    if (x+etendue<size[0]) {
                        for (int detendue = 0; detendue<=etendue;detendue++){
                            ListTerrains.Add(new Terre([x+detendue, 0]));
                        }
                    }
                    else {
                        for (int detendue = 0; detendue<size[0]-x;detendue++){
                            ListTerrains.Add(new Terre([x+detendue, 0]));
                        }
                    }
                    break;
                case 1:
                    if (x+etendue<size[0]) {
                        for (int detendue = 0; detendue<=etendue;detendue++){
                            ListTerrains.Add(new Argile([x+detendue, 0]));
                        }
                    }
                    else {
                        for (int detendue = 0; detendue<size[0]-x;detendue++){
                            ListTerrains.Add(new Argile([x+detendue, 0]));
                        }
                    }
                    break;
                case 2:
                    if (x+etendue<size[0]) {
                        for (int detendue = 0; detendue<=etendue;detendue++){
                            ListTerrains.Add(new Sable([x+detendue, 0]));
                        }
                    }
                    else {
                        for (int detendue = 0; detendue<size[0]-x;detendue++){
                            ListTerrains.Add(new Sable([x+detendue, 0]));
                        }
                    }
                    break;
            }
            x+=etendue;
        }

        for (int y = 1; y < size[1]; y++)
        {
            etendue = rand.Next(1, 3);
            switch(rand.Next(0, 3)){
                case 0:
                    if (y+etendue<size[1]) {
                        for (int detendue = 0; detendue<=etendue;detendue++){
                            ListTerrains.Add(new Terre([0,y+detendue]));
                        }
                    }
                    else {
                        for (int detendue = 0; detendue<size[1]-y;detendue++){
                            ListTerrains.Add(new Terre([0,y+detendue]));
                        }
                    }
                    break;
                case 1:
                    if (y+etendue<size[1]) {
                        for (int detendue = 0; detendue<=etendue;detendue++){
                            ListTerrains.Add(new Argile([0,y+detendue]));
                        }
                    }
                    else {
                        for (int detendue = 0; detendue<size[1]-y;detendue++){
                            ListTerrains.Add(new Argile([0,y+detendue]));
                        }
                    }
                    break;
                case 2:
                    if (y+etendue<size[1]) {
                        for (int detendue = 0; detendue<=etendue;detendue++){
                            ListTerrains.Add(new Sable([0,y+detendue]));
                        }
                    }
                    else {
                        for (int detendue = 0; detendue<size[1]-y;detendue++){
                            ListTerrains.Add(new Sable([0,y+detendue]));
                        }
                    }
                    break;
            }
            y+=etendue;
        }

        for (int y = 1; y < size[1]; y++)
        {
            etendue = rand.Next(1, 3);
            switch(rand.Next(0, 3)){
                case 0:
                    if (y+etendue<size[1]) {
                        for (int detendue = 0; detendue<=etendue;detendue++){
                            ListTerrains.Add(new Terre([size[0]-1,y+detendue]));
                        }
                    }
                    else {
                        for (int detendue = 0; detendue<size[1]-y;detendue++){
                            ListTerrains.Add(new Terre([size[0]-1,y+detendue]));
                        }
                    }
                    break;
                case 1:
                    if (y+etendue<size[1]) {
                        for (int detendue = 0; detendue<=etendue;detendue++){
                            ListTerrains.Add(new Argile([size[0]-1,y+detendue]));
                        }
                    }
                    else {
                        for (int detendue = 0; detendue<size[1]-y;detendue++){
                            ListTerrains.Add(new Argile([size[0]-1,y+detendue]));
                        }
                    }
                    break;
                case 2:
                    if (y+etendue<size[1]) {
                        for (int detendue = 0; detendue<=etendue;detendue++){
                            ListTerrains.Add(new Sable([size[0]-1,y+detendue]));
                        }
                    }
                    else {
                        for (int detendue = 0; detendue<size[1]-y;detendue++){
                            ListTerrains.Add(new Sable([size[0]-1,y+detendue]));
                        }
                    }
                    break;
            }
            y+=etendue;
        }

        // Étape 2 : remplissage progressif en moyenne avec les voisins supérieurs et latéraux
        for (int y = 1; y < size[1]; y++)
        {
            for (int x = 1; x < size[0]-1; x++)
            {
                float sum = 0;
                int count = 0;

                // voisin du haut
                foreach (Terrain terrain in ListTerrains){
                    if (terrain.Coordonnées[0]==x && terrain.Coordonnées[1]==y-1){
                        switch(terrain.Type){
                            case "Terre":
                                sum += 0;
                                break;
                            case "Argile":
                                sum += 1;
                                break;
                            case "Sable":
                                sum += 2;
                                break;
                        }
                    }
                }
                count++;

                // voisin gauche
                if (x > 0)
                {
                    foreach (Terrain terrain in ListTerrains){
                        if (terrain.Coordonnées[0]==x-1 && terrain.Coordonnées[1]==y){
                            switch(terrain.Type){
                                case "Terre":
                                    sum += 0;
                                    break;
                                case "Argile":
                                    sum += 1;
                                    break;
                                case "Sable":
                                    sum += 2;
                                    break;
                            }
                        }
                    }
                    count++;
                }

                // voisin droite
                if (x < size[0] - 1)
                {
                    foreach (Terrain terrain in ListTerrains){
                        if (terrain.Coordonnées[0]==x+1 && terrain.Coordonnées[1]==y-1){
                            switch(terrain.Type){
                                case "Terre":
                                    sum += 0;
                                    break;
                                case "Argile":
                                    sum += 1;
                                    break;
                                case "Sable":
                                    sum += 2;
                                    break;
                            }
                        }
                    }
                    count++;
                }

                // Moyenne avec un bruit
                double average = (double)sum / count;

                // Ajout d'un décalage aléatoire
                double noise = rand.NextDouble() * 0.6 - 0.3; // bruit entre -0.3 et 0.3
                double finalValue = average + noise;

                // Clamp et arrondi à 0, 1 ou 2
                int value = (int)Math.Round(finalValue);
                value = Math.Max(0, Math.Min(2, value));
                switch(value){
                    case 0:
                        ListTerrains.Add(new Terre([x, y]));
                        break;
                    case 1:
                        ListTerrains.Add(new Argile([x, y]));
                        break;
                    case 2:
                        ListTerrains.Add(new Sable([x, y]));
                        break;
                }
            }
        }
    }

    public void NouveauJour(){
        foreach (Terrain terrain in ListTerrains){
            if (terrain.Legume!=null){
                terrain.Legume.Grandir(terrain.Engrais);
            }
        }
        int[] selectedIndex;
        do
        {
            selectedIndex = PotagerEtInventaire([0,0]);
            switch(PotagerEtAction(selectedIndex))
            {
                case 0:
                    Planter("Patate",selectedIndex);
                    break;
            }
        } while (false);
    }
}
public class Jeu{
    public List<Potager> Sauvegardes {get; private set;}
    public Jeu(){
        Sauvegardes = new List<Potager>();
        bool quitter = false;
        do{
            AfficherTitle();
            switch (AfficherMenu(["1. Nouvelle Partie 🌾","2. Charger une Partie 🧺","3. Crédits 🖋️","4. Quitter 🌙"])){
                case 0:
                    switch (AfficherMenu(["1. France FR","2. Madagascar MD","3. Placinland PL","4. Retour"]))
                    {
                        case 0:
                            CreerPotager(DemanderTaillePotager(),"France");
                            break;
                        case 1:
                            CreerPotager(DemanderTaillePotager(),"Madagascar");
                            break;
                        case 2:
                            CreerPotager(DemanderTaillePotager(),"Placinland");
                            break;
                        case 3:
                            break;
                    }
                    break;
                case 1:
                    int numéroPartie = ChargerSauvegarde();
                    if (numéroPartie!=Sauvegardes.Count()) {Sauvegardes[numéroPartie].ChargerPotager();}
                    break;
                case 2:
                    Credit();
                    break;
                case 3:
                    quitter = true;
                    break;
            }
        } while (!quitter);
    }
    //Affiche le titre
    public void AfficherTitle()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("███████╗███╗   ██╗███████╗");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("███████╗███╗   ███╗███████╗███╗   ██╗");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(" ██████╗\n");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("██╔════╝████╗  ██║██╔════╝");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("██╔════╝████╗ ████║██╔════╝████╗  ██║");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("██╔═══██╗\n");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("█████╗  ██╔██╗ ██║███████╗");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("█████╗  ██╔████╔██║█████╗  ██╔██╗ ██║");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("██║   ╚═╝\n");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("██╔══╝  ██║╚██╗██║     ██║");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("██╔══╝  ██║╚██╔╝██║██╔══╝  ██║╚██╗██║");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("██║   ██╗\n");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("███████╗██║ ╚████║███████║");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("███████╗██║ ╚═╝ ██║███████╗██║ ╚████║");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("╚██████╔╝\n");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("══════╝╚═╝  ╚═══╝╚══════╝");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("╚╚══════╝╚═╝     ╚═╝╚══════╝═╝  ╚═══╝ ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(" ╚═════╝ \n");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("                  🌱 Le simulateur de potager ultime 🌱                  \n");
    }
    //Affiche le menu
    public int AfficherMenu(string[] menuItems){
        ConsoleKey key;
        int selectedIndex = 0;
        do
        {
            Console.Clear();
            AfficherTitle();
            Console.WriteLine("────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("Utilisez les flèches ↑ ↓ pour naviguer, Entrée pour sélectionner :\n");
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    // Met en surbrillance l'élément sélectionné
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(menuItems[i]);
                }
            }
            Console.WriteLine("────────────────────────────────────────────────────────────────────────");
            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % menuItems.Length;
                    break;
                case ConsoleKey.Enter:
                    break;
            }
        } while (key != ConsoleKey.Enter);
        return (selectedIndex);
    }
    //Affiche et charge les sauvegardes
    public int ChargerSauvegarde(){
        ConsoleKey key;
        int selectedIndex = 0;
        do
        {
            Console.Clear();
            AfficherTitle();
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("Utilisez les flèches ↑ ↓ pour naviguer, Entrée pour sélectionner :\n");
            for (int i = 0; i < Sauvegardes.Count(); i++)
            {
                if (i == selectedIndex)
                {
                    // Met en surbrillance l'élément sélectionné
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($"{i+1}. Semaine {Sauvegardes[i].Semaine+1} - Taille: {Sauvegardes[i].Size[0]*Sauvegardes[i].Size[1]} - {Sauvegardes[i].Climat}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{i+1}. Semaine {Sauvegardes[i].Semaine+1} - Taille: {Sauvegardes[i].Size[0]*Sauvegardes[i].Size[1]} - {Sauvegardes[i].Climat}");
                }
            }
            if (selectedIndex == Sauvegardes.Count())
                {
                    // Met en surbrillance l'élément sélectionné
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($"{Sauvegardes.Count()+1}. Quitter");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{Sauvegardes.Count()+1}. Quitter");
                }
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex == 0) ? Sauvegardes.Count()+1 - 1 : selectedIndex - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % (Sauvegardes.Count()+1);
                    break;
                case ConsoleKey.Enter:
                    break;
            }
        } while (key != ConsoleKey.Enter);
        return(selectedIndex);
    }
    //Demande la taille du potager et verifie les entrées de l'utilisateur
    public int[] DemanderTaillePotager(){
        int[] size = [0,0];
        string reponse = "";
        do{
            Console.Clear();
            AfficherTitle();
            Console.WriteLine("────────────────────────────────────────────────────────────────────────");
            if (size[0]==0){
                Console.WriteLine("Entrez la largeur du potager (supérieur à 5) :\n");
                reponse = Console.ReadLine();
                try
                {
                    if (!int.TryParse(reponse, out size[0]))
                    {
                        throw new Exception("Format incorrecte, un entier est demandé");
                    }
                    size[0] = Convert.ToInt32(reponse);
                    if (size[0]<6)
                    {
                        size[0]=0;
                        throw new Exception("Nombre superieur à 5");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message+"\n────────────────────────────────────────────────────────────────────────");
                    Thread.Sleep(2000);
                }
            } else {
                Console.WriteLine("Entrez la longueur du potager (supérieur à 5) :\n");
                reponse = Console.ReadLine();
                try
                {
                    if (!int.TryParse(reponse, out size[1]))
                    {
                        throw new Exception("Format incorrecte, un entier est demandé");
                    }
                    size[1] = Convert.ToInt32(reponse);
                    if (size[1]<6)
                    {
                        size[1]=0;
                        throw new Exception("Nombre superieur à 5");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message+"\n────────────────────────────────────────────────────────────────────────");
                    Thread.Sleep(2000);
                }
            }
        } while (size[0]==0 || size[1]==0);
        return (size);
        }
    //Affiche les crédits
    public void Credit(){
        Console.Clear();
        Console.WriteLine("────────────────────────────────────────────────────────────────────────");
        Console.WriteLine(@"🖋️ Crédits – Le simulateur de potager ultime 🌱
Développement & Programmation
👨‍💻 Elian BENOIS
💻 Moteur de menus fluide comme une rivière d’irrigation

Game Design
🌾 Elian BENOIS
💡 Idées fertiles comme un compost bien mûr

Graphismes & Interface
🎨 Elian BENOIS
🧑‍🎨 UI aux petits oignons (bio, bien sûr)

Scénario & Lore du Potager
📚 Elian BENOIS
🧙 Histoires de légumes enchantés et terres fertiles oubliées

Tests & QA (Qualité des Asperges)
🐛 Elian BENOIS
🧪 A détecté plus de bugs que de doryphores en saison

Remerciements Spéciaux
🥕 À nos grand-parents pour les méthodes de culture
🍄 À M. PLACIN, pour son amour des champignons
🚷 À Mathis GARNIER, parti trop tôt
💚 À toi, joueur·se, pour faire pousser la vie pixel par pixel

───────────────────────────────────────────────────────────────
         🌙 Merci d’avoir joué… et bon jardinage ! 🌿
───────────────────────────────────────────────────────────────
Entrée pour quitter :");
Console.ReadKey();
    }
    //Crée le potager
    public void CreerPotager(int[] size,string pays){
        Sauvegardes.Add(new Potager(size,pays));
    }
}
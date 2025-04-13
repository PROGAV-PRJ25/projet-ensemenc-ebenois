public class Jeu{
    public List<Potager> Sauvegardes {get; private set;}
    public Jeu(){
        Sauvegardes = new List<Potager>();
        AfficherTitle();
        AfficherMenu();
    }
    public void AfficherTitle(){
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
    public void AfficherMenu(){
        string[] menuItems =["1. Nouvelle Partie 🌾","2. Charger une Partie 🧺","3. Options ⚙️","4. Crédits 🖋️","5. Quitter 🌙"];
        int selectedIndex = 0;
        ConsoleKey key;
        do
        {
            Console.Clear();
            AfficherTitle();
            Console.WriteLine("────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("Utilise les flèches ↑ ↓ pour naviguer, Entrée pour sélectionner :\n");
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
        switch (selectedIndex){
            case 0:
                CreerPotager();
                break;
        }
    }
 
    public void CreerPotager(){
        Sauvegardes.Add(new Potager([5,5],"France"));
        Sauvegardes[0].Ajouter("Patate",10);
        Sauvegardes[0].Ajouter("Champignon",2);
        for (int i = 0;i<2;i++)
        {
            Sauvegardes[0].Planter("Patate",i,i);
        }
        Sauvegardes[0].Planter("Champignon",1,2);
        Console.WriteLine(Sauvegardes[0]);
        Console.ReadKey();
        Sauvegardes[0].NouveauJour();
        Sauvegardes[0].Planter("Champignon",1,2);
        Console.WriteLine(Sauvegardes[0]);
        Console.ReadKey();
        Sauvegardes[0].NouveauJour();
        Sauvegardes[0].Planter("Champignon",1,3);
        Console.WriteLine(Sauvegardes[0]);
        Console.ReadKey();
        Sauvegardes[0].NouveauJour();
        Sauvegardes[0].Planter("Champignon",1,4);
        Console.WriteLine(Sauvegardes[0]);
        Console.ReadKey();
        Sauvegardes[0].NouveauJour();
        Console.WriteLine(Sauvegardes[0]);
        Console.ReadKey();
        Sauvegardes[0].NouveauJour();
        Console.WriteLine(Sauvegardes[0]);
        Console.ReadKey();
        Sauvegardes[0].NouveauJour();
        Console.WriteLine(Sauvegardes[0]);
        Console.ReadKey();
        Sauvegardes[0].NouveauJour();
        Console.WriteLine(Sauvegardes[0]);
        Console.ReadKey();
        Sauvegardes[0].NouveauJour();
        Console.WriteLine(Sauvegardes[0]);
        Console.ReadKey();
        Sauvegardes[0].NouveauJour();
        Console.WriteLine(Sauvegardes[0]);
    }
}
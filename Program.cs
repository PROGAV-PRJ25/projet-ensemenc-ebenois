using System.Text;
Console.OutputEncoding = Encoding.UTF8;

Potager v1 = new Potager([5,7],"France");
v1.Ajouter("Patate",10);
v1.Ajouter("Champignon",2);
for (int i = 0;i<2;i++)
{
    v1.Planter("Patate",i,i);
}
v1.Planter("Champignon",1,2);
Console.WriteLine(v1);
Thread.Sleep(5000);
v1.NouveauJour();
v1.Ajouter("Patate",2);
v1.Planter("Champignon",1,2);
Console.WriteLine(v1);
Thread.Sleep(5000);
v1.NouveauJour();
v1.Planter("Champignon",1,3);
Console.WriteLine(v1);
Thread.Sleep(5000);
v1.NouveauJour();
v1.Planter("Champignon",1,4);
Console.WriteLine(v1);
Thread.Sleep(5000);
v1.NouveauJour();
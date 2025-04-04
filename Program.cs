Potager v1 = new Potager([5,7],"France");
for (int i = 0;i<2;i++)
{
    v1.Planter("Patate",i,i);
}
v1.Planter("Champignon",1,2);
for (int i = 0;i<8;i++)
{
    Console.WriteLine(v1);
    Thread.Sleep(5000);
    v1.NouveauJour();
}
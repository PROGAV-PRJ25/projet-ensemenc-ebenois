Potager v1 = new Potager([5,7],"France");
for (int i = 0;i<2;i++)
{
    v1.Ajouter(new Patate(i,i));
}
v1.Ajouter(new Champignon(1,2));
Console.WriteLine(v1);
v1.Information();
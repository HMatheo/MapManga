using MangaMap.Model;
using MangaMap.Stub;
using MangaMap.Views;

namespace MangaMap;

public partial class App : Application
{
    public string FileName { get; set; } = "SauvegardeDonnees.xml";
    public string FilePath { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

    public Manager MyManager { get; private set; } = new Manager(new Stub.Stub());      //pour utiliser le stub comme moyen de persistance.

    public Admin MyAdmin { get; private set; } = new Admin("test", "test@test.ts", "Pseudo_test");

    public App()
    {
        InitializeComponent();

        if (File.Exists(Path.Combine(FilePath, FileName)))
        {
            MyManager = new Manager(new Stub.Stub());	//pour utiliser le dataContract comme moyen de persistance.
        }

        //MyManager.charger();
        MyManager.Admins.Add(MyAdmin);
        MyManager.UtilisateurActuel = MyManager.charger();

        MainPage = new AppShell();

        if (!File.Exists(Path.Combine(FilePath, FileName)))
        {
            MyManager.Persistance = new DataContract();     //pour utiliser le stub comme moyen de persistance.
        }

        //MyManager.sauvegarder();
        Console.WriteLine("sauvegarde faite");
    }
}

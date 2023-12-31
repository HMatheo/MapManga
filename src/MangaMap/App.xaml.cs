﻿///// \brief Fichier pour la classe App
///// \author HERSAN Mathéo, JOURDY Vianney
/// \file App.xaml.cs

using Models;
using Stub;
using MangaMap.Views;
using System.Diagnostics;

namespace MangaMap;

/// <summary>
/// Classe représentant l'application principale.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Nom du fichier de sauvegarde des données.
    /// </summary>
    public string FileName { get; set; } = "SauvegardeDonnees.xml";

    /// <summary>
    /// Chemin du fichier de sauvegarde des données.
    /// </summary>
    public string FilePath { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

    /// <summary>
    /// Gestionnaire principal de l'application.
    /// </summary>
    public Manager MyManager { get; private set; } = new Manager(new Stub.Stub()); // Utilise le Stub comme moyen de persistance.

    /// <summary>
    /// Administrateur principal de l'application.
    /// </summary>
    public Admin MyAdmin { get; private set; } = new Admin("test", "test@test.ts", "Pseudo_test");

    /// <summary>
    /// Constructeur de l'application.
    /// </summary>
    public App()
    {
        InitializeComponent();

        if (File.Exists(Path.Combine(FilePath, FileName)))
        {
            MyManager = new Manager(new DataContractPersistance.DataContractXml()); // Utilise le DataContract comme moyen de persistance.
            //MyManager = new Manager(new Stub.DataContractJson()); // Utilise le DataContract comme moyen de persistance.
        }

        MyManager.charger();
        MyManager.Admins.Add(MyAdmin);

        MainPage = new AppShell();

        if (!File.Exists(Path.Combine(FilePath, FileName)))
        {
            MyManager.Persistance = new DataContractPersistance.DataContractXml(); // Utilise le Stub comme moyen de persistance.
        }

        MyManager.sauvegarder();
        Console.WriteLine("Sauvegarde effectuée.");
    }
}
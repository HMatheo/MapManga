///// \brief Fichier pour la classe Stub
///// \author HERSAN Mathéo, JOURDY Vianney
/// \file Stub.cs

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Stub
{
    /// <summary>
    /// Classe de stub pour la gestion de la persistance des données.
    /// </summary>
    public class Stub : IPersistanceManager
    {
        /// <summary>
        /// Charge un jeu de données en mémoire.
        /// </summary>
        /// <returns>Un tuple contenant la liste des oeuvres et la liste des utilisateurs.</returns>
        public (ObservableCollection<Oeuvre>, List<Utilisateur>) chargeDonne()
        {
            ObservableCollection<Oeuvre> l1 = new ObservableCollection<Oeuvre>();
            List<Utilisateur> l2 = new List<Utilisateur>();

            Utilisateur u1 = new Utilisateur("t", "Pseudo1", "t", "Jean", "Baptiste", 12);
            Utilisateur u2 = new Utilisateur("s", "Pseudo2", "s", "Baptiste", "Jean", 12);
            Utilisateur u3 = new Utilisateur("v", "Pseudo3", "v", "David", "Marc", 12);
            List<string> genres = new List<string>();
            genres.Add("Action");
            genres.Add("Future");
            Oeuvre o1 = new Oeuvre("Evangelion", genres, "TV", "En 2000, une gigantesque explosion se produit en Antarctique, provoquant un cataclysme (raz-de-marée, fonte des calottes polaires) qui dévaste une grande partie de la planète. Les autorités déclarent que cette catastrophe était due à la chute d'un astéroïde sur la planète.\r\n\r\nQuinze ans plus tard, l'humanité a surmonté cet événement, appelé le Second Impact. Mais de mystérieuses créatures nommées Anges font leur apparition, et tentent de détruire Tokyo-3, la nouvelle capitale forteresse du Japon, construite après le Second Impact.\r\n\r\nPour les combattre, l'organisation secrète NERV a mis au point une arme ultime, l'Evangelion ou l'Eva, robot géant anthropoïde piloté.\r\n\r\nShinji Ikari, quatorze ans, se rend à Tokyo-3 sur invitation de son père, qu'il n'a pas revu depuis dix ans. Il est loin de se douter qu'il sera impliqué dans un conflit qui pourrait bien signifier la fin de l'humanité quoi qu'il arrive...", 4, 26, "evangelion.jpg");
            Oeuvre o2 = new Oeuvre("[Oshi No Ko]", genres, "DVD", "Le docteur Gorô est obstétricien dans un hôpital de campagne. Il est loin du monde de paillettes dans lequel évolue Ai Hoshino, une chanteuse au succès grandissant dont il est \"un fan absolu\". Ces deux-là vont peut-être se rencontrer dans des circonstances peu favorables, mais cet événement changera leur vie à jamais !", 2, 11, "oshinoko.png");
            Oeuvre o3 = new Oeuvre("One Piece", genres, "TV", "Gloire, fortune et puissance, c'est ce que possédait Gold Roger, le tout puissant roi des pirates, avant de mourir sur l'échafaud. Mais ses dernières paroles ont éveillées bien des convoitises, et lança la fabuleuse \"ère de la piraterie\", chacun voulant trouver le fabuleux trésor qu'il disait avoir laissé.\r\n\r\nBien des années plus tard, Shanks, un redoutable pirate aux cheveux rouges, rencontre Luffy, un jeune garçon d'une dizaine d'années dans un petit port de pêche. Il veut devenir pirate et le rejoindre, mais Shanks lui répond qu'il est trop jeune. Plus tard, Luffy avalera accidentellement le fruit Gomu Gomu qui rendra son corps élastique, mais aussi maudit par les eaux. Incapable de nager, Luffy ne veut pourtant pas renoncer à son rêve. Pour le consoler lorsqu'il part, Shanks lui offre son chapeau. Luffy jure alors de le rejoindre un jour avec son propre équipage.\r\n\r\nA 17 ans, Luffy prend la mer dans une petite barque avec pour but de réunir un équipage de pirates, mais de pirates pas comme les autres, qui devront partager sa conception un peu étrange de la piraterie. L'aventure est lancée.", 2, 1064, "onepiece.jpg");
            Oeuvre o4 = new Oeuvre("Naruto", genres, "DVD", "Dans le village de Konoha vit Naruto, un jeune garçon détesté et craint des villageois du fait qu'il détienne en lui Kyuubi (démon renard à neuf queues) d'une incroyable force, qui a tué un grand nombre de personnes. Le ninja le plus puissant de Konoha à l'époque, le quatrième Hokage, Minato Namikaze, réussit à sceller ce démon dans le corps de Naruto.\r\nMalheureusement il y laissa la vie.\r\n\r\nC'est ainsi que douze ans plus tard, Naruto rêve de devenir le plus grand Hokage de Konoha afin que tous le reconnaissent à sa juste valeur. Mais la route pour devenir Hokage est très longue et Naruto sera confronté à un bon nombre d'épreuves et devra affronter de nombreux ennemis pour atteindre son but !", 2, 220, "naruto.jpg");
            Oeuvre o5 = new Oeuvre("Vinland Saga Season 2", genres, "DVD", "Il s'agit de la seconde saison de la série animée Vinland Saga. Il s'agit de l'adaptation de l'arc des esclaves.\r\n\r\nCet arc débute un an et demi après la fin de la première saison. Après avoir tenté de tuer Canute, Thorfinn est vendu comme esclave à un certain Ketil. C'est dans la ferme de ce dernier que le jeune homme, difficilement reconnaissable, défriche la forêt et cultive la terre. Dans cet endroit, il rencontre et se lie d'amitié avec Einar, un autre esclave qui va l'obliger à changer d'attitude. Malgré les cauchemars de son ancienne vie qui le hantent, Thorfinn, avec le soutien de quelques personnes, va doucement se reconstruire et emprunter la voie de la rédemption.\r\n\r\nPendant ce temps, le roi Canute met en place son plan pour créer un paradis sur Terre et s'occupe aussi de la malédiction de la couronne.", 2, 24, "vinlandsaga.jpg");
            Oeuvre o6 = new Oeuvre("Hell's Paradise", genres, "DVD", "Gabimaru, « Le Vide », un célèbre et puissant shinobi a été capturé et croupit en prison. Affirmant n'avoir plus aucune raison de vivre, il attend désespérément qu'un bourreau parvienne à lui ôter la vie, son entraînement surhumain lui permettant de résister aux pires des châtiments. C'est alors qu'il reçoit la visite d'un exécuteur pas comme les autres : une puissante manieuse de sabre et trancheuse de tête. Après un âpre combat dont il réchappe de peu, celle-ci le pousse dans ses retranchements. En échange de la vie sauve, elle lui propose un marché : il devra se rendre sur une île mystérieuse afin de récupérer un élixir d'immortalité. Seul problème : les seuls humains rescapés de cette île en sont revenu sous forme de... fleurs.", 2, 13, "jigokuraku.jpg");
            Oeuvre o7 = new Oeuvre("Bocchi the Rock!", genres, "TV", "L'histoire suit le quotidien de Gotou Hitori, une lycéenne qui a commencé à apprendre à jouer de la guitare pour réaliser son rêve : faire partie d'un groupe. Malheureusement, la jeune musicienne est bien trop timide et n'a donc pas réussi à se faire un seul ami. Cependant, sa rencontre avec Ijichi Nijika pourrait bien tout changer. En effet, cette dernière est une batteuse et elle est à la recherche d'une guitariste pour son groupe.", 3, 12, "bocchi.png");
            Oeuvre o8 = new Oeuvre("Mashle", genres, "TV", "Dans un monde où la magie fait loi, il était une fois Mash Burnedead ! Élevé au fin fond de la forêt, le jeune garçon passe ses journées entre séances de musculation et dégustations de choux à la crème.\r\nMais un jour, un agent de police découvre son secret : il est né sans pouvoirs magiques, ce qui est puni de mort ! Pour survivre, il va devoir postuler à Easton, une prestigieuse académie de magie, et en devenir le meilleur élève...\r\nLa magie n'a plus qu'à bien se tenir : avec sa musculature affûtée et sa force hors du commun, Mash compte bien pulvériser tous les sorts et briser les codes de cette société !", 4, 12, "mashle.png");
            Oeuvre o9 = new Oeuvre("Tengoku Daimakyou", genres, "TV", "À l'intérieur de ces murs, ces enfants vivent dans l'insouciance absolue. Car s'ils devaient sortir, ils entreraient en Enfer. Pourtant, l'un d'eux semble avoir eu une vision : deux humains viendraient les chercher depuis l'extérieur, l'un d'entre eux leur ressemblant étrangement...\r\n\r\nPendant ce temps, Maru et sa garde-du-corps tentent de survivre dans un monde désolé peuplé de pillards et de monstres difformes. Leur objectif : atteindre \"le paradis\".", 4, 13, "tengoku.jpg");
            Oeuvre o10 = new Oeuvre("NieR:Automata Ver1.1a", genres, "TV", "Il s'agit d'une série TV basée sur l'univers du jeu NieR :Automata.\r\n\r\n2B, une androïde de type YoRHa, a pour mission d'aider l'Humanité à reprendre le contrôle de la Terre. Elle est pour cela secondée par 9S.", 3, 8, "nier.jpg");
            Oeuvre o11 = new Oeuvre("Devilman: Crybaby", genres, "ONA", "Devilman Crybaby est un projet de série TV animée du réalisateur Masaaki Yuasa, produit en collaboration avec Netflix. Il s'agit d'une nouvelle adaptation de Devilman, réalisée à l'occasion des 50 ans de carrière du mangaka à l'origine de l'œuvre, Go Nagai.\r\n\r\nLa série est diffusée dans le monde entier sur toutes les plateformes Netflix des différents pays dans lesquelles le service est disponible, soit plus de 190 pays et dans 25 langues différentes.\r\n\r\nLes démons qui dominaient la Terre il y a longtemps ont vu leur monde détruit. De nos jours, Fudô Akira, un lycéen de faible constitution logeant chez son amie Makimura Miki voit revenir son ami d'enfance,Asuka Ryô, qui a découvert lors de son séjour en Amérique que les démons agissent toujours dans l'ombre et se sont infiltrés dans la société humaine.\r\n\r\nCe dernier lui demande de l'aider à les combattre et il va alors fusionner avec Amon, un démon, et ainsi devenir Devilman, l'homme-démon. S'ensuit alors des combats incessants et sanglants où démons et humains montreront les pires facettes de leurs personnalités.", 5, 10, "devilman.jpg");
            Oeuvre o12 = new Oeuvre("Fullmetal Alchemist: Brotherhood", genres, "TV" ,"Cette version est une seconde adaptation du manga de Hiromu Arakawa. Elle est bien plus fidèle au manga que la précédente version, et le design change quelque peu.\r\n\r\nEdward Elric et son frère Alphonse Elric sont de jeunes Alchimistes. En tentant de ramener leur mère à la vie, ils ont payé un lourd tribut, et ils tentent désormais de récupérer ce qu'ils ont perdu. Pour cela, Edward est devenu Alchimiste d'État : le Fullmetal Alchemist. Mais au cours de leurs recherches, bien des épreuves attendent les deux frères et des êtres étranges : les Homonculus, les poursuivent.", 4, 64, "fmab.jpg");
            Oeuvre o13 = new Oeuvre("Hunter x Hunter (2011)", genres, "TV", "Réadaptation du célèbre manga Hunter x Hunter en une nouvelle série.\r\n\r\nLe jeune Gon vit sur une petite île avec sa tante. Abandonné par son père qui est un Hunter, à la fois un aventurier et un chasseur de primes, Gon décide à l'âge de 12 ans de partir pour devenir un Hunter.\r\nCela ne sera pas chose aisée, il devra passer une suite de tests et examens en compagnie de milliers d'autres prétendants au titre de Hunter.\r\nIl sera aidé par de nouvelles connaissances qui aspirent au même but que lui, telles que Kurapika, Leorio et Killua.", 4, 148, "hxh.png");

            l1.Add(o1); l1.Add(o2); l1.Add(o3); l1.Add(o4); l1.Add(o5); l1.Add(o6); l1.Add(o7); l1.Add(o8); l1.Add(o9); l1.Add(o10); l1.Add(o11); l1.Add(o12); l1.Add(o13); 
            l2.Add(u1); l2.Add(u2); l2.Add(u3);

            return (l1, l2);
        }

        /// <summary>
        /// Méthode non implémentée pour la sauvegarde des données.
        /// </summary>
        /// <param name="o">La liste des oeuvres à sauvegarder.</param>
        /// <param name="u">La liste des utilisateurs à sauvegarder.</param>
        public void sauvegarder(ObservableCollection<Oeuvre> o, List<Utilisateur> u)
        {
            Console.WriteLine("Méthode sauvegarder() appelée.");
        }
    }
}

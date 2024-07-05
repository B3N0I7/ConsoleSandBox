using consolesandbox.Models;
using consolesandbox.UseCases;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("dP                 .8888b                   oo                   ");
        Console.WriteLine("88                 88                                            ");
        Console.WriteLine("88        .d8888b. 88aaa  .d8888b. dP    dP dP 88d888b. .d8888b. ");
        Console.WriteLine("88        88'  `88 88     88'  `88 88    88 88 88'  `88 88ooood8 ");
        Console.WriteLine("88        88.  .88 88     88.  .88 88.  .88 88 88    88 88.  ... ");
        Console.WriteLine("88888888P `88888P8 dP     `88888P' `88888P' dP dP    dP `88888P' ");
        Console.WriteLine();
        Console.WriteLine("####    ####    ####    ####    ####    ####    ####    ####    #");
        Console.WriteLine();
        Console.WriteLine(" .d888888  dP dP            dP            dP");
        Console.WriteLine("d8'    88  88 88            88            88");
        Console.WriteLine("88aaaaa88a 88 88 .d8888b. d8888P .d8888b. 88d888b. dP    dP .d8888b.");
        Console.WriteLine("88     88  88 88 88'  `88   88   88'  `88 88'  `88 88    88 Y8ooooo.");
        Console.WriteLine("88     88  88 88 88.  .88   88   88.  .88 88.  .88 88.  .88       88");
        Console.WriteLine("88     88  dP dP `88888P'   dP   `88888P' 88Y8888' `88888P' `88888P'");
        Console.WriteLine();

        //string userName = AskName();
        //ShowHelloName(userName);

        //Console.Write("Donne ton nom : ");
        //var askedName = Console.ReadLine();
        // Devient :
        var askedName = PersonInteractions.GetUserName();

        var newPerson = new Person
        {
            Firstname = askedName
        };

        Console.WriteLine($"Salut l'ami {newPerson.Firstname}");
        Console.WriteLine();

        // Déclarer des variables composant le chemin et le nom du fichier userfirstname-dictionnary.txt 
        //string filePath = "C:\\repos\\";
        //string fileName = ($"{newPerson.Firstname}-dictionary.txt");
        // Devient :
        string filePath = Path.Combine("C:\\repos\\", $"{newPerson.Firstname}-dictionary.txt");

        var existingWords = FileOperations.ReadWordsFromFile(filePath);

        if (existingWords.Count > 0)
        {
            Console.WriteLine("Mots existants dans le dictionnaire :");

            foreach (var word in existingWords)
            {
                Console.WriteLine($"Dans la liste de mots depuis fichier : {word.MotFr}");
            }
        }
        else
        {
            Console.WriteLine("Je vais te créer un dictionnaire à ton nom");
        }

        int numberOfWordsInInteger = PersonInteractions.GetWordCount();

        Console.WriteLine($"Tu as choisi d'ajouter {numberOfWordsInInteger} mots.");

        var addedWords = WordManagement.AddNewWords(numberOfWordsInInteger, existingWords);

        FileOperations.WriteWordsToFile(filePath, addedWords);

        Console.WriteLine("Voici le contenu actuel du dictionnaire :");

        FileOperations.PrintFileContent(filePath);
    }

    static string AskName()
    {
        Console.Write("Utilisateur, donne-moi ton nom : ");
        return Console.ReadLine();
    }

    static void ShowHelloName(string userName)
    {
        Console.WriteLine();
        Console.WriteLine($"Bonjour {userName}.");
    }
}



//BenchmarkRunner.Run<DateParserBenchmarcks>();





//// Instancier une liste de mots 
//var newListMot = new List<Mot>();
//var line = "";


//if (File.Exists(Path.Combine(filePath, fileName)))
//{
//    // Ouvrir en mode lecture du fichier
//    using (StreamReader streamReader = new StreamReader(Path.Combine(filePath, fileName)))
//    {
//        // Lire la première ligne
//        line = streamReader.ReadLine();

//        // Continuer à lire tant que line n'est pas null
//        while (line != null)
//        {
//            // Ecrire une nouvelle classe Mot

//            var newMot = new Mot();
//            newMot.MotFr = line;
//            newListMot.Add(newMot);

//            // Lire la ligne suivante
//            line = streamReader.ReadLine();
//        }

//        foreach (var mot in newListMot)
//        {
//            Console.WriteLine($"Dans la liste de mots depuis fichier : {mot.MotFr}");
//        }

//        foreach (var mot in newListMot)
//        {
//            Console.WriteLine($"Dans classe depuis fichier : {mot.MotFr}");
//        }
//    }
//}
//else
//{ Console.WriteLine("nous allons creer un dictionnaire à ton nom"); }

//int nombreDeMotsEnChiffres = 666;

//while (nombreDeMotsEnChiffres < 1 || nombreDeMotsEnChiffres > 10)
//{
//    Console.Write("Combien de mots veux-tu ajouter (1-10) ?  ");

//    var nombreDeMots = Console.ReadLine();


//    nombreDeMotsEnChiffres = int.Parse(nombreDeMots);
//}

//var listAddedWords = new List<Mot>();

//Console.WriteLine($"Tu as choisis d'ajouter {nombreDeMotsEnChiffres} mots.");

//var listeMots = new List<Mot>();

//for (var i = 0; i < nombreDeMotsEnChiffres; i++)
//{
//    Console.Write($"Ajoute le mot N° {i + 1} : ");

//    // Demander le nouveau mot
//    var newWord = Console.ReadLine();

//    // Tester s'il existe déjà
//    bool wordExists = newListMot.Exists(m => m.MotFr == newWord);

//    if (!wordExists)
//    {
//        // Ajouter le nouveau mot à la liste s'il n'existe pas
//        listAddedWords.Add(new Mot { MotFr = newWord });
//        Console.WriteLine($"Le mot '{newWord}' a été ajouté !!!");
//    }
//    else
//    {
//        Console.WriteLine($"Le mot '{newWord}' existe déjà !!!.");
//    }
//}

//// Ouvrir en mode écriture du fichier userfirstname-dictionnary 
//StreamWriter streamWriter = new StreamWriter(Path.Combine(filePath, fileName), true);

//// Ecrire les nouveaux mots dans la console et dans le dictionary.txt
//foreach (var mot in listAddedWords)
//{
//    Console.WriteLine($"La classe temp écrit : {mot.MotFr}");

//    streamWriter.WriteLine(mot.MotFr);
//}

//// Afficher des nouveaux mots dans la console et consignation dans le dictionnary.txt
//foreach (var mot in listeMots)
//{
//    Console.WriteLine($"La classe écrit : {mot.MotFr}");
//    streamWriter.WriteLine(mot.MotFr);
//}
//// Fermer userfirstname-dictionnary
//streamWriter.Close();

//// Lire le fichier dictionnary.txt
//StreamReader inputFile = new StreamReader(Path.Combine(filePath, fileName));


//// Lire la première ligne
//var line2 = inputFile.ReadLine();

//// Continuer à lire tant que line n'est pas null
//while (line2 != null)
//{
//    // Ecrire la ligne dans la console
//    Console.WriteLine($"Le fichier écrit : {line2}");

//    // Lire la ligne suivante
//    line2 = inputFile.ReadLine();
//}

//// Lire la première ligne
//line = inputFile.ReadLine();

//// Continuer à lire tant que line n'est pas null
//while (line != null)
//{
//    // Ecrire la ligne dans la console
//    Console.WriteLine($"Le fichier écrit : {line}");

//    // Lire la ligne suivante
//    line = inputFile.ReadLine();
//}

//// Fermer le fichier dictionary.txt
//inputFile.Close();


// TODO
// Add the translation in english, in spanish
// Add question on words

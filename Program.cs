using consolesandbox.Helpers;
using consolesandbox.Models;

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
        Console.WriteLine("####    ####    ####    ####    ####    ####    ####    ####    ####");
        Console.WriteLine();
        Console.WriteLine(" .d888888  dP dP            dP            dP");
        Console.WriteLine("d8'    88  88 88            88            88");
        Console.WriteLine("88aaaaa88a 88 88 .d8888b. d8888P .d8888b. 88d888b. dP    dP .d8888b.");
        Console.WriteLine("88     88  88 88 88'  `88   88   88'  `88 88'  `88 88    88 Y8ooooo.");
        Console.WriteLine("88     88  88 88 88.  .88   88   88.  .88 88.  .88 88.  .88       88");
        Console.WriteLine("88     88  dP dP `88888P'   dP   `88888P' 88Y8888' `88888P' `88888P'");
        Console.WriteLine();

        var askedName = PersonInteractions.GetUserName();

        var newPerson = new Person
        {
            Firstname = askedName
        };

        Console.WriteLine($"Salut l'ami {newPerson.Firstname}");
        Console.WriteLine();

        string filePath = Path.Combine("C:\\repos\\", $"{newPerson.Firstname}-dictionary.txt");

        var existingWords = FileOperations.ReadWordsFromFile(filePath);

        if (existingWords.Count > 0)
        {
            Console.WriteLine("Mots existants dans le dictionnaire :");

            foreach (var word in existingWords)
            {
                Console.WriteLine($"Dans la liste de mots depuis fichier : {word.MotFr}\t{word.MotEn}\t{word.MotEs}");
            }
        }
        else
        {
            Console.WriteLine("Je vais te créer un dictionnaire à ton nom");
        }

        // quiz ou ajout
        var response = string.Empty;

        while (!(response.ToUpper() == "A") && !(response.ToUpper() == "Q"))
        {
            Console.WriteLine($"Que veux-tu faire {newPerson.Firstname} ?");
            Console.WriteLine("A : Ajouter des mots");
            Console.WriteLine("Q : Faire un quiz");
            response = Console.ReadLine();
        }

        switch (response.ToUpper())
        {
            case "A":
                int numberOfWordsInInteger = PersonInteractions.GetWordCount("Combien de mots veux-tu ajouter (1-10) ? ");

                Console.WriteLine($"Tu as choisi d'ajouter {numberOfWordsInInteger} mots.");

                var addedWords = WordManagement.AddNewWords(numberOfWordsInInteger, existingWords);

                FileOperations.WriteWordsToFile(filePath, addedWords);

                Console.WriteLine("Voici le contenu actuel du dictionnaire :");

                FileOperations.PrintFileContent(filePath);
                break;
            case "Q":
                Console.WriteLine("Let's go to the quiz !");
                Console.WriteLine($"Que veux-tu faire {newPerson.Firstname} ?");
                Console.WriteLine("1 : Français => Anglais");
                Console.WriteLine("2 : Français => Espagnol");
                Console.WriteLine("3 : Anglais => Français");
                Console.WriteLine("4 : Espagnol => Français");
                var responseQuiz = Console.ReadLine();
                switch (responseQuiz)
                {
                    case "1":
                        Console.WriteLine("Français => Anglais");
                        filePath = Path.Combine("C:\\repos\\", $"{newPerson.Firstname}-dictionary.txt");

                        existingWords = FileOperations.ReadWordsFromFile(filePath);

                        Random rand = new Random();

                        numberOfWordsInInteger = PersonInteractions.GetWordCount($"Combien de mots veux-tu traduire (1-{existingWords.Count}) ? ");
                        for (var i = 0; i < numberOfWordsInInteger; i++)
                        {
                            var numberRandomWord = rand.Next(0, existingWords.Count);

                            Console.WriteLine($"Traduis {existingWords[numberRandomWord].MotFr}");
                            responseQuiz = Console.ReadLine();
                            if (responseQuiz == existingWords[numberRandomWord].MotEn)
                            {
                                ShowManyWays.ShowYellow("Bravo !");
                            }
                            else
                            {
                                ShowManyWays.ShowDarkCyan($"Ce n'est pas {responseQuiz}, mais {existingWords[numberRandomWord].MotEn}.");
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("Français => Espagnol");
                        break;
                    case "3":
                        Console.WriteLine("Anglais => Français");
                        break;
                    case "4":
                        Console.WriteLine("Espagnol => Français");
                        break;
                    default:
                        ShowManyWays.ShowYellow("Au revoir");
                        break;
                }
                break;
            default:
                Console.WriteLine($"{newPerson.Firstname}, tu dois répondre 'A' ou 'Q' !");
                break;
        }
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


// TODO
// Continue quiz (En>FR, Fr>Es, Es>Fr)
// Refactor
// Add Unit Tests




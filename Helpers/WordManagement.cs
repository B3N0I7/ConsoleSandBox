using consolesandbox.Models;

namespace consolesandbox.Helpers
{
    public class WordManagement
    {
        public static List<Mot> AddNewWords(int count, List<Mot> existingWords)
        {
            var addedWords = new List<Mot>();

            for (var i = 0; i < count; i++)
            {
                Console.Write(($"Ajoute le mot N°{i + 1} : "));

                var newWordFr = Console.ReadLine();

                if (!existingWords.Exists(w => w.MotFr == newWordFr) && !addedWords.Exists(w => w.MotFr == newWordFr))
                {
                    Console.Write("Ajoute la traduction en anglais : ");
                    var newWordEn = Console.ReadLine();

                    Console.Write("Ajoute la traduction en espagnol : ");
                    var newWordEs = Console.ReadLine();
                    addedWords.Add(new Mot { MotFr = newWordFr, MotEn = newWordEn, MotEs = newWordEs });

                    Console.WriteLine($"Le mot '{newWordFr}' a été ajouté, sa traduction en anglais est '{newWordEn}' et sa traduction en espagnol est '{newWordEs}.");

                }
                else
                {
                    Console.WriteLine($"Le mot '{newWordFr}' est déjà dans le dictionnaire.");
                }
            }

            return addedWords;
        }

        public static void LoadQuiz(string person, string typeQuiz)
        {
            var filePath = Path.Combine("C:\\repos\\", $"{person}-dictionary.txt");

            var existingWords = FileOperations.ReadWordsFromFile(filePath);

            Random rand = new Random();

            var numberOfWordsInInteger = PersonInteractions.GetWordCount($"Combien de mots veux-tu traduire (1-{existingWords.Count}) ? ");

            for (var i = 0; i < numberOfWordsInInteger; i++)
            {
                var numberRandomWord = rand.Next(0, existingWords.Count);

                string wordToTranslate = string.Empty;
                string correctAnswer = string.Empty;

                switch (typeQuiz)
                {
                    case "FrEn":
                        wordToTranslate = existingWords[numberRandomWord].MotFr;
                        correctAnswer = existingWords[numberRandomWord].MotEn;
                        break;
                    case "EnFr":
                        wordToTranslate = existingWords[numberRandomWord].MotEn;
                        correctAnswer = existingWords[numberRandomWord].MotFr;
                        break;
                    case "FrEs":
                        wordToTranslate = existingWords[numberRandomWord].MotFr;
                        correctAnswer = existingWords[numberRandomWord].MotEs;
                        break;
                    case "EsFr":
                        wordToTranslate = existingWords[numberRandomWord].MotEs;
                        correctAnswer = existingWords[numberRandomWord].MotFr;
                        break;
                    default:
                        Console.WriteLine("Quiz inconnu !");
                        break;
                }

                Console.WriteLine($"Traduis {wordToTranslate}");

                var responseQuiz = Console.ReadLine();

                if (responseQuiz == correctAnswer)
                {
                    ShowManyWays.ShowYellow("Bravo !");
                }
                else
                {
                    ShowManyWays.ShowDarkCyan($"Ce n'est pas {responseQuiz}, mais {correctAnswer}.");
                }
            }
        }
    }
}

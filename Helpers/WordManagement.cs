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

            List<string> ListofWords = new List<string>();

            var goodAnswers = 0;

            for (var i = 0; i < numberOfWordsInInteger; i++)
            {
                var numberRandomWord = rand.Next(0, existingWords.Count);

                (string wordToTranslate, string correctAnswer) = GetLanguages(existingWords, numberRandomWord, typeQuiz);

                if (!ListofWords.Contains(wordToTranslate))
                {
                    ListofWords.Add(wordToTranslate);

                    Console.WriteLine($"Traduis {wordToTranslate}");

                    var responseQuiz = Console.ReadLine();

                    if (responseQuiz == correctAnswer)
                    {
                        goodAnswers++;
                        ShowManyWays.ShowYellow("Bravo !");
                    }
                    else
                    {
                        ShowManyWays.ShowDarkCyan($"Ce n'est pas {responseQuiz}, mais {correctAnswer}.");
                    }
                }
                else
                {
                    i--;
                }
            }

            Console.WriteLine($"{person}, tu as donné {goodAnswers} bonne(s) réponse(s) sur {numberOfWordsInInteger} possibles.");
        }

        private static (string, string) GetLanguages(List<Mot> words, int index, string typeQuiz)
        {
            string wordToTranslate;
            string correctAnswer;

            switch (typeQuiz)
            {
                case "FrEn":
                    wordToTranslate = words[index].MotFr;
                    correctAnswer = words[index].MotEn;
                    break;
                case "EnFr":
                    wordToTranslate = words[index].MotEn;
                    correctAnswer = words[index].MotFr;
                    break;
                case "FrEs":
                    wordToTranslate = words[index].MotFr;
                    correctAnswer = words[index].MotEs;
                    break;
                case "EsFr":
                    wordToTranslate = words[index].MotEs;
                    correctAnswer = words[index].MotFr;
                    break;
                default:
                    throw new ArgumentException("Quiz type not recognized", nameof(typeQuiz));
            }

            return (wordToTranslate, correctAnswer);
        }
    }
}

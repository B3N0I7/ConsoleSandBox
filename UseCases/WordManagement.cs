using consolesandbox.Models;

namespace consolesandbox.UseCases
{
    public class WordManagement
    {
        public static List<Mot> AddNewWords(int count, List<Mot> existingWords)
        {
            var addedWords = new List<Mot>();

            for (var i = 0; i < count; i++)
            {
                Console.Write(($"Ajoute le mot N°{i + 1} : "));

                var newWord = Console.ReadLine();

                if (!existingWords.Exists(w => w.MotFr == newWord) && !addedWords.Exists(w => w.MotFr == newWord))
                {
                    addedWords.Add(new Mot { MotFr = newWord });

                    Console.WriteLine($"Le mot '{newWord}' a été ajouté.");
                }
                else
                {
                    Console.WriteLine($"Le mot '{newWord}' est déjà dans le dictionnaire.");
                }
            }

            return addedWords;
        }
    }
}

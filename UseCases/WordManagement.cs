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
    }
}

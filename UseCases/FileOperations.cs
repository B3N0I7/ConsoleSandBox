using consolesandbox.Models;

namespace consolesandbox.UseCases
{
    public class FileOperations
    {
        public static List<Mot> ReadWordsFromFile(string filePath)
        {
            var words = new List<Mot>();

            if (File.Exists(filePath))
            {
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    string line;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        words.Add(new Mot { MotFr = line });
                    }
                }
            }

            return words;
        }

        public static void WriteWordsToFile(string filePath, List<Mot> words, bool append = true)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, append))
            {
                foreach (var word in words)
                {
                    streamWriter.WriteLine(word.MotFr);
                }

            }
        }

        public static void PrintFileContent(string filePath)
        {
            using (StreamReader inputFile = new StreamReader(filePath))
            {
                string line;

                while ((line = inputFile.ReadLine()) != null)
                {
                    Console.WriteLine($"Mot dans le fichier : {line}");
                }
            }
        }
    }
}

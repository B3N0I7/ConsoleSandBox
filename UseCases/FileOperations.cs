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
                        string[] wordsInLine = line.Split('\t');
                        if (wordsInLine.Length > 0)
                        {
                            for (var i = 0; i < wordsInLine.Length; i = i + 3)
                            {
                                words.Add(new Mot { MotFr = wordsInLine[i], MotEn = wordsInLine[i + 1], MotEs = wordsInLine[i + 2] });
                            }
                        }
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
                    streamWriter.WriteLine($"{word.MotFr}\t{word.MotEn}\t{word.MotEs}");
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

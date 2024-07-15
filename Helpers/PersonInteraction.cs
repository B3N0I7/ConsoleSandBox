namespace consolesandbox.Helpers
{
    public class PersonInteractions
    {
        public static string GetUserName()
        {
            Console.Write("Utilisateur, donne-moi ton nom : ");

            return Console.ReadLine();
        }

        public static int GetWordCount(string question)
        {
            int numberOfWordsInInteger = 0;

            while (numberOfWordsInInteger < 1 || numberOfWordsInInteger > 10)
            {
                Console.Write(question);

                if (int.TryParse(Console.ReadLine(), out numberOfWordsInInteger))
                {
                    if (numberOfWordsInInteger >= 1 && numberOfWordsInInteger <= 10)
                    {
                        return numberOfWordsInInteger;
                    }
                }

                Console.WriteLine("Veuillez entrer un nombre entre 1 et 10.");
            }

            return numberOfWordsInInteger;
        }
    }
}

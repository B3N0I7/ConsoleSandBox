namespace consolesandbox.UseCases
{
    public class PersonInteractions
    {
        public static string GetUserName()
        {
            Console.Write("Utilisateur, donne-moi ton nom : ");

            return Console.ReadLine();
        }

        public static int GetWordCount()
        {
            int numberOfWordsInInteger = 0;

            while (numberOfWordsInInteger < 1 || numberOfWordsInInteger > 10)
            {
                Console.Write("Combien de mots veux-tu ajouter (1-10) ? ");

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

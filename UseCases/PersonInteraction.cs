namespace consolesandbox.UseCases
{
    public class PersonInteractions
    {
        public static string GetUserName()
        {
            Console.Write("Utilisateur, donne-moi ton nom : ");

            return Console.ReadLine();
        }
    }
}

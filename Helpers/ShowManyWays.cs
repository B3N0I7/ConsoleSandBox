namespace consolesandbox.Helpers
{
    public class ShowManyWays
    {
        public static void ShowGreen(string textToShow)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(textToShow);
            Console.ResetColor();
        }
        public static void ShowYellow(string textToShow)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(textToShow);
            Console.ResetColor();
        }
        public static void ShowRed(string textToShow)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(textToShow);
            Console.ResetColor();
        }

        public static void ShowDarkCyan(string textToShow)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(textToShow);
            Console.ResetColor();
        }
    }
}
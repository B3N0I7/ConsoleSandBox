// See https://aka.ms/new-console-template for more information
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("dP                 .8888b                   oo                   ");
        Console.WriteLine("88                 88                                            ");
        Console.WriteLine("88        .d8888b. 88aaa  .d8888b. dP    dP dP 88d888b. .d8888b. ");
        Console.WriteLine("88        88'  `88 88     88'  `88 88    88 88 88'  `88 88ooood8 ");
        Console.WriteLine("88        88.  .88 88     88.  .88 88.  .88 88 88    88 88.  ... ");
        Console.WriteLine("88888888P `88888P8 dP     `88888P' `88888P' dP dP    dP `88888P' ");
        Console.WriteLine();
        Console.WriteLine("####    ####    ####    ####    ####    ####    ####    ####    #");
        Console.WriteLine();
        Console.WriteLine(" .d888888  dP dP            dP            dP");
        Console.WriteLine("d8'    88  88 88            88            88");
        Console.WriteLine("88aaaaa88a 88 88 .d8888b. d8888P .d8888b. 88d888b. dP    dP .d8888b.");
        Console.WriteLine("88     88  88 88 88'  `88   88   88'  `88 88'  `88 88    88 Y8ooooo.");
        Console.WriteLine("88     88  88 88 88.  .88   88   88.  .88 88.  .88 88.  .88       88");
        Console.WriteLine("88     88  dP dP `88888P'   dP   `88888P' 88Y8888' `88888P' `88888P'");

        string userName = AskName();
        ShowHelloName(userName);
    }

    static string AskName()
    {
        Console.Write("Utilisateur, donne-moi ton nom : ");
        return Console.ReadLine();
    }

    static void ShowHelloName(string userName)
    {
        Console.WriteLine();
        Console.WriteLine($"Bonjour {userName}.");
    }
}

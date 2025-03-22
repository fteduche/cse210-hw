using System;

class Program
{
    static void Main()
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life");

        while (true)
        {
            Console.WriteLine(scripture.GetReference().GetDisplayText());
            Console.WriteLine(scripture.GetDisplayText());

            Console.Write("Press Enter to hide a random word or type 'quit' to exit... ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(1);

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Exiting...");
                break;
            }
        }
    }
}
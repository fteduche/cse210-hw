using System;

class Program
{
    static void Main(string[] args)
    {
        var journal = new Journal();
        var prompts = new[] { "What did you learn today?", "What are you grateful for?", "What did you accomplish?" };

        while (true)
        {
            Console.WriteLine("Journal Program");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    WriteNewEntry(journal, prompts);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    SaveJournalToFile(journal);
                    break;
                case "4":
                    LoadJournalFromFile(journal);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal, string[] prompts)
    {
        var prompt = prompts[new Random().Next(prompts.Length)];
        Console.Write($"Prompt: {prompt}\nResponse: ");
        var response = Console.ReadLine();
        var entry = new Entry(prompt, response, DateTime.Now.ToString("yyyy-MM-dd"));
        journal.AddEntry(entry);
    }

    static void SaveJournalToFile(Journal journal)
    {
        Console.Write("Enter filename: ");
        var filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved to file.");
    }

    static void LoadJournalFromFile(Journal journal)
    {
        Console.Write("Enter filename: ");
        var filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded from file.");
    }
    
}
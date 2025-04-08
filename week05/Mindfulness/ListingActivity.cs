using System;
using System.Threading;

public class ListingActivity : Activity
{
    private string[] _prompts;
    private Random _random;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 60)
    {
        _prompts = new string[] { "Who are people that you appreciate?", "What are personal strengths of yours?" };
        _random = new Random();
    }

    public override void Run()
    {
        DisplayStartingMessage();
        ShowCountdown();
        string prompt = _prompts[_random.Next(_prompts.Length)];
        Console.WriteLine(prompt);
        Thread.Sleep(3000);
        Console.WriteLine("List as many items as you can:");
        for (int i = 0; i < Duration; i++)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
        }
        DisplayEndingMessage();
        ShowAnimation();
    }
}

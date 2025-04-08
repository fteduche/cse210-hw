using System;
using System.Threading;

public abstract class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    public Activity(string name, string description, int duration)
    {
        Name = name;
        Description = description;
        Duration = duration;
    }

    public virtual void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {Name} activity...");
    }

    public virtual void DisplayEndingMessage()
    {
        Console.WriteLine($"Ending {Name} activity...");
    }

    public virtual void ShowAnimation()
    {
        Console.Write("Loading...");
        for (int i = 0; i < 10; i++)
        {
            Console.Write("\b-");
            Thread.Sleep(200);
            Console.Write("\b\\");
            Thread.Sleep(200);
            Console.Write("\b|");
            Thread.Sleep(200);
            Console.Write("\b/");
            Thread.Sleep(200);
        }
        Console.WriteLine();
    }

    public virtual void ShowCountdown()
    {
        Console.Write("Countdown: ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
            Console.Write("\b\b\b"); // Move cursor back
        }
        Console.WriteLine("Go!");
    }

    public abstract void Run();
}
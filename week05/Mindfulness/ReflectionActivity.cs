using System;
using System.Threading;

public class ReflectionActivity : Activity
{
    private string[] _prompts;
    private string[] _questions;
    private Random _random;

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.", 60)
    {
        _prompts = new string[] { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult." };
        _questions = new string[] { "Why was this experience meaningful to you?", "Have you ever done anything like this before?" };
        _random = new Random();
    }

    public override void Run()
    {
        DisplayStartingMessage();
        ShowCountdown();
        string prompt = _prompts[_random.Next(_prompts.Length)];
        Console.WriteLine(prompt);
        for (int i = 0; i < Duration; i++)
        {
            string question = _questions[_random.Next(_questions.Length)];
            Console.WriteLine(question);
            Thread.Sleep(3000);
        }
        DisplayEndingMessage();
        ShowAnimation();
    }
}

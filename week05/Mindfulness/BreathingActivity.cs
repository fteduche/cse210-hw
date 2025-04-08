using System;
using System.Threading;

public class BreathingActivity : Activity
{
    private int _breathingDuration;

    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly.", 30)
    {
        _breathingDuration = 3000;
    }

    public override void Run()
    {
        DisplayStartingMessage();
        ShowCountdown();
        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(_breathingDuration);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(_breathingDuration);
        }
        DisplayEndingMessage();
        ShowAnimation();
    }
}


using System;
using System.Collections.Generic;

class Program
{
    static List<string> activityHistory = new List<string>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. View Activity Descriptions");
            Console.WriteLine("5. Customize Activity Duration");
            Console.WriteLine("6. View Activity History");
            int choice = Convert.ToInt32(Console.ReadLine());
            Activity activity;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    activity.Run();
                    activityHistory.Add("Breathing Activity");
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    activity.Run();
                    activityHistory.Add("Reflection Activity");
                    break;
                case 3:
                    activity = new ListingActivity();
                    activity.Run();
                    activityHistory.Add("Listing Activity");
                    break;
                case 4:
                    ViewActivityDescriptions();
                    break;
                case 5:
                    CustomizeActivityDuration();
                    break;
                case 6:
                    ViewActivityHistory();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid activity.");
                    break;
            }
        }
    }

    static void ViewActivityDescriptions()
    {
        Console.WriteLine("Activity Descriptions:");
        Console.WriteLine("1. Breathing - This activity will help you relax by walking you through breathing in and out slowly.");
        Console.WriteLine("2. Reflection - This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("3. Listing - This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }

    static void CustomizeActivityDuration()
    {
        Console.Write("Enter new duration (in seconds): ");
        int duration = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Choose an activity to customize:");
        Console.WriteLine("1. Breathing");
        Console.WriteLine("2. Reflection");
        Console.WriteLine("3. Listing");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Duration = duration;
                breathingActivity.Run();
                break;
            case 2:
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                reflectionActivity.Duration = duration;
                reflectionActivity.Run();
                break;
            case 3:
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Duration = duration;
                listingActivity.Run();
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose a valid activity.");
                break;
        }
    }

    static void ViewActivityHistory()
    {
        Console.WriteLine("Activity History:");
        foreach (string activity in activityHistory)
        {
            Console.WriteLine(activity);
        }
    }
}
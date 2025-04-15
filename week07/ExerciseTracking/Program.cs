using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static List<Activity> activities = new List<Activity>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Add Activity");
            Console.WriteLine("2. Display Activities");
            Console.WriteLine("3. Save Activities");
            Console.WriteLine("4. Load Activities");
            Console.WriteLine("5. Calculate Total Distance, Speed, and Pace");
            Console.WriteLine("6. Filter Activities by Type");
            Console.WriteLine("7. Sort Activities by Date");
            Console.WriteLine("8. Delete Activity");
            Console.WriteLine("9. Display Activity Statistics");
            Console.WriteLine("10. Exit");

            Console.Write("Choose an option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AddActivity();
                    break;
                case 2:
                    DisplayActivities();
                    break;
                case 3:
                    SaveActivities();
                    break;
                case 4:
                    LoadActivities();
                    break;
                case 5:
                    CalculateTotalDistanceSpeedPace();
                    break;
                case 6:
                    FilterActivitiesByType();
                    break;
                case 7:
                    SortActivitiesByDate();
                    break;
                case 8:
                    DeleteActivity();
                    break;
                case 9:
                    DisplayActivityStatistics();
                    break;
                case 10:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }
    }

    static void AddActivity()
    {
        Console.Write("Enter activity type (Running, Cycling, Swimming): ");
        string type = Console.ReadLine();

        Console.Write("Enter date (MM/dd/yyyy): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter length in minutes: ");
        int lengthInMinutes = Convert.ToInt32(Console.ReadLine());

        Activity activity = null;

        switch (type)
        {
            case "Running":
                Console.Write("Enter distance in miles: ");
                double distanceInMiles = Convert.ToDouble(Console.ReadLine());
                activity = new Running(date, lengthInMinutes, distanceInMiles);
                break;
            case "Cycling":
                Console.Write("Enter speed in mph: ");
                double speedInMph = Convert.ToDouble(Console.ReadLine());
                activity = new Cycling(date, lengthInMinutes, speedInMph);
                break;
            case "Swimming":
                Console.Write("Enter number of laps: ");
                int laps = Convert.ToInt32(Console.ReadLine());
                activity = new Swimming(date, lengthInMinutes, laps);
                break;
            default:
                Console.WriteLine("Invalid activity type.");
                return;
        }

        activities.Add(activity);
    }

    static void DisplayActivities()
    {
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }

    static void SaveActivities()
    {
        using (StreamWriter writer = new StreamWriter("activities.txt"))
        {
            foreach (var activity in activities)
            {
                writer.WriteLine($"{activity.GetType().Name},{activity.Date.ToString("MM/dd/yyyy")},{activity.LengthInMinutes}");
                if (activity is Running running)
                {
                    writer.WriteLine($"DistanceInMiles,{running.DistanceInMiles}");
                }
                else if (activity is Cycling cycling)
                {
                    writer.WriteLine($"SpeedInMph,{cycling.SpeedInMph}");
                }
                else if (activity is Swimming swimming)
                {
                    writer.WriteLine($"Laps,{swimming.Laps}");
                }
            }
        }
    }

    static void LoadActivities()
    {
        if (File.Exists("activities.txt"))
        {
            string[] lines = File.ReadAllLines("activities.txt");
            for (int i = 0; i < lines.Length; i += 2)
            {
                string[] parts = lines[i].Split(',');
                string type = parts[0];
                DateTime date = DateTime.Parse(parts[1]);
                int lengthInMinutes = Convert.ToInt32(parts[2]);

                Activity activity = null;

                if (type == "Running")
                {
                    string[] runningParts = lines[i + 1].Split(',');
                    double distanceInMiles = Convert.ToDouble(runningParts[1]);
                    activity = new Running(date, lengthInMinutes, distanceInMiles);
                }
                else if (type == "Cycling")
                {
                    string[] cyclingParts = lines[i + 1].Split(',');
                    double speedInMph = Convert.ToDouble(cyclingParts[1]);
                    activity = new Cycling(date, lengthInMinutes, speedInMph);
                }
                else if (type == "Swimming")
{
    string[] swimmingParts = lines[i + 1].Split(',');
    int laps = Convert.ToInt32(swimmingParts[1]);
    activity = new Swimming(date, lengthInMinutes, laps);
}

activities.Add(activity);
}
}
}

static void CalculateTotalDistanceSpeedPace()
{
    double totalDistance = 0;
    double totalSpeed = 0;
    double totalPace = 0;
    int count = 0;

    foreach (var activity in activities)
    {
        totalDistance += activity.GetDistance();
        totalSpeed += activity.GetSpeed();
        totalPace += activity.GetPace();
        count++;
    }

    Console.WriteLine($"Total Distance: {totalDistance:F2} miles");
    Console.WriteLine($"Average Speed: {totalSpeed / count:F2} mph");
    Console.WriteLine($"Average Pace: {totalPace / count:F2} min/mile");
}

static void FilterActivitiesByType()
{
    Console.Write("Enter activity type (Running, Cycling, Swimming): ");
    string type = Console.ReadLine();

    foreach (var activity in activities)
    {
        if (activity.GetType().Name == type)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

static void SortActivitiesByDate()
{
    activities.Sort((x, y) => x.Date.CompareTo(y.Date));

    foreach (var activity in activities)
    {
        Console.WriteLine(activity.GetSummary());
    }
}

static void DeleteActivity()
{
    Console.Write("Enter index of activity to delete: ");
    int index = Convert.ToInt32(Console.ReadLine());

    if (index >= 0 && index < activities.Count)
    {
        activities.RemoveAt(index);
    }
    else
    {
        Console.WriteLine("Invalid index.");
    }
}

static void DisplayActivityStatistics()
{
    var runningActivities = activities.OfType<Running>();
    var cyclingActivities = activities.OfType<Cycling>();
    var swimmingActivities = activities.OfType<Swimming>();

    Console.WriteLine("Running Statistics:");
    if (runningActivities.Any())
    {
        Console.WriteLine($"Total Distance: {runningActivities.Sum(a => a.GetDistance()):F2} miles");
        Console.WriteLine($"Total Time: {runningActivities.Sum(a => a.LengthInMinutes)} minutes");
        Console.WriteLine($"Average Speed: {runningActivities.Average(a => a.GetSpeed()):F2} mph");
        Console.WriteLine($"Average Pace: {runningActivities.Average(a => a.GetPace()):F2} min/mile");
    }
    else
    {
        Console.WriteLine("No running activities.");
    }

    Console.WriteLine("Cycling Statistics:");
    if (cyclingActivities.Any())
    {
        Console.WriteLine($"Total Distance: {cyclingActivities.Sum(a => a.GetDistance()):F2} miles");
        Console.WriteLine($"Total Time: {cyclingActivities.Sum(a => a.LengthInMinutes)} minutes");
        Console.WriteLine($"Average Speed: {cyclingActivities.Average(a => a.GetSpeed()):F2} mph");
        Console.WriteLine($"Average Pace: {cyclingActivities.Average(a => a.GetPace()):F2} min/mile");
    }
    else
    {
        Console.WriteLine("No cycling activities.");
    }

    Console.WriteLine("Swimming Statistics:");
    if (swimmingActivities.Any())
    {
        Console.WriteLine($"Total Distance: {swimmingActivities.Sum(a => a.GetDistance()):F2} miles");
        Console.WriteLine($"Total Time: {swimmingActivities.Sum(a => a.LengthInMinutes)} minutes");
        Console.WriteLine($"Average Speed: {swimmingActivities.Average(a => a.GetSpeed()):F2} mph");
        Console.WriteLine($"Average Pace: {swimmingActivities.Average(a => a.GetPace()):F2} min/mile");
    }
    else
    {
        Console.WriteLine("No swimming activities.");
    }
}
}
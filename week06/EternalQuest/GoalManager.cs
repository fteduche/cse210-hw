using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. List Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");

            Console.Write("Choose an option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    RecordEvent();
                    break;
                case 3:
                    ListGoalDetails();
                    break;
                case 4:
                    SaveGoals();
                    break;
                case 5:
                    LoadGoals();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.Write("Enter goal type (Simple, Eternal, Checklist): ");
        string goalType = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter goal points: ");
        int points = Convert.ToInt32(Console.ReadLine());

        if (goalType.ToLower() == "simple")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (goalType.ToLower() == "eternal")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (goalType.ToLower() == "checklist")
        {
            Console.Write("Enter target: ");
            int target = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter bonus: ");
            int bonus = Convert.ToInt32(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    public void RecordEvent()
{
    Console.WriteLine("Choose a goal to record an event for:");
    for (int i = 0; i < _goals.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
    }

    Console.Write("Enter the number of the goal: ");
    int goalNumber = Convert.ToInt32(Console.ReadLine()) - 1;

    if (goalNumber >= 0 && goalNumber < _goals.Count)
    {
        _goals[goalNumber].RecordEvent();
        _score += _goals[goalNumber].Points;
        Console.WriteLine($"Event recorded for {_goals[goalNumber].ShortName}.");
    }
    else
    {
        Console.WriteLine("Invalid goal number.");
    }
}
    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved to goals.txt.");
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            _goals.Clear();

            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 4)
                    {
                        if (parts[3] == "True" || parts[3] == "False")
                        {
                            _goals.Add(new SimpleGoal(parts[0], parts[1], int.Parse(parts[2])));
                        }
                        else
                        {
                            _goals.Add(new EternalGoal(parts[0], parts[1], int.Parse(parts[2])));
                        }
                    }
                    else if (parts.Length == 6)
                    {
                        _goals.Add(new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4])));
                    }
                }
            }

            Console.WriteLine("Goals loaded from goals.txt.");
        }
        else
        {
            Console.WriteLine("goals.txt does not exist.");
        }
    }
}
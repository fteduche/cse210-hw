using System;
using System.Collections.Generic;
using System.IO;
using EternalQuest;
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
        Console.Write("Enter goal priority (Low, Medium, High): ");
        string priority = Console.ReadLine();
        GoalPriority goalPriority = (GoalPriority)Enum.Parse(typeof(GoalPriority), priority);
        Console.Write("Enter goal due date (MM/dd/yyyy): ");
        string dueDate = Console.ReadLine();
        DateTime goalDueDate = DateTime.Parse(dueDate);

        if (goalType.ToLower() == "simple")
        {
            _goals.Add(new SimpleGoal(name, description, points, goalPriority, goalDueDate));
        }
        else if (goalType.ToLower() == "eternal")
        {
            _goals.Add(new EternalGoal(name, description, points, goalPriority, goalDueDate));
        }
        else if (goalType.ToLower() == "checklist")
        {
            Console.Write("Enter target: ");
            int target = Convert.ToInt32(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, goalPriority, goalDueDate, target));
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
            Console.WriteLine($"{i + 1}. {_goals[i].Name}");
        }
        Console.Write("Enter the number of the goal: ");
        int goalNumber = Convert.ToInt32(Console.ReadLine()) - 1;
    if (goalNumber >= 0 && goalNumber < _goals.Count)
        {
            _goals[goalNumber].RecordEvent(); // Calls the overridden RecordEvent method
            _score += _goals[goalNumber].Points; // Adds the goal's points to the score
            Console.WriteLine($"Event recorded for {_goals[goalNumber].Name}.");
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
                    if (parts[0].ToLower() == "simple")
                    {
                        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), (GoalPriority)Enum.Parse(typeof(GoalPriority), parts[4]), DateTime.Parse(parts[5])));
                    }
                    else if (parts[0].ToLower() == "eternal")
{
    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), (GoalPriority)Enum.Parse(typeof(GoalPriority), parts[4]), DateTime.Parse(parts[5])));
}
else if (parts[0].ToLower() == "checklist")
{
    _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), (GoalPriority)Enum.Parse(typeof(GoalPriority), parts[4]), DateTime.Parse(parts[5]), int.Parse(parts[6])));
}
                }
            }
            Console.WriteLine("Goals loaded from goals.txt.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }

    public int GetScore()
    {
        return _score;
    }
}
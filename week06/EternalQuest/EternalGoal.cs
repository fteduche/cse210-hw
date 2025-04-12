using System;
using EternalQuest;
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points, GoalPriority priority, DateTime dueDate) 
        : base(name, description, points, priority, dueDate)
    {
    }

    public override void RecordEvent()
    {
        Progress += 10;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[{Name}] - {Description} - {Points} points - {Priority} priority - Due: {DueDate.ToString("MM/dd/yyyy")} - Progress: {Progress}%";
    }

    public override string GetStringRepresentation()
    {
        return $"{Name},{Description},{Points},{Priority},{DueDate.ToString("MM/dd/yyyy")},{Progress}";
    }
}
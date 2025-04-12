using System;
using EternalQuest;
public class ChecklistGoal : Goal
{
    public int Target { get; set; }

    public ChecklistGoal(string name, string description, int points, GoalPriority priority, DateTime dueDate, int target) 
        : base(name, description, points, priority, dueDate)
    {
        if (target <= 0)
        {
            throw new ArgumentException("Target must be greater than zero.", nameof(target));
        }
        if (points < 0)
        {
            throw new ArgumentException("Points cannot be negative.", nameof(points));
        }
        Target = target;
    }

    public override void RecordEvent()
    {
        Progress += (int)((double)100 / Target);
        if (Progress > 100)
        {
            Progress = 100;
        }
    }

    public override bool IsComplete()
    {
        return Progress >= 100; // Goal is complete when progress reaches or exceeds 100%
    }

    public override string GetDetailsString()
    {
        return $"[{Name}] - {Description} - {Points} points - {Priority} priority - Due: {DueDate:MM/dd/yyyy} - Progress: {Progress}% - Target: {Target}";
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist,{Name},{Description},{Points},{Priority},{DueDate:MM/dd/yyyy},{Progress},{Target}";
    }
}
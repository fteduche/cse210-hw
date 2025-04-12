using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    // You can remove this method if you want to use the base class implementation
    //public override string GetDetailsString()
    //{
    //    return $"[{(_amountCompleted >= _target ? "[X]" : "[ ]")}] {_shortName} - {_description} ({_amountCompleted}/{_target})";
    //}

    public override string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
    }
}
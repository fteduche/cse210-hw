using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public string ShortName => _shortName;
    public int Points => _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        return $"[{((IsComplete() ? "[X]" : "[ ]"))}] {ShortName} ({Points} points) - {_description}";
    }
    public abstract string GetStringRepresentation();
}

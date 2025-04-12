using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public GoalPriority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public int Progress { get; set; }

        protected Goal(string name, string description, int points, GoalPriority priority, DateTime dueDate)
        {
            Name = name;
            Description = description;
            Points = points;
            Priority = priority;
            DueDate = dueDate;
            Progress = 0;
        }

        public abstract void RecordEvent();
        public abstract bool IsComplete(); // Add this abstract method
        public abstract string GetDetailsString();
        public abstract string GetStringRepresentation();
    }
}
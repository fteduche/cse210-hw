public class Cycling : Activity
{
    public double SpeedInMph { get; set; }

    public Cycling(DateTime date, int lengthInMinutes, double speedInMph) : base(date, lengthInMinutes)
    {
        SpeedInMph = speedInMph;
    }

    public override double GetDistance()
    {
        return (SpeedInMph / 60) * LengthInMinutes;
    }

    public override double GetSpeed()
    {
        return SpeedInMph;
    }

    public override double GetPace()
    {
        return 60 / SpeedInMph;
    }
}
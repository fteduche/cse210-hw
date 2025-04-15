public class Running : Activity
{
    public double DistanceInMiles { get; set; }

    public Running(DateTime date, int lengthInMinutes, double distanceInMiles) : base(date, lengthInMinutes)
    {
        DistanceInMiles = distanceInMiles;
    }

    public override double GetDistance()
    {
        return DistanceInMiles;
    }

    public override double GetSpeed()
    {
        return (DistanceInMiles / LengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return LengthInMinutes / DistanceInMiles;
    }
}
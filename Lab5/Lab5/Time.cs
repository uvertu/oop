using System;

internal class Time
{
    private int hours;
    private int minutes;

    public Time(int hours, int minutes)
    {
        this.hours = hours;
        this.minutes = minutes;
        ValidateTime();
    }

    public int Hours
    {
        get { return hours; }
        set
        {
            hours = value;
            ValidateTime();
        }
    }

    public int Minutes
    {
        get { return minutes; }
        set
        {
            minutes = value;
            ValidateTime();
        }
    }

    private void ValidateTime()
    {
        if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59)
        {
            throw new ArgumentException("Invalid time format.");
        }
    }

    public void DisplayTime()
    {
        Console.WriteLine($"Time: {hours:D2}:{minutes:D2}");
    }

    public static Time SubtractMinutesStatic(Time originalTime, int subtractedMinutes)
    {
        int totalMinutes = originalTime.hours * 60 + originalTime.minutes - subtractedMinutes;
        int newHours = totalMinutes / 60;
        int newMinutes = totalMinutes % 60;

        return new Time(newHours, newMinutes);
    }

    public Time SubtractMinutes(int subtractedMinutes)
    {
        int totalMinutes = hours * 60 + minutes - subtractedMinutes;
        int newHours = totalMinutes / 60;
        int newMinutes = totalMinutes % 60;

        return new Time(newHours, newMinutes);
    }

    private static int objectCount = 0;

    public Time()
    {
        objectCount++;
    }

    public static int GetObjectCount()
    {
        return objectCount;
    }
}

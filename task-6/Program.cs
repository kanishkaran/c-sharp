



public class Counter
{

    public delegate void ThresholdEventHandler(Object sender, EventArgs e);
    public int threshold;
    public int Count;

    public event ThresholdEventHandler ThresholdReached;

    public Counter(int thres)
    {
        threshold = thres;
    }

    public void Increment()
    {
        Count++;
        Console.WriteLine($"The Current Count is: {Count}");

        if (Count > threshold)
        {
            OnThresholdReachedEventHandler(EventArgs.Empty);
        }
    }

    protected virtual void OnThresholdReachedEventHandler(EventArgs e)
    {
        ThresholdReached?.Invoke(this, e);
        Count = 0;
    }
}

public class Program
{
    static void Main()
    {
        Counter counter = new(5);

        counter.ThresholdReached += Handler1;
        counter.ThresholdReached += EventHandler2.Handler2;

        for (int i = 0; i < 15; i++)
        {
            counter.Increment();
        }


    }
    static void Handler1(object sender, EventArgs e)
    {
        Console.WriteLine("The event is handled by handler 1");
    }
}

public class EventHandler2
{
    public static void Handler2(object sender, EventArgs e)
    {
        Console.WriteLine("The event is handled by handler 2");
    }
}
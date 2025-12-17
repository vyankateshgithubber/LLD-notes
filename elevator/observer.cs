public interface IElevatorObserver
{
    void Update(Elevator elevator);
}

public class Display : IElevatorObserver
{
    public void Update(Elevator elevator)
    {
        Console.WriteLine($"[DISPLAY] Elevator {elevator.Id} | Current Floor: {elevator.CurrentFloor} | Direction: {elevator.GetDirection()}");
    }
}
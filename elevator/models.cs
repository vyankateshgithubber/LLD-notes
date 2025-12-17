using System.Runtime.CompilerServices;

public class Request
{
    public int TargetFloor {get; private set;}
    public Direction Direction {get; private set;} 
    public RequestSource RequestSource {get; private set;}

    public Request(int targetFloor, Direction direction, RequestSource requestSource)
    {
        TargetFloor = targetFloor;
        Direction = direction;
        RequestSource = requestSource;
    }
}



public class Elevator
{
    public int Id {get; private set;}
    
    private IElevatorState ElevatorState;
    public volatile bool isRunning = true;

    public SortedSet<int> UpRequests { get; }
    public SortedSet<int> DownRequests { get; }
    private readonly object _lock = new object();

    // list of observers
    private readonly List<IElevatorObserver> observers =  new List<IElevatorObserver>();

    private int currentFloor;
    public int CurrentFloor
    {
        get
        {
            lock (_lock)
            {
                return currentFloor;
            }
            
        }
        set
        {
                
            lock (_lock)
            {
                currentFloor = value;
            }
            NotifyObservers(); // Notify observers on floor change
        }

    }
    public Elevator(int id)
    {
        Id = id;
        CurrentFloor = 1;
        UpRequests = new SortedSet<int>();
        DownRequests = new SortedSet<int>(Comparer<int>.Create((a,b) => b.CompareTo(a)));
        ElevatorState = new IdleState();
    }

    public void AddObserver(IElevatorObserver observer)
    {
        observers.Add(observer);
        observer.Update(this);
    }

    public void NotifyObservers()
    {
        foreach(IElevatorObserver observer in observers)
        {
            observer.Update(this);
        }
    }

    // set state
    public void AddRequest(Request request)
    {
        lock (_lock)
        {
            Console.WriteLine($"Elevator {request.TargetFloor} processing: {request}");
            ElevatorState.AddRequest(this, request);
        }
    }
    public void SetState(IElevatorState state)
    {
        ElevatorState = state;
        NotifyObservers();
    }
    public void Move()
    {
        ElevatorState.Move(this);
    }
    
    public Direction GetDirection() => ElevatorState.GetDirection();
    public bool IsRunning() => isRunning;
    public void StopElevator() => isRunning = false;

    public void Run()
    {
        while (isRunning)
        {
            Move();
            try
            {
                Thread.Sleep(1000); // Simulate movement time
            }
            catch (ThreadInterruptedException)
            {
                isRunning = false;
            }
        }
    }
}

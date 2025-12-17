public interface IElevatorState
{
    void Move(Elevator elevator);
    void AddRequest(Elevator elevator, Request request);
    Direction GetDirection();
}

public class IdleState : IElevatorState
{
    public void Move(Elevator elevator)
    {
        if(elevator.UpRequests.Count > 0)
        {
            elevator.SetState(new MovingUpState());
        } 
        else if(elevator.DownRequests.Count > 0)
        {
            elevator.SetState(new MovingDownState());
        }
    }

    
    public void AddRequest(Elevator elevator, Request request)
    {
        if (request.TargetFloor > elevator.CurrentFloor)
        {
            elevator.UpRequests.Add(request.TargetFloor);
        }
        else if (request.TargetFloor < elevator.CurrentFloor)
        {
            elevator.DownRequests.Add(request.TargetFloor);
        }
        // If request is for current floor, doors would open (handled implicitly by moving to that floor)
    }

    public Direction GetDirection() => Direction.IDLE;
}

public class MovingUpState : IElevatorState
{
    public void Move(Elevator elevator)
    {
        if (elevator.UpRequests.Count == 0)
        {
            elevator.SetState(new IdleState());
            return;
        }

        int nextFloor = elevator.UpRequests.Min();
        elevator.CurrentFloor += 1;

        if (elevator.CurrentFloor == nextFloor)
        {
            Console.WriteLine($"Elevator {elevator.Id} stopped at floor {nextFloor}");
            elevator.UpRequests.Remove(nextFloor);
        }

        if (elevator.UpRequests.Count == 0)
        {
            elevator.SetState(new IdleState());
        }
    }

    public void AddRequest(Elevator elevator, Request request)
    {
        // Internal requests always get added to the appropriate queue
        if (request.RequestSource == RequestSource.INTERNAL)
        {
            if (request.TargetFloor > elevator.CurrentFloor)
            {
                elevator.UpRequests.Add(request.TargetFloor);
            }
            else
            {
                elevator.DownRequests.Add(request.TargetFloor);
            }
            return;
        }

        // External requests
        if (request.Direction == Direction.UP && request.TargetFloor >= elevator.CurrentFloor)
        {
            elevator.UpRequests.Add(request.TargetFloor);
        }
        else if (request.Direction == Direction.DOWN)
        {
            elevator.DownRequests.Add(request.TargetFloor);
        }
    }

    public Direction GetDirection() => Direction.UP;
}

public class MovingDownState : IElevatorState
{
    public void Move(Elevator elevator)
    {
        if (elevator.DownRequests.Count == 0)
        {
            elevator.SetState(new IdleState());
            return;
        }

        int nextFloor = elevator.DownRequests.Max();
        elevator.CurrentFloor = -1;

        if (elevator.CurrentFloor == nextFloor)
        {
            Console.WriteLine($"Elevator {elevator.Id} stopped at floor {nextFloor}");
            elevator.DownRequests.Remove(nextFloor);
        }

        if (elevator.DownRequests.Count == 0)
        {
            elevator.SetState(new IdleState());
        }
    }

    public void AddRequest(Elevator elevator, Request request)
    {
        // Internal requests always get added to the appropriate queue
        if (request.RequestSource == RequestSource.INTERNAL)
        {
            if (request.TargetFloor > elevator.CurrentFloor)
            {
                elevator.UpRequests.Add(request.TargetFloor);
            }
            else
            {
                elevator.DownRequests.Add(request.TargetFloor);
            }
            return;
        }

        // External requests
        if (request.Direction == Direction.DOWN && request.TargetFloor <= elevator.CurrentFloor)
        {
            elevator.DownRequests.Add(request.TargetFloor);
        }
        else if (request.Direction == Direction.UP)
        {
            elevator.UpRequests.Add(request.TargetFloor);
        }
    }

    public Direction GetDirection() => Direction.DOWN;
}
public interface IElevatorSelectionStrategy
{
    Elevator SelectElevator(List<Elevator> elevators, Request request);
}

public class NearestElevatorStrategy : IElevatorSelectionStrategy
{
    public Elevator SelectElevator(List<Elevator> elevators, Request request)
    {
        Elevator bestElevator = null;
        int minDistance = int.MaxValue;

        foreach (Elevator elevator in elevators)
        {
            if (IsSuitable(elevator, request))
            {
                int distance = Math.Abs(elevator.CurrentFloor - request.TargetFloor);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    bestElevator = elevator;
                }
            }
        }
        return bestElevator;
    }

    private bool IsSuitable(Elevator elevator, Request request)
    {
        if (elevator.GetDirection() == Direction.IDLE)
            return true;
        if (elevator.GetDirection() == request.Direction)
        {
            if (request.Direction == Direction.UP && elevator.CurrentFloor <= request.TargetFloor)
                return true;
            if (request.Direction == Direction.DOWN && elevator.CurrentFloor >= request.TargetFloor)
                return true;
        }
        return false;
    }
}
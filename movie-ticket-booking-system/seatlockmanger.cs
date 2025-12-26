using System.Reflection.Metadata;

public class SeatLockManager
{
    private readonly Dictionary<Show, Dictionary<Seat, User>> _lockedSeats;
    private readonly object _lockObject = new object();
    public void LockSeats(Show show, List<Seat> seats, User user)
    {
        lock (_lockObject)
        {
            // check seat availability and lock seats
            foreach(var seat in seats)
            {
                if(seat.SeatStatus != SeatStatus.Available)
                {
                    throw new InvalidOperationException($"Seat {seat.SeatNumber} is not available for locking.");
                }
                seat.SeatStatus = SeatStatus.Locked;
            }
            if (!_lockedSeats.ContainsKey(show))
            {
                _lockedSeats[show] = new Dictionary<Seat, User>();
            }

            foreach (var seat in seats)
            {
                if (_lockedSeats[show].ContainsKey(seat))
                {
                    throw new InvalidOperationException($"Seat {seat.SeatNumber} is already locked.");
                }
                _lockedSeats[show][seat] = user;
            }
        }
        Task.Delay(TimeSpan.FromMinutes(5)).ContinueWith(_ => UnlockSeats(show, seats, user));
    }
    public void UnlockSeats(Show show, List<Seat> seats, User user)
    {
        lock (_lockObject)
        {
            if (!_lockedSeats.ContainsKey(show))
            {
                return;
            }

            foreach (var seat in seats)
            {
                if (_lockedSeats[show].TryGetValue(seat, out var lockingUser) && lockingUser == user)
                {
                    seat.SeatStatus = SeatStatus.Available;
                    _lockedSeats[show].Remove(seat);
                }
            }

            if (_lockedSeats[show].Count == 0)
            {
                _lockedSeats.Remove(show);
            }
        }
    }
    public bool ShutDown()
    {
        lock (_lockObject)
        {
            return _lockedSeats.Count == 0;
        }
    }
}
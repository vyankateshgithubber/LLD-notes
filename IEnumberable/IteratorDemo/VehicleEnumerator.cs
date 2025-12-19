using System;
using System.Collections;
using System.Collections.Generic;

public class VehicleEnumerator : IEnumerator<Vehicle>
{
    private readonly List<Vehicle> _vehicles;
    private int _index;

    public VehicleEnumerator(List<Vehicle> vehicles)
    {
        _vehicles = vehicles ?? throw new ArgumentNullException(nameof(vehicles));
        _index = -1;
    }

    public Vehicle Current => (_index >= 0 && _index < _vehicles.Count)
        ? _vehicles[_index]
        : throw new InvalidOperationException();

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _index++;
        return _index < _vehicles.Count;
    }

    public void Reset() => _index = -1;

    public void Dispose() { }
}

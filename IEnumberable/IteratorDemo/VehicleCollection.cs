using System.Collections;
using System.Collections.Generic;

public class VehicleCollection : IEnumerable<Vehicle>
{
    private readonly List<Vehicle> _vehicles = new();

    public void Add(Vehicle v) => _vehicles.Add(v);

    // Strongly-typed enumerator (enables foreach and manual use)
    public VehicleEnumerator GetEnumerator() => new VehicleEnumerator(_vehicles);

    IEnumerator<Vehicle> IEnumerable<Vehicle>.GetEnumerator() => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

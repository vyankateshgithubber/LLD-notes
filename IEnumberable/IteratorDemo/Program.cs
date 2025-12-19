using System;

var vehicles = new VehicleCollection();
vehicles.Add(new Vehicle("Car-A", 1, 2));
vehicles.Add(new Vehicle("Truck-B", 5, 6));
vehicles.Add(new Vehicle("Bike-C", -1, 0));

// foreach demo (uses IEnumerable)
Console.WriteLine("Foreach iteration:");
foreach (var v in vehicles)
{
    Console.WriteLine($" - {v}");
}

// Manual enumerator demo
Console.WriteLine("\nManual enumerator iteration:");
using var enumerator = vehicles.GetEnumerator();
while (enumerator.MoveNext())
{
    var v = enumerator.Current;
    Console.WriteLine($" > {v}");
}

// Also demonstrate IEnumerator<T> interface usage
Console.WriteLine("\nManual (IEnumerator<T>) usage:");
using var ie = ((System.Collections.Generic.IEnumerable<Vehicle>)vehicles).GetEnumerator();
while (ie.MoveNext())
{
    Console.WriteLine($" * {ie.Current}");
}

using System;
using System.Collections.Generic;
using Packt.CS7;

public class ThingOfDefaults
{
    // fields
    public int Population;
    public DateTime When;
    public string Name;
    public List<Person> People;

    public ThingOfDefaults()
    {
        Population = default; // C# 7.1 and later
        When = default;
        Name = default;
        People = default;
    }
}
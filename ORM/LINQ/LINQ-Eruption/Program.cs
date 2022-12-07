List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

IEnumerable<Eruption> AllEruptions = eruptions;
PrintFirst( AllEruptions);
FindAll(AllEruptions);
 
// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
static void PrintFirst(IEnumerable<Eruption> item)
{
    Eruption? FirstInChile = item.FirstOrDefault(c => c.Location == "Chile");
    System.Console.WriteLine($"first eruption in chile: {FirstInChile}"); 

    Eruption? FirstInHawaii = item.FirstOrDefault(h => h.Location == "Hawaiian Is");

    Eruption? FirstInGreen = item.FirstOrDefault(g => g.Location == "Greenland");

    Eruption? FirstYearAndNewZealand = item.FirstOrDefault(g => g.Year > 1900 && g.Location == "New Zealand");

    int? HighestElevation = item.Max(h => h.ElevationInMeters);

    Eruption? VolcanoMatchElevation = item.FirstOrDefault(v => v.ElevationInMeters == HighestElevation);

// Hawaii
    if (FirstInHawaii == null)
    {
        System.Console.WriteLine($"No Hawaiian Is Eruption found");
    } else {
        System.Console.WriteLine($"first eruption in Hawaii: {FirstInHawaii}");
    }
// Greenland
    if (FirstInGreen == null)
    {
        System.Console.WriteLine($"No Greenland Eruption found");
    } else {
        System.Console.WriteLine($"first eruption in Greenland: {FirstInGreen}");
    }
// After 1900 and in New Zealand
    if (FirstYearAndNewZealand == null)
    {
        System.Console.WriteLine($"Nothing matched your query");
    } else {
        System.Console.WriteLine($"first eruption after 1900 and in New Zealand: {FirstYearAndNewZealand}");
    }

    System.Console.WriteLine($"Highest Elevation: {HighestElevation}");

    System.Console.WriteLine($"Volcano that matches the highest elevation is: {VolcanoMatchElevation}");

}

static void FindAll(IEnumerable<Eruption> item)
{

    IEnumerable<Eruption>? AllEruptionOver2000 = item.Where(a => a.ElevationInMeters > 2000);

    IEnumerable<Eruption>? StartsWithL = item.Where(i => i.Volcano.Substring(0,1) == "L");

    IEnumerable<Eruption>? SortVolcanoAlphabetical = item.OrderBy(v => v.Volcano);

    bool DidErupt2000 = item.Any(a => a.Year == 2000);

    IEnumerable<Eruption>? Find3Strat = item.Where(i => i.Type == "Stratovolcano").Take(3);

    IEnumerable<Eruption>? Before1000AndAlphabetical = item.Where(b => b.Year < 1000).OrderBy(v => v.Volcano);

    foreach(Eruption i in AllEruptionOver2000)
    {
        System.Console.WriteLine($"all eruptions where volcano's elevation is over 2000m: {i} ");
    }

    foreach(Eruption i in StartsWithL)
    {
        System.Console.WriteLine($"all volcano name that starts with L: {i} ");
    }

    if (SortVolcanoAlphabetical != null)
    {
        System.Console.WriteLine("Sort Alphabetically");
        foreach(Eruption i in SortVolcanoAlphabetical)
        {
            System.Console.WriteLine(i);
        }
    }
    // PRINT SUM OF ALL ELEVATIONS
    int? sum = 0;
    foreach(Eruption i in item)
    {   
        sum += i.ElevationInMeters;
        // System.Console.WriteLine($"{i.ElevationInMeters}");
    }
    System.Console.WriteLine($"Sum of all elevations: {sum}");

    // Did Volcano Erupt in Year 2000
    System.Console.WriteLine($"Did any volcanoes erupt in year 2000?: {DidErupt2000}");

    if (Find3Strat != null)
    {
        System.Console.WriteLine("Find 3 Stratovolcanoes:");
        foreach(Eruption i in Find3Strat)
        {

        System.Console.WriteLine($"{i}");
        }
    }

        if (Before1000AndAlphabetical != null)
    {
        System.Console.WriteLine("Find All Volcanoes Before Year 1000 and Sort Alphabetically");
        foreach(Eruption i in Before1000AndAlphabetical)
        {
            System.Console.WriteLine(i.Volcano);
        }
    }
    
}
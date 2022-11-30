class Vehicle
{
    private string Name;
    public string _Name {get {return Name;} set {Name = value;}}
    private int Capacity;
    public int _Capacity {get {return Capacity;}}
    private string Color;
    public string _Color {get {return Color;} set {Color = value;}}
    private bool HasEngine;
    public bool _HasEngine {get {return HasEngine;}}
    private int TopSpeed;
    public int _TopSpeed {get {return TopSpeed;}}
    private int MilesTraveled; // start at 0
    public int _MilesTraveled {get {return MilesTraveled;}} // start at 0

    public Vehicle(string n,  string col)
    {
        Name = n;
        Capacity = 5;
        Color = col;
        HasEngine = true;
        TopSpeed = 220;
        MilesTraveled = 0;
    }


    public void ShowInfo()
    {
        Console.WriteLine($"");
        Console.WriteLine($"name: {this.Name} \ncapacity: {this.Capacity} \ncolor: {this.Color} \nhas engine: {this.HasEngine} \ntop speed: {this.TopSpeed} \nmiles traveled: {this.MilesTraveled} ");
        Console.WriteLine($"");
        
    }

    public void Travel()
    {
        Console.WriteLine($"Please enter distance traveled: ");
        string TravelInput = Console.ReadLine();
        Console.WriteLine($"You traveled {TravelInput} miles");
        int converted = Convert.ToInt32(TravelInput);
        this.MilesTraveled = converted;
    }

}


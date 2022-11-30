class Range : Enemy
{
    private int Distance = 5;
    public int _Distance {get{return Distance;} set{Distance = value;}}
    public Range(string name, List<Attack> a) : base(name)
    {
        attacks = a;
    }

    public void Attack()
    {
        Random random = new Random();
        int steps = random.Next(3, 10);
        this._Distance += steps;
        int num = random.Next(0, attacks.Count);

        if (this._Distance < 10)
        {
            Console.WriteLine($"The enemy {this._name} cannot perform an attack");
        } else 
        {
            Console.WriteLine($"Enemy {this._name} is attacking you with {attacks[num]._name} dealing {attacks[num]._damage}.  Close the distance to disable the opponent!");
        }
        
    }

    public void Dash()
    {
        this._Distance = 20;
        Console.WriteLine($"{this._name} used dash 20 spaces away");
        
    }
}
class Enemy
{
    private string name;
    public string _name {get {return name;} set {name = value;}}
    private int health;
    public int _health {get{return health;}}
    public List<Attack> attacks = new List<Attack>();

    public Enemy(string n)
    {
        name = n;
        health = 100;
        

    }

    public void RandomAttack()
    {
        // Console.WriteLine($"{attacks[0]._name}");
        
        if (attacks.Count > 0) {
            Random random = new Random();
            int num = random.Next(0, attacks.Count);
            Console.WriteLine($"Enemy {this.name} attacked you with {attacks[num]._name} dealing {attacks[num]._damage} damage");
        }
        
        
    }

    public void AddAttacks(List<Attack> a)
    {
        if (a == null)
        {
            Console.WriteLine($"Attack list cannot be empty");
            
        }
        this.attacks = a;
    }
}


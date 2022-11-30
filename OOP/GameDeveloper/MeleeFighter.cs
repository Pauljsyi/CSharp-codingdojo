class Melee : Enemy
{
    public Melee(string name, List<Attack> a) : base(name)
    {
        _health = 120;
        attacks = a;
    }

    public void Rage()
    {
        Random random = new Random();
        int num = random.Next(0, attacks.Count);
        int rageDamage = attacks[num]._damage + 10;
        Console.WriteLine($"Enemy {this._name}'s Rage was activated, attacking you with {attacks[num]._name} dealing {attacks[num]._damage} + 10 damage. Rage did a total damage of {rageDamage}");
        
    }

    public void ShowInfo()
    {
        Console.WriteLine($"name: {this._name} \nhealth: {this._health}");

        for(int i =0; i < attacks.Count; i++)
        {
            Console.WriteLine($"attack name:{attacks[i]._name} \ndamage: {attacks[i]._damage}");
            
        }
        Console.WriteLine($"");
        
    }
}
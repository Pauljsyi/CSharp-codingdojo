class MagicCaster : Enemy
{
    public MagicCaster(string name, List<Attack> a) : base(name)
    {
        _health = 80;
        attacks = a;
    }

    public void Attack()
    {
        Random random = new Random();
        int num = random.Next(0, attacks.Count);
        if (attacks[num]._name == "shield") {
            Console.WriteLine($"Enemy {this._name} protected herself with {attacks[num]._name} taking {attacks[num]._damage} damage ");
        } 
        else 
        {
        Console.WriteLine($"Enemy {this._name} attacking you with {attacks[num]._name} dealing {attacks[num]._damage}.");
        }

    }

    public void Heal(Enemy e)
    {
        Console.WriteLine($"{e._name}'s health before heal: {e._health}");
        
        e._health += 40;
        Console.WriteLine($"{this._name} healed {e._name} for 40 pts. {e._name}'s health: {e._health} ");
        
    }
}
class Attack
{
    private string name;
    public string _name {get{return name;} set{name = value;}}
    private int damage;
    public int _damage {get{return damage;} set{damage = value;}}

    public Attack(string n, int d)
    {
        name = n;
        damage = d;
    }

}
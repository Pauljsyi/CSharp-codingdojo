
// MELEE ATTACKS
Attack kick = new Attack("kick", 15);
Attack punch = new Attack("punch", 20);
Attack tackle = new Attack("tackle", 25);
// RANGED ATTACKS
Attack shootArrow = new Attack("shoot arrow", 20);
Attack throwKnife = new Attack("throw knife", 15);
List<Attack> MeleeAttackList = new List<Attack>() {kick, punch, tackle};
List<Attack> RangeAttackList = new List<Attack>() {shootArrow, throwKnife};
Enemy p1 = new Enemy("Paul");
Enemy p2 = new Enemy("George");

// Console.WriteLine($"{p1._name} {p1._health}");
// Console.WriteLine($"{kick._name} {kick._damage}");
// Console.WriteLine($"{punch._name} {punch._damage}");
// Console.WriteLine($"{bodyslam._name} {bodyslam._damage}");

// attackList.Add(kick);
// attackList.Add(punch);
// attackList.Add(bodyslam);

// Console.WriteLine($"{p1.attacks[1]._name}");


// foreach(var i in p1.attacks) {
//     Console.WriteLine($"name: {p1._name} \nhealth: {p1._health} \nattack name: {i._name} \nattack damage: {i._damage} ");
    
// }
// p1.AddAttacks(attackList);
// p2.AddAttacks(attackList);


// p1.RandomAttack();
// p2.RandomAttack();

Melee Assassin = new Melee("general assassin", MeleeAttackList);
// Assassin.Rage();
// Assassin.ShowInfo();
Range Archer = new Range("hunter", RangeAttackList);
Archer.Attack();
Console.WriteLine($"{Archer._Distance}");
Archer.Dash();
Console.WriteLine($"{Archer._Distance}");


// Console.WriteLine($"{Archer._DistanceField}");


// Console.WriteLine($"{Assassin._name} {Assassin._health}");



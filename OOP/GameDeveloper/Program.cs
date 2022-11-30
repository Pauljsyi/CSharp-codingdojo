Attack kick = new Attack("kick", 30);
Attack punch = new Attack("punch", 15);
Attack bodyslam = new Attack("bodyslam", 60);
List<Attack> attackList = new List<Attack>() {kick, punch, bodyslam};
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
p1.AddAttacks(attackList);
p2.AddAttacks(attackList);


p1.RandomAttack();
p2.RandomAttack();
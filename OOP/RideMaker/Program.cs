Vehicle car1 = new Vehicle("Honda Accord", "white");
Vehicle car2 = new Vehicle("Toyota Sienna", "gold");
Vehicle car3 = new Vehicle("Dodge Charger", "black");
Vehicle car4 = new Vehicle("Ford Mustang", "purple");
Vehicle car5 = new Vehicle("GMC", "silver");

car1._Name = "Mazda Miata";
car1._Color = "Black";


// Console.WriteLine($"{car1._Name}");


// Console.WriteLine($"name: {MyVehicle._Name}, color: {MyVehicle._Color} ");
// car1.Travel();
// car1.ShowInfo();

List<Vehicle> cars = new List<Vehicle>(5);

cars.Add(car1);
cars.Add(car2);
cars.Add(car3);
cars.Add(car4);
cars.Add(car5);



foreach (var item in cars)
{
    item.ShowInfo();
}

cars[1].Travel();

cars[1].ShowInfo();


# C# OOP

## Class and Object Construction
### Building a class
- Build each class in its own ClassName.cs file
> Class Constructor
```cs
class ClassName
{
    string AttributeName;
    ClassName(string attributeName)
    {
        AttributeName = attributeName
        //Notice the attribute is capitalized but the variable to assign it to is not, to differentiate the two
    }
}
```
> Instantiating the Class
```cs
ClassName instanceName = new ClassName("name");
```
---

## Class Members
- anything inside the { } of the Class
### Fields
- variables/data that make up our class's attributes
```cs
class Dog
{
    string Name;
    string Breed;
    string FurColor;
}
```
### Methods
- functions that a class can perform
```cs
class Dog
{
    //fields here
    void Bark()
    {
        Console.WriteLine("berk berk!");
    }
    void Fetch(string Item)
    {
        Console.WriteLine($"{Name} hurries to fetch the {Item}");
    }
}
```
---
## Access Modifiers and Properties
- C# provides a way to control where class members can be accessed from, called **access modifiers**
### 4 levels of accessibility:
- **public**: No access restrictions
- **private**: Access restricted to own class
- **protected**: Access restricted to own class and any children classes
- **internal**: restricted to Assembly (the projects's compiled .dll)

> Public:
```cs
class Dog
{
    public Dog(string n, string b, string f)
    {
        Name = n;
        Breed = b;
        FurColor = f;
    }
}
// Without the public access modifier, Dog.Dog(string, string, string) would be inaccessible
```
### Properties and Encapsulation
- **Encapsulation** is one of the four pillars of OOP and is the idea of hiding some elements of our code so that only necessary elements are publicly provided
- **Properties** give us control over how fields are retrieved and updated.  They look much like fields, but have the ability to GET and SET our property
```cs
class Dog
{
    // original attribute field, set to private
    private string Name;
    // property version of Name, set to public
    public string _Name
    {
        get { return Name; }
        // GETs the data from the original Name and returns it
    }
}
```
- we can now access our pet's name using _Name, but we cannot SET it
- SET can be used in the property if you want to be able to change the value without making the Name field public
- logic can be added to the GET and SET functions to get special functionalities, such as validations

### Auto-Implemented Properties
```cs
public string FurColor {get;set;}
```
- This creates a "backing field" for our class that will be known to the compiler but hidden from our source code.
---
## Inheritance
- Child classes can inherit attributes/fields and methods from their parent class
### Base()
```cs
class Cat : Animal // Parent class goes after the colon
{
    public string FurType;

    public Cat(string name, string diet, string furType) : base (name, diet)
    //uses the parent class's constructor to inherit those fields by adding them to the base()
    {
        //new fields unique to the child class go here
        FurType = furType;
    }
}
```
### Inheriting Methods
- Methods of the parent class may be directly called by instances of the child class
- Child classes can also "overwrite" methods from the parent class
```cs
class Animal
{
    // Fields here
    public virtual void ShowInfo()
    // Add the "virtual" keyword to the parent class method
    {
        Console.WriteLine($"Name: {Name}");
    }
}

class Cat : Animal
{
    // Fields here
    public override void ShowInfo()
    // Add the "override" keyword to the child class method
    {
        base.ShowInfo();
        // Can use base here to keep the original functionality from the parent method and then add to it OR create all new functionality if you don't use base.
        Console.WriteLine($"Fur Type: {FurType}");
    }
}
```
### Inheritance and Accessibility
- fields referenced by the child class must be set to **protected**, instead of private, for the child class to be able to access them
---
## Polymorphism
- **Polymorphism** is the idea that objects can be treated as if they belonged to any of the classes above them in an inheritance chain. i.e. all cats are animals, but not the other way around.
- For instance, we can add children classes to a list as their parent class type:
```cs
Cat MyCat = new Cat("Fluffy");
Dog MyDog = new Dog("Woof");
Bird MyBird = new Bird("Chirp");
List<Animal> allAnimals = new List<Animal>(){MyCat, MyDog, MyBird};
```
- we can then use logic on the list to find all instances of a certain type:
```cs
foreach (Animal a in allAnimals)
{
    if (a is Cat)
    {
        Console.WriteLine($"{a.Name} is a cat!");
    }
}
```
---
## Interfaces
- **Interfaces** can be used to create a shared set of behaviors between any class, not just parent/child classes
- they are defined similarly to a class, but instead of a blueprint of what an object *is*, it provides a blueprint of what an object *is able to do*
### Creating an Interface
- start by creating a new .cs file for the interface, commonly starting with the letter "I"
```cs
interface ILayEggs
{
    int EggsPerBatch {get;set;}
    // get;set; auto-implemented properties are required in order for interfaces to work
    void LayEggs();
}
```
- When creating a method that is part of an interface, we do not actually fill out what the method does. Rather, we describe that a method must exist, and it will be the responsibility of the programmer that is including this interface in a class to fill out what exactly that method will do for that particular class.

### Implementing Interfaces
- the interface can be seen as a "contract" that must be fulfilled by any class that we choose to implement it in
- when we implement the contained interface members, we must make them public
```cs
class Bird : Animal, ILayEggs // implementing the interface, much like a parent class
{
    public bool CanFly;
    public int EggsPerBatch {get;set;}
    public Bird(bool canFly, string diet, int epb) : base("Bird", diet, true)
    {
        CanFly = canFly;
        EggsPerBatch = epb;
    }

    //Filling out the LayEggs method inside the class
    public void LayEggs()
    {
        Console.WriteLine($"{Name} laid {EggsPerBatch} egg(s)!");
    }
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Can Fly: {CanFly}");
    }
}
```
- ILayEggs can be added to any number of classes, adding its pre-built properties
### Polymorphism and Interfaces
- We can group alike objects together using Interfaces, much like inheritance
- We can use this ability to do something specific to all instances that have the interface
```cs
// Inside the program.cs

Bird My Bird = new Bird(true, "Herbivore", 3);
Reptile MyReptile = new Reptile("Omnivore", 6);
List<ILayEggs> canLayEggs = new List<ILayEggs>();
canLayEggs.Add(MyBird);
canLayEggs.Add(MyReptile);
foreach (ILayEggs animal in canLayEggs)
{
    animal.LayEggs();
}
```
- Lists, arrays, and dictionaries all share an interface called IEnumerable, which we can use to loop/enumerate through them
```cs
string[] wordArr = new string[]
{
    "Goat", "Bear", "Skunk"
};

List<string> wordList = new List<string>()
{
    "Plate", "Cup", "Fork", "Spatula"
};

static void LoopingThrough(IEnumerable<string> someWords)
{
    foreach(var word in someWords)
    {
        Console.WriteLine(word);
    }
}
// Now we can call the function with either, as it will accept any collection of strings
LoopingThrough(wordArr);
LoopingThrough(wordList);
```
---
## Abstract Classes
### Creating an abstract class
- An abstract class is one that cannot be instantiated, but is built with the intention of being extended to children classes.
- Abstract classes simply have the **abstract** keyword before class in the definition
```cs
abstract class Animal
{
    public string Name;
    public string Diet;

    public Animal(string n, string d)
    {
        Name = n;
        Diet = d;
    }
}
```
- We would now be unable to make an instance of an "Animal" but all fields and methods can be passed down to children classes, which CAN be instantiated
### Abstract methods
- methods can also use the keyword **abstract**
- All child classes must now have an override method of the abstract, much like an interface, or the program will not compile
---
## Static Classes
- can have methods that don't need to affect an instance of the class
- static classes allow us to create toolboxes that we can use across our project
```cs
static class Calculator
{
    public static double Add(double FirstValue, double SecondValue)
    {
    	return FirstValue + SecondValue;
    }
}
```
### Extension Methods
- useful for adding a method to an already existing class, which you do not have permission to edit
- we first use a class that is "untouchable"
```cs
// Assume this is the class provided that we cannot edit.
public class ShoppingCart
{
    public List<Product> Products { get; set; }
}
```
- Now we can create our extension method.  NOTE: this code does not need to be in the original file of the class
```cs
// Note the static keyword
public static class MyExtensionMethods
{
    // Note how the parameters for the new function is the previous class
    public static decimal TotalPrices(this ShoppingCart cartParam)
    {
         decimal total = 0;
         foreach (Product prod in cartParam.Products)
         {
             total += prod.Price;
         }
         return total;
    }
}
```
---

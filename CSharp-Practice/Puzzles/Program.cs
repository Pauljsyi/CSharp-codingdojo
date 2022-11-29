// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("Type something, then hit enter: ");
string InputLine = Console.ReadLine();
Console.WriteLine($"You wrote: {InputLine}");

Console.WriteLine("Type a number, then hit enter: ");
string NumberInput = Console.ReadLine();
Console.WriteLine(10 + NumberInput);

string aNumber = "7";
int converted = Convert.ToInt32(aNumber);
Console.WriteLine(14 + converted); // should print 21
string aDecimal = "3.14";
double convertDec = Convert.ToDouble(aDecimal);
Console.WriteLine(1.8 + convertDec); // should print 4.94
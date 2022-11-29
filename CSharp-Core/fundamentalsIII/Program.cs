// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


static void PrintList(List<string> MyList)
{
    for(int i = 0; i < MyList.Count; i++){
        Console.WriteLine($"{MyList[i]}");
        // Console.Write(MyList[i]);
        
    }

    foreach(var item in MyList){
        Console.WriteLine(item);
    }

    
    MyList.ForEach(item => Console.WriteLine(item));

    MyList.ForEach(Console.WriteLine);

    Console.WriteLine(string.Join(", ", MyList));
    
}

List<string> bikes = new List<string>();
// Use the Add function in a similar fashion to push
bikes.Add("Kawasaki");
bikes.Add("Triumph");
bikes.Add("BMW");
bikes.Add("Moto Guzzi");
bikes.Add("Harley Davidson");
bikes.Add("Suzuki");

// PrintList(bikes);


// 2. PRINT SUM

static void SumOfNumbers(List<int> IntList) 
{
    int result = 0;
    for (int i = 0; i< IntList.Count; i++) 
    {
        result += IntList[i];
        // Console.WriteLine(IntList[i]);
    }
    Console.WriteLine(result);
}

List<int> IntegerList = new List<int>();
// Use the Add function in a similar fashion to push
IntegerList.Add(1);
IntegerList.Add(2);
IntegerList.Add(3);
IntegerList.Add(4);
IntegerList.Add(5);
IntegerList.Add(6);

SumOfNumbers(IntegerList);

static int FindMax(List<int> IntList)
{
    int max = 0;
    
    for (int i = 0; i < IntList.Count; i++)
    {
        if (IntList[i] > max)
        {
            max = IntList[i];
        }
        
    }
    return max;
}

// Console.WriteLine(FindMax(IntegerList));


// SQUARE THE VALUES

static List<int> SquareValues(List<int> IntList)
{
    List<int> result = new List<int>();
    for (int i = 0; i < IntList.Count; i++)
    {
        result.Add(IntList[i] * IntList[i]);
        
    }

    for(int i =0; i < result.Count; i++)
    {
        Console.WriteLine(result[i]);
    }
    
    return result;
}

Console.WriteLine(SquareValues(IntegerList).ToArray());
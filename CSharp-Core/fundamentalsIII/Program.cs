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
    // Console.WriteLine(result);
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

// static List<int> SquareValues(List<int> IntList)
// {
//     List<int> result = new List<int>();
//     for (int i = 0; i < IntList.Count; i++)
//     {
//         result.Add(IntList[i] * IntList[i]);
        
//     }

//     for(int i =0; i < result.Count; i++)
//     {
//         Console.WriteLine(result[i]);
//     }
    
//     return result;
// }

// Console.WriteLine(SquareValues(IntegerList).ToArray());


static int[] NonNegatives(int[] IntArray)
{
    // Console.WriteLine($"{IntArray.Length}");
    
    // Your code here
    int[] result = new int[IntArray.Length];
    for (int i = 0; i < IntArray.Length; i++)
    {
        if (IntArray[i] < 0)
        {
            result[i] = 0;
        }
        else 
        {
            result[i] = IntArray[i];
        }
    }

    for (int i = 0; i < result.Length; i++)
    {
        Console.WriteLine(result[i]);
    }

    
    
    return result;
}


int[] NegArray = new int[] {1, -4, 5, -2, 10, -30, 30};

// Console.WriteLine(NonNegatives(NegArray));


static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
    // Your code here
    foreach(KeyValuePair<string,string> entry in MyDictionary) 
    {

    Console.WriteLine($"{entry.Key} - {entry.Value}");
    }
    

}

Dictionary<string,string> profile = new Dictionary<string,string>();
// We add values to our dictionary the same way we add in Lists
// But remember to specify the key AND value
profile.Add("Name", "Sandra");
profile.Add("Language", "C#");
profile.Add("Location", "England");

PrintDictionary(profile);

static bool FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
    // Your code here
    foreach(KeyValuePair<string, string> entry in MyDictionary) {
        if (SearchTerm == entry.Key) {
            return true;
        }
    }
    return false;
}

// // true
// Console.WriteLine( FindKey(profile, "Location" ));
// // false
// Console.WriteLine( FindKey(profile, "age" ));

// GENERATE A DICTIONARY

// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 

List<string> namesList = new List<string>() {"Julie", "Harold", "James", "Monica"} ;
List<int> ageList = new List<int>() {6,12,7,10} ;

static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string,int> people = new Dictionary<string,int>();
    // Your code here
    if (Names.Count != Numbers.Count) {
        Console.WriteLine($"names count does not match numbers count");
        
        return people;
    }
    for (int i = 0; i < Names.Count; i++)
    {
        people.Add(Names[i], Numbers[i]);
    }

    foreach(KeyValuePair<string,int> person in people)
{
    Console.WriteLine($"{person.Key} - {person.Value}");
}
    
   return people;
}

Console.WriteLine(GenerateDictionary(namesList, ageList));
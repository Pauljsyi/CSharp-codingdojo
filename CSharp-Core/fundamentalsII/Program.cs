// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// // THREE BASIC ARRAYS
// int[] arrayInt = new int[] {0,1,2,3,4,5,6,7,8,9};

// Console.WriteLine(arrayInt[5]);

// string[] arrayString = new string[] {"Tim", "Martin", "Nikki", "Sara"};

// Console.WriteLine(arrayString[0]);


// bool[] isFalse = new bool[10];
// for (int i = 0; i < isFalse.Length; i++){   
//     if (i%2 == 0){
//         isFalse[i] = true;
//     } else if (i%2 == 1) {
//         isFalse[i] = false;
//     }
// }

// foreach(bool res in isFalse) {
//     Console.WriteLine(res);
// }


// // LIST OF FLAVORS

List<string> flavors = new List<string>();

flavors.Add("Vanilla");
flavors.Add("Strawberry");
flavors.Add("Chocolate");
flavors.Add("Cookies'n Cream");
flavors.Add("Coffee");
flavors.RemoveAt(2);

for(int i = 0; i < flavors.Count; i++) {
    Console.WriteLine(flavors[i]);
}

Console.WriteLine(flavors.Count);

// Console.WriteLine(flavors[2]);



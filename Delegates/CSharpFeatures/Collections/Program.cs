// See https://aka.ms/new-console-template for more information
using System.Collections;

Console.WriteLine("Array List examples");
Console.WriteLine("===========================================================");
ArrayList arrayList = new ArrayList();

arrayList.Add(10);
arrayList.Add("Sanjay");
arrayList.Add(33.1);

arrayList.AddRange(new ArrayList() { "Keerthi", 28, 15 });

arrayList.Insert(1, "First Index");
//arrayList.Insert(15, "15th Index"); Should be in the size of Array List
arrayList.Insert(3, "This is 3rd Index");

arrayList.Remove("This is 3rd Index");
arrayList.RemoveRange(0, 2);
arrayList.Remove(2);

//For Sorting we need to have same data type
//Whenever ArrayList is created memory for 4 items are added. Whenever 5th item is added
//Memory for another 4 items are added

foreach (var item in arrayList)
{
    Console.WriteLine(item);
}
Console.WriteLine("===========================================================");

Console.WriteLine("Sorted List");
SortedList sorted = new SortedList();
sorted.Add(5, "Number Five");
sorted.Add(1, "Number One");
sorted.Add(2, "Number Two");
sorted.Add(4, "Number Four");
sorted.Add(3, "Number Three");

Console.WriteLine($"Contains(2) - {sorted.Contains(2)}");
Console.WriteLine($"ContainsKey(7) - {sorted.ContainsKey(7)}");
Console.WriteLine($"ContainsValue() - {sorted.ContainsValue("Number Four")}");
foreach (DictionaryEntry item in sorted)
{
    Console.WriteLine($"Key : {item.Key}, Value : {item.Value}");
}
Console.WriteLine($"Capacity : {sorted.Capacity}");
Console.WriteLine("===========================================================");
Console.WriteLine("Stack");
Console.Read();

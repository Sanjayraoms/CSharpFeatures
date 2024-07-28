// See https://aka.ms/new-console-template for more information
using Delegates;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Hello, World!");

var d = new DelegateTesting();

d.testDelegate = d.MyFunc1;
d.testDelegate += d.MyFuncNew;

Console.WriteLine("Multicast delegate results after adding two functions");
d.testDelegate();

d.testDelegate -= d.MyFuncNew;

Console.WriteLine("Multicast delegate results after removing one function");
d.testDelegate();

Console.WriteLine("Delegate with parameter and return type");
d.delegatewithParamReturn = d.TestDel;
d.delegatewithParamReturn(3);


d.testDelegate = delegate () { Console.WriteLine("Anonymous Function"); };
d.testDelegate += () => { Console.WriteLine("Lambda Function"); };
d.testDelegate();

d.delegatewithParamReturn = (int j) => { return j < 5; };
Console.WriteLine(d.delegatewithParamReturn(3));

d.TestFunc = (int i, float j) => Console.WriteLine("Build-in delegates");

d.TestFuncReturn = (int j) => { return j < 5; };
Console.WriteLine(d.TestFuncReturn(8));


Console.WriteLine("Testing Events");
EventSample eventSample = new EventSample();
eventSample.stringEvent += eventSample.ToLower;

string str;
do
{
    str = Console.ReadLine();
    if (!str.Equals("exit"))
    {
        eventSample.SetString = str;
    }
} while (!str.Equals("exit"));



Console.Read();



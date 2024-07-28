using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class DelegateTesting
    {
        public delegate void TestDelegate();
        public delegate bool DelegatewithParamReturn(int val);

        public TestDelegate testDelegate;
        public DelegatewithParamReturn delegatewithParamReturn;

        //Built-in delegates
        public Action TestAction;
        public Action<int,float> TestFunc;
        
        //In Func delegate last parameter is a return type
        public Func<int,bool> TestFuncReturn;
        public void MyFunc1()
        {
            Console.WriteLine("MyFunc1");
        }

        public void MyFuncNew()
        {
            Console.WriteLine("MyFuncNew");
        }

        public bool TestDel(int num)
        {
            return num < 5;
        }
    }
}

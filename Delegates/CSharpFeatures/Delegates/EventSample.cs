using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void StringDelegate(string s);
    public class EventSample
    {
        public event StringDelegate stringEvent;
        private string mystring;

        public void ToLower(string value) => Console.WriteLine(value.ToLower());

        public string SetString {  set
            {
                mystring = value;
                stringEvent(mystring);
            }
        }
    }
}

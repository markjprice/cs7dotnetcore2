using System;

namespace Packt.CS7
{
    public class Thing
    {
        public object Data;

        public string Process(string input)
        {
            if (Data == input)
            {
                return Data.ToString() + Data.ToString();
            }
            else
            {
                return Data.ToString();
            }
        }
    }
}
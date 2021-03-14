using System;

namespace Packt.Shared
{
    public class GenericThing<T> where T : IComparable
    {
        public T Data = default(T);

        public string Process(T input)
        {
            if (Data.CompareTo(input) == 0)
            {
                return "Data and input are the same.";
            }
            return "Data and input are not the same.";
        }
    }
}
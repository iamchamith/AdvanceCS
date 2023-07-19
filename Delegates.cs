using System;

namespace CShard
{
    internal class Delegates
    {
        delegate void CalcDelegate(int one, int two);
        static void Process()
        {
            CalcDelegate add = Add;
            DoOparation(add);

            CalcDelegate sub = Sub;
            DoOparation(sub);

        }
        static void DoOparation(CalcDelegate add)
        {

            add.Invoke(10, 5);
        }
        static void Add(int one, int two)
        {

            Console.WriteLine(one + two);
        }
        static void Sub(int one, int two)
        {

            Console.WriteLine(one - two);
        }
    }
}

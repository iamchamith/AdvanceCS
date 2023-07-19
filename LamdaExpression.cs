using System;

namespace CShard
{
    public class LamdaExpression
    {
        public LamdaExpression() { }

        public void Execute() {

            var add = new Func<int,int,int>((int one,int two) =>
            {
                return one + two;
            });
            Console.WriteLine(add(10, 5));
        }
    }
}

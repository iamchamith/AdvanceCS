using System.Collections;
using System.Collections.Generic;

namespace CShard
{
    internal class Collections
    {
        public Collections()
        {
            var ht = new Hashtable();
            ht.Add(1, "chamith");
            ht.Add("age", "12");

            // be unique
            var hs = new HashSet<string>();
            hs.Add("1");
            hs.Add("1");// return false.
        }
    }
}

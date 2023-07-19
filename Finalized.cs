using System;

namespace CShard
{
    internal class MyDisposeClass : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposed) {

            if (disposed) { 
                // clear memory allocation .
                // handle manage and unmanage codes/
            }
        }
    }
}

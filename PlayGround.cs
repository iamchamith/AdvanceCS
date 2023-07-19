using System;
using System.Collections.Generic;
using System.Text;

namespace CShard
{
    interface IInterface
    {
        void Play();
    }
    internal struct PlayGround : IInterface
    {
        public void Play()
        {
            Add();
        }
        public void Add(params int[] numbers)
        {
            throw new NotImplementedException();
        } 
    }
}

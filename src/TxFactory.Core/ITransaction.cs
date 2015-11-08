using System;

namespace TxFactory
{
    public interface ITransaction : IDisposable
    {
        void Complete();
    }
}
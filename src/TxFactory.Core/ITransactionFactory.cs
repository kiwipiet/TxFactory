namespace TxFactory
{
    public interface ITransactionFactory
    {
        ITransaction New();
    }

    public interface ITransactionFactory<in T> : ITransactionFactory
        where T : ITransactionOptions
    {
        ITransaction New(T txOptions);
    }
}
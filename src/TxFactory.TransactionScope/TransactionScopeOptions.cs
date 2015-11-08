using System.Transactions;

namespace TxFactory
{
    public sealed class TransactionScopeOptions : ITransactionOptions
    {
        public static readonly TransactionScopeOptions Default = GetDefault();

        public TransactionScopeOptions(TransactionScopeOption transactionScopeOption, TransactionOptions transactionOptions)
        {
            TransactionScopeOption = transactionScopeOption;
            TransactionOptions = transactionOptions;
        }

        public TransactionScopeOption TransactionScopeOption { get; }
        public TransactionOptions TransactionOptions { get; }

        private static TransactionScopeOptions GetDefault()
        {
            return new TransactionScopeOptions(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.DefaultTimeout
            });
        }
    }
}
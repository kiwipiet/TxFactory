using System;
using System.Transactions;

namespace TxFactory
{
    public sealed class TransactionScopeFactory : ITransactionFactory<TransactionScopeOptions>
    {
        public ITransaction New()
        {
            return New(TransactionScopeOptions.Default);
        }

        public ITransaction New(TransactionScopeOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            var scope = new TransactionScope(options.TransactionScopeOption, options.TransactionOptions);
            return new TransactionScopeWrapper(scope);
        }

        private sealed class TransactionScopeWrapper : ITransaction
        {
            private readonly TransactionScope _underlyingScope;

            public TransactionScopeWrapper(TransactionScope underlyingScope)
            {
                _underlyingScope = underlyingScope;
            }

            public void Complete()
            {
                _underlyingScope.Complete();
            }

            public void Dispose()
            {
                _underlyingScope.Dispose();
            }
        }
    }
}
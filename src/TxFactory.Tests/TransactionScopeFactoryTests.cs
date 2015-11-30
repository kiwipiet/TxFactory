using System;
using System.Threading;
using System.Transactions;
using Shouldly;

namespace TxFactory.Tests
{
    public class TransactionScopeFactoryTests
    {
        public void Should_New_return_NotNull_transaction()
        {
            using (var tx = new TransactionScopeFactory().New())
            {
                tx.ShouldNotBeNull();
            }
        }

        public void Should_throw_when_timeout_exceeded()
        {
            Should.Throw<TransactionAbortedException>(() =>
            {
                using (var tx = new TransactionScopeFactory().New(new TransactionScopeOptions(TransactionScopeOption.Required, new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromMilliseconds(100)
                })))
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(1000));
                    tx.Complete();
                }
            });
        }

        public void Should_throw_when_options_null()
        {
            Should.Throw<ArgumentNullException>(() => { new TransactionScopeFactory().New(null); });
        }
    }
}
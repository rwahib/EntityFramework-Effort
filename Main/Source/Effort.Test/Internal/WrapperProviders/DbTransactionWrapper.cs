﻿// --------------------------------------------------------------------------------------------
// <copyright file="DbTransactionWrapper.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
//     This source is subject to the Microsoft Public License (Ms-PL).
//     Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//     All other rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------

namespace Effort.Test.Internal.WrapperProviders
{
    using System.Data.Common;

    /// <summary>
    /// Implementation of common methods for <see cref="DbTransaction"/> wrappers.
    /// </summary>
    internal abstract class DbTransactionWrapper : DbTransaction
    {
        private DbTransaction wrappedTransaction;
        private DbConnectionWrapper connectionWrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbTransactionWrapper"/> class.
        /// </summary>
        /// <param name="wrappedTransaction">The wrapped transaction.</param>
        /// <param name="connection">The connection.</param>
        protected DbTransactionWrapper(DbTransaction wrappedTransaction, DbConnectionWrapper connection)
        {
            this.wrappedTransaction = wrappedTransaction;
            this.connectionWrapper = connection;
        }

        /// <summary>
        /// Specifies the <see cref="T:System.Data.IsolationLevel"/> for this transaction.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The <see cref="T:System.Data.IsolationLevel"/> for this transaction.
        /// </returns>
        public override System.Data.IsolationLevel IsolationLevel
        {
            get { return this.wrappedTransaction.IsolationLevel; }
        }

        /// <summary>
        /// Gets the wrapped transaction.
        /// </summary>
        /// <value>The wrapped transaction.</value>
        public DbTransaction WrappedTransaction
        {
            get { return this.wrappedTransaction; }
        }

        /// <summary>
        /// Specifies the <see cref="T:System.Data.Common.DbConnection"/> object associated with the transaction.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The <see cref="T:System.Data.Common.DbConnection"/> object associated with the transaction.
        /// </returns>
        protected override DbConnection DbConnection
        {
            get { return this.connectionWrapper; }
        }

        /// <summary>
        /// Gets the connection wrapper.
        /// </summary>
        /// <value>The connection wrapper.</value>
        protected DbConnectionWrapper ConnectionWrapper
        {
            get { return this.connectionWrapper; }
        }

        /// <summary>
        /// Commits the database transaction.
        /// </summary>
        public override void Commit()
        {
            this.wrappedTransaction.Commit();
        }

        /// <summary>
        /// Rolls back a transaction from a pending state.
        /// </summary>
        public override void Rollback()
        {
            this.wrappedTransaction.Rollback();
        }
    }
}

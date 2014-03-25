using System;
using System.Threading;

namespace ThreadSafeCollections
{
    /// <summary>
    /// Provides LINQ extensions for the ReaderWriterLockSlim
    /// to make it easier to ensure the lock is released
    /// </summary>
    public static class ReadWriteLockSlimExtend
    {
        /// <summary>
        /// Performs a Read Lock
        /// </summary>
        /// <param name="readerWriterLockSlim">the slim lock</param>
        /// <param name="action">action to perform during the lock</param>
        public static void PerformUsingReadLock(this ReaderWriterLockSlim readerWriterLockSlim, Action action)
        {
            try
            {
                readerWriterLockSlim.EnterReadLock();
                action();
            }
            finally
            {
                readerWriterLockSlim.ExitReadLock();
            }
        }

        /// <summary>
        /// Performs a Read Lock
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="readerWriterLockSlim">the slim lock</param>
        /// <param name="action">action to perform during the lock</param>
        public static T PerformUsingReadLock<T>(this ReaderWriterLockSlim readerWriterLockSlim, Func<T> action)
        {
            try
            {
                readerWriterLockSlim.EnterReadLock();
                return action();
            }
            finally
            {
                readerWriterLockSlim.ExitReadLock();
            }
        }

        /// <summary>
        /// Performs a Write Lock
        /// </summary>
        /// <param name="readerWriterLockSlim">the slim lock</param>
        /// <param name="action">action to perform during the lock</param>
        public static void PerformUsingWriteLock(this ReaderWriterLockSlim readerWriterLockSlim, Action action)
        {
            try
            {
                readerWriterLockSlim.EnterWriteLock();
                action();
            }
            finally
            {
                readerWriterLockSlim.ExitWriteLock();
            }
        }

        /// <summary>
        /// Performs a Write Lock
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="readerWriterLockSlim">the slim lock</param>
        /// <param name="action">action to perform during the lock</param>
        public static T PerformUsingWriteLock<T>(this ReaderWriterLockSlim readerWriterLockSlim, Func<T> action)
        {
            try
            {
                readerWriterLockSlim.EnterWriteLock();
                return action();
            }
            finally
            {
                readerWriterLockSlim.ExitWriteLock();
            }
        }

        /// <summary>
        /// Performs an upgradeable Read / Write Lock
        /// </summary>
        /// <param name="readerWriterLockSlim">the slim lock</param>
        /// <param name="action">action to perform during the lock</param>
        public static void PerformUsingUpgradeableReadLock(this ReaderWriterLockSlim readerWriterLockSlim, Action action)
        {
            try
            {
                readerWriterLockSlim.EnterUpgradeableReadLock();
                action();
            }
            finally
            {
                readerWriterLockSlim.ExitUpgradeableReadLock();
            }
        }

        /// <summary>
        /// Performs an upgradeable Read / Write Lock
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="readerWriterLockSlim">the slim lock</param>
        /// <param name="action">action to perform during the lock</param>
        public static T PerformUsingUpgradeableReadLock<T>(this ReaderWriterLockSlim readerWriterLockSlim, Func<T> action)
        {
            try
            {
                readerWriterLockSlim.EnterUpgradeableReadLock();
                return action();
            }
            finally
            {
                readerWriterLockSlim.ExitUpgradeableReadLock();
            }
        }
    }
}

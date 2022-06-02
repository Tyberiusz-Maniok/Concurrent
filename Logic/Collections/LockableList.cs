using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Logic.Collections
{
    internal class LockableList<T> : List<T>
    {
        private Mutex mutex = new Mutex();

        public void TryLock()
        {
            mutex.WaitOne();
        }

        public void ReleaseLock()
        {
            mutex.ReleaseMutex();
        }
    }
}

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using System.Collections.Generic;
using System.Threading;

namespace br.ufc.mdcc.common.impl.IteratorImpl 
{ 
	
public class IIteratorImpl<T> : BaseIIteratorImpl<T>, IIterator<T>
where T:IData
{
		public IIteratorImpl() 
		{ 
			this.items = new List<Option<T>>();
			counter_sem = new Semaphore(0,int.MaxValue);
			rear=-1; front=0;
		} 

		private object lock_put = new object();
		private object lock_fetch = new object();

		private IList<Option<T>> items = null;

		private int rear, front;

		private Semaphore counter_sem = null;

		public void put (T item)
		{
			lock(lock_put)
			{
				if (this.HasFinished)
					throw new FinishedIteratorException();

				this.items.Insert(++rear,new Some<T>(item));
				counter_sem.Release();
			}
		}

		public void finish ()
		{
			lock(lock_put) 
			{
				lock(lock_fetch)
				{
					if (this.HasFinished)
						throw new FinishedIteratorException();

					this.items.Insert(++rear,new None<T>());
					counter_sem.Release();
				}
			}
		}

		public T fetch_next ()
		{
			lock (lock_fetch)
			{
				if (this.HasFinished)
					throw new FinishedIteratorException();

				counter_sem.WaitOne();
				return this.items[front++].Value;
			}
		}

		public bool HasFinished
		{
			get { return this.items[front].IsNone; }
		}

		public class FinishedIteratorException : Exception
		{
		}

		public class NonRestartableIteratorException : Exception
		{
		}
}

// Used as return type from method
	public abstract class Option<T>
	{
		// Could contain the value if Some, but not if None
		public abstract T Value { get; }

		public abstract bool IsSome { get; }

		public abstract bool IsNone { get; }
	}

	public sealed class Some<T> : Option<T>
	{
		private T value;
		public Some(T value)
		{
			// Setting Some to null, nullifies the purpose of Some/None
			if (value == null)
			{
				throw new System.ArgumentNullException("value", "Some value was null, use None instead");
			}

			this.value = value;
		}

		public override T Value { get { return value; } }

		public override bool IsSome { get { return true; } }

		public override bool IsNone { get { return false; } }
	}

	public sealed class None<T> : Option<T>
	{
		public override T Value
		{
			get { throw new System.NotSupportedException("There is no value"); }
		}

		public override bool IsSome { get { return false; } }

		public override bool IsNone { get { return true; } }
	}

}

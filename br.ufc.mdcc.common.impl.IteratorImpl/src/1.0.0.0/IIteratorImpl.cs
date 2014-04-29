using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;

namespace br.ufc.mdcc.common.impl.IteratorImpl 
{ 
	
	public class IIteratorImpl<T> : BaseIIteratorImpl<T>, IIterator<T>
	where T:IData
	{
		public IIteratorImpl() { newInstance (); } 

		public IIteratorInstance<T> newIteratorInstance ()
		{
			return (IIteratorInstance<T>) newInstance ();
		}

		public object newInstance ()
		{
			return this.Instance = new IIteratorInstanceImpl<T>();
		}

		private IIteratorInstance<T> instance;

		public object Instance {
			get { return instance; }
			set { this.instance = (IIteratorInstance<T>) value; }
		}

		public object createItem ()
		{
			return Item_factory.newInstance ();
		}
	}


	public class IIteratorInstanceImpl<T> : IIteratorInstance<T>
		where T:IData
	{

		public IIteratorInstanceImpl() { } 

		private ConcurrentQueue<Option<object>> items = null;

		public void put (object item)
		{
			items.Enqueue(new Some<object>(item));
		}

		public void putAll (IIteratorInstance<T> items)
		{
			while (!items.HasFinished)
				put(items.fetch_next());
		}

		public void finish ()
		{
			if (this.HasFinished)
				throw new FinishedIteratorException();

			this.items.Enqueue(new None<object>());
		}

		public object fetch_next ()
		{
			if (this.HasFinished)
				throw new FinishedIteratorException();

			Option<object> item;
			items.TryDequeue(out item);

			if (item.IsNone)
				throw new FinishedIteratorException();

			return item.Value;
		}

		public bool HasFinished
		{
			get 
			{ 
				Option<object> item;
				items.TryPeek(out item);

				return item.IsNone; 
			}
		}

		}

		public class FinishedIteratorException : Exception
		{
		}

		public class NonRestartableIteratorException : Exception
		{
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

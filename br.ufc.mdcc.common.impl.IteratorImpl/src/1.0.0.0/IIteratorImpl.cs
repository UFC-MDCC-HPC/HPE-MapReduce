using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace br.ufc.mdcc.common.impl.IteratorImpl 
{ 
	
	public class IIteratorImpl<T> : BaseIIteratorImpl<T>, IIterator<T>
	where T:IData
	{
		public IIteratorImpl() { } 

		override public void initialize()
		{
			newInstance(); 
		}

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

		private ConcurrentQueue<Option<object>> items = new ConcurrentQueue<Option<object>>();

		readonly object not_empty = new object();

		public void put (object item)
		{
			items.Enqueue(new Some<object>(item));

			lock (not_empty) { Monitor.Pulse(not_empty); }
		}

		public void putAll (IIteratorInstance<T> items)
		{
			object item;
			while (items.fetch_next(out item)) put(item);
		}

		public void finish ()
		{
			this.items.Enqueue(new None<object>());

			lock (not_empty) { Monitor.Pulse(not_empty); }

		}

		public bool fetch_next (out object result)
		{
			bool has_finished = false; //this.HasFinished;

			result = null;

			while (items.IsEmpty)
				lock (not_empty) { Monitor.Wait(not_empty); }

			Option<object> item;
			items.TryDequeue(out item);

			Trace.WriteLineIf(item == null, "Item is NULL " + this.GetHashCode());

			if (item.IsNone) 
			{
				has_finished = true;
		    }
			else 
				result = item.Value;				

			return !has_finished;
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

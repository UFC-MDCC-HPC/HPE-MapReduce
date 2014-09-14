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
		private bool has_finished = false;

		public IIteratorInstanceImpl() { } 

		private ConcurrentQueue<Option<object>> items = new ConcurrentQueue<Option<object>>();

		readonly object not_empty = new object();
		readonly Semaphore finished_iterator_1 = new Semaphore (0, int.MaxValue);
		readonly Semaphore finished_iterator_2 = new Semaphore (0, int.MaxValue);

		public void put (object item)
		{
			//if (this.HasFinished)
			//	throw new FinishedIteratorException();

			items.Enqueue(new Some<object>(item));

			lock (not_empty) { Monitor.Pulse(not_empty); }
		}

		public void putAll (IIteratorInstance<T> items)
		{
			//if (this.HasFinished)
			//	throw new FinishedIteratorException();

			object item;
			while (items.fetch_next(out item)) put(item);
		}

		public void finish ()
		{
			//if (this.HasFinished)
			//	throw new FinishedIteratorException();

			this.items.Enqueue(new None<object>());

			lock (not_empty) { Monitor.Pulse(not_empty); }

			Console.Out.WriteLine ("FINISH - BEGIN WAIT " + finished_iterator_1.GetHashCode());
		//	finished_iterator_1.WaitOne ();
			Console.Out.WriteLine ("FINISH - END WAIT " + finished_iterator_1.GetHashCode() + 
			                             " : BEGIN RELEASE " + finished_iterator_2.GetHashCode());
		//	finished_iterator_2.Release ();
			Console.Out.WriteLine ("FINISH - END RELEASE " + finished_iterator_2.GetHashCode());

		}

		public bool fetch_next (out object result)
		{
			bool has_finished = false; //this.HasFinished;

			//if (has_finished)
			//	throw new FinishedIteratorException();

			result = null;

			if (items.IsEmpty)
				lock (not_empty) { Monitor.Wait(not_empty); }

			Option<object> item;
			items.TryDequeue(out item);

			if (item.IsNone) 
			{
				Console.Out.WriteLine ("FETCH_NEXT - BEGIN RELEASE " + finished_iterator_1.GetHashCode());
			//	finished_iterator_1.Release ();
				Console.Out.WriteLine ("FETCH_NEXT - END RELEASE " + finished_iterator_1.GetHashCode() 
				                               + " : BEGIN WAIT " + finished_iterator_2.GetHashCode());
			//	finished_iterator_2.WaitOne ();
				Console.Out.WriteLine ("FETCH_NEXT - END WAIT " + finished_iterator_2.GetHashCode());
				/*this.has_finished =*/ has_finished = true;
		}
			else 
				result = item.Value;				

			return !has_finished;
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

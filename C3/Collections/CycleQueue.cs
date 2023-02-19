using System.Collections;
using System.Collections.ObjectModel;

namespace C3.Collections
{
    public class CycleQueue<T> : Collection<T>, IEnumerator<T>
    {
        protected int Position { get; private set; }

        public T Current { get; private set; }

        object IEnumerator.Current => throw new NotImplementedException();

        public CycleQueue(IList<T> Values) : base(Values) { }
        public CycleQueue(IEnumerable<T> Values) : this(Values.ToList()) { }
        public CycleQueue(params T[] Values) : base(Values) { }

        public T Cycle()
        {
            var ReturnValue = Current;
            MoveNext();
            return ReturnValue;
        }
        public void Reset()
        {
            Position = 0;
            Current = this[Position];
        }
        public bool MoveNext()
        {
            if (Count == 0)
                throw new ArgumentException("No elements to cycle.");

            Current = this[Position];

            if (Position + 1 >= Count)
            {
                Position = 0;
            }
            else
            {
                Position++;
            }
            return true;
        }

        public void Dispose() { }
    }
}

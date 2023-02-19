using System.Collections.Specialized;

namespace C3.Collections.Trackers
{
    public class ListChangedArgs<T> : EventArgs
    {
        public required NotifyCollectionChangedAction Action { get; init; }
        public IList<T>? NewItems { get; init; }
        public IList<T>? OldItems { get; init; }
    }
}

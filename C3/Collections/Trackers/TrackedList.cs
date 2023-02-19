using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace C3.Collections.Trackers
{
    public class TrackedList<T> : Collection<T>
    {
        public event EventHandler<ListChangedArgs<T>> ListChanged = delegate { };

        public TrackedList(IList<T> Collection) : base(Collection) { }
        public TrackedList() : base() { }

        public void TrackedAdd(T Item)
        {
            var OldItems = new Collection<T>(this.ToList());
            Add(Item);
            var NewItems = new Collection<T>(this.ToList());

            var Args = new ListChangedArgs<T>
            {
                Action = NotifyCollectionChangedAction.Add,
                NewItems = NewItems,
                OldItems = OldItems
            };
            ListChanged.Invoke(this, Args);
        }
        public void TrackedAddRange(IEnumerable<T> Items)
        {
            var OldItems = new Collection<T>(this.ToList());
            foreach (var Item in Items)
                Add(Item);
            var NewItems = new Collection<T>(this.ToList());

            var Args = new ListChangedArgs<T>
            {
                Action = NotifyCollectionChangedAction.Add,
                NewItems = NewItems,
                OldItems = OldItems
            };
            ListChanged.Invoke(this, Args);
        }
        public bool TrackedRemove(T Item)
        {
            var OldItems = new Collection<T>(this.ToList());
            bool Removed = Remove(Item);
            var NewItems = new Collection<T>(this.ToList());

            var Args = new ListChangedArgs<T>
            {
                Action = NotifyCollectionChangedAction.Add,
                NewItems = NewItems,
                OldItems = OldItems
            };
            ListChanged.Invoke(this, Args);
            return Removed;
        }
        public void TrackedRemoveAt(int Index)
        {
            var OldItems = new Collection<T>(this.ToList());
            RemoveAt(Index);
            var NewItems = new Collection<T>(this.ToList());

            var Args = new ListChangedArgs<T>
            {
                Action = NotifyCollectionChangedAction.Add,
                NewItems = NewItems,
                OldItems = OldItems
            };
            ListChanged.Invoke(this, Args);
        }
        public void TrackedInsert(int Index, T Item)
        {
            var OldItems = new Collection<T>(this.ToList());
            Insert(Index, Item);
            var NewItems = new Collection<T>(this.ToList());

            var Args = new ListChangedArgs<T>
            {
                Action = NotifyCollectionChangedAction.Add,
                NewItems = NewItems,
                OldItems = OldItems
            };
            ListChanged.Invoke(this, Args);
        }
        public void TrackedClear()
        {
            var OldItems = new Collection<T>(this.ToList());
            Clear();
            var NewItems = new Collection<T>(this.ToList());

            var Args = new ListChangedArgs<T>
            {
                Action = NotifyCollectionChangedAction.Add,
                NewItems = NewItems,
                OldItems = OldItems
            };
            ListChanged.Invoke(this, Args);
        }
    }
}

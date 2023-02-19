namespace C3.Math.Random
{
    public class WeightedItem<T>
    {
        public T Value { get; init; }
        public percent Chance { get; init; }

        public WeightedItem(T Value, percent Chance)
        {
            this.Value = Value;
            this.Chance = Chance;
        }

        public static implicit operator WeightedItem<T>((T Value, percent Chance) Item) => new(Item.Value, Item.Chance);
    }
}

namespace C3.Math
{
    public class WeightedItem<T>
    {
        public required T Value { get; init; }
        public required percent Chance { get; init; }
        public static implicit operator WeightedItem<T>((T Value, percent Chance) Item) => new()
        {
            Value = Item.Value,
            Chance = Item.Chance
        };
    }
}

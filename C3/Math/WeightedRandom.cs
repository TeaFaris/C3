namespace C3.Math
{
    public class WeightedRandom<T>
    {
        public Random Random { get; init; }
        public required IReadOnlyList<WeightedItem<T>> Items { get; set; }
        public percent TotalRatio => Items.Sum(Item => Item.Chance);
        public WeightedRandom()
        {
            Random ??= new Random();
        }
        public WeightedItem<T> GetWeightedItem()
        {
            var RandomPercent = Random.NextPercent() * TotalRatio;

            for (int i = 0; i < Items.Count; i++)
            {
                WeightedItem<T> Item = Items[i];

                RandomPercent -= Item.Chance;

                if (RandomPercent > 0)
                    continue;

                return Item;
            }
            return null!;
        }
        public T GetItem() => GetWeightedItem().Value;
    }
}

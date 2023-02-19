using RandomNumberGenerator = System.Random;

namespace C3.Math.Random
{
    public class WeightedRandom<T>
    {
        public RandomNumberGenerator RNG { get; init; }
        public IReadOnlyList<WeightedItem<T>> Items { get; set; }
        public percent TotalRatio => Items.Sum(Item => Item.Chance);
        public WeightedRandom(IEnumerable<WeightedItem<T>> Items)
        {
            RNG ??= RandomNumberGenerator.Shared;
            this.Items = Items.ToList();
        }
        public WeightedRandom(IEnumerable<T> Items) : this(Items.Select(Item => (WeightedItem<T>)(Item, 100f / Items.Count()))) { }
        public WeightedItem<T> GetWeightedItem()
        {
            var RandomPercent = RNG.NextPercent() * (TotalRatio / 100);

            for (int i = 0; i < Items.Count; i++)
            {
                WeightedItem<T> Item = Items[i];

                RandomPercent -= Item.Chance;

                if (RandomPercent > 0)
                    continue;

                return Item;
            }
            throw new ArgumentException("No elements");
        }
        public T GetItem() => GetWeightedItem().Value;
    }
}

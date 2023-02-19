namespace C3.Linq
{
    public static class LINQExtentions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> Source, Action<T> Action)
        {
            foreach(var Item in Source)
                Action(Item);
            return Source;
        }
        public static IEnumerable<T> For<T>(this IEnumerable<T> Source, Action<T, int> Action)
        {
            var Index = 0;
            foreach (var Item in Source)
            {
                Action(Item, Index);
                Index++;
            }

            return Source;
        }
        /// <summary>
        /// MultiDim Array to 1D Array
        /// </summary>
        /// <typeparam name="T">Array type</typeparam>
        /// <param name="MultDimArray">Multi Dim Array</param>
        /// <returns>1D array</returns>
        public static T[] Flatten<T>(this Array MultDimArray)
        {
            T[] FlattenArray = new T[MultDimArray.Length];
            int i = 0;
            foreach (var Item in MultDimArray)
            {
                FlattenArray[i] = (T)Item;
                i++;
            }

            return FlattenArray;
        }
        /// <summary>
        /// 1D Array to 3D Array
        /// </summary>
        /// <typeparam name="T">Array type</typeparam>
        /// <param name="Array">1D array</param>
        /// <param name="XMax">Max length on X</param>
        /// <param name="YMax">Max length on Y</param>
        /// <param name="ZMax">Max length on Z</param>
        /// <returns>3D array</returns>
        public static T[,,] Expand<T>(this T[] Array, int XMax, int YMax, int? ZMax = null)
        {
            int Length = Array.GetLength(0);
            ZMax ??= Length / XMax / YMax;

            T[,,] ArrayExpanded = new T[XMax, YMax, ZMax.Value];
            int i, j, k;
            for (k = 0; k < XMax; k++)
            {
                for (j = 0; j < YMax; j++)
                {
                    for (i = 0; i < ZMax; i++)
                    {
                        ArrayExpanded[k, j, i] = Array[i + (j * ZMax.Value) + (k * YMax * ZMax.Value)];
                    }
                }
            }

            return ArrayExpanded;
        }
        public static Dictionary<T, uint> Quantify<T>(this IEnumerable<T> Enumerable, Func<T, T, bool> Comparison) where T : notnull
        {
            var AllItems = Enumerable.Distinct();
            Dictionary<T, uint> Result = new Dictionary<T, uint>();
            AllItems.ForEach(Single => Result.Add(Single, (uint)Enumerable.Count(Item => Comparison(Single, Item))));
            return Result;
        }
        public static Dictionary<T, uint> QuantifyBy<T, TKey>(this IEnumerable<T> Enumerable, Func<T, TKey> ByFunc) where T : notnull => Enumerable.Quantify((x, y) => ByFunc(x)?.Equals(ByFunc(y)) ?? false);
        public static Dictionary<T, uint> Quantify<T>(this IEnumerable<T> Enumerable) where T : notnull => Enumerable.Quantify((Single, Item) => (Single is null && Item is null) || Single!.Equals(Item));
    }
}

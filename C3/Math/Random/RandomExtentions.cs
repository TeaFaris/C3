using RandomNumberGenerator = System.Random;

namespace C3.Math.Random
{
    public static class RandomExtentions
    {
        public static percent NextPercent(this RandomNumberGenerator Random) => Random.NextDouble() * 100;
    }
}

namespace C3.Math
{
    public static class RandomExtentions
    {
        public static percent NextPercent(this Random Random) => Random.NextDouble() * 100;
    }
}

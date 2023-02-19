using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace C3.Math
{
    public struct percent : INumber<percent>
    {
        private readonly decimal Value;

        private percent(decimal Value) => this.Value = Value;

        public static percent One => (percent)0;

        public static int Radix => 0;

        public static percent Zero => (percent)0;

        public static percent AdditiveIdentity => (percent)0;

        public static percent MultiplicativeIdentity => (percent)1;

        public decimal AsNumber() => this.Value;

        public static percent Abs(percent value) => (percent)decimal.Abs(value.Value);

        public static bool IsCanonical(percent value) => decimal.IsCanonical(value.Value);

        public static bool IsComplexNumber(percent value) => false;

        public static bool IsEvenInteger(percent value) => decimal.IsEvenInteger(value.Value);

        public static bool IsFinite(percent value) => true;

        public static bool IsImaginaryNumber(percent value) => false;

        public static bool IsInfinity(percent value) => false;

        public static bool IsInteger(percent value) => decimal.IsInteger(value.Value);

        public static bool IsNaN(percent value) => false;

        public static bool IsNegative(percent value) => decimal.IsNegative(value.Value);

        public static bool IsNegativeInfinity(percent value) => false;

        public static bool IsNormal(percent value) => true;

        public static bool IsOddInteger(percent value) => decimal.IsOddInteger(value.Value);

        public static bool IsPositive(percent value) => decimal.IsPositive(value.Value);

        public static bool IsPositiveInfinity(percent value) => false;

        public static bool IsRealNumber(percent value) => true;

        public static bool IsSubnormal(percent value) => false;

        public static bool IsZero(percent value) => value.Value == 0M;

        public static percent MaxMagnitude(percent x, percent y) => (percent)decimal.MaxMagnitude(x.Value, y.Value);

        public static percent MaxMagnitudeNumber(percent x, percent y) => (percent)decimal.MaxMagnitude(x.Value, y.Value);

        public static percent MinMagnitude(percent x, percent y) => (percent)decimal.MinMagnitude(x.Value, y.Value);

        public static percent MinMagnitudeNumber(percent x, percent y) => (percent)decimal.MinMagnitude(x.Value, y.Value);

        public static percent Parse(
          ReadOnlySpan<char> s,
          NumberStyles style,
          IFormatProvider? provider)
        {
            return (percent)Decimal.Parse(s, style, provider);
        }

        public static percent Parse(string s, NumberStyles style, IFormatProvider? provider) => (percent)decimal.Parse(s, style, provider);

        public static percent Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => (percent)decimal.Parse(s, provider);

        public static percent Parse<Num>(Num Value) where Num : INumber<Num> => (percent)Convert.ToDecimal(Value);

        public static percent ParseBase<Num>(Num Value) where Num : INumberBase<Num> => (percent)Convert.ToDecimal(Value);

        public static percent Parse(string s, IFormatProvider? provider) => (percent)decimal.Parse(s, provider);

        public static bool TryParse(
          ReadOnlySpan<char> s,
          NumberStyles style,
          IFormatProvider? provider,
          [MaybeNullWhen(false)] out percent result)
        {
            decimal result1;
            int num = decimal.TryParse(s, style, provider, out result1) ? 1 : 0;
            result = (percent)result1;
            return num != 0;
        }

        public static bool TryParse(
          [NotNullWhen(true)] string? s,
          NumberStyles style,
          IFormatProvider? provider,
          [MaybeNullWhen(false)] out percent result)
        {
            decimal result1;
            int num = decimal.TryParse(s, style, provider, out result1) ? 1 : 0;
            result = (percent)result1;
            return num != 0;
        }

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out percent result)
        {
            decimal result1;
            int num = decimal.TryParse(s, provider, out result1) ? 1 : 0;
            result = (percent)result1;
            return num != 0;
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out percent result)
        {
            decimal result1;
            int num = decimal.TryParse(s, provider, out result1) ? 1 : 0;
            result = (percent)result1;
            return num != 0;
        }

        public static bool TryConvertFromChecked<TOther>(TOther value, out percent result) where TOther : INumberBase<TOther>
        {
            result = percent.ParseBase<TOther>(value);
            return true;
        }

        public static bool TryConvertFromSaturating<TOther>(TOther value, out percent result) where TOther : INumberBase<TOther> => percent.TryConvertFromChecked<TOther>(value, out result);

        public static bool TryConvertFromTruncating<TOther>(TOther value, out percent result) where TOther : INumberBase<TOther> => percent.TryConvertFromChecked<TOther>(value, out result);

        public static bool TryConvertToChecked<TOther>(percent value, out TOther result) where TOther : INumberBase<TOther> => TOther.TryConvertFromChecked(value, out result);

        public static bool TryConvertToSaturating<TOther>(percent value, out TOther result) where TOther : INumberBase<TOther> => TOther.TryConvertFromSaturating(value, out result);

        public static bool TryConvertToTruncating<TOther>(percent value, out TOther result) where TOther : INumberBase<TOther> => TOther.TryConvertFromTruncating(value, out result);

        public int CompareTo(object? obj) => this.Value.CompareTo(obj);

        public int CompareTo(percent other) => this.Value.CompareTo((Decimal)other);

        public bool Equals(percent other) => this.Value.Equals((Decimal)other);

        public string ToString(string? format, IFormatProvider? formatProvider) => this.Value.ToString(format, formatProvider) + "%";

        public bool TryFormat(
          Span<char> destination,
          out int charsWritten,
          ReadOnlySpan<char> format,
          IFormatProvider? provider)
        {
            return this.Value.TryFormat(destination, out charsWritten, format, provider);
        }

        public static percent operator +(percent value) => (percent)value.Value;

        public static percent operator +(percent left, percent right) => left.Value + right.Value;

        public static percent operator -(percent value) => -value.Value;

        public static percent operator -(percent left, percent right) => left.Value - right.Value;

        public static percent operator ++(percent value) => value.Value + 1M;

        public static percent operator --(percent value) => value.Value - 1M;

        public static percent operator *(percent left, percent right) => left.Value * right.Value;

        public static percent operator /(percent left, percent right) => left.Value / right.Value;

        public static percent operator %(percent left, percent right) => left.Value % right.Value;

        public static bool operator ==(percent left, percent right) => left.Value == right.Value;

        public static bool operator !=(percent left, percent right) => left.Value != right.Value;

        public static bool operator <(percent left, percent right) => left.Value < right.Value;

        public static bool operator >(percent left, percent right) => left.Value > right.Value;

        public static bool operator <=(percent left, percent right) => left.Value <= right.Value;

        public static bool operator >=(percent left, percent right) => left.Value >= right.Value;

        public static Decimal operator *(Decimal Total, percent Percent) => Total / 100M * Percent.Value;

        public static float operator *(float Left, percent Right) => Left / 100f * (float)Right.Value;

        public static double operator *(double Left, percent Right) => Left / 100.0 * (double)Right.Value;

        public static int operator *(int Left, percent Right) => Left / 100 * (int)Right.Value;

        public static long operator *(long Left, percent Right) => Left / 100L * (long)Right.Value;

        public static Decimal operator *(percent Percent, Decimal Total) => Percent.Value * Total;

        public static Decimal operator *(percent Percent, float Total) => Percent.Value * (decimal)Total;

        public static Decimal operator *(percent Percent, double Total) => Percent.Value * (decimal)Total;

        public static Decimal operator *(percent Percent, int Total) => Percent.Value * (decimal)Total;

        public static Decimal operator *(percent Percent, long Total) => Percent.Value * (decimal)Total;

        public static Decimal operator -(Decimal Left, percent Right) => Left - Left * Right;

        public static float operator -(float Left, percent Right) => Left - Left * Right;

        public static double operator -(double Left, percent Right) => Left - Left * Right;

        public static int operator -(int Left, percent Right) => Left - Left * Right;

        public static Decimal operator +(Decimal Left, percent Right) => Left + Left * Right;

        public static float operator +(float Left, percent Right) => Left + Left * Right;

        public static double operator +(double Left, percent Right) => Left + Left * Right;

        public static int operator +(int Left, percent Right) => Left + Left * Right;

        /// <summary>
        /// Gets percent value and clamps from 0.0f to 1f
        /// </summary>
        public static float operator ~(percent Value) => (float)(Value / 100f);

        public static implicit operator percent(Decimal Value) => new percent(Value);

        public static implicit operator percent(double Value) => Parse(Value);

        public static implicit operator percent(float Value) => Parse(Value);

        public static implicit operator percent(int Value) => Parse(Value);

        public static implicit operator percent(uint Value) => Parse(Value);

        public static implicit operator percent(byte Value) => Parse(Value);

        public static implicit operator percent(sbyte Value) => Parse(Value);

        public static implicit operator percent(short Value) => Parse(Value);

        public static implicit operator percent(ushort Value) => Parse(Value);

        public static implicit operator percent(long Value) => Parse(Value);

        public static implicit operator percent(ulong Value) => Parse(Value);

        public static implicit operator decimal(percent Percent) => Percent.Value;

        public static explicit operator double(percent Percent) => (double)Percent.Value;

        public static explicit operator float(percent Percent) => (float)Percent.Value;

        public static explicit operator int(percent Percent) => (int)Percent.Value;

        public static explicit operator uint(percent Percent) => (uint)Percent.Value;

        public static explicit operator byte(percent Percent) => (byte)Percent.Value;

        public static explicit operator sbyte(percent Percent) => (sbyte)Percent.Value;

        public static explicit operator short(percent Percent) => (short)Percent.Value;

        public static explicit operator ushort(percent Percent) => (ushort)Percent.Value;

        public static explicit operator long(percent Percent) => (long)Percent.Value;

        public static explicit operator ulong(percent Percent) => (ulong)Percent.Value;
        public override string ToString() => $"{Value}%";
    }
}

namespace OeX.Dashboard.Domain.Utils
{
    public static class OeXMath
    {
        public static decimal TruncateToDecimalPlaces(decimal value, int decimalPlaces)
        {
            decimal factor = (decimal)Math.Pow(10, decimalPlaces);
            return Math.Truncate(value * factor) / factor;
        }
    }
}

namespace Marketplace.Framework
{
    public static class StringTools
    {

        // Extension Methods (C# Programming Guide)
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
        public static bool IsEmpty(this string value) => string.IsNullOrWhiteSpace(value);
    }
}
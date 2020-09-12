using System;

namespace AlkarInjector.Utilities
{
    public static class VarianceUtility
    {
        public static object Convert< TOriginalArray>(this TOriginalArray[] self, Type elementType)
        {
            var result = Array.CreateInstance(elementType, self.Length);
            Array.Copy(self, result, self.Length);
            return result;
        }
    }
}
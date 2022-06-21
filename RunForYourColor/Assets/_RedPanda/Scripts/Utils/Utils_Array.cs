namespace RedPanda
{
    public static class Utils_Array
    {
        public static T GetRandomValueOfArray<T>(this T[] array)
        {
            return array[Utils_Randomizer.Randomize(array.Length)];
        }
    }
}
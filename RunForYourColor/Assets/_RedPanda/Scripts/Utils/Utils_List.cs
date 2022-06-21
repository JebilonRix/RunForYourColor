using System.Collections.Generic;

namespace RedPanda
{
    public static class Utils_List
    {
        public static T GetMaxValueOfList<T>(this List<T> list)
        {
            list.Sort();
            return list[list.Count - 1];
        }
        public static T GetMinValueOfList<T>(this List<T> list)
        {
            list.Sort();
            return list[0];
        }
        public static T GetRandomValueOfList<T>(this List<T> list)
        {
            return list[Utils_Randomizer.Randomize(list.Count)];
        }
        public static void Shuffle<T>(this IList<T> list)
        {
            System.Random rng = new System.Random();

            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
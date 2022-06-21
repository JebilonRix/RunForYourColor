using UnityEngine;

namespace RedPanda
{
    public static class Utils_Randomizer
    {
        public static int Randomize(int maxValue)
        {
            return Random.Range(0, maxValue);
        }
        public static int Randomize(int minValue, int maxValue)
        {
            return Random.Range(minValue, maxValue);
        }
        public static float Randomize(float maxValue)
        {
            return Random.Range(0.0f, maxValue);
        }
        public static float Randomize(float minValue, float maxValue)
        {
            return Random.Range(minValue, maxValue);
        }
    }
}
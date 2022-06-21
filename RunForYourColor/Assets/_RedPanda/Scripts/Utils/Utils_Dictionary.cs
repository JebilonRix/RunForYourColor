using System.Collections.Generic;
using UnityEngine;

namespace RedPanda
{
    public static class Utils_Dictionary
    {
        public static void ToDictionary(this Dictionary<string, Queue<GameObject>> dictionary, string tag, GameObject obj)
        {
            dictionary[tag].Enqueue(obj);
        }
        public static GameObject FromDictionary(this Dictionary<string, Queue<GameObject>> dictionary, string tag)
        {
            if (dictionary[tag].Count <= 0)
            {
                return null;
            }
            else
            {
                return dictionary[tag].Dequeue();
            }
        }
    }
}
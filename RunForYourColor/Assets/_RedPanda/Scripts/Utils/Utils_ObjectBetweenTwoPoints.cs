using UnityEngine;

namespace RedPanda
{
    public static class Utils_ObjectBetweenTwoPoints
    {
        public static void SetObjectBetweenTwoPoints(GameObject objectToSpawn, Vector3 startPoint, Vector3 endPoint)
        {
            objectToSpawn.transform.SetPositionAndRotation((startPoint + endPoint) / 2,
                Quaternion.Euler(new Vector3(0, AngleBetweenTwoVectors(startPoint, endPoint), 0)));
            objectToSpawn.transform.localScale = new Vector3(0.5f, 0.1f, Vector3.Distance(startPoint, endPoint));
        }
        private static float AngleBetweenTwoVectors(Vector3 from, Vector3 to)
        {
            float angle = Vector3.Angle(Vector3.forward, to - from);

            if (from.x > to.x)
            {
                angle = 360 - angle;
            }

            return angle;
        }
    }
}
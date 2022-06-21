using UnityEngine;

namespace RedPanda.Utils
{
    public static class Utils_MousePosition
    {
        public static Vector3 GetMousePosition(Camera camera, Vector3 mousePosition)
        {
            Vector3 mouseWorld = camera.WorldToScreenPoint(mousePosition);
            mouseWorld.x = 0f;
            mouseWorld.z = 0f;

            return mouseWorld;
        }
    }
}
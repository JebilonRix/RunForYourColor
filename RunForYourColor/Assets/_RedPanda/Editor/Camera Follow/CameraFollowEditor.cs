using UnityEditor;
using UnityEngine;

namespace RedPanda.CameraFollow
{
    [CustomEditor(typeof(CameraFollow))]
    public class CameraFollowEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            CameraFollow cameraFollow = (CameraFollow)target;

            if (GUILayout.Button("Set Camera Position"))
            {
                cameraFollow.SetPosition();
            }
        }
    }
}
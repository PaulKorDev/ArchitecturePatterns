using UnityEngine;

namespace UnityToolKits
{
    public static class ToolKitClass //: MonoBehaviour
    {
        //Create TextMesh in world
        public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = 5000)
        {
            if (color == null) color = Color.white; 
            GameObject gameObject = new GameObject("World_text", typeof(TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = (Color)color;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
            return textMesh;
        }
        
        //Get coordinates of mouse position
        public static Vector3 GetMouseWorldPosition()
        {
            Vector3 mousePos = GetMouseWorldPositionWithZ();
            mousePos.z = 0f;
            return mousePos;
        }
        public static Vector3 GetMouseWorldPositionWithZ()
        {
            return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        }
        public static Vector3 GetMouseWorldPositionWithZ(Camera camera)
        {
            return GetMouseWorldPositionWithZ(Input.mousePosition, camera);
        }
        public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera camera)
        {
            return camera.ScreenToWorldPoint(screenPosition);
        }

    }
}

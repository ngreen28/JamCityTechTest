using UnityEngine.UIElements;

namespace Extension
{
    public static class VisualElementExt
    {
        public static T GetReference<T>(this VisualElement visualElement, string reference)
            where T : VisualElement
        {
            if (visualElement == null) throw new System.Exception("visualElement required");
            if (reference == null) throw new System.Exception("reference required");
            return visualElement.Q<T>(reference);
        }

        public static T GetReferenceChildren<T, TR>(this VisualElement visualElement, string reference, int position)
            where T : VisualElement
            where TR : VisualElement
        {
            if (visualElement == null) throw new System.Exception("visualElement required");
            if (reference == null) throw new System.Exception("reference required");
            return (T)visualElement.GetReference<TR>(reference).ElementAt(position);
        }

        public static void RemoveAllChildren<T>(this VisualElement visualElement, string reference)
            where T : VisualElement
        {
            if (visualElement == null) throw new System.Exception("visualElement required");
            if (reference == null) throw new System.Exception("reference required");
            visualElement.GetReference<T>(reference).Clear();
        }

        public static void AddChildren<T, TR>(this VisualElement visualElement, string reference, TR children)
            where T : VisualElement
            where TR : VisualElement
        {
            if (visualElement == null) throw new System.Exception("visualElement required");
            if (reference == null) throw new System.Exception("reference required");
            if (children == null) throw new System.Exception("children required");
            visualElement.GetReference<T>(reference).Add(children);
        }

        public static void AddChildren<T, TR>(this T visualElement, TR children)
            where T : VisualElement
            where TR : VisualElement
        {
            if (visualElement == null) throw new System.Exception("visualElement required");
            if (children == null) throw new System.Exception("children required");
            visualElement.Add(children);
        }
    }
}

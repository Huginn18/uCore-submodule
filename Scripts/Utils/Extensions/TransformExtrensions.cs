namespace HoodedCrow.uCore.Utils
{
    using System.Collections.Generic;
    using UnityEngine;

    public static class TransformExtrensions
    {
        public static List<Transform> GetChildren(this Transform transform)
        {
            List<Transform> children = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
            {
                children.Add(transform.GetChild(i));
            }

            return children;
        }

        public static T FindParentWithComponent<T>(this Transform transform) where T : MonoBehaviour
        {
            T component = null;
            Transform t = transform;
            while (component == null)
            {
                t = transform.parent;
                if (t == null)
                {
                    throw new NoParentsWithComponentException($"Cannot find parent with component: {typeof(T).Name} not found");
                }

                component = t.GetComponent<T>();
                if (component != null)
                {
                    break;
                }
            }

            return component;
        }

        public static T FindChildWithComponent<T>(this Transform transform) where T : MonoBehaviour
        {
            T component = null;
            List<Transform> children = transform.GetChildren();
            foreach (Transform child in children)
            {
                component = child.GetComponent<T>();
                if (component != null)
                {
                    break;
                }
            }

            if (component is null)
            {
                throw new NoChildrenWithComponentException($"Cannot find child with component: {typeof(T).Name} not found");
            }

            return component;
        }
    }
}

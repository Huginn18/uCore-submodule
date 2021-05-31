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

        public static List<T> FindChildrenWithComponent<T>(this Transform transform) where T : MonoBehaviour
        {
            List<T> components = new List<T>();
            List<Transform> children = transform.GetChildren();

            foreach (Transform child in children)
            {
                T component = child.GetComponent<T>();
                if (component is null)
                {
                    continue;
                }

                components.Add(component);
            }

            if (components.Count == 0)
            {
                throw new NoChildrenWithComponentException($"Cannot find children with component: {typeof(T).Name} not found");
            }

            return components;
        }
    }
}

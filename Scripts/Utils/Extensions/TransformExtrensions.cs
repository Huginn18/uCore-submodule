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
    }
}

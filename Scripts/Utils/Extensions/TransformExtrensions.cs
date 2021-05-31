namespace HoodedCrow.uCore.Utils
{
    using UnityEngine;

    public static class TransformExtrensions
    {
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

namespace HoodedCrow.uCore.UI
{
    using HoodedCrow.uCore.Utils;
    using UnityEngine;

    public abstract class ASubview<TParentView>: AView where TParentView : AView
    {
        [SerializeField] protected TParentView _parentView;
        protected virtual void Reset()
        {
            if (_parentView == null)
            {
                _parentView = transform.FindParentWithComponent<TParentView>();
                if (_parentView == null)
                {
                    Debug.LogWarning($"Cannot assign parent view: Parent with {typeof(TParentView).Name} component not found");
                }
            }
        }
    }
}

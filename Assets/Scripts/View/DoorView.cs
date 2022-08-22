using UnityEngine;

namespace EcsLiteDoors
{
    public class DoorView : ColorizedView
    {
        [SerializeField] private Transform viewTransform;
        
        public void SetOpenPercent(float percent)
        {
            viewTransform.localPosition = new Vector3(0f, (percent * 2f) - 0.95f, 0f);
        }
    }
}

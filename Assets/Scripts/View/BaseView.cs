using UnityEngine;

namespace EcsLiteDoors
{
    public abstract class BaseView : MonoBehaviour
    {
        public void Init(Vector3 position, uint color)
        {
            transform.position = position;
            GetComponentInChildren<Renderer>().material.color = ColorFromInt(color);
        }
        
        private Color32 ColorFromInt(uint aCol)
        {
            Color32 c = new Color32
            {
                b = (byte) ((aCol) & 0xFF),
                g = (byte) ((aCol >> 8) & 0xFF),
                r = (byte) ((aCol >> 16) & 0xFF),
                a = (byte) ((aCol >> 24) & 0xFF)
            };
            return c;
        }
    }
}

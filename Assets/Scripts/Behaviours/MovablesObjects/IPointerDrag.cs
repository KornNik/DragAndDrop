using UnityEngine;

namespace Behaviours
{
    interface IPointerDrag
    {
        void OnEndPointerDrag();
        void OnBeginPointerDrag();
        void OnPointerDrag(Vector3 position);
    }
}

using System;
using UnityEngine;

namespace Behaviours
{
    [Serializable]
    class ShelfSpace
    {
        public Transform ItemTransform;
        public IItem CurrentItem;
        public int ItemRenderOrder;

        public bool IsEmpty => CurrentItem == null ? true : false;
    }
}

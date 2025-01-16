using UnityEngine;

namespace Behaviours
{
    sealed class Shelf : MonoBehaviour, IShelf
    {
        [SerializeField] private Collider2D _fitCollider;
        [SerializeField] private ShelfSpace[] _shelfSpaces;

        private void Awake()
        {

        }

        public void PutObjectOnShelf(IItem item)
        {
            if (IsHasSpace())
            {
                var space = GetClosestEmptyShelfSpace();
                item.PutOnShelf(space, this);
                space.CurrentItem = item;
            }
        }

        public void RemoveFromShelf(IItem item)
        {
            ShelfSpace space = GetShelfSpaceByItem(item);
            space.CurrentItem = null;
            item.RemoveFromShelf();
        }

        private bool IsHasSpace()
        {
            for (int i = 0; i < _shelfSpaces.Length; i++)
            {
                if (_shelfSpaces[i].IsEmpty)
                {
                    return true;
                }
            }
            return false;
        }
        private ShelfSpace GetClosestEmptyShelfSpace()
        {
            for (int i = 0; i < _shelfSpaces.Length; i++)
            {
                if (_shelfSpaces[i].IsEmpty)
                {
                    return _shelfSpaces[i];
                }
            }
            return null;
        }
        private ShelfSpace GetShelfSpaceByItem(IItem item)
        {
            for (int i = 0; i < _shelfSpaces.Length; i++)
            {
                if (!_shelfSpaces[i].IsEmpty && _shelfSpaces[i].CurrentItem == item)
                {
                    return _shelfSpaces[i];
                }
            }
            return null;
        }
    }
}

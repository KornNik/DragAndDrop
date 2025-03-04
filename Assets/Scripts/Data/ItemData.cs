using DG.Tweening;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Data/ItemData")]
    sealed class ItemData : ScriptableObject
    {
        [SerializeField] private Ease _putInShelfEase;
        [SerializeField] private float _putOnsShelfDuration;
        [SerializeField] private float _movementDuration;
        [SerializeField] private Color _dragColor;

        public Ease PutInShelfEase => _putInShelfEase;
        public float PutOnsShelfDuration => _putOnsShelfDuration;
        public float MovementDuration => _movementDuration;
        public Color DragColor => _dragColor;
    }
}

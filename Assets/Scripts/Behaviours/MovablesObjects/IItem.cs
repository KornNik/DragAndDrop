namespace Behaviours
{
    interface IItem
    {
        bool IsOnShelf { get; }
        void PutOnShelf(ShelfSpace shelfSpace, IShelf currentShelf);
        void RemoveFromShelf();
    }
}

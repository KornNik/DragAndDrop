namespace Behaviours
{
    interface IShelf
    {
        void PutObjectOnShelf(IItem item);
        void RemoveFromShelf(IItem item);
    }
}

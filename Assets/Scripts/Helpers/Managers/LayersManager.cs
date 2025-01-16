using UnityEngine;

namespace Helpers.Managers
{
    static class LayersManager
    {
        public const string UI = "UI";
        public const string DEFAULT = "Default";
        public const string SHELF = "Shelf";


        public const int DEFAULT_LAYER = 0;
        
        static LayersManager()
        {
            DefaultLayer = LayerMask.GetMask(DEFAULT);
            UiLayer = LayerMask.GetMask(UI);
            Shelf = LayerMask.GetMask(SHELF);
            ShelfLayer = LayerMask.NameToLayer(SHELF);
        }
        
        public static int DefaultLayer { get; }
        public static int UiLayer { get; }
        public static int Shelf { get; }
        public static int ShelfLayer { get; }
    }
}

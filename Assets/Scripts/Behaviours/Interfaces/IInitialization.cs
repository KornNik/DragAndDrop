using System.Threading.Tasks;

namespace Behaviours
{
    interface IInitialization
    {
        void Initialization();
    }
    interface IInitializationAsync
    {
        Task InitializationAsync();
    }
}

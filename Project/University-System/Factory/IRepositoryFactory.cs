using SysUniPro.Repostory;

namespace SysUniPro.Factory
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>() where T : class;
    }
}

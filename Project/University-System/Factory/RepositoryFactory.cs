using SysUniPro.Context;
using SysUniPro.Repostory;

namespace SysUniPro.Factory
{
    public class RepositoryFactory: IRepositoryFactory
    {
       
            private readonly MyContext _context;

            public RepositoryFactory(MyContext context)
            {
                _context = context;
            }

            public IRepository<T> CreateRepository<T>() where T : class
            {
                return new Repository<T>(_context);
            }
    }
}


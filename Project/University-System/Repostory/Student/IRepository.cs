namespace SysUniPro.Repostory
{
        public interface IRepository<T> where T : class
        {
            IEnumerable<T> GetAll();
            void Add(T entity);
            void Delete(int id);
        }

}

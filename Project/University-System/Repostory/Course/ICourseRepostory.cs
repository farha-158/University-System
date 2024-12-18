using SysUniPro.Models;

namespace SysUniPro.Repostory
{
    public interface ICourseRepostory
    {
         public List<Course> GetAllCourse();

        public void AddCourse(Course course);

        public void Delete(int id);

    }
}

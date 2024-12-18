using NuGet.Protocol.Plugins;
using SysUniPro.Context;
using SysUniPro.Models;

namespace SysUniPro.Repostory
{
    public class CourseRepostory : ICourseRepostory
    {
        private readonly MyContext _context;
        public CourseRepostory(MyContext context)
        {
            _context = context;
        }
        public List<Course> GetAllCourse()
        {
                List<Course> coulist = (from couobj in _context.Courses
                                            select couobj).ToList();
                return coulist;
         }
        public void AddCourse(Course course)
        {
           
                _context.Courses.Add(course);
            _context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            Course course =(from cou  in _context.Courses
                            where cou.CourseId==id
                            select cou).FirstOrDefault();

            _context.Courses.Remove(course);           
            _context.SaveChanges();
        }

        

        
    }
}

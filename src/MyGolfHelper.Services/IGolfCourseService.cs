using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Services
{
    public interface IGolfCourseService<TGolfCourse, TGolfCourseId>
    {
        public Task<IEnumerable<TGolfCourse>> GetAllGolfCourses();
        public Task<TGolfCourse> FindGolfCourse(TGolfCourseId id);
        public Task<int> UpdateGolfCourse(TGolfCourseId golfCourse);
        public Task<TGolfCourse> CreateGolfCourse(TGolfCourseId golfCourse);
        public Task<int> DeleteGolfCourse(TGolfCourseId id);
    }
}

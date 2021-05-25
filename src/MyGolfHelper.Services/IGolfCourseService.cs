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
        public Task<int> UpdateGolfCourse(TGolfCourse golfCourse);
        public Task<bool> CreateGolfCourse(TGolfCourse golfCourse);
        public Task<int> DeleteGolfCourse(TGolfCourseId id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Services
{
    public interface IGolfCourseService<TGolfCourse, TGolfCourseId>
    {
        public Task<IEnumerable<TGolfCourse>> GetAllGolfCoursesAsync();
        public Task<TGolfCourse> FindGolfCourseAsync(TGolfCourseId id);
        public Task<int> UpdateGolfCourseAsync(TGolfCourse golfCourse);
        public Task<bool> CreateGolfCourseAsync(TGolfCourse golfCourse);
        public Task<int> DeleteGolfCourseAsync(TGolfCourseId id);
    }
}

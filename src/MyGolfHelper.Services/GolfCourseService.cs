﻿using Microsoft.EntityFrameworkCore;
using MyGolfHelper.Data;
using MyGolfHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Services
{
    public class GolfCourseService : IGolfCourseService<GolfCourse, long>
    {
        private readonly IDbContextFactory<MyGolfHelperDbContext> _contextFactory;

        public GolfCourseService(IDbContextFactory<MyGolfHelperDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> CreateGolfCourse(GolfCourse golfCourse)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var result = await context.GolfCourses.AddAsync(golfCourse);
                return await context.SaveChangesAsync() == 1;
            }
        }

        public Task<int> DeleteGolfCourse(long id)
        {
            throw new NotImplementedException();
        }

        public Task<GolfCourse> FindGolfCourse(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GolfCourse>> GetAllGolfCourses()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateGolfCourse(GolfCourse golfCourse)
        {
            throw new NotImplementedException();
        }
    }
}

using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigSchool.ViewModels
{
    public class CoursesViewModel
    {
        private readonly ApplicationDbContext _dbContext;

        public CoursesViewModel()
        {
            _dbContext = new ApplicationDbContext();
        }
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }

        public bool CheckFollow(string followeeId, string userId)
        {
            var listFollowing = _dbContext.Followings.Where(c => c.FolloweeId == userId).ToList();
            foreach(var i in listFollowing)
            {
                if(i.FolloweeId.Equals(followeeId))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckAttend(int courseId, string userId)
        {
            var listAttend = _dbContext.Attendances.Where(c => c.AttendeeId == userId).ToList();
            foreach (var i in listAttend)
            {
                if (i.CourseId == courseId)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
using AcademyModel.BuisnessLogic;
using AcademyModel.Entities;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Services
{
    public interface ICoursesService
    {
        Course GetCourseById(long id);
        IEnumerable<Course> GetAllCourses();
        IEnumerable<Course> FindCourseByTitleLike(string title);
        IEnumerable<Course> FindCourseByCourseDescriptionLike(string description);
        IEnumerable<Course> FindCourseByArea(long idArea);
        IEnumerable<Course> GetLastCourses(int n);
        Course CreateCourse(Course c);
        Course UpdateCourse(Course c);
        void DeleteCourse(Course c);
        void DeleteCourse(long id);
    }
}

using AcademyEFPersistance.EFContext;
using AcademyModel.Entities;
using AcademyModel.Repositories;
using AcademyModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEFPersistance.Services
{
    public class EFCoursesService : ICoursesService
    {

        private ICourseRepository courseRepo;

        private AcademyContext ctx;
        public EFCoursesService(ICourseRepository courseRepo, AcademyContext ctx)
        {
            this.courseRepo = courseRepo;
            this.ctx = ctx;
        }

        public Course GetCourseById(long id)
        {
            return courseRepo.FindById(id);
        }
        public IEnumerable<Course> GetAllCourses()
        {
            return courseRepo.GetAll();
        }
        public IEnumerable<Course> FindCourseByTitleLike(string title)
        {
            return courseRepo.FindCourseByTitleLike(title);
        }
        public IEnumerable<Course> FindCourseByCourseDescriptionLike(string description)
        {
            return courseRepo.FindCourseByCourseDescriptionLike(description);
        }
        public IEnumerable<Course> FindCourseByArea(long idArea)
        {
            return courseRepo.FindCourseByArea(idArea);
        }
        public IEnumerable<Course> GetLastCourses(int n)
        {
            return courseRepo.GetLastCourses(n);
        }
        public Course CreateCourse(Course c)
        {
            var res = courseRepo.Create(c);
            ctx.SaveChanges();
            return res;
        }
        public void DeleteCourse(Course c)
        {
            courseRepo.Delete(c);
            ctx.SaveChanges();
        }
        public void DeleteCourse(long id)
        {
            courseRepo.Delete(id);
            ctx.SaveChanges();
        }
        public Course UpdateCourse(Course c)
        {
            var res = courseRepo.Update(c);
            ctx.SaveChanges();
            return res;
        }

    }
}

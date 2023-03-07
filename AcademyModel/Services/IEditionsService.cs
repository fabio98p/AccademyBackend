using AcademyModel.BuisnessLogic;
using AcademyModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Services
{
    public interface IEditionsService
    {
        CourseEdition CreateCourseEdition(CourseEdition e);

        IEnumerable<CourseEdition> GetAllEditions();
        CourseEdition GetEditionById(long id);
        CourseEdition EditCourseEdition(CourseEdition e);
        void DeleteCourseEdition(long id);
        public IEnumerable<CourseEdition> GetEditionsByCourseId(long id);
        IEnumerable<CourseEdition> Search(EditionSearchInfo info);
    }
}

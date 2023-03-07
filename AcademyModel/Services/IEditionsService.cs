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
        Edition CreateCourseEdition(Edition e);

        IEnumerable<Edition> GetAllEditions();
        Edition GetEditionById(long id);
        Edition EditCourseEdition(Edition e);
        void DeleteCourseEdition(long id);
        public IEnumerable<Edition> GetEditionsByCourseId(long id);
        IEnumerable<Edition> Search(EditionSearchInfo info);
    }
}

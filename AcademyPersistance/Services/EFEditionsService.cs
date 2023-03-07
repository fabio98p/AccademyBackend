using AcademyEFPersistance.EFContext;
using AcademyEFPersistance.Repository;
using AcademyModel.BuisnessLogic;
using AcademyModel.Entities;
using AcademyModel.Exceptions;
using AcademyModel.Repositories;
using AcademyModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEFPersistance.Services
{
    public class EFEditionsService : IEditionsService
    {
        private IEditionRepository editionRepo;
        private ICourseRepository courseRepo;
        private IInstructorRepository instructorRepo;
        private AcademyContext ctx;
        public EFEditionsService(IEditionRepository editonRepo, ICourseRepository courseRepo, IInstructorRepository instructorRepo, AcademyContext ctx) {
            this.editionRepo = editonRepo;
            this.courseRepo = courseRepo;
            this.instructorRepo = instructorRepo;
            this.ctx = ctx;
        } 

        #region CourseEditions
        public IEnumerable<CourseEdition> GetAllEditions()
        {
            return editionRepo.GetAll();
        }
        public CourseEdition GetEditionById(long id)
        {
            return editionRepo.FindById(id);
        }
        public IEnumerable<CourseEdition> GetEditionsByCourseId(long id)
        {
            return editionRepo.GetEditionsByCourseId(id);
        }
        public CourseEdition CreateCourseEdition(CourseEdition e)
        {
            CheckCourse(e.CourseId);
            CheckInstructor(e.InstructorId);
            editionRepo.Create(e);
            ctx.SaveChanges();
            return e;
        }
        public CourseEdition EditCourseEdition(CourseEdition e)
        {
            CheckCourse(e.CourseId);
            CheckInstructor(e.InstructorId);
            //CheckCourseEdition(e.Id);
            editionRepo.Update(e);
            ctx.SaveChanges();
            return e;
        }
        public void DeleteCourseEdition(long id)
        {
            var edition = CheckCourseEdition(id);
            editionRepo.Delete(edition);
            ctx.SaveChanges();
        }
        public IEnumerable<CourseEdition> Search(EditionSearchInfo info)
        {
            if (info.Start != null || info.End != null)
            {
                if (info.InTheFuture != null || info.InThePast != null)
                {
                    throw new BuinsnessLogicException("I criteri di ricerca non possono comprende  allo stesso tempo date e richiesta su futuro e passato");
                }
            }

            if (info.Start != null && info.End != null)
            {
                if (info.Start > info.End)
                {
                    throw new BuinsnessLogicException("La data di inizio non può essere successiva a quella di fine");
                }
            }

            if (info.InTheFuture == true && info.InThePast == true)
            {
                throw new BuinsnessLogicException("Non è possibile richiedere edizioni sia nel passatro che nel futuro");
            }
            return editionRepo.Search(info).ToList();
        }
        #endregion

        private Course CheckCourse(long id)
        {
            var course = courseRepo.FindById(id);
            if (course == null)
            {
                throw new EntityNotFoundException("L'id del corso non corrisponde ad un corso esistente", nameof(Course));
            }
            return course;
        }
        private Instructor CheckInstructor(long id)
        {
            var instructor = instructorRepo.FindById(id);
            if (instructor == null)
            {
                throw new EntityNotFoundException("L'id dell'istruttore non corrisponde ad un istruttore esistente", nameof(Instructor));
            }
            return instructor;
        }
        private CourseEdition CheckCourseEdition(long id)
        {
            var courseEdition = editionRepo.FindById(id);
            if (courseEdition == null)
            {
                throw new EntityNotFoundException("L'id dell'edizione non corrisponde ad un edizione esistente", nameof(CourseEdition));
            }
            return courseEdition;
        }
    }
}

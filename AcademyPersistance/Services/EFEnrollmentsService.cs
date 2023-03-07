using AcademyEFPersistance.EFContext;
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
    public class EFEnrollmentsService : IEnrollmentsService
    {
        private IEnrollmentRepository enrollmentRepo;
        private IEditionRepository editionRepo;
        private IStudentRepository studentRepo;
        private AcademyContext ctx;

        public EFEnrollmentsService(IEnrollmentRepository enrollmentRepo, IEditionRepository editionRepo, IStudentRepository studentRepo, AcademyContext ctx)
        {
            this.enrollmentRepo = enrollmentRepo;
            this.editionRepo = editionRepo;
            this.studentRepo = studentRepo;
            this.ctx = ctx;
        }

        public Enrollment EnrollSudentToEdition(EnrollData data)
        {
            var student = studentRepo.FindById(data.IdStudent);
            if (student == null)
            {
                throw new EntityNotFoundException($"Lo studente con id {data.IdStudent} non esiste.", nameof(Student));
            }
            var edition = editionRepo.FindById(data.IdEdition);
            if (edition == null)
            {
                throw new EntityNotFoundException($"L'edizione con id {data.IdEdition} non esiste.", nameof(Edition));
            }
            var enr = new Enrollment()
            {
                CourseEditionId = edition.Id,
                StudentId = student.Id
            };
            ctx.Enrollments.Add(enr);
            ctx.SaveChanges();
            //ctx.Entry(enr).Reference(e => e.Student).Load();
            //ctx.Entry(enr).Reference(e => e.CourseEdition).Load();
            //ctx.Entry(enr.CourseEdition).Reference(e => e.Course).Load();
            return enr;
        }
        public Enrollment CreateEnrollment(Enrollment e)
        {
            enrollmentRepo.Create(e);
            ctx.SaveChanges();  //Salviamo qui invece che nella repository
            return e;
        }
        public void DeleteEnrollment(long id)
        {
            var enrollmment = enrollmentRepo.FindById(id);
            enrollmentRepo.Delete(enrollmment);
            ctx.SaveChanges();
        }
        public IEnumerable<Enrollment> GetSubscribedEnrollmentByStudentId(long id)
        {
            return enrollmentRepo.GetSubscribedEnrollmentByStudentId(id).ToList();
        }
    }
}

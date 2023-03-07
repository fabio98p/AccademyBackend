using AcademyModel.BuisnessLogic;
using AcademyModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Services
{
    public interface IEnrollmentsService
    {
        IEnumerable<Enrollment> GetSubscribedEnrollmentByStudentId(long id);
        Enrollment EnrollSudentToEdition(EnrollData data);
        Enrollment CreateEnrollment(Enrollment s);
        void DeleteEnrollment(long id);
    }
}

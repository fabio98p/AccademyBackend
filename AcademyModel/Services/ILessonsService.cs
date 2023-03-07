using AcademyModel.Entities;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Services
{
    public interface ILessonsService
    {
        IEnumerable<Lesson> FindLessonForEditionId(long id);
        IEnumerable<Lesson> FindLessonInRange(LocalDate start, LocalDate end);
    }
}

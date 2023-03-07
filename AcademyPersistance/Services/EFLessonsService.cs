using AcademyEFPersistance.EFContext;
using AcademyModel.Entities;
using AcademyModel.Repositories;
using AcademyModel.Services;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEFPersistance.Services
{
    public class EFLessonsService : ILessonsService
    {
        private ILessonRepository lessonRepo;
        private AcademyContext ctx;
        public EFLessonsService(ILessonRepository lessonRepo, AcademyContext ctx)
        {
            this.lessonRepo = lessonRepo;
            this.ctx = ctx;
        }

        public IEnumerable<Lesson> FindLessonForEditionId(long id)
        {
            return lessonRepo.FindLessonForEditionId(id);
        }

        public IEnumerable<Lesson> FindLessonInRange(LocalDate start, LocalDate end)
        {
            return lessonRepo.FindLessonInRange(start, end);
        }
    }
}

using AcademyModel.Entities;
using NodaTime;

namespace CodeAcademyWeb.DTOs
{
    public class LessonDTO
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public long CourseEditionId { get; set; }
        public long ClassroomId { get; set; }
        //public LocalDateTime Start { get; set; }
        //public LocalDateTime End { get; set; }
    }
}

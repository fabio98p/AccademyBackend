using AcademyModel.Entities;
using AutoMapper;
using CodeAcademyWeb.DTOs;

namespace CodeAcademyWeb.Profiles
{
    public class LessonProfile : Profile
    {
        public LessonProfile() {
            CreateMap<Lesson, LessonDTO>();
		    CreateMap<LessonDTO, Lesson>();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyModel.BuisnessLogic;
using AcademyModel.Entities;
using AcademyModel.Extensions;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using NodaTime;
using NodaTime.Text;

namespace CodeAcademyWeb.Profiles
{
	public class StudentProfile : Profile
	{
		public StudentProfile()
		{
			CreateMap<Student, StudentDTO>()
				.ForMember(dto => dto.DateOfBirth, opt => opt.MapFrom(student => student.DateOfBirth.ToLocalDateString()))
				.ForMember(dto => dto.Surname, opt => opt.MapFrom(student => student.Lastname));

			CreateMap<StudentDTO, Student>()
				.ForMember(student => student.DateOfBirth, opt => opt.MapFrom(dto => dto.DateOfBirth.Parse()))
				.ForMember(student => student.Lastname, opt =>opt.MapFrom(dto => dto.Surname));
			CreateMap<EnrollData, EnrollDataDTO>();
			CreateMap<EnrollDataDTO, EnrollData>();

			CreateMap<Enrollment, EnrollmentDTO>()
				.ForMember(dto => dto.CourseEditionStartDate, opt => opt.MapFrom(enrollment => enrollment.CourseEdition.StartDate.ToLocalDateString()));

			CreateMap<EnrollmentDTO, Enrollment>();
		}
	}
}

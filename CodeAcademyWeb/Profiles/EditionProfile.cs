using AcademyModel.Entities;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using NodaTime;
using NodaTime.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyModel.Extensions;

namespace CodeAcademyWeb.Profiles
{
	public class EditionProfile : Profile
	{
		public EditionProfile()
		{
			CreateMap<Edition, EditionDTO>();
			CreateMap<EditionDTO, Edition>();
			CreateMap<Edition, EditionDetailsDTO>()
				.ForMember(dto => dto.InstructorFullName, opt => opt.MapFrom(edition => $"{edition.Instructor.Firstname} {edition.Instructor.Lastname}"))
				.ForMember(dto => dto.StartDate, opt => opt.MapFrom(edition => edition.StartDate.ToString("yyyy-MM-dd", null)))
				.ForMember(dto => dto.FinalizationDate, opt => opt.MapFrom(edition => edition.FinalizationDate.ToString("yyyy-MM-dd", null)));
			CreateMap<EditionDetailsDTO, Edition>()
				.ForMember(edition => edition.StartDate, opt => opt.MapFrom(dto => dto.StartDate.Parse()))
				.ForMember(edition => edition.FinalizationDate, opt => opt.MapFrom(dto => dto.FinalizationDate.Parse()));
			
				
		}
	}
}

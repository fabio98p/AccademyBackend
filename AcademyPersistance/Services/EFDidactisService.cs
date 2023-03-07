﻿using AcademyEFPersistance.EFContext;
using AcademyModel.BuisnessLogic;
using AcademyModel.Entities;
using AcademyModel.Exceptions;
using AcademyModel.Repositories;
using AcademyModel.Services;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEFPersistence.Services
{
	public class EFDidactisService : IDidactisService
	{
		private IInstructorRepository instructorRepo;
		private ICourseRepository courseRepo;
		private IEditionRepository editionRepo;
		private ILessonRepository lessonRepo;
		private IAreaRepository areaRepo;

		private AcademyContext ctx;
		public EFDidactisService(ICourseRepository courseRepo,IEditionRepository editionRepo, IInstructorRepository instructorRepo,  IAreaRepository areaRepo, AcademyContext ctx)
		{
			this.courseRepo = courseRepo;
			this.editionRepo = editionRepo;
			this.instructorRepo = instructorRepo;
			this.areaRepo = areaRepo;
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

		#region Lesson
		public IEnumerable<Lesson> FindLessonForEditionId(long id)
		{
			return lessonRepo.FindLessonForEditionId(id);
		}

		public IEnumerable<Lesson> FindLessonInRange(LocalDate start, LocalDate end)
		{
			return lessonRepo.FindLessonInRange(start, end);
		}
		#endregion
		
		//public IEnumerable<Area> GetAllAreas()
		//{
		//	return areaRepo.GetAll().ToList();
		//}

		#region Helpers
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

		


		#endregion

	}
}

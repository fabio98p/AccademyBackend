using AcademyModel.BuisnessLogic;
using AcademyModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Repositories
{
	public interface IEditionRepository : ICrudRepository<Edition, long>
	{
		// corsi futuri | corisi passati | corsi in range tra a e b |
		// corsi futuri su id instructor | corisi passati su id instructor | corsi in range tra a e b su id instructor |
		// ricerca like su titolo e in range tra a e b
		public IEnumerable<Edition> GetEditionsByCourseId(long id);
		IEnumerable<Edition> Search(EditionSearchInfo info);
		IEnumerable<Edition> GetAvailableEnrollmentByStudentId(long id);
	}
}

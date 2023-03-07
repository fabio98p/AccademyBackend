using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyEFPersistance.EFContext;
using AcademyModel.Entities;
using AcademyModel.Repositories;
using AcademyModel.Services;


namespace AcademyEFPersistance.Services
{
    public class EFAreasService : IAreasService
    {
        private IAreaRepository areaRepo;
        private AcademyContext ctx;
        public EFAreasService(IAreaRepository areaRepo, AcademyContext ctx)
        {
            this.areaRepo = areaRepo;
            this.ctx = ctx;
        }
        public IEnumerable<Area> GetAllAreas()
        {
            return areaRepo.GetAll().ToList();
        }
    }
}

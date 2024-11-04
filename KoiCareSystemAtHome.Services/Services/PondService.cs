using KoiCareSystemAtHome.Repositories;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services.Services
{
    public class PondServices : IPondService
    {
        private readonly IPondReponsitoriy _reponsitory;
        public PondServices(IPondReponsitoriy _reponsitory)
        {
            _reponsitory =_reponsitory;
        }

        public Task<List<Pond>> Ponds()
        {
            return _reponsitory.GetAllPond();
        }
    }
}

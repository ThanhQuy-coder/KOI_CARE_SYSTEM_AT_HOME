using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services
{
  public class PondService : IPondService
  { 
        private readonly IPondRepository _repository;
        public PondService(IPondRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Pond>> ponds()
        {
            return _repository.GetAllPonds();
        }
    }
}

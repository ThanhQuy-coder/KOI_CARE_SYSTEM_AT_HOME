﻿
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
    public class PondService : IPondService
    {
        private readonly IPondRepository _repository;
        public PondService(IPondRepository repository)
        {
            _repository = repository;
        }
        public bool AddPond(Pond pond)
        {
            return _repository.AddPond(pond);
        }

        public bool DeletePond(Guid Id)
        {
            return _repository.DeletePond(Id);
        }

        public bool DeletePond(Pond pond)
        {
            return _repository.AddPond(pond);
        }

        public Task<List<Pond>> GetAllPond()
        {
            return _repository.GetAllPond();
        }

        public Task GetKoiFishById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Pond> GetPondById(Guid Id)
        {
            return _repository.GetPondById(Id);
        }

        public bool UpdatePond(Pond pond)
        {
            return _repository.UpdatePond(pond);
        }
        public async Task<Pond> InitializePond(Guid userId)
        {
            // Khởi tạo đối tượng KoiFish với PondId được truyền vào
            return await Task.FromResult(new Pond { UserId = userId });
        }
        // trả về hàm tìm kiếm ở repository
        public async Task<List<Pond>> SearchPondAsync(string searchTerm)
        {
            return await _repository.SearchPondAsync(searchTerm);

        }
    }
}

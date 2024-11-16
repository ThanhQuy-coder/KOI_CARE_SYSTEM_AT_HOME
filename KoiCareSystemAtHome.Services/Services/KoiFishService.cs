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
    public class KoiFishService : IKoiFishService
    {
        private readonly IKoiFishRepository _repository;
        public KoiFishService(IKoiFishRepository repository)
        {
            _repository = repository;
        }
        public bool AddKoiFish(KoiFish koiFish)
        {
            return _repository.AddKoiFish(koiFish);
        }

        public bool DeleteKoiFish(Guid Id)
        {
            return _repository.DeleteKoiFish(Id);
        }

        public bool DeleteKoiFish(KoiFish koiFish)
        {
            return _repository.DeleteKoiFish(koiFish);
        }

        public Task<List<KoiFish>> GetAllKoiFish()
        {
            return _repository.GetAllKoiFish();
        }

        public Task<KoiFish> GetKoiFishById(Guid Id)
        {
            return _repository.GetKoiFishById(Id);
        }

        public bool UpdateKoiFish(KoiFish koifish)
        {
            return _repository.UpdateKoiFish(koifish);
        }
        public async Task<KoiFish> InitializeKoiFish(Guid pondId)
        {
            // Khởi tạo đối tượng KoiFish với PondId được truyền vào
            return await Task.FromResult(new KoiFish { PondId = pondId });
        }
        // trả về hàm tìm kiếm ở repository
        public async Task<List<KoiFish>> SearchKoiFishAsync(string searchTerm)
        {
            return await _repository.SearchKoiFishAsync(searchTerm);

        }
    }
}

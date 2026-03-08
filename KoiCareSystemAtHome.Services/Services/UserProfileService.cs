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
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _repository;
        public UserProfileService(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddUser(UserProfile user)
        {
            return await _repository.AddUser(user);
        }

        public async Task<bool> DelUser(Guid Id)
        {
            return await _repository.DelUser(Id);
        }

        public bool DelUser(UserProfile user)
        {
            return _repository.DelUser(user);
        }

        public async Task<UserProfile?> GetUserById(Guid? Id)
        {
            return await _repository.GetUserById(Id);
        }

        public async Task<List<UserProfile>> GetAllUser()
        {
            return await _repository.GetAllUser();
        }

        public async Task<bool> UpdateUser(UserProfile user)
        {
            return await _repository.UpdateUser(user);
        }

        public async Task<(bool IsExisted, UserProfile? User)> CheckUser(Guid AccountId)
        {
            return await _repository.CheckUser(AccountId);
        }
    }
}

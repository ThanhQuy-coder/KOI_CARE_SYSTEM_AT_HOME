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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool AddUser(UserProfile user)
        {
            return _repository.AddUser(user);
        }

        public bool DelUser(Guid Id)
        {
            return _repository.DelUser(Id);
        }

        public bool DelUser(UserProfile user)
        {
            return _repository.DelUser(user);
        }

        public Task<UserProfile?> GetUserById(Guid? Id)
        {
            return _repository.GetUserById(Id);
        }

        public Task<List<UserProfile>> GetAllUser()
        {
            return _repository.GetAllUser();
        }

        public bool UpdateUser(UserProfile user)
        {
            return _repository.UpdateUser(user);
        }

        public bool CheckUser(Guid AccountId,ref Guid UserId)
        {
            return (_repository.CheckUser(AccountId, ref UserId));
        }
    }
}

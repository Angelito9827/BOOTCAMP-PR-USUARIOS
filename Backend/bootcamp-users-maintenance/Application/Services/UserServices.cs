using AutoMapper;
using bootcamp_framework.Application;
using bootcamp_framework.Application.Services;
using bootcamp_users_maintenance.Application.Dtos;
using bootcamp_users_maintenance.Domain.Entities;
using bootcamp_users_maintenance.Domain.Persistence;

namespace bootcamp_users_maintenance.Application.Services
{
    public class UserServices : GenericService<User, UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
        }

        public PagedList<UserDto> GetUsersByCriteriaPaged(string? filter, PaginationParameters paginationParameters)
        {
            var users = _userRepository.GetUsersByCriteriaPaged(filter, paginationParameters);
            return users;
        }
    }
}

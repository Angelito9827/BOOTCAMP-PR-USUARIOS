using AutoMapper;
using bootcamp_caso_practico_backend.Application.Dtos;
using bootcamp_caso_practico_backend.Application.Services;
using bootcamp_caso_practico_backend.Domain.Entities;
using bootcamp_caso_practico_backend.Domain.Persistence;
using bootcamp_framework.Application;
using bootcamp_framework.Application.Services;
using bootcamp_framework.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

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

        public override UserDto Update(UserDto userDto)
        {
            var user = _userRepository.GetById(userDto.Id);

            if (user == null)
            {
                throw new ElementNotFoundException();
            }

            if (userDto.RowVersion != user.RowVersion)
            {
                throw new ConcurrencyException("The user record has been modified by another admin.");
            }

            try
            {
                user.Name = userDto.Name;
                user.LastName = userDto.LastName;
                user.Email = userDto.Email;
                user.RoleId = userDto.RoleId;

                _userRepository.Update(user);
                return _mapper.Map<UserDto>(user);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("The user record has been modified by another admin.");
            }
        }
    }
}

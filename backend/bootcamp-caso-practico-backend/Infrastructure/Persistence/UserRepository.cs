using bootcamp_caso_practico_backend.Application.Dtos;
using bootcamp_caso_practico_backend.Domain.Entities;
using bootcamp_caso_practico_backend.Domain.Persistence;
using bootcamp_caso_practico_backend.Infrastructure.Persistence;
using bootcamp_framework.Application;
using bootcamp_framework.Domain.Persistence;
using bootcamp_framework.Infraestructure.Persistence;
using bootcamp_framework.Infraestructure.Specs;
using Microsoft.EntityFrameworkCore;

namespace bootcamp_users_maintenance.Infraestructure.Persistence
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private ListContext _userListContext;
        private readonly ISpecificationParser<User> _specificationParser;
        public UserRepository(ListContext context, ISpecificationParser<User> specificationParser) : base(context)
        {
            _userListContext = context;
            _specificationParser = specificationParser;
        }

        public override User GetById(long id)
        {
            var user = _userListContext.Users.Include(i => i.Role).SingleOrDefault(i => i.Id == id);

            if (user == null)
            {
                throw new ElementNotFoundException();
            }
            return user;
        }

        public override User Insert(User user)
        {
            _userListContext.Users.Add(user);
            _userListContext.SaveChanges();
            _userListContext.Entry(user).Reference(i => i.Role).Load();
            return user;
        }

        public override User Update(User user)
        {
            _userListContext.Users.Update(user);
            _userListContext.SaveChanges();
            _userListContext.Entry(user).Reference(i => i.Role).Load();
            return user;
        }

        public PagedList<UserDto> GetUsersByCriteriaPaged(string? filter, PaginationParameters paginationParameters)
        {
            var users = _userListContext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                Specification<User> specification = _specificationParser.ParseSpecification(filter);
                users = specification.ApplySpecification(users);
            }

            if (!string.IsNullOrEmpty(paginationParameters.Sort))
            {
                users = ApplySortOrder(users, paginationParameters.Sort);
            }

            var usersDto = users.Select(i => new UserDto
            {
                Id = i.Id,
                Name = i.Name,
                LastName = i.LastName,
                Email = i.Email,
                RoleId = i.RoleId,
                RoleName = i.Role.Name
            });

            return PagedList<UserDto>.ToPagedList(usersDto, paginationParameters.PageNumber, paginationParameters.PageSize);
        }
    }
}

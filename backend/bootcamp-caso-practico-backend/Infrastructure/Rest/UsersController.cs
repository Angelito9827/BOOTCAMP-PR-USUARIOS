using bootcamp_caso_practico_backend.Application.Dtos;
using bootcamp_caso_practico_backend.Application.Services;
using bootcamp_framework.Application;
using bootcamp_framework.Domain.Persistence;
using bootcamp_framework.Infraestructure.Rest;
using Microsoft.AspNetCore.Mvc;

namespace bootcamp_caso_practico_backend.Infraestructure.Rest
{

    [Route("/users")]
    [ApiController]
    public class UsersController : GenericCrudController<UserDto>
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        [NonAction]
        public override ActionResult<IEnumerable<UserDto>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Produces("application/json")]
        public ActionResult<PagedResponse<UserDto>> Get([FromQuery] string? filter, [FromQuery] PaginationParameters paginationParameters)
        {
            try
            {
                PagedList<UserDto> page = _userService.GetUsersByCriteriaPaged(filter, paginationParameters);
                var response = new PagedResponse<UserDto>
                {
                    CurrentPage = page.CurrentPage,
                    TotalPages = page.TotalPage,
                    PageSize = page.PageSize,
                    TotalCount = page.TotalCount,
                    Data = page
                };
                return Ok(response);
            }
            catch (MalformedFilterException)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public override ActionResult<UserDto> Update(UserDto userDto)
        {
            try
            {
                var updatedUser = _userService.Update(userDto);
                return Ok(updatedUser);
            }
            catch (ConcurrencyException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }
    }
}

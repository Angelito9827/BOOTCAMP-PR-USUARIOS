using bootcamp_framework.Application;
using bootcamp_framework.Infraestructure.Rest;
using bootcamp_users_maintenance.Application.Dtos;
using bootcamp_users_maintenance.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace bootcamp_users_maintenance.Infraestructure.Rest
{

    [Route("/userList")]
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
    }
}

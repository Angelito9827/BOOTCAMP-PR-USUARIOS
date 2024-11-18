using bootcamp_framework.Application.Dtos;

namespace bootcamp_caso_practico_backend.Application.Dtos
{
    public class RoleDto : IDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}

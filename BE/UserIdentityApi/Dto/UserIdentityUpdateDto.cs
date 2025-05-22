using System;
namespace UserIdentityApi.Dto
{
    public class UserIdentityUpdateDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}

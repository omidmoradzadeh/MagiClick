using MagiClick.Application.Dto;

namespace MagiClick.Application.ApplicationUser.Queries.GetToken
{
    public class LoginResponse
    {
        public ApplicationUserDto User { get; set; }

        public string Token { get; set; }
    }
}

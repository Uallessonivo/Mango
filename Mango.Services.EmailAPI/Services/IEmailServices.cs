using Mango.Services.EmailAPI.Models.Dtos;

namespace Mango.Services.EmailAPI.Services
{
    public interface IEmailServices
    {
        Task EmailCartAndLog(CartDto cartDto);
        Task RegisterUserEmailAndLog(string email);
    }
}

using DTO;
using System;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterUserAsync(UserRegisterModel model);
    }
}

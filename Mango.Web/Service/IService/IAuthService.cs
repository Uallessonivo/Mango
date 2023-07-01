﻿using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterASync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
    }
}

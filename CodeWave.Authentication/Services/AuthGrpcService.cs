using CodeWave.Authentication.Domain.Entities;
using CodeWave.Authentication.Domain.Interfaces;
using CodeWave.Authentication.Protos;
using Grpc.Core;

namespace CodeWave.Authentication.Services
{
    public class AuthGrpcService : AuthServiceProto.AuthServiceProtoBase
    {
        private readonly IAuthService _authService;

        public AuthGrpcService(IAuthService authService)
        {
            _authService = authService;

        }

        public override async Task<LoginResponse> Login(LoginRequest request, ServerCallContext context)
        {
            var res = await _authService.LoginAsync(request.Email, request.Password);
            return new LoginResponse
            {
                Token = res.Token,
                Message = res.DisplayMessage,
                Success = res.IsSuccess
            };
        }

        public override async Task<RegisterResponse> Register(RegisterRequest registerRequest, ServerCallContext context)
        {
            IdentityUser user = new IdentityUser
            {
                Email = registerRequest.Email,
                Username = registerRequest.Username
            };
            var result = await _authService.RegisterAsync(user, registerRequest.Password);
            return new RegisterResponse
            {
                Token = result.Token,
                Message = result.DisplayMessage,
                Success = result.IsSuccess
            };
        }
    }
    
}

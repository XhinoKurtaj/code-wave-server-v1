using CodeWave.Authentication.Application.Utils;
using CodeWave.Authentication.Domain.Dto;
using CodeWave.Authentication.Domain.Entities;
using CodeWave.Authentication.Domain.Interfaces;

namespace CodeWave.Authentication.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUnitOfWork unitOfWork, IIdentityUserRepository identityUserRepository, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _identityUserRepository = identityUserRepository;
            _tokenService = tokenService;
        }

        public async Task<ResponseDto> LoginAsync(string email, string password)
        {
            var user = await _identityUserRepository.FindOneAsync(x => x.Email == email);

            if (user == null)
                return CreateErrorResponse("User Not Found", "Not Found");

            if (!PasswordHash.VerifyPassword(password, user.Password, user.PasswordSalt))
                return CreateErrorResponse("Invalid credentials", "Invalid credentials");

            var jwtToken = _tokenService.GenerateToken(user);


            return new ResponseDto
            {
                IsSuccess = true,
                Token = jwtToken,
                DisplayMessage = string.Empty
            };
        }

        public async Task<ResponseDto> RegisterAsync(IdentityUser user, string password)
        {
            var existingUser = await _identityUserRepository.FindOneAsync(x => x.Email == user.Email);

            if (existingUser != null)
                return CreateErrorResponse($"Email {user.Email} is already taken", "User Exists");


            byte[] passwordHash, passwordSalt;

            PasswordHash.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.Password = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _unitOfWork.IdentityUserRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            var jwtToken = _tokenService.GenerateToken(user);

            return new ResponseDto
            {
                IsSuccess = true,
                Token = jwtToken,
                DisplayMessage = string.Empty
            };
        }

        private ResponseDto CreateErrorResponse(string displayMessage, string errorMessage)
        {
            return new ResponseDto
            {
                IsSuccess = false,
                DisplayMessage = displayMessage,
                ErrorMessages = new List<string> { errorMessage }
            };
        }
    }
}

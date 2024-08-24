namespace CodeWave.Authentication.Domain.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public string Token { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string>? ErrorMessages { get; set; }
    }
}

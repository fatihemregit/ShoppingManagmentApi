namespace Entity.IAuthService
{
	public class IAuthServiceLoginResponse
	{
		public string AccessToken { get; set; }
		public DateTime AcessTokenExpiration { get; set; }
		public string RefreshToken { get; set; }
		public DateTime RefreshTokenExpiration { get; set; }
	}
}
namespace Entity.IAuthService
{
	public class IAuthServiceNewAccessTokenResponse
	{
		public string AccessToken { get; set; }
		public DateTime AcessTokenExpiration { get; set; }
	}
}
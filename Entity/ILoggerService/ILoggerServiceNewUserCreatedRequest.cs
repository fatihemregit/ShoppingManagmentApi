namespace Entity.ILoggerService
{
	public class ILoggerServiceNewUserCreatedRequest
	{
		public string UserName { get; set; }

		public string Email { get; set; }

		public string RefreshToken { get; set; }

		public DateTime? RefreshTokenEndDate { get; set; }
        public string AccessToken { get; set; }

		public string AccessTokenEndDate { get; set; }

    }

	public class myClass
	{
        public string Name { get; set; }

        public int Age { get; set; }
    }

}
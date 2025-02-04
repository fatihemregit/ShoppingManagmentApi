using Microsoft.AspNetCore.Identity;

namespace Entity.ILoggerService
{
	public class ILoggerServiceNewUserNotCreatedRequest
	{
		public string UserName { get; set; }

		public string Email { get; set; }

        public IEnumerable<IdentityError> errors { get; set; }
    }
}
using ShoppingManagment.Utils.AutoMapper;

namespace ShoppingManagment.Utils.Extensions
{
	public static class MainExtensions
	{
		public static void setAutoMapperForMainLayer(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MappingProfileForMainLayer));
		}

	}
}

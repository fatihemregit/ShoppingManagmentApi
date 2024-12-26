using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstracts
{
	// bu işi daha sonra yap
	public interface IRepository<T> where T : class
	{
		List<T> GetAll();

	}
}

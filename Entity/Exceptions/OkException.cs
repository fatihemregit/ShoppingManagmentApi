using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
	public class OkException<T> : Exception where T : class
	{
        public T Item { get; set; }
		public OkException(string? message, T item) : base(message)
		{
			Item = item;
		}
	}
}

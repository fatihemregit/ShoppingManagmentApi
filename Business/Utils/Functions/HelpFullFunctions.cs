using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utils.Functions
{
	public static class HelpFullFunctions
	{
		public static bool nullCheckObjectProps(object item, bool nuls = true)
		{
			//eğer null veri var sa true,yoksa false

			if (item is IEnumerable)
			{
				//obje bir liste
				foreach (object i in (IEnumerable)item)
				{
					//obje bir primitive liste(List<string>) olduğu için direkt setNullState fonksiyonuna gidiyor
					if (setNullState(i))
					{
						return true;
					}
				}
				return false;
			}

			Console.WriteLine("else blooğuna girildi");
			Type type = item.GetType();
			IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
			foreach (PropertyInfo prop in props)
			{
				object? propValue;
				if (nuls)
				{
					propValue = prop.GetValue(item, null);

				}
				else
				{
					propValue = prop.GetValue(item);
				}
				Console.WriteLine($"prop value is : {propValue}");
				bool nullState = setNullState(propValue);
				if (nullState)
				{
					return true;
				}

			}

			return false;
		}

		private static bool setNullState(object? propValue)
		{
			bool result = false;

			//switch case yazabiliriz

			//String veride null check
			if (propValue is string)
			{
				result = ((string)propValue).IsNullOrEmpty();
			}
			//int veride null check
			else if (propValue is int)
			{
				result = (((int)propValue) == 0);
			}
			//decimal veride null check
			else if (propValue is decimal)
			{
				result = (((decimal)propValue) == 0);
			}
			return result;
		}


	}
}

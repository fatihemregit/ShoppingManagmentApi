using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utils.Functions
{
	public static class HelpFullFunctions
	{
		public static bool nullCheckObjectProps(object item)
		{
			//eğer null veri var sa true,yoksa false
			Type type = item.GetType();
			IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
            foreach (PropertyInfo prop in props)
            {
				object? propValue =  prop.GetValue(item,null);
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

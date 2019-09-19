using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CMPS_285
{
	public static class RegexUtil
	{
		public static Regex ValidateEmailAddress()
		{
			return new Regex(@"[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
		}

		public static Regex ValidatePhoneNumber()
		{
			return new Regex(@"^\d{10}$");
		}
	}
}

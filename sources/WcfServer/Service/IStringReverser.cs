using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WcfServer.Service
{
	[ServiceContract]
	public interface IStringReverser
	{
		[OperationContract]
		string ReverseString(string value);
	}

	public class StringReverser : IStringReverser
	{
		public string ReverseString(string value)
		{
			var result = new String(value.ToArray().Reverse().ToArray());

			Console.WriteLine(String.Format("Processing {0}: {1}", value, result));
			return new String(value.ToArray().Reverse().ToArray());
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using WcfServer.Service;

namespace WcfClient
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("WCF Client...");

			ChannelFactory<IStringReverser> pipeFactory = new ChannelFactory<IStringReverser>(new NetNamedPipeBinding(), 
				new EndpointAddress("net.pipe://localhost/PipeReverse"));

			IStringReverser pipeProxy = pipeFactory.CreateChannel();

			Console.WriteLine("pipe: " + pipeProxy.ReverseString("ASD 1"));
			Console.WriteLine("pipe: " + pipeProxy.ReverseString("ASD 2"));

			while (true)
			{
				var str = Console.ReadLine();
				pipeProxy.ReverseString(str);
			}
		}
	}
}

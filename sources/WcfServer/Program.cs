using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using WcfServer.Service;

namespace WcfServer
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("WCF Server...");

			#region RESTfull
			//CustomBinding binding = new CustomBinding();
			//TextMessageEncodingBindingElement msgEncoder = new TextMessageEncodingBindingElement();
			//msgEncoder.MessageVersion = MessageVersion.None;
			//binding.Elements.Add(msgEncoder);

			//HttpTransportBindingElement http = new HttpTransportBindingElement();
			//binding.Elements.Add(http);

			//ServiceHost host = new ServiceHost(typeof(SimpleServiceContract));
			//ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(SimpleServiceContract), binding, @"http://localhost:8889/TestPoint");

			//host.Open();
			#endregion

			using (ServiceHost host = new ServiceHost(typeof(StringReverser), new Uri("net.pipe://localhost")))
			{
				host.AddServiceEndpoint(typeof(IStringReverser), new NetNamedPipeBinding(), "PipeReverse");
				host.Open();

				Console.WriteLine("Service started...");


				Console.ReadLine();
				host.Close();
			}
		}
	}

	[ServiceContract]
	public class SimpleServiceContract
	{
		[OperationContract(Action = "*", ReplyAction = "*")]
		string Act(string parameter)
		{
			string result = parameter + " ... processed";
			Console.WriteLine(result);
			return result;
		}
	}
}

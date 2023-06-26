namespace ZsutPw.Sdn.ControlSvc
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Summary description for Class1
	/// </summary>
	public class OnosFakeNetwork
	{
		private List<Switch> switches = new List<Switch>();
		private List<Link> links = new List<Link>();
		private List<OnosHost> hosts = new List<OnosHost>();
		private OnosCommunicationInterface request_provider = new OnosCommunicationInterface();

		public OnosFakeNetwork()
		{

		}
	}
}
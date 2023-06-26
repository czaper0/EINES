namespace ZsutPw.Sdn.ControlSvc
{ 
using System;
	using System.Threading.Tasks;
	/// <summary>
	/// Summary description for Class1
	/// </summary>
	public interface IOnosRequestProvider
	{
		public Task<int> AddSwitchRequest(string name);
		public Task<int> AddHostRequest(string name);
		public Task<int> AddLinkRequest(string name, string device_one, string device_two);
	}

}

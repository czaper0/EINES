namespace ZsutPw.Sdn.ControlSvc
{
	using System;
	using System.Threading.Tasks;
	/// <summary>
	/// Summary description for Class1
	/// </summary>
	public class OnosCommunicationInterface : IOnosRequestProvider
	{
		public OnosCommunicationInterface()
		{
			
		}

        public Task<int> AddSwitchRequest(string name)
		{
			//not implemented yet
			int fake_result = -1;
			return Task.FromResult(fake_result);
		}

        public Task<int> AddHostRequest(string name) 
		{
            //not implemented yet
            int fake_result = -1;
            return Task.FromResult(fake_result);
        }

        public Task<int> AddLinkRequest(string name, string device_one, string device_two)
		{
            //not implemented yet
            int fake_result = -1;
            return Task.FromResult(fake_result);
        }
    }
}

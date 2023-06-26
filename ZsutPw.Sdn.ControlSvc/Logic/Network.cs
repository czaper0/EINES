//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace ZsutPw.Sdn.ControlSvc
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Net.Http;
  using System.Threading.Tasks;

  using ZsutPw.Utilities;

  public class Network : INetwork
  {
    private static object lockNetwork = new object();

    private const string onosRestApiHost = "mininet";
    private const int onosRestApiPort = 8181;

    private const string onosUser = "onos";
    private const string onosPassword = "rocks";

    #region INetwork

    public Switch[ ] GetSwitches( string id )
    {
      const string webCallUrlFormat = "onos/v1/devices";

      ServiceClient serviceClient = new ServiceClient( ServiceProtocol.Http, onosRestApiHost, onosRestApiPort ) { User = onosUser, Password = onosPassword };

      string webCallUrl = String.Format( webCallUrlFormat );

      OnosDevices onosDevices = serviceClient.CallWebService<OnosDevices>( HttpMethod.Get, webCallUrl );

      const string onosSwitchType = "SWITCH";

      Switch[ ] switches = onosDevices.Devices.Where( device => device.Type == onosSwitchType ).Select( device => new Switch( device.Id ) ).ToArray( );

      return switches;
    }

    #endregion
  }
}

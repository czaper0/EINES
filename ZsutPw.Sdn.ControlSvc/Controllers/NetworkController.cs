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
  using System.Threading.Tasks;

  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Logging;

  [ApiController]
  [Route( "[controller]" )]
  public class NetworkController : ControllerBase, INetwork
  {
    private readonly ILogger<NetworkController> logger;
    private readonly INetwork network;

    public NetworkController( ILogger<NetworkController> logger, INetwork network )
    {
      this.logger = logger;
      this.network = network;
    }

    #region INetwork

    [HttpGet]
    [Route( "GetSwitches" )]
    public Switch[ ] GetSwitches( string id )
    {
      return this.network.GetSwitches( id );
    }

    #endregion
  }
}

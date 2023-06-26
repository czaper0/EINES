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

  public class FakeNetwork : INetwork
  {
    private static readonly Switch[ ] switches = new Switch[ ] { new Switch( "s1" ), new Switch( "s2" ) };

    private static object lockNetwork = new object();

    #region INetwork

    public Switch[ ] GetSwitches( string id )
    {
      lock( FakeNetwork.lockNetwork )
      {
        return FakeNetwork.switches.Where( s => s.Id.Contains( id ) ).ToArray( );
      }
    }

    #endregion
  }
}

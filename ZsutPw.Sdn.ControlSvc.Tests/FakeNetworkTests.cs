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

namespace ZsutPw.Sdn.ControlSvc.Tests
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  using ZsutPw.Sdn.ControlSvc;

  [TestClass]
  public class FakeNetworkTests
  {
    [TestMethod]
    public void GetSwitches_FilterBySwitchIdPrefix_All2SwitchesAreReturned( )
    {
      INetwork network = new FakeNetwork( );

      const string id = "s";

      const int expectedCount = 1;

      int count = network.GetSwitches( id ).Length;

      Assert.AreEqual( expectedCount, count, "The number of switches should be {0} and not {1}", expectedCount, count );
    }
  }
}

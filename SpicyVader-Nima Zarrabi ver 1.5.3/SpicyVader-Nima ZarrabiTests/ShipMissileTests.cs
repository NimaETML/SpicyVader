using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpicyVader_Nima_Zarrabi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyVader_Nima_Zarrabi.Tests
{
    [TestClass()]
    public class ShipMissileTests
    {

        [TestMethod()]
        public void ShipMissileSpawnTest()
        {
            ShipMissile shipmissile = new ShipMissile(0,0);
            shipmissile.ShipMissileSpawn();
            double shipMissileSpawnX = 0;
            foreach (char _ in Ship.SHIPSKIN1)
            {
                shipMissileSpawnX++;
            }
            shipMissileSpawnX = Convert.ToInt32(Math.Round(shipMissileSpawnX/2));
            shipMissileSpawnX = (shipMissileSpawnX + GameEngine.ship.ShipX);
            Assert.AreEqual(shipMissileSpawnX, shipmissile.ShipMissileX);
        }
    }
}
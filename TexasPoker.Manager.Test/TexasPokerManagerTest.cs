﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orleans;
using System.Threading.Tasks;
using TexasPoker.GrainInterface;

namespace TexasPoker.Manager.Test
{
    [TestClass]
    public class TexasPokerManagerTest
    {
        [TestMethod]
        public async Task TestPumpingRate()
        {
            GrainClient.Initialize();

            string id = "TaxasPokerManager";
            var grain = GrainClient.GrainFactory.GetGrain<ITexasPokerManager>(id);

            float expectedRate = 50.0f;
            float setResult = await grain.SetPumpingRate(expectedRate);
            Assert.AreEqual(expectedRate, setResult);

            float getResult = await grain.GetPumpingRate();
            Assert.AreEqual(expectedRate, getResult);

            int desktopId = 1;
            int expectedSeatFee = 100;
            var setResult1 = await grain.SetSeatFee(desktopId, expectedSeatFee);
            Assert.AreEqual(expectedSeatFee, setResult1[desktopId]);

            var getResult1 = await grain.GetSeatFee();
            Assert.AreEqual(expectedSeatFee, getResult1[desktopId]);
        }
    }
}

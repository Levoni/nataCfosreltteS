using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nataC_fo_sreltteS;

namespace ServerTestProject
{
    [TestClass]
    public class ClientPlayerTest
    {
        [TestMethod]
        public void TestPlayerName()
        {
            Player player = new Player();
            string nameTest = "Ma dude";
            player.name = nameTest;
            Assert.AreEqual(player.name, nameTest);
        }

        [TestMethod]
        public void TestPlayerVP()
        {
            Player player = new Player();
            int vp = 5;
            player.vp = vp;
            Assert.AreEqual(player.vp, vp);
        }

        [TestMethod]
        public void TestSetResources()
        {
            Player player = new Player();
            player.SetResources(1, 2, 3, 4);
            Assert.AreEqual(player.food, 1);
            Assert.AreEqual(player.stone, 2);
            Assert.AreEqual(player.wood, 3);
            Assert.AreEqual(player.animal, 4);
        }

        [TestMethod]
        public void TestBuyTerritory()
        {
            Player player = new Player();
            player.SetResources(1, 2, 3, 4);
            player.BuyTerritory();

            Assert.AreEqual(player.stone, 1);
            Assert.AreEqual(player.wood, 2);
        }

        [TestMethod]
        public void TestBuyCity()
        {
            Player player = new Player();
            player.SetResources(1, 2, 3, 4);
            player.BuyCity();

            Assert.AreEqual(player.stone, 1);
            Assert.AreEqual(player.wood, 2);
            Assert.AreEqual(player.food, 0);
            Assert.AreEqual(player.animal, 3);
        }

        [TestMethod]
        public void TestTotalResources()
        {
            Player player = new Player();
            player.SetResources(1, 2, 3, 4);

            Assert.AreEqual(player.GetTotalResources(), 10);

        }

        [TestMethod]
        public void BuyDevCardClientTest()
        {
            Player player = new Player();
            player.SetResources(1, 2, 3, 4);

            player.BuyDevCard("MONOPOLY");

            Assert.AreEqual(player.GetTotalDevCards(), 1);
        }
    }
}

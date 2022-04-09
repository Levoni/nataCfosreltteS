using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nataC_fo_sreltteS;

namespace ClientUnitTestProject
{
   [TestClass]
   public class PlayerRequestTest
   {
      [TestMethod]
      public void PlayerRequestSelectionErrorTest()
      {
         int numOfPlayers = 4;
         int currPlayer = 1;
         PlayerRequest testForm = new PlayerRequest(numOfPlayers, currPlayer);
         string errorMsg = "Pick a player";

         testForm.PressOK();
         Assert.IsTrue(errorMsg.Equals(testForm.CheckError()));
         testForm.Close();
      }

      [TestMethod]
      public void PlayerRequestGetPlayerTest()
      {
         int numOfPlayers = 4;
         int currPlayer = 1;
         int playerSelect = 2;
         PlayerRequest testForm = new PlayerRequest(numOfPlayers, currPlayer);

         testForm.SelectRadioBtn(playerSelect);
         int testPlayer = testForm.playerNum;

         Assert.AreEqual(testPlayer, playerSelect);
         testForm.Close();
      }
   }
}

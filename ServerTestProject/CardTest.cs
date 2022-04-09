using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nataC_Server;

namespace ServerTestProject
{
   [TestClass]
   public class CardTest
   {
      [TestMethod]
      public void TestCardTypeProperty()
      {
         Assert.AreEqual(Card.Type.KNIGHT, new Card(Card.Type.KNIGHT).CardType);
      }
   }
}

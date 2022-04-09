using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nataC_Server;

namespace ServerTestProject
{
   [TestClass]
   public class DeckTest
   {
      [TestMethod]
      public void TestDeckSize()
      {
         Deck deckTest1 = new Deck();
         int deckSize = 25;
         Assert.AreEqual(deckSize, deckTest1.GetCurrentDeckSize());
      }

      [TestMethod]
      public void TestDeckShuffle()
      {
         Deck deckTest1 = new Deck();
         System.Threading.Thread.Sleep(500);
         Deck deckTest2 = new Deck();

         Assert.IsFalse(Deck.Equals(deckTest1, deckTest2));
      }

      [TestMethod]
      public void TestGetTopCard()
      {
         Deck deckTest = new Deck();
         int initialSize; 
         int postSize;

         initialSize = deckTest.GetCurrentDeckSize();
         Card tempCard = deckTest.GetTopCard();
         postSize = deckTest.GetCurrentDeckSize();


         Assert.AreNotEqual(initialSize, postSize);
      }
   }
}

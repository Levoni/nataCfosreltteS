using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nataC_Server;

namespace ServerTestProject
{
   [TestClass]
   public class PlayerTest
   {
      [TestMethod]
      public void StealRandomResourceTest()
      {
         Players p = new Players("dude", 4);
         string resource = p.StealRandomResource();

         string[] resourceList = resource.Split(',');
         int numResources = resourceList.Length - 1;
         bool isResource = false;

         for (int i = 0; i < numResources; i++)
         {
            switch (resourceList[i])
            {
               case "ANIMAL":
                  isResource = true;
                  break;
               case "FOOD":
                  isResource = true;
                  break;
               case "STONE":
                  isResource = true;
                  break;
               case "WOOD":
                  isResource = true;
                  break;
            }
            Assert.IsTrue(isResource);
         }

      }

      [TestMethod]
      public void StealResourceTest()
      {
         int numResources = 4;
         Players p = new Players("dude", numResources);
         int stolen = p.StealResource("ANIMAL");

         Assert.AreEqual(numResources, stolen);
         Assert.AreEqual(p.animal, 0);
      }
   }
}

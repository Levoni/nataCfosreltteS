using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nataC_Server;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ServerTestProject
{
   [TestClass]
   public class GenerationTests
   {
      [TestMethod]
      public void GenerateMap_RandomTileTypes_TilesAreDifferent()
      {
         frmServer fm = new frmServer();
         string[] mapOne = fm.GenerateMapTest().Split(';');
         string[] mapTwo = fm.GenerateMapTest().Split(';');
         Assert.AreNotEqual(mapOne[0], mapTwo[0]);
     }

      [TestMethod]
      public void GenerateMap_NumberPattern_CorrectPattern()
      {
         frmServer fm = new frmServer();
         int[] randNums = { 3, 8, 10, 9, 12, 11, 4, 8, 5, 2, 6, 9, 4, 5, 6, 3, 10, 11 };
         string mapOne = fm.GenerateMapTest().Split(';')[1];
         string[] nums = mapOne.Split(',');
         int index = 0;
         bool isSame = true;
         for(int i = 0; i < nums.Length - 1; i++)
         {
            if(nums[i] != "0")
            {
               if(int.Parse(nums[i]) != randNums[index % randNums.Length])
               {
                  isSame = false;
               }
               index++;
            }
         }
         Assert.IsTrue(isSame);
      }
   }
}
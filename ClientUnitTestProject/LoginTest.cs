using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nataC_fo_sreltteS;

namespace ClientUnitTestProject
{
   [TestClass]
   public class LoginTest
   {
      [TestMethod]
      public void TestNameLoginBug()
      {
         Login login = new Login();
         login.PressEnterGame();
         string errMsg = "Please enter a name";
         Assert.IsTrue(login.GetErrorMsg().Equals(errMsg));
         login.Close();

      }
   }
}

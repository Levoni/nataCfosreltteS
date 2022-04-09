using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nataC_fo_sreltteS;

namespace ClientUnitTestProject
{
   [TestClass]
   public class ResourceRequestTest
   {
      [TestMethod]
      public void ResourceRequestSelectionErrorTest()
      {
         ResourceRequest testForm = new ResourceRequest();
         string errorMsg = "Pick a resource";

         testForm.PressOK();
         Assert.IsTrue(errorMsg.Equals(testForm.CheckError()));
         testForm.Close();
      }

      [TestMethod]
      public void ResourceRequestGetResourceTest()
      {
         ResourceRequest testForm = new ResourceRequest();
         string resource = "ANIMAL";

         testForm.SelectRadioBtn(resource);
         string cmpResource = testForm.resource;
         Assert.IsTrue(resource.Equals(cmpResource));
         testForm.Close();
      }

      [TestMethod]
      public void ResourceRequestSetMonopolyTest()
      {
         ResourceRequest testForm = new ResourceRequest(true);
         string title = "Monopoly";

         Assert.IsTrue(title.Equals(testForm.Text));
         testForm.Close();
      }
   }
}

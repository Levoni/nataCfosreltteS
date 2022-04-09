using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nataC_fo_sreltteS
{
   /// <summary>
   /// Form used to get user selection of resource for Year of Plenty
   /// </summary>
   public partial class ResourceRequest : Form
   {
      public string resource { get; set; }

      public ResourceRequest(bool isMonopoly = false)
      {
         InitializeComponent();
         resource = "";
         rdoAnimal.Checked = false;

         if(isMonopoly)
         {
            this.Text = "Monopoly";
            pictureBox1.Image = nataC_fo_sreltteS.Properties.Resources.MonopolyCard;

         }
      }

      private void rdoAnimal_Click(object sender, EventArgs e)
      {
         resource = "ANIMAL";
         erpYoP.Clear();
      }

      private void rdoFood_Click(object sender, EventArgs e)
      {
         resource = "FOOD";
         erpYoP.Clear();
      }

      private void rdoStone_Click(object sender, EventArgs e)
      {
         resource = "STONE";
         erpYoP.Clear();
      }

      private void rdoWood_Click(object sender, EventArgs e)
      {
         resource = "WOOD";
         erpYoP.Clear();
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         if (!resource.Equals(""))
         {
            DialogResult = DialogResult.OK;
         }
         else
            erpYoP.SetError(btnOK, "Pick a resource");
      }

      /// <summary>
      /// Used to test clicking OK button
      /// </summary>
      public void PressOK()
      {
         btnOK_Click(null, EventArgs.Empty);
      }

      /// <summary>
      /// Used to test clicking a radio button
      /// </summary>
      public void SelectRadioBtn(string resource)
      {
         switch(resource)
         {
            case "ANIMAL":
               rdoAnimal_Click(null, EventArgs.Empty);
               break;
            case "WOOD":
               rdoWood_Click(null, EventArgs.Empty);
               break;
            case "STONE":
               rdoStone_Click(null, EventArgs.Empty);
               break;
            case "FOOD":
               rdoFood_Click(null, EventArgs.Empty);
               break;
         }

         btnOK_Click(null, EventArgs.Empty);
      }

      /// <summary>
      /// Used to get current error
      /// Used for testing
      /// </summary>
      /// <returns>Error message</returns>
      public string CheckError()
      {
         return erpYoP.GetError(btnOK);
      }
   }
}

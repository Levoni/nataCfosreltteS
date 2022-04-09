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
   public partial class PlayerRequest : Form
   {
      private const int PLAYER_COUNT4 = 4;
      private const int PLAYER_COUNT3 = 3;
      private const int PLAYER_COUNT2 = 2;
      private const int PLAYER_COUNT1 = 1;

      public int playerNum { get; set; }

      public PlayerRequest(int totalPlayerCount, int currPlayerNum)
      {
         InitializeComponent();

         if (totalPlayerCount < PLAYER_COUNT4 || currPlayerNum == PLAYER_COUNT4)
            rdoP4.Visible = false;
         if (totalPlayerCount < PLAYER_COUNT3 || currPlayerNum == PLAYER_COUNT3)
            rdoP3.Visible = false;
         if (totalPlayerCount < PLAYER_COUNT2 || currPlayerNum == PLAYER_COUNT2)
            rdoP2.Visible = false;
         if (totalPlayerCount < PLAYER_COUNT1 || currPlayerNum == PLAYER_COUNT1)
            rdoP1.Visible = false;

         

         playerNum = -1;
      }

      private void rdoP1_Click(object sender, EventArgs e)
      {
         playerNum = 1;
         erpPlayer.Clear();
      }

      private void rdoP2_Click(object sender, EventArgs e)
      {
         playerNum = 2;
         erpPlayer.Clear();
      }

      private void rdoP3_Click(object sender, EventArgs e)
      {
         playerNum = 3;
         erpPlayer.Clear();
      }

      private void rdoP4_Click(object sender, EventArgs e)
      {
         playerNum = 4;
         erpPlayer.Clear();
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         if (playerNum > 0)
         {
            DialogResult = DialogResult.OK;
         }
         else
            erpPlayer.SetError(btnOK, "Pick a player");
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
      public void SelectRadioBtn(int playerNum)
      {
         switch (playerNum)
         {
            case 1:
               rdoP1_Click(null, EventArgs.Empty);
               break;
            case 2:
               rdoP2_Click(null, EventArgs.Empty);
               break;
            case 3:
               rdoP3_Click(null, EventArgs.Empty);
               break;
            case 4:
               rdoP4_Click(null, EventArgs.Empty);
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
         return erpPlayer.GetError(btnOK);
      }
   }
}

//--------------------------------------------------------------------
// Territory.cs is a user control class that 
//--------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nataC_fo_sreltteS
{
   public partial class Territory : UserControl
   {
      public static bool beginning = true;
      public static bool isTurn = false;
      public static int clientPlayer;
      public bool infoChanged = false;
      public bool cityChanged = false;
      public bool terChanged = false;
      public bool cityNextTo = false;
      public bool freeTerritoryFlag = false;

      public static int setUp = 0;
      EventHandler Input;
      EventHandler Check;
      public int xPos, yPos;
      public bool canBuild { get; set; }

      public int rollID { get; set; }
      public bool hascity { get; set; }
      public Territory(int rID, int x, int y, EventHandler input, EventHandler check)
      {
         InitializeComponent();
         rollID = rID;
         Input = input;
         Check = check;
         xPos = x;
         yPos = y;
      }



      private void MapImage_Click(object sender, EventArgs e) { }

      public void setClientPlayer(string playNum)
      {
         clientPlayer = int.Parse(playNum);
      }
      private void pictureBox1_Click(object sender, EventArgs e)
      {
         if (isTurn)
         {
            Check.Invoke(sender, e);
            if (setUp < 2)
            {
               if (BackColor == System.Drawing.Color.Black)
               {
                  MessageBox.Show(clientPlayer.ToString());
                  hascity = true;
                  ChangeBackgroundColor(clientPlayer);
                  SetCity(hascity);
                  infoChanged = true;
                  setUp++;
                  Input.Invoke(sender, e);
                  Territory.isTurn = false;
               }
            }
            else
            {
               if (canBuild)
               {
                  if (freeTerritoryFlag)
                  {
                     if (BackColor == System.Drawing.Color.Black && Client.purchaseTerr == true)
                     {
                        ChangeBackgroundColor(clientPlayer);
                        infoChanged = true;
                        terChanged = true;
                        Input.Invoke(sender, e);
                     }     
                  }
                  else if (CheckBackGroundColor() == clientPlayer && !hascity && Client.purchaseCity == true && !cityNextTo)
                  {
                     DialogResult dr = MessageBox.Show("Would you like to purchase a settlement? \n It will cost you 1 of each resource.",
                        "Settlement Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     if (dr == DialogResult.Yes)
                     {
                        MessageBox.Show(clientPlayer.ToString());
                        hascity = true;
                        SetCity(hascity);
                        infoChanged = true;
                        cityChanged = true;
                        Input.Invoke(sender, e);
                        //ToDo subtract
                     }
                  }
                  else if (BackColor == System.Drawing.Color.Black && Client.purchaseTerr == true)
                  {
                     DialogResult dr = MessageBox.Show("Would you like to purchase this territory? \n It will cost you 1 stone and 1 wood.",
                      "Territory Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     if (dr == DialogResult.Yes)
                     {
                        ChangeBackgroundColor(clientPlayer);
                        infoChanged = true;
                        terChanged = true;
                        Input.Invoke(sender, e);
                     }
                  }
                  else if(!hascity)
                     MessageBox.Show("You have insufficient resources to purchase this territory",
                      "Unsuccessful Territory Purchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
         }
      }
      public void ResizeTer(int terNum = -1)
      {
         Bitmap temp;
         MapImage.Size = new Size(this.Size.Width - 4, this.Size.Height - 4);
         Size mapSize = new Size(MapImage.Size.Width, MapImage.Size.Height); //Gets the Size varible for the PictureBox
         if (terNum == 1)
            temp = new Bitmap(nataC_fo_sreltteS.Properties.Resources.Food1x1);
         else if (terNum == 2)
            temp = new Bitmap(nataC_fo_sreltteS.Properties.Resources.Stone1x1);
         else if (terNum == 3)
            temp = new Bitmap(nataC_fo_sreltteS.Properties.Resources.Wood1x1);
         else if (terNum == 4)
            temp = new Bitmap(nataC_fo_sreltteS.Properties.Resources.Animal1x1);
         else if (terNum == 5)
            temp = new Bitmap(nataC_fo_sreltteS.Properties.Resources.Desert1x1);
         else
            temp = new Bitmap(nataC_fo_sreltteS.Properties.Resources.Untitled);

         Bitmap bmp = new Bitmap(temp, mapSize.Width, mapSize.Height); //Resizes base image
         MapImage.Location = new Point(MapImage.Location.X + 1, MapImage.Location.Y + 1); //Sets location of picture box so its not at 0,0
         MapImage.Image = bmp;
      }
      public void UpdateRollNum(string test)
      {
         rollID = int.Parse(test);
      }

      public void ChangeBackgroundColor(int player)
      {
         if (player == 1)
            BackColor = System.Drawing.Color.Gold;
         else if (player == 2)
            BackColor = System.Drawing.Color.Red;
         else if (player == 3)
            BackColor = System.Drawing.Color.Lime;
         else
            BackColor = System.Drawing.Color.Aqua;
      }

      public int CheckBackGroundColor()
      {
         if (BackColor == System.Drawing.Color.Gold)
            return 1;
         else if (BackColor == System.Drawing.Color.Red)
            return 2;
         else if (BackColor == System.Drawing.Color.Lime)
            return 3;
         else if (BackColor == System.Drawing.Color.Aqua)
            return 4;
         else
            return -1;



      }

      public void SendBack()
      {
         lblRollId.SendToBack();
      }
      public void SetRollNum()
      {
         lblRollId.Text = rollID.ToString();
         lblRollId.Show();
      }

      public void SetCity(bool city)
      {
         if (city)
         {
            lblRollId.BackColor = Color.White;
            lblRollId.ForeColor = Color.Black;
            hascity = true;
         }
      }

      private void lblRollId_Click(object sender, EventArgs e)
      {
         pictureBox1_Click(MapImage, e);
      }

      private void Territory_MouseClick(object sender, MouseEventArgs e)
      {
         pictureBox1_Click(MapImage, e);
      }

      private void MapImage_MouseEnter(object sender, EventArgs e)
      {
         if (beginning == false)
            lblRollId.BringToFront();
      }

      private void Territory_MouseLeave(object sender, EventArgs e)
      {
         //if (beginning == false)
           // lblRollId.SendToBack();
      }

      private void lblRollId_MouseHover(object sender, EventArgs e)
      {
         //lblRollId.BringToFront();
         //inLabel = true;
      }

      private void MapImage_MouseHover(object sender, EventArgs e)
      {
         //lblRollId.BringToFront();
         //inLabel = true;
      }

      private void lblRollId_MouseLeave(object sender, EventArgs e)
      {
         if (beginning == false)
            lblRollId.SendToBack();
      }

      private void MapImage_MouseLeave(object sender, EventArgs e)
      {
         if (this.Bounds.Location.Y + 5 < Cursor.Position.Y && this.Bounds.Location.Y + this.Bounds.Height -5 > Cursor.Position.Y
             && this.Bounds.Location.X + 5 < Cursor.Position.X && this.Bounds.Location.X  + this.Bounds.Width - 5 > Cursor.Position.X)
            lblRollId.BringToFront();
         else if (beginning == false)
            lblRollId.SendToBack();

      }

      private void lblRollId_MouseEnter(object sender, EventArgs e)
      {
         if (beginning == false)
            lblRollId.BringToFront();
      }
   }
}

//23 methods
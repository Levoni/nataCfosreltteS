//--------------------------------------------------------------------
// Players.cs is a user control class that houses the information of 
// a given player their name, enumerated player number, and resources
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
   public partial class Players : UserControl
   {
      private bool mainPlayer;
      private Player player = new Player();

      string name { get; set; }

      public int animal { get { return player.animal; } set { player.animal = value; } }
      public int food { get { return player.food; } set { player.food = value; } }
      public int stone { get { return player.stone; } set { player.stone = value; } }
      public int wood { get { return player.wood; } set { player.wood = value; } }

      public int vp { get { return player.vp; } set { player.vp = value; } }
      public int DevCardTotal { get { return player.GetTotalDevCards(); } set { player.setDevCards(value); } }

      public Players()
      {
         InitializeComponent();
         UpdateResource();
         //player = new Player();

         pictureBox1.Hide();
         pictureBox2.Hide();
         pictureBox3.Hide();
         pictureBox4.Hide();

         mainPlayer = false;

         lblRsrc.Visible = false;
         lblDevCard.Visible = false;
         txtDevCard.Visible = false;
         txtRsrc.Visible = false;
      }
      public void UpdateResource()
      {
         txtFood.Text = food.ToString();
         txtStone.Text = stone.ToString();
         txtWood.Text = wood.ToString();
         txtAnimal.Text = animal.ToString();
         txtVP.Text = vp.ToString();

         txtRsrc.Text = player.GetTotalResources().ToString();
         txtDevCard.Text = player.GetTotalDevCards().ToString();
      }

      public void UpdateName(string name)
      {
         lblName.Text = name;
      }

      public void SetResources(int tfood, int tstone, int twood, int tanimal, int tvp)
      {
         food = tfood;
         stone = tstone;
         wood = twood;
         animal = tanimal;
         vp = tvp;

         player.SetResources(tfood, tstone, twood, tanimal);
      }

      public void minusResourceTerritory()
      {
         wood--;
         stone--;
         UpdateResource();

         player.BuyTerritory();
      }

      public void minusResourceCity()
      {
         food--;
         stone--;
         wood--;
         animal--;
         UpdateResource();

         player.BuyCity();
      }

      // Return the total number of resources the player has
      public int numOfResouce()
      {
         return player.GetTotalResources();
      }

      private void pictureBox1_Click(object sender, EventArgs e)
      {

      }

      private void pictureBox2_Click(object sender, EventArgs e)
      {

      }

      public void setMostVPPic(bool youOwn)
      {
         if (youOwn)
            pictureBox1.Show();
         else
            pictureBox1.Hide();
      }

      public void setMostTerPic(bool youOwn)
      {
         if (youOwn)
            pictureBox2.Show();
         else
            pictureBox2.Hide();
      }

      public void setMostCityPic(bool youOwn)
      {
         if (youOwn)
            pictureBox3.Show();
         else
            pictureBox3.Hide();
      }

      public void setMostResources(bool youOwn)
      {
         if (youOwn)
         {
            pictureBox4.Show();
         }
         else
            pictureBox4.Hide();
      }

      // Sets this player as the main player of the current client
      // If not main player, switches to total resource and dev cards display
      public void SetMainPlayer(bool IsMainPlayer)
      {
         mainPlayer = IsMainPlayer;
         if (!mainPlayer)
         {
            
            lblRsrc.Visible = !mainPlayer;
            lblDevCard.Visible = !mainPlayer;
            txtDevCard.Visible = !mainPlayer;
            txtRsrc.Visible = !mainPlayer;

            txtFood.Visible = mainPlayer;
            txtStone.Visible = mainPlayer;
            txtWood.Visible = mainPlayer;
            txtAnimal.Visible = mainPlayer;
            txtVP.Visible = mainPlayer;

            lblFood.Visible = mainPlayer;
            lblStone.Visible = mainPlayer;
            lblWood.Visible = mainPlayer;
            lblAnimal.Visible = mainPlayer;
            lblDesert.Visible = mainPlayer;
         } 

      }

      public void BuyDevCard(string type)
      {
         player.BuyDevCard(type);
      }

      public void DecrimentDevCard(string type)
      {
         player.UseDevCard(type);
      }

      public int GetDevCardTypeCount(string cardType)
      {
         return player.GetDevCardCount(cardType);
      }
   }
}

//13 methods